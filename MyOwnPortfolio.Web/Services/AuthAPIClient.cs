

using MyOwnPortfolio.Web.Models.RequestResponseModels;

namespace MyOwnPortfolio.Web.Services
{
    public class AuthAPIClient
    {
        private readonly HttpClient _httpClient;

        public AuthAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Login method
        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequest)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<LoginResponseModel>();
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Login failed: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during login: {ex.Message}");
            }
        }

        // Register method
        public async Task<RegistrationResponseModel> RegisterAsync(RegistrationRequestModel registerRequest)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/register", registerRequest);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RegistrationResponseModel>();
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Registration failed: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during registration: {ex.Message}");
            }
        }
    }
}
