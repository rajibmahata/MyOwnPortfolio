namespace MyOwnPortfolio.ApiService.Models.RequestResponseModels
{
    /// <summary>
    /// Model for user registration request.
    /// </summary>
    public class RegistrationRequestModel
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        public required string ContactNumber { get; set; }
    }
}
