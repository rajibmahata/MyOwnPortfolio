
namespace MyOwnPortfolio.ApiService.Models.RequestResponseModels
{
    /// <summary>
    /// Represents the response model for a login request.
    /// </summary>
    public class LoginResponseModel : BaseResponse
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the about me information.
        /// </summary>
        public AboutMeUIModel AboutMe { get; set; }
    }
}
