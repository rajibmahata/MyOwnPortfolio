using Microsoft.AspNetCore.Components;
using MyOwnPortfolio.Web.Services;

namespace MyOwnPortfolio.Web.Components.Pages.Admin
{
    public partial class MyPortfolioSettings:IDisposable
    {
        [Inject] private ChatGPTAIService chatGPTAIService { get; set; } = default!;
        [Parameter]
        public string? Id { get; set; }

        protected override void OnInitialized()
        {
            // You can use the Id parameter here
            Console.WriteLine($"The ID is: {Id}");
            chatGPTAIService.Main();
        }
        public void Dispose()
        {
            // Dispose logic here
        }
    }
}
