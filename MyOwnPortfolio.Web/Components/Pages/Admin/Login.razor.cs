using Microsoft.AspNetCore.Components;
using System.Net.NetworkInformation;
using MyOwnPortfolio.Web.Services;
using MyOwnPortfolio.Web.Models.RequestResponseModels;
using MyOwnPortfolio.Web.Components.Layout;
using MyOwnPortfolio.Web.Enum;

namespace MyOwnPortfolio.Web.Components.Pages.Admin
{
    public partial class Login : IDisposable
    {
        [Inject] private LayoutService layoutService { get; set; } = default!;
        [Inject] private NavigationManager navigationManager { get; set; } = default!;
        private bool isDisposed = false;
        [Inject] private AuthAPIClient ApiClient { get; set; } = default!;

        [SupplyParameterFromForm]
        private LoginRequestModel loginRequest { get; set; } = new LoginRequestModel();



        protected override void OnInitialized()
        {
            layoutService.SetLayout(typeof(AdminLayout));
            isDisposed = false;
        }
        private async Task HandleLogin()
        {
            try
            {
                var loginResponse = await ApiClient.LoginAsync(loginRequest);

                if (loginResponse.StatusCode == (int)MyOwnPortfolioStatusEnum.Success)
                {
                    Console.WriteLine("Login successful: " + loginResponse.Username);

                    if (!string.IsNullOrEmpty(loginResponse.ID))
                    {
                        var url = $"/admin/MyPortfolioSettings/{loginResponse.ID}";
                        Console.WriteLine("Navigating to: " + url);
                        navigationManager.NavigateTo(url, forceLoad: false);
                    }
                    else
                    {
                        Console.WriteLine("Login failed: Invalid user ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Login failed: " + loginResponse.StatusMessage);
                }
            }
            catch (Exception ex)
            {
                // Handle error (e.g., show error message to the user)
                Console.WriteLine("Login failed: " + ex.Message);
            }
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
