using Microsoft.AspNetCore.Components;
using MyOwnPortfolio.Model;
using MyOwnPortfolio.Services;

namespace MyOwnPortfolio.Components.Pages.Admin
{
    public partial class Login
    {
      [Inject]  LayoutService LayoutService { get; set; }


        private LoginModel loginModel = new LoginModel();
        protected override void OnInitialized()
        {
            LayoutService.ChangeLayout(typeof(Layout.AdminLoginLayout));
            StateHasChanged();
        }


        private async Task HandleLogin()
        {
            // Add your login logic here
            if (loginModel.Username == "admin" && loginModel.Password == "password")
            {
                // Redirect or show a success message
                Console.WriteLine("Login successful!");
            }
            else
            {
                // Show an error message
                Console.WriteLine("Invalid username or password.");
            }
        }
    }
}
