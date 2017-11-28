using InvenTID_App;
using InvenTID_App.Models;
using System;
using System.Configuration;
using System.Web.Mvc;
using Twilio;
using Microsoft.AspNet.Identity;
using System.Web.Routing;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Security.Policy;
using System.Security.Claims;
using System.Net;


public enum RBACStatus
{
    Success = 0,
    LockedOut = 1,
    RequiresVerification = 2,
    Failure = 3,
    EmailVerification = 4,
    PhoneVerification = 5,
    RequiresAccountActivation = 6,
    EmailUnconfirmed = 7,
    PhoneNumberUnconfirmed = 8,
    InvalidToken = 9,
}

public static class RBAC_ExtendedMethods
{
    public static string c_AccountLockout = "Votre compte est bloqué pour {0} minutes suite à plusieurs tentatives de connexion echouées";
    //public static string c_InvalidCredentials = "Invalid credentials. You have {0} more attempt(s) before your account gets locked out";
    public static string c_InvalidCredentials = "Le mot de passe est incorrect. Verifier votre mot de passe. Il vous reste {0} tentative(s) avant blocage temporaire de votre compte";
    public static string c_InvalidLogin = "Echec d'authentification";
    public static string c_InvalidUser = "Cet identifiant n'existe pas. Entrer les bonnes informations d'identification...";
    public static string c_AccountEmailUnconfirmed = "Vous devez suivre le lien envoyé par mail pour activer votre compte...";    
    public static string c_AccountPhoneNumberUnconfirmed = "Prière de verifier le code de securité envoyé à numero de téléphone.  Un nouveau code de securité a été envoyé au numero {0}.  Veuillez entrer le code et cliquer sur 'Verifier mon compte' pour verifier votre identité...";
    public static string c_AccountUnverified = "Votre identité n'a pas encore été verifié.  Prière de demander un nouveau code de securité...";
    
    public static string c_EmailCode = "Code email";
    public static string c_PhoneCode = "Code téléphone";

    public static string cKey_UserLockoutEnabled = "Activer la deconnexion si inactif";
    public static string cKey_AccountLockoutTimeSpan = "Temps d'inactivité avant deconnexion";
    public static string cKey_MaxFailedAccessAttemptsBeforeLockout = "Nombre des tentatives avant blocage";
    public static string cKey_2FAEnabled = "Activer authentification 2-tiers";
    public static string cKey_2FADeviceType = "Type de service 2-tiers";
    public static string cKey_AccountVerificationRequired = "Verification de compte requis";
    public static string cKey_PasswordRequiredLength = "Longueur du mot de passe";
    public static string cKey_PasswordRequireNonLetterOrDigit = "Exigence exclusive des caractères speciaux";
    public static string cKey_PasswordRequireDigit = "Exigence des chiffres dans le mot de passe";
    public static string cKey_PasswordRequireLowercase = "Exigence de miniscule dans le mot de passe";
    public static string cKey_PasswordRequireUppercase = "Exigence de majuscule dans le mot de passe";
   
    public static string cKey_SmtpEMailFrom = "Exp. Email";
    public static string cKey_SmtpServer = "Server Smtp";
    public static string cKey_SmtpPort = "Port Smtp";
    public static string cKey_SmtpUsername = "Identifiant Smtp";
    public static string cKey_SmtpPassword = "Mot de passe Smtp";
    public static string cKey_SmtpNetworkDeliveryMethodEnabled = "Activer la méthode d'envoi SMTP";

    public static string cKey_SMSSid = "Id Service SMS";
    public static string cKey_SMSToken = "Token SMS";
    public static string cKey_SMSFromPhone = "Exp. SMS";

    public static string cKey_GeneralAuditEnabled = "Activer l'audit";
    public static string cKey_GeneralMaintenanceUrl = "Url de maintenance";
    public static string cKey_GeneralMaintenanceEnabled = "Activer maintenance de l'app";
    public static string cKey_GeneralMaintenanceAllowedIPs = "Liste IPs autorisé";


    public static ApplicationParameters Parameters
    {
        get { return new ApplicationParameters(); }
    }
    
