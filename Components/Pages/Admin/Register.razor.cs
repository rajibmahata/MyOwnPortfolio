using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MyOwnPortfolio.Model;
using MyOwnPortfolio.Services;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyOwnPortfolio.Components.Pages.Admin
{
    public partial class Register
    {
        [Inject] LayoutService LayoutService { get; set; }
        [Inject] ApiService apiService { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] CustomAuthenticationStateProvider customAuthenticationState { get; set; }
       
        private bool isDisposed = false;

        private RegistrationModel registrationModel = new RegistrationModel();

        protected override void OnInitialized()
        {
            LayoutService.ChangeLayout(typeof(Layout.AdminLoginLayout));
            isDisposed = false;
            base.OnInitialized();
        }


        private async Task HandleRegistration()
        {
            try
            {
                if (isDisposed) return;

                var response = await apiService.PostAsync<MyPortal>("api/Auth/register", registrationModel);
                if (response != null)
                {
                    // Save the token (e.g., localStorage, sessionStorage)
                    await Task.Delay(0); // Simulating token save
                    customAuthenticationState.MarkUserAsAuthenticated(response.Username);
                    _navigationManager.NavigateTo("admin/login");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            isDisposed = true;
        }
    }
}
