using System.ComponentModel.DataAnnotations;

namespace Assignment_4.Models
{
    public class Signup
    {
        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a valid email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your full name.")]
        public string Name { get; set; } = null!;

        public List<string> Country { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "The password must contain at least one uppercase letter, one lowercase letter, one digit, and be at least 8 characters long.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Please confirm your password.")]
        [Compare("Password", ErrorMessage = "The password and confirmation do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
