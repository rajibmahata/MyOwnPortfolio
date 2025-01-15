using Microsoft.AspNetCore.Components;
using MyOwnPortfolio.Model;
using MyOwnPortfolio.Services;

namespace MyOwnPortfolio.Components.Pages.Admin
{
    public partial class Login : IDisposable
    {
        [Inject] LayoutService LayoutService { get; set; }
        private bool isDisposed = false;

        [SupplyParameterFromForm]
        private LoginModel? loginModel { get; set; } 
        private string formName = $"LoginForm";

        protected override void OnInitialized()
        {
            loginModel ??= new();
            LayoutService.ChangeLayout(typeof(Layout.AdminLoginLayout));
            isDisposed = false;
        }

        private void HandleLogin()
        {
            if (isDisposed) return;
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

        public void Dispose()
        {
            isDisposed = true;
        }
    }
}
