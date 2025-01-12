using System.ComponentModel.DataAnnotations;

namespace MyOwnPortfolio.ApiService.Models.RequestResponseModel
{
    /// <summary>
    /// Represents the base response model for API responses.
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier for the response.
        /// </summary>
               public required string ID { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the response was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the response was last modified.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the response is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the status code of the response.
        /// </summary>
        public required int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the status message of the response.
        /// </summary>
        public required string StatusMessage { get; set; }
    }
}
