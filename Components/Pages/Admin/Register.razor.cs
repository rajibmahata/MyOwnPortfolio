using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MyOwnPortfolio.Model;
using MyOwnPortfolio.Services;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyOwnPortfolio.Components.Pages.Admin
{
    public partial class Register : IDisposable
    {
        [Inject] LayoutService? LayoutService { get; set; }
        [Inject] ApiService? apiService { get; set; }
        [Inject] NavigationManager? _navigationManager { get; set; }
        [Inject] CustomAuthenticationStateProvider? customAuthenticationState { get; set; }

        private bool isDisposed = false, loadLayout=false;

        private RegistrationModel registrationModel = new RegistrationModel();
        private string formName = $"RegisterForm_{Guid.NewGuid()}";
        protected override async Task OnInitializedAsync()
        {
            if (!loadLayout)
            {
                LayoutService.ChangeLayout(typeof(Layout.AdminLoginLayout));
                loadLayout = true;
               
            }
           
            isDisposed = false;
            await Task.Delay(1000);

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
               
            }
        }
        protected override async Task OnParametersSetAsync()
        {
            
        }
        private void HandleRegistration()
        {
            try
            {
                if (isDisposed) return;

                var response =  apiService.PostAsync<MyPortal>("api/Auth/register", registrationModel);
                if (response.Result != null)
                {
                    // Save the token (e.g., localStorage, sessionStorage)
                     Task.Delay(0); // Simulating token save
                    customAuthenticationState.MarkUserAsAuthenticated(response.Result.Username);
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
