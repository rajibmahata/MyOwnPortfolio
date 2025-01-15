using System.ComponentModel.DataAnnotations;

namespace MyOwnPortfolio.Web.Models.RequestResponseModels
{
    /// <summary>
    /// Model for user registration request.
    /// </summary>
    public class RegistrationRequestModel
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [Required(ErrorMessage = "Username is required.")]
        public  string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// 
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// 
        [Required(ErrorMessage = "Name is required.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "ContactNumber is required.")]
        public string ContactNumber { get; set; }
    }
}
