using InvenTID_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


public static class AuditHelpers
{
    private static string GetIPAddress()
    {
        HttpContext hc = System.Web.HttpContext.Current;
        return hc != null ? hc.Request.UserHostAddress : "";
    }
    private static bool IsAduitEnabled()
    {
        string Name = "general-audit-enabled";
        HttpContext hc = HttpContext.Current;
        List<PARAMETER> _Parameters = (List<PARAMETER>)hc.Application["Parameters"];
        string Value = _Parameters.FirstOrDefault(t => t.Name.ToLower() == Name.ToLower()).Value;
        return (Value == "true");
    }

    public static void AppEventInfo(String MemberEmail, String Description, String Details = null, bool NoMatterIfAuditEnabled = false)
    {
        if (!IsAduitEnabled())
            return;

        AUDITEVENT Item = new AUDITEVENT
        {
            EventType = AuditEventType.Info,
            IPAddress = GetIPAddress(),
            MemberEmail = string.IsNullOrEmpty(MemberEmail) ? HttpContext.Current.User.Identity.GetUserId().ToString() : MemberEmail,
            Description = Description,
            Details = Details
        };

        AddEvent(Item);
    }
    public static void AppEventSuccess(String MemberEmail, String Description, String Details = null, bool NoMatterIfAuditEnabled = false)
    {
        if (!IsAduitEnabled())
            return;

        AUDITEVENT Item = new AUDITEVENT
        {
            EventType = AuditEventType.Success,
            IPAddress = GetIPAddress(),
            MemberEmail = MemberEmail,
            Description = Description,
            Details = Details
        };

        AddEvent(Item);
    }
    public static void AppEvent(AuditEventType AuditEventType, String MemberEmail, String Description, String Details = null, bool NoMatterIfAuditEnabled = false)
    {
        if (!IsAduitEnabled())
            return;

        AUDITEVENT Item = new AUDITEVENT
        {
            EventType = AuditEventType,
            IPAddress = GetIPAddress(),
            MemberEmail = MemberEmail,
            Description = Description,
            Details = Details
        };

        AddEvent(Item);
    }

    private static void AddEvent(AUDITEVENT EventItem)
    {
        if (!IsAduitEnabled())
            return;

        string IPAddress = GetIPAddress();
        if (EventItem.IPAddress == "::1")
            IPAddress = "localhost";

        using (RBACDbContext db = new RBACDbContext())
        {
            AUDITEVENT Event = new AUDITEVENT();
            Event.EventType = EventItem.EventType;
            Event.Description = EventItem.Description;
            Event.MemberEmail = EventItem.MemberEmail;
            Event.Details = EventItem.Details;
            Event.IPAddress = IPAddress;
            Event.Created = System.DateTime.Now;
            db.Entry(Event).State = EntityState.Added;
            db.SaveChanges();
        }
    }

    public static String MemberLoggedIn { get { return "L'utilisateur \"{0}\"<{1}> s'est connecté avec succès."; } }
    public static String MemberLogOut { get { return "L'utilisateur \"{0}\"<{1}> s'est deconnecté avec succès."; } }

    /// <summary></summary>
    public static String MemberWrongEmail { get { return "L'utilisateur <{0}>  n'a pas pu se connecter suite à un mauvais email"; } }
    /// <summary></summary>
    public static String MemberWrongPassword { get { return "L'utilisateur \"{0}\"<{1}>  n'a pas pu se connecter suite à un mot de passe erroné"; } }
    /// <summary></summary>
    public static String SavingMemberInfo { get { return "Informations incorrectes \"{0}\"<{1}>: \"{0}\""; } }

    /// <summary></summary>
    public static String MemberAssigToRole { get { return "L'utilisateur \"{0}\"<{1}> a été assigné à un rôle : \"{2}\""; } }
    /// <summary></summary>
    public static String MemberRemovedFromRole { get { return "L'utilisateur \"{0}\"<{1}> a été rétiré du rôle : \"{2}\""; } }
    /// <summary></summary>
    public static String MemberRemovedFromAllRole { get { return "L'utilisateur \"{0}\"<{1}> a été retiré de tous les rôles"; } }
    /// <summary></summary>
    public static String MemberNoRemovedAdminFromRole { get { return "Cet utilisateur \"{0}\"<{1}> est un administrateur et ne peut pas étre effacer du rôle \"{2}\""; } }
    /// <summary></summary>
    public static String SentRandomPasswordBadFormat { get { return "Un mot de passe aleatoire a été proposé: <{0}>"; } }
    /// <summary></summary>
    public static String SentRandomPasswordNotExist { get { return "Member upload has started. \"{0}\"<{1}>"; } }
    /// <summary></summary>
    public static String SentRandomPasswordSent { get { return "Random password has been generated and sent. \"{0}\"<{1}>"; } }

    /// <summary></summary>
    public static String RoleContainsMembers { get { return "Ce rôle \"{0}\" contient des membres."; } }
    /// <summary></summary>
    public static String RoleIsBuiltIn { get { return "Ce rôle \"{0}\" est defini par defaut et ne peut être supprimé."; } }
    /// <summary></summary>
    public static String RoleDeleted { get { return "Le rôle \"{0}\" a été supprimé."; } }

    /// <summary></summary>
    public static String AccountNotActivated { get { return "Votre compte \"{0}\"<{1}> n'est pas activé."; } }
    /// <summary></summary>
    public static String AccountAccountBlocked { get { return "Votre compte \"{0}\"<{1}> est bloqué."; } }
    /// <summary></summary>
    public static String AccountWrongUser { get { return "Erreur utilisateur ou mot de passe \"{0}\"<{1}>."; } }
    /// <summary></summary>
    public static String AccountWrongEmail { get { return "Mauvais format pour l'email: \"{0}\"<{1}> "; } }
    /// <summary></summary>
    public static String AccountAccountExists { get { return "Ce compte \"{0}\"<{1}>  existe dejà."; } }
    /// <summary></summary>
    public static String AccountActivationMailSent { get { return "L'email d'activation a été envoyé à \"{0}\"<{1}>."; } }
    /// <summary></summary>
    public static String AccountWrongActiveLink { get { return "Wrong activation link or activation has been expared. The token is: {0}"; } }
    /// <summary></summary>
    public static String AccountActivated { get { return "Votre compte \"{0}\"<{1}>  a été activé avec succès."; } }
    /// <summary></summary>
    public static String AccountAccountDoesntExist { get { return "Ce compte \"{0}\"<{1}>  n'existe pas."; } }
    /// <summary></summary>
    public static String AccountResetPassMail { get { return "Le lien de restauration du mot de passe a été envoyé à \"{0}\"<{1}>."; } }
    /// <summary></summary>
    public static String AccountWrongResetPassLink { get { return "Wrong reset passowrd link or the link has been expared. The token is: {0}"; } }
    /// <summary></summary>
    public static String AccountPassChanged { get { return "\"{0}\"<{1}> le mot de passe de ce compte a été changé."; } }

    /// <summary></summary>
    public static String TheEmailhasBeenSent { get { return "Un mail a été envoyé. De: \"{0}\" {1} à: \"{2}\" {3}  ccc:{4} avec l'object:{5} "; } }

}