    #region Registration
    private static int RegisterUser(this ControllerBase controller, RegisterViewModel model, ApplicationUserManager userMngr, out List<string> _errors)
    {
        int _retVal = -1;
        _errors = new List<string>();
        try
        {
            bool Is2FAEnabled = GetConfigSettingAsBool(cKey_2FAEnabled);
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, Firstname = model.Firstname, Lastname = model.Lastname, PhoneNumber = model.Mobile, TwoFactorEnabled = Is2FAEnabled };

            if (userMngr != null)
            {
                var result = userMngr.Create(user, model.Password);
                if (result.Succeeded)
                {
                    _retVal = user.Id;
                }
                else
                {
                    _errors.AddRange(result.Errors);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return _retVal;
    }

    public static RBACStatus Register(this ControllerBase controller, RegisterViewModel model, ApplicationUserManager userMngr, ApplicationSignInManager signInMngr, out List<string> _errors)
    {
        RBACStatus _retVal = RBACStatus.Failure;
        try
        {
            //Logic driven by settings defined in the application’s configuration file...
            int _userId = RBAC_ExtendedMethods.RegisterUser(controller, model, userMngr, out _errors);
            if (_userId > -1)
            {
                model.Id = _userId;
                if (userMngr != null)
                {
                    //Check if we require an Account Verification Email as part of our registration process...
                    bool IsAccountVerificationRequired = GetConfigSettingAsBool(cKey_AccountVerificationRequired);
                    bool Is2FAEnabled = GetConfigSettingAsBool(cKey_2FAEnabled);
                    string DeviceType = GetConfigSetting(cKey_2FADeviceType);

                    //if ((IsAccountVerificationRequired) || (Is2FAEnabled && DeviceType == c_EmailCode))
                    if ((IsAccountVerificationRequired && DeviceType == c_EmailCode) || (Is2FAEnabled && DeviceType == c_EmailCode))
                    {
                        //Generate Email Confirmation Token                      
                        _retVal = RBACStatus.Failure;
                        if (SendOTP2Email(controller, userMngr, _userId, model.Email))
                            _retVal = RBACStatus.RequiresAccountActivation;

                        return _retVal;
                    }
                    //else if (Is2FAEnabled && DeviceType == c_PhoneCode)
                    else if ((IsAccountVerificationRequired && DeviceType == c_PhoneCode) || (Is2FAEnabled && DeviceType == c_PhoneCode))
                    {
                        _retVal = RBACStatus.Failure;
                        if (SendOTP2Phone(controller, userMngr, _userId, model.Mobile))
                            _retVal = RBACStatus.PhoneVerification;

                        return _retVal;
                    }
                }
                _retVal = RBACStatus.Success;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return _retVal;
    }
    #endregion

    #region Login
    public static RBACStatus Login(this ControllerBase controller, LoginViewModel model, ApplicationUserManager userMngr, ApplicationSignInManager signInMngr, out List<string> _errors)
    {
        RBACStatus _retVal = RBACStatus.Failure;
        _errors = new List<string>();
        try
        {
            var user = userMngr.FindByName(model.UserName);
            if (user != null)
            {
                var validCredentials = userMngr.Find(model.UserName, model.Password);
                if (userMngr.IsLockedOut(user.Id))
                {
                    _errors.Add(string.Format(c_AccountLockout, GetConfigSettingAsDouble(cKey_AccountLockoutTimeSpan)));
                    return RBACStatus.LockedOut;
                }
                else if (userMngr.GetLockoutEnabled(user.Id) && validCredentials == null)
                {
                    userMngr.AccessFailed(user.Id);
                    if (userMngr.IsLockedOut(user.Id))
                    {
                        _errors.Add(string.Format(c_AccountLockout, GetConfigSettingAsDouble(cKey_AccountLockoutTimeSpan)));
                        return RBACStatus.LockedOut;
                    }
                    else
                    {
                        int _attemptsLeftB4Lockout = (GetConfigSettingAsInt(cKey_MaxFailedAccessAttemptsBeforeLockout) - userMngr.GetAccessFailedCount(user.Id));
                        _errors.Add(string.Format(c_InvalidCredentials, _attemptsLeftB4Lockout));
                        return _retVal;
                    }
                }
                else if (validCredentials == null)
                {
                    _errors.Add(c_InvalidLogin);
                    return _retVal;
                }
                else
                {
                    //Valid credentials entered, we need to check whether email verification is required...
                    bool IsAccountVerificationRequired = GetConfigSettingAsBool(cKey_AccountVerificationRequired);
                    bool Is2FAEnabled = GetConfigSettingAsBool(cKey_2FAEnabled);
                    string DeviceType = GetConfigSetting(cKey_2FADeviceType);

                    if ((IsAccountVerificationRequired && DeviceType == c_EmailCode) || (Is2FAEnabled && DeviceType == c_EmailCode))
                    {
                        //Check if email verification has been confirmed!
                        if (!userMngr.IsEmailConfirmed(user.Id))
                        {
                            //Display error message on login page, take no further action...                         
                            _errors.Add(c_AccountEmailUnconfirmed);
                            return RBACStatus.EmailUnconfirmed;
                        }
                    }
                    //else if (Is2FAEnabled && DeviceType == c_PhoneCode)
                    else if ((IsAccountVerificationRequired && DeviceType == c_PhoneCode) || (Is2FAEnabled && DeviceType == c_PhoneCode))
                    {
                        if (!userMngr.IsPhoneNumberConfirmed(user.Id))
                        {
                            _errors.Add(c_AccountPhoneNumberUnconfirmed);
                            return RBACStatus.PhoneNumberUnconfirmed;
                        }
                    }

                    bool _userLockoutEnabled = GetConfigSettingAsBool(cKey_UserLockoutEnabled);

                    //Before we signin, check that our 2FAEnabled config setting agrees with the database setting for this user...
                    if (Is2FAEnabled != userMngr.GetTwoFactorEnabled(user.Id))
                    {
                        userMngr.SetTwoFactorEnabled(user.Id, Is2FAEnabled);
                    }

                    _retVal = (RBACStatus)signInMngr.PasswordSignIn(model.UserName, model.Password, model.RememberMe, shouldLockout: _userLockoutEnabled);
                    switch (_retVal)
                    {
                        case RBACStatus.Success:
                            {
                                userMngr.ResetAccessFailedCount(user.Id);
                                break;
                            }                        
                        default:
                            {
                                _errors.Add(c_InvalidLogin);
                                break;
                            }
                    }
                }
            }
            else
            {
                _errors.Add(c_InvalidUser);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return _retVal;
    }

    #endregion

    #region Verification
    public static RBACStatus VerifyOTP4Phone(int _userId, string _phoneNumber, string _token, ApplicationUserManager userMngr, ApplicationSignInManager signInMngr, out IEnumerable<string> _errors)
    {
        RBACStatus _retVal = RBACStatus.Failure;       
        try
        {
            IdentityResult result = userMngr.ChangePhoneNumber(_userId, _phoneNumber, _token);
            if (result == IdentityResult.Success)
            {
                ApplicationUser user = userMngr.FindById(_userId);
                if (user != null)
                {
                    signInMngr.SignIn(user, isPersistent: false, rememberBrowser: false);
                }
                _retVal = RBACStatus.Success;
            }
            _errors = result.Errors;
        }
        catch (Exception)
        {
            throw;
        }
        return _retVal;
    }

    public static bool SendOTP2Phone(this ControllerBase controller, ApplicationUserManager _userMngr, int _userId, string _phoneNumber)
    {
        bool _retVal = false;    

        if (string.IsNullOrEmpty(_phoneNumber))
            throw new Exception("Pas de numéro de téléphone transmis. Impossible d'envoyer un sms...");

        if (_userMngr.SmsService != null)
        {
            //Generate security code for phone confirmation   
            var code = _userMngr.GenerateChangePhoneNumberToken(_userId, _phoneNumber);
            var message = new IdentityMessage
            {
                Destination = _phoneNumber,
                Body = "Votre code de securité est : " + code
            };

            //Send the security code  
            _userMngr.SmsService.Send(message);
            _retVal = true;
        }
        else
        {        
            throw new Exception("Le service SMS n'est pas configuré, Impossible d'envoyer le message...");
        }
        return _retVal;
    }

    public static bool SendOTP2Email(this ControllerBase controller, ApplicationUserManager _userMngr, int _userId, string _email)
    {
        bool _retVal = false;

        if (string.IsNullOrEmpty(_email))
            throw new Exception("Pas d'addresse email transmis, Impossible d'envoyer le mail de vérification...");

        if (_userMngr.EmailService != null)
        {
            //Generate security code for email confirmation
            string _code = _userMngr.GenerateEmailConfirmationToken(_userId);

            var callbackUrl = new UrlHelper(controller.ControllerContext.RequestContext).Action("ConfirmEmail", "Account", new { userId = _userId, code = _code }, protocol: controller.ControllerContext.RequestContext.HttpContext.Request.Url.Scheme);
            var message = new IdentityMessage { Subject = "Email de verification (TOTP) de securité", Destination = _email, Body = string.Format("Please <a href='{0}'>vérifier</a> votre compte pour avoir accès.", callbackUrl) };

            //Email the security code  
            _userMngr.EmailService.Send(message);
            _retVal = true;
        }
        else
        {         
            throw new Exception("Le service Smtp n'est pas configuré, impossible d'envoyer le mail de vérification...");
        }
        return _retVal;
    }

    public static bool VerifyOTP4Email(int _userId, string _token, ApplicationUserManager userMngr, ApplicationSignInManager signInMngr, out IEnumerable<string> _errors)
    {
        bool _retVal = false;
        _errors = new List<string>();
        try
        {
            ApplicationUser user = userMngr.FindById(_userId);
            if (userMngr.VerifyTwoFactorToken(user.Id, c_EmailCode, _token))
            {
                signInMngr.SignIn(user, isPersistent: false, rememberBrowser: false);
                return true;
            }
            else
            {
                _errors = _errors = new List<string> { "Code invalide..." };
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return _retVal;
    }

    public static RBACStatus RequestAccountVerification(this ControllerBase controller, int _userId, string _email, ApplicationUserManager userMngr, out IEnumerable<string> _errors)
    {
        RBACStatus _retVal = RBACStatus.Failure;
        _errors = new List<string>();

        try
        {
            if (userMngr.EmailService != null)
            {
                string _code = userMngr.GenerateEmailConfirmationToken(_userId);

                var callbackUrl = new UrlHelper(controller.ControllerContext.RequestContext).Action("ConfirmEmail", "Account", new { userId = _userId, code = _code }, protocol: controller.ControllerContext.RequestContext.HttpContext.Request.Url.Scheme);
                var message = new IdentityMessage { Subject = "Verification de votre compte", Destination = _email, Body = string.Format("Prière de <a href='{0}'>vérifier</a> votre compte pour pouvoir vous connecter...", callbackUrl) };
                userMngr.EmailService.Send(message);

                _retVal = RBACStatus.RequiresAccountActivation;
            }
            else
            {
                _errors = new List<string> { "Le service Smtp n'est pas configuré!", "Impossible d'envoyer le token par mail..." };
            }
        }
        catch (Exception)
        {

            throw;
        }


        return _retVal;
    }

    #endregion

    #region Helper Functions
    public static bool GetConfigSettingAsBool(string _name, bool _defaultValue = false)
    {
        bool _retVal = _defaultValue;
        try
        {
            //_retVal = Convert.ToBoolean(ConfigurationManager.AppSettings[_name].ToString());
            _retVal = Convert.ToBoolean(Parameters.GetParam(_name).Value.ToString());

        }
        catch (Exception)
        {
        }
        return _retVal;
    }

    public static int GetConfigSettingAsInt(string _name, int _defaultValue = 0)
    {
        int _retVal = _defaultValue;
        try
        {
            //_retVal = Convert.ToInt32(ConfigurationManager.AppSettings[_name].ToString());
            _retVal = Convert.ToInt32(Parameters.GetParam(_name).Value.ToString());

        }
        catch (Exception)
        {
        }
        return _retVal;
    }

    public static double GetConfigSettingAsDouble(string _name, double _defaultValue = 0)
    {
        double _retVal = _defaultValue;
        try
        {
           // _retVal = Convert.ToDouble(ConfigurationManager.AppSettings[_name].ToString());
            _retVal = Convert.ToDouble(Parameters.GetParam(_name).Value.ToString());

        }
        catch (Exception)
        {
        }
        return _retVal;
    }

    public static string GetConfigSetting(string _name)
    {
        string _retVal = string.Empty;
        try
        {
            //_retVal = ConfigurationManager.AppSettings[_name].ToString();
            _retVal = Parameters.GetParam(_name).Value.ToString();

        }
        catch (Exception)
        {
        }
        return _retVal;
    }
    #endregion
}