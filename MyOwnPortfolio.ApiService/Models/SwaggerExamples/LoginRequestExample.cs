using MyOwnPortfolio.ApiService.Models.RequestResponseModel;

namespace MyOwnPortfolio.ApiService.Models.SwaggerExamples
{
    public class LoginRequestExample : Swashbuckle.AspNetCore.Filters.IExamplesProvider<LoginRequestModel>
    {
        public LoginRequestModel GetExamples()
        {
            return new LoginRequestModel
            {
                Username = "rajibmahata",
                Password = "12345678",
            };

        }
    }


}
