using MyOwnPortfolio.ApiService.Entities.RequestModel;

namespace MyOwnPortfolio.ApiService.Entities.SwaggerExamples
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
