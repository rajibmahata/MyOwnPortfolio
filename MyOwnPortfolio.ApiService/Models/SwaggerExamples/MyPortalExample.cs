using MyOwnPortfolio.ApiService.Models.RequestResponseModels;

namespace MyOwnPortfolio.ApiService.Models.SwaggerExamples
{
    public class MyPortalExample : Swashbuckle.AspNetCore.Filters.IExamplesProvider<MyPortalRequest>
    {
        public MyPortalRequest GetExamples()
        {
            return new MyPortalRequest
            {
                Username = "rajibmahata",
                Password = "12345678",
                IsActive = true
            };

        }
    }


}
