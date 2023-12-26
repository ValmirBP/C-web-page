using System.ComponentModel.DataAnnotations;

namespace Assignment_4.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter your username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string password { get; set; }
    }
}
