namespace MyOwnPortfolio.ApiService.Models.RequestResponseModels
{
    /// <summary>
    /// Represents the response model for a registration request.
    /// </summary>
    public class RegistrationResponseModel : BaseResponse
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the about me information.
        /// </summary>
        public required AboutMeUIModel AboutMe { get; set; }
    }
}
