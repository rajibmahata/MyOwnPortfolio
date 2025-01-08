using System.Text.Json;

namespace MyOwnPortfolio.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>(url);
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP-related exceptions
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
            }
            catch (NotSupportedException ex)
            {
                // Handle content type errors
                Console.WriteLine($"Content Type Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing errors
                Console.WriteLine($"JSON Parsing Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return default;
        }

        public async Task<T?> PostAsync<T>(string url, object data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Parsing Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return default;
        }

        public async Task<T?> PutAsync<T>(string url, object data)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(url, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Parsing Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return default;
        }

        public async Task<bool> DeleteAsync(string url)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return false;
        }
    }
}
