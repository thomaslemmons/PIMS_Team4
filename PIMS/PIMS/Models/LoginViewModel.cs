using System.ComponentModel.DataAnnotations;
namespace LoginRegister.Models
{
    public class LoginViewModel
    {
        [Display(Name ="Email Address")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
