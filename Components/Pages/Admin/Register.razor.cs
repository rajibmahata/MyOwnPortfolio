using Microsoft.AspNetCore.Components;
using MyOwnPortfolio.Model;
using MyOwnPortfolio.Services;

namespace MyOwnPortfolio.Components.Pages.Admin
{
    public partial class Register
    {
        [Inject] LayoutService LayoutService { get; set; }


        private RegistrationModel registrationModel = new RegistrationModel();
        protected override void OnInitialized()
        {
            LayoutService.ChangeLayout(typeof(Layout.AdminLoginLayout));
        }


        private async Task HandleRegistration()
        {
           
        }
    }
}
