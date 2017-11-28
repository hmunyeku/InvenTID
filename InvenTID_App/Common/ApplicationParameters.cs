using InvenTID_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ApplicationParameters
{
    public List<PARAMETER> AppParameters
    {
        get
        {
            HttpContext.Current.Application.Lock();
            List<PARAMETER> _Parameters = null;
            if (HttpContext.Current.Application["Parameters"] != null)
            {
                _Parameters = (List<PARAMETER>)HttpContext.Current.Application["Parameters"];
            }
            else
            {
                RBACDbContext database = new RBACDbContext();
                _Parameters = database.PARAMETERS.ToList();
                HttpContext.Current.Application["Parameters"] = _Parameters;
            }
            HttpContext.Current.Application.UnLock();
            return _Parameters;
        }
    }public PARAMETER GetParam(String Name)
    {
        return AppParameters.FirstOrDefault(t => t.Name.ToLower() == Name.ToLower());
    }

    public void RefreshAppParameters()
    {
        HttpContext.Current.Application.Lock();
        RBACDbContext database = new RBACDbContext();
        HttpContext.Current.Application["Parameters"] = database.PARAMETERS.ToList();
        HttpContext.Current.Application.UnLock();
    }
    public PARAMETER GeneralAuditEnabled { get { return GetParam("general-audit-enabled"); } }
    public PARAMETER GeneralMaintenanceUrl { get { return GetParam("general-app-maintenance-url"); } }
    public PARAMETER GeneralMaintenanceEnabled { get { return GetParam("general-app-maintenance-enabled"); } }
    public PARAMETER GeneralMaintenanceAllowedIPs { get { return GetParam("general-app-maintenance-allowedIPs"); } }
    public PARAMETER UserLockoutEnabled { get { return GetParam("UserLockoutEnabled"); } }
    public PARAMETER AccountLockoutTimeSpan { get { return GetParam("AccountLockoutTimeSpan"); } }
    public PARAMETER MaxFailedAccessAttemptsBeforeLockout { get { return GetParam("MaxFailedAccessAttemptsBeforeLockout"); } }
    public PARAMETER TwoFAEnabled { get { return GetParam("2FAEnabled"); } }
    public PARAMETER TwoFADeviceType { get { return GetParam("2FADeviceType"); } }
    public PARAMETER AccountVerificationRequired { get { return GetParam("AccountVerificationRequired"); } }
    public PARAMETER SmtpEMailFrom { get { return GetParam("SmtpEMailFrom"); } }
    public PARAMETER SmtpServer { get { return GetParam("SmtpServer"); } }
    public PARAMETER SmtpPort { get { return GetParam("SmtpPort"); } }
    public PARAMETER SmtpUsername { get { return GetParam("SmtpUsername"); } }
    public PARAMETER SmtpPassword { get { return GetParam("SmtpPassword"); } }
    public PARAMETER SmtpNetworkDeliveryMethodEnabled { get { return GetParam("SmtpNetworkDeliveryMethodEnabled"); } }
    public PARAMETER SMSSid { get { return GetParam("SMSSid"); } }
    public PARAMETER SMSToken { get { return GetParam("SMSToken"); } }
    public PARAMETER SMSFromPhone { get { return GetParam("SMSFromPhone"); } }
    public PARAMETER PasswordRequiredLength { get { return GetParam("PasswordRequiredLength"); } }
    public PARAMETER PasswordRequireNonLetterOrDigit { get { return GetParam("PasswordRequireNonLetterOrDigit"); } }
    public PARAMETER PasswordRequireDigit { get { return GetParam("PasswordRequireDigit"); } }
    public PARAMETER PasswordRequireLowercase { get { return GetParam("PasswordRequireLowercase"); } }
    public PARAMETER PasswordRequireUppercase { get { return GetParam("PasswordRequireUppercase"); } }

}
