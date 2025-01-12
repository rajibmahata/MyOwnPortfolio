using MyOwnPortfolio.ApiService.Models.RequestResponseModel;

namespace MyOwnPortfolio.ApiService.Models.SwaggerExamples
{
    /// <summary>
    /// Provides example data for the RegistrationRequestModel.
    /// </summary>
    public class RegistrationRequestExample : Swashbuckle.AspNetCore.Filters.IExamplesProvider<RegistrationRequestModel>
    {
        /// <summary>
        /// Gets an example of RegistrationRequestModel.
        /// </summary>
        /// <returns>An example of RegistrationRequestModel.</returns>
        public RegistrationRequestModel GetExamples()
        {
            return new RegistrationRequestModel
            {
                Username = "rajibmahata",
                Password = "12345678",
                ContactNumber = "8420249020",
                Email = "rajibmahata143@outlook.com",
                Name = "Rajib Mahata"
            };
        }
    }


}
