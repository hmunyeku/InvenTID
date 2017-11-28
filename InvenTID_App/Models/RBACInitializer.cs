namespace InvenTID_App.DatabaseInitializer
{
    using Microsoft.AspNet.Identity;
    using InvenTID_App.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    public class RBACDatabaseInitializer : CreateDatabaseIfNotExists<RBACDbContext>
    {
        private readonly string c_SysAdmin = "Administrateur Système";
        private readonly string c_DefaultUser = "Utilisateur Standard";

        protected override void Seed(RBACDbContext context)
        {
            
            //Application parameters
            using (RBACDbContext db = new RBACDbContext())
            {
                db.PARAMETERS.AddOrUpdate(s => s.Name,
                        new PARAMETER { Name = "UserLockoutEnabled", Value = "true", MemberID = 1, TypeID = ParameterType.Bool, Created = DateTime.Now },
                        new PARAMETER { Name = "AccountLockoutTimeSpan", Value = "15", MemberID = 1, TypeID = ParameterType.SmallInteger, Created = DateTime.Now },
                        new PARAMETER { Name = "MaxFailedAccessAttemptsBeforeLockout", Value = "5", MemberID = 1, TypeID = ParameterType.SmallInteger, Created = DateTime.Now },
                        new PARAMETER { Name = "2FADeviceType", Value = "Email Code", MemberID = 1, TypeID = ParameterType.ShortString, Created = DateTime.Now },
                        new PARAMETER { Name = "2FAEnabled", Value = "false", MemberID = 1, TypeID = ParameterType.Bool, Created = DateTime.Now },
                        new PARAMETER { Name = "AccountVerificationRequired", Value = "false", MemberID = 1, TypeID = ParameterType.Bool, Created = DateTime.Now },
                        new PARAMETER { Name = "PasswordRequiredLength", Value = "6", MemberID = 1, TypeID = ParameterType.SmallInteger, Created = DateTime.Now },
                        new PARAMETER { Name = "PasswordRequireNonLetterOrDigit", Value = "true", MemberID = 1, TypeID = ParameterType.Bool, Created = DateTime.Now },
                        new PARAMETER { Name = "PasswordRequireDigit", Value = "true", MemberID = 1, TypeID = ParameterType.Bool, Created = DateTime.Now },
                        new PARAMETER { Name = "PasswordRequireLowercase", Value = "true", MemberID = 1, TypeID = ParameterType.Bool, Created = DateTime.Now },
                        new PARAMETER { Name = "PasswordRequireUppercase", Value = "true", MemberID = 1, TypeID = ParameterType.Bool, Created = DateTime.Now },
                        new PARAMETER { Name = "SmtpEMailFrom", Value = "info@rolebasedaccess.com", MemberID = 1, TypeID = ParameterType.ShortString, Created = DateTime.Now },
                        new PARAMETER { Name = "SmtpServer", Value = "smtp.live.com", MemberID = 1, TypeID = ParameterType.ShortString, Created = DateTime.Now },
                        new PARAMETER { Name = "SmtpPort", Value = "587", MemberID = 1, TypeID = ParameterType.SmallInteger, Created = DateTime.Now },
                        new PARAMETER { Name = "SmtpUsername", Value = "username@hotmail.com", MemberID = 1, TypeID = ParameterType.ShortString, Created = DateTime.Now },
                        new PARAMETER { Name = "SmtpPassword", Value = "password", MemberID = 1, TypeID = ParameterType.ShortString, Created = DateTime.Now },
                        new PARAMETER { Name = "SmtpNetworkDeliveryMethodEnabled", Value = "true", MemberID = 1, TypeID = ParameterType.Bool, Created = DateTime.Now },
                        new PARAMETER { Name = "SMSSid", Value = "info@rolebasedaccess.com", MemberID = 1, TypeID = ParameterType.ShortString, Created = DateTime.Now },
                        new PARAMETER { Name = "SMSToken", Value = "smtp.live.com", MemberID = 1, TypeID = ParameterType.ShortString, Created = DateTime.Now },
                        new PARAMETER { Name = "SMSFromPhone", Value = "587", MemberID = 1, TypeID = ParameterType.ShortString, Created = DateTime.Now },
                        new PARAMETER { Name = "general-audit-enabled", Value = "true", MemberID = 1, TypeID = ParameterType.Bool, Created = DateTime.Now },
                        new PARAMETER { Name = "general-app-maintenance-enabled", Value = "false", MemberID = 1, TypeID = ParameterType.Bool, Created = DateTime.Now },
                        new PARAMETER { Name = "general-app-maintenance-url", Value = "Offline", MemberID = 1, TypeID = ParameterType.Bool, Created = DateTime.Now },
                        new PARAMETER { Name = "general-app-maintenance-allowedIPs", Value = "", MemberID = 1, TypeID = ParameterType.ShortString, Created = DateTime.Now }
                    );
                db.SaveChanges();
            }
            
            
            //Create Default Roles...
            IList<ApplicationRole> defaultRoles = new List<ApplicationRole>();
            defaultRoles.Add(new ApplicationRole { Name = c_SysAdmin, RoleDescription = "Autorise la gestion des utilisateurs/rôles/permissions", LastModified = DateTime.Now, IsSysAdmin = true });
            defaultRoles.Add(new ApplicationRole { Name = c_DefaultUser, RoleDescription = "Role par defaut avec restrictions", LastModified = DateTime.Now, IsSysAdmin = false });

            ApplicationRoleManager RoleManager = new ApplicationRoleManager(new ApplicationRoleStore(context));
            foreach (ApplicationRole role in defaultRoles)
            {                
                RoleManager.Create(role);
            }              
            
            //Create User...
            var user = new ApplicationUser { UserName = "Admin", Email = "admin@exemple.com", Firstname = "Système", Lastname = "Administrateur", LastModified = DateTime.Now, Inactive = false, EmailConfirmed = true };

            ApplicationUserManager UserManager = new ApplicationUserManager(new ApplicationUserStore(context));
            var result = UserManager.Create(user, "Password64!");

            if (result.Succeeded)
            {
                //Add User to Admin Role...
                UserManager.AddToRole(user.Id, c_SysAdmin);                
            }


            //Create Default User...
            user = new ApplicationUser { UserName = "Technicien", Email = "tech@exemple.com", Firstname = "Standard", Lastname = "Utilisateur", LastModified = DateTime.Now, Inactive = false, EmailConfirmed = true };
            result = UserManager.Create(user, "Password64!");            

            if (result.Succeeded)
            {
                //Add User to Admin Role...
                UserManager.AddToRole(user.Id, c_DefaultUser);
            }

            //Create User with NO Roles...
            user = new ApplicationUser { UserName = "Invité", Email = "invite@exemple.com", Firstname = "Invité", Lastname = "Utilisateur", LastModified = DateTime.Now, Inactive = false, EmailConfirmed=true };
            result = UserManager.Create(user, "Password64!");

          
            base.Seed(context);

            //Create a permission...
            PERMISSION _permission = new PERMISSION();
            _permission.PermissionDescription = "Main-Reports";
            ApplicationRoleManager.AddPermission(_permission);

            //Add Permission to DefaultUser Role...
            ApplicationRoleManager.AddPermission2Role(context.Roles.Where(p=>p.Name == c_DefaultUser).First().Id, context.PERMISSIONS.First().PermissionId);
        }        
    }
}
