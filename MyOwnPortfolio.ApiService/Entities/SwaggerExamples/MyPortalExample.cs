using MyOwnPortfolio.ApiService.Entities.RequestModel;

namespace MyOwnPortfolio.ApiService.Entities.SwaggerExamples
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
