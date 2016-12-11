using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class SignInVm
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string AuthenticationCode { get; set; }
    }
}