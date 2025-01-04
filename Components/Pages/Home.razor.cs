using Microsoft.AspNetCore.Components;
using MyOwnPortfolio.Components.Layout;
using MyOwnPortfolio.Services;

namespace MyOwnPortfolio.Components.Pages
{
    public partial class Home
    {
        [Inject] LayoutService LayoutService { get; set; }
        protected override void OnInitialized()
        {
            LayoutService.ChangeLayout(typeof(Layout.MyPortfolioLayout));
        }
    }
}
