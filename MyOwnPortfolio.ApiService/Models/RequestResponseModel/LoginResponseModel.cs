using MyOwnPortfolio.ApiService.Models;
using MyOwnPortfolio.ApiService.Models.RequestResponseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyOwnPortfolio.ApiService.Entities.RequestModel
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
