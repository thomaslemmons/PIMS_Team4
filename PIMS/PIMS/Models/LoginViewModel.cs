using System.ComponentModel.DataAnnotations;
namespace LoginRegister.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [Display(Name ="Email Address")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
