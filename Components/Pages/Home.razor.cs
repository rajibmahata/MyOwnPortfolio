using Microsoft.AspNetCore.Components;
using MyOwnPortfolio.Components.Layout;
using MyOwnPortfolio.Services;

namespace MyOwnPortfolio.Components.Pages
{
    public partial class Home : IDisposable
    {
        [Inject] LayoutService? LayoutService { get; set; }

        private bool isDisposed = false;
        protected override void OnInitialized()
        {
            LayoutService.ChangeLayout(typeof(Layout.MyPortfolioLayout));
            isDisposed = false;
           
        }


        public void Dispose()
        {
            isDisposed = true;
        }
    }
}
