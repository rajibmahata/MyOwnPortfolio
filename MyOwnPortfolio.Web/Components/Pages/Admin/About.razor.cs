using Microsoft.AspNetCore.Components;
using MyOwnPortfolio.Web.Components.Layout;
using MyOwnPortfolio.Web.Models;
using MyOwnPortfolio.Web.Models.RequestResponseModels;
using MyOwnPortfolio.Web.Services;

namespace MyOwnPortfolio.Web.Components.Pages.Admin
{
    public partial class About : IDisposable
    {
        [Parameter]
        public string? PortalID { get; set; }

        [Inject] private NavigationManager navigationManager { get; set; } = default!;
        private bool isDisposed = false;
        [Inject] private AboutMeApiClient ApiClient { get; set; } = default!;

        [SupplyParameterFromForm]
        private AboutMeUIModel aboutMeUIModel { get; set; } = new AboutMeUIModel
        {
            Name = string.Empty,
            Email = string.Empty,
            ContactNumber = string.Empty
        };

        protected override async void OnInitialized()
        {
            base.OnInitialized();

            if (!string.IsNullOrEmpty(PortalID))
            {
                aboutMeUIModel =await ApiClient.GetAboutMeByPortalIDAsync(PortalID);
            }
            else
            {
                navigationManager.NavigateTo("/admin/login");
            }

            isDisposed = false;
        }
        public void Dispose()
        {
            if (!isDisposed)
            {
                isDisposed = true;
            }
        }
    }
}
