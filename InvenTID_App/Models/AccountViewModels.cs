using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvenTID_App.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Se souvenir de ce navigateur?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Identifiant")]      
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Display(Name = "Se souvenir de moi?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "Le {0} doit avoir au moins {2} caractères.", MinimumLength = 6)]
        [Display(Name = "Identifiant")]
        public string UserName { get; set; }

        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Le {0} doit avoir au moins {2} caractères.", MinimumLength = 2)]
        [Display(Name = "Prenom")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Le {0} doit avoir au moins {2} caractères.", MinimumLength = 2)]
        [Display(Name = "Nom")]
        public string Lastname { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Le {0} doit avoir au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmation du mot de passe")]
        [Compare("Password", ErrorMessage = "Le mot de passe n'a pu être verifié.")]
        public string ConfirmPassword { get; set; }
                
        [StringLength(30, ErrorMessage = "Le {0} doit être composé d'au moins {2} chiffres.", MinimumLength = 11)]
        [Display(Name = "Téléphone")]
        public string Mobile { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Le {0} doit avoir au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmation du mot de passe")]
        [Compare("Password", ErrorMessage = "Le mot de passe n'a pu être verifié.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }


    //********** RBAC View Models **************
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Le {0} doit avoir au moins {2} caractères.", MinimumLength = 2)]
        [Display(Name = "Libellé du rôle")]
        public string RoleName { get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "Le {0} doit avoir au moins {2} caractères.", MinimumLength = 2)]
        [Display(Name = "Description du rôle")]
        public string RoleDescription { get; set; }

        [Required]       
        [Display(Name = "Compte administrateur?")]
        public bool IsSysAdmin { get; set; }
    }

    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Le {0} doit avoir au moins {2} caractères.", MinimumLength = 6)]
        [Display(Name = "Identifiant")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Le {0} doit avoir au moins {2} caractères.", MinimumLength = 2)]
        [Display(Name = "Prenom")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Le {0} doit avoir au moins {2} caractères.", MinimumLength = 2)]
        [Display(Name = "Nom")]
        public string Lastname { get; set; }

       
    }

}
