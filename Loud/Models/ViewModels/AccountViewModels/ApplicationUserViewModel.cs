using System.ComponentModel.DataAnnotations;

namespace SAS.Models.ViewModels.AccountViewModels
{
    public class ApplicationUserViewModel
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Avatar URL")]
        public string AvatarURL { get; set; }
        [Display(Name = "Date Registered")]
        public string DateRegistered { get; set; }
        public string Position { get; set; }
        [Display(Name = "Nick Name")]
        public string NickName { get; set; }
        [Display(Name = "User Role")]
        public string UserRole { get; set; }
    }
}
