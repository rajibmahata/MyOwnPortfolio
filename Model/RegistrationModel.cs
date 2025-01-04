using System.ComponentModel.DataAnnotations;

namespace MyOwnPortfolio.Model
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Firstname is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "ContactNumber is required.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Linkedin is required.")]
        public string Linkedin { get; set; }

        [Required(ErrorMessage = "Github is required.")]
        public string Github { get; set; }

       
    }
}
