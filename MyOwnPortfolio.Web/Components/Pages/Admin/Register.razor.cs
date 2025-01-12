using Microsoft.AspNetCore.Components;
using MyOwnPortfolio.Web.Models.RequestResponseModels;
using MyOwnPortfolio.Web.Services;

namespace MyOwnPortfolio.Web.Components.Pages.Admin
{
    public partial class Register
    {
        [Inject] private AuthAPIClient ApiClient { get; set; } = default!;
        [SupplyParameterFromForm]
        private RegistrationRequestModel registerRequest { get; set; } = new RegistrationRequestModel
        {
            Username = string.Empty,
            Password = string.Empty,
            Name = string.Empty,
            Email = string.Empty,
            ContactNumber = string.Empty
        };

        private async Task HandleRegister()
        {
            try
            {
                var registerResponse = await ApiClient.RegisterAsync(registerRequest);
                // Handle registration success (e.g., show success message or redirect)
                Console.WriteLine("Registration successful: " + registerResponse.Username);
            }
            catch (Exception ex)
            {
                // Handle error (e.g., show error message to the user)
                Console.WriteLine("Registration failed: " + ex.Message);
            }
        }
    }
}
