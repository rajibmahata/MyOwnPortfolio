using Microsoft.AspNetCore.Components;
using System.Net.NetworkInformation;
using MyOwnPortfolio.Web.Services;
using MyOwnPortfolio.Web.Models.RequestResponseModels;

namespace MyOwnPortfolio.Web.Components.Pages.Admin
{
    public partial class Login
    {
        [Inject] private AuthAPIClient ApiClient { get; set; } = default!;

        [SupplyParameterFromForm]
        private LoginRequestModel loginRequest { get; set; } = new LoginRequestModel();

        private async Task HandleLogin()
        {
            try
            {
                var loginResponse = await ApiClient.LoginAsync(loginRequest);
                // Handle login success, e.g., store token or user info
                Console.WriteLine("Login successful: " + loginResponse.Username);
            }
            catch (Exception ex)
            {
                // Handle error (e.g., show error message to the user)
                Console.WriteLine("Login failed: " + ex.Message);
            }
        }
    }
}
