using MyOwnPortfolio.Web.Models;

namespace MyOwnPortfolio.Web.Services
{
    public class AboutMeApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AboutMeApiClient> _logger;

        public AboutMeApiClient(HttpClient httpClient, ILogger<AboutMeApiClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<AboutMeUIModel>> GetAboutMesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<AboutMeUIModel>>("api/AboutMe");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching AboutMe records.");
                throw;
            }
        }

        public async Task<AboutMeUIModel> GetAboutMeByPortalIDAsync(string portalID)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<AboutMeUIModel>($"api/AboutMe/{portalID}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching AboutMe record by portal ID: {PortalID}", portalID);
                throw;
            }
        }

        public async Task<AboutMeUIModel> GetAboutMeAsync(string portalID, string id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<AboutMeUIModel>($"api/AboutMe/{portalID}/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching AboutMe record by portal ID: {PortalID} and ID: {ID}", portalID, id);
                throw;
            }
        }

        public async Task<AboutMeUIModel> CreateAboutMeAsync(AboutMeUIModel aboutMe)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/AboutMe", aboutMe);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<AboutMeUIModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating AboutMe record.");
                throw;
            }
        }

        public async Task UpdateAboutMeAsync(string id, AboutMeUIModel aboutMe)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/AboutMe/{id}", aboutMe);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating AboutMe record with ID: {ID}", id);
                throw;
            }
        }

        public async Task DeleteAboutMeAsync(string id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/AboutMe/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting AboutMe record with ID: {ID}", id);
                throw;
            }
        }
    }
}
