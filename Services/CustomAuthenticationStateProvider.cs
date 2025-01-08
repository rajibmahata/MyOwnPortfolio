using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace MyOwnPortfolio.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(_anonymous);
            }

            // Parse token to create user claims
            var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }

        public void MarkUserAsAuthenticated(string username)
        {
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, "jwt");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut()
        {
            _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            // Implement JWT parsing here if needed
            return new List<Claim>();
        }
    }
}
