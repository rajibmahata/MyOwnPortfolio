using System.Web;

namespace MyOwnPortfolio.Web.Services
{
    public class ChatGPTAIService
    {
        public async Task Main()
        {
            // Define the prompt to be sent
            string prompt = "Please generate a simple  title from \"I am a skilled and experienced .NET Azure Developer with a strong track record of success in the IT industry for over 9 years. I have extensive knowledge of .NET technologies, including .NET Core and Blazor development.\"";

            // Enter E-mail to generate API
            string apiKey = "4dab06a99c32e1495833017ce351ee35";

            // Define the default model if none is specified
            string defaultModel = "gpt-3.5-turbo";

            // Uncomment the model you want to use, and comment out the others
            // string model = "gpt-4";
            // string model = "gpt-4-32k";
            // string model = "gpt-3.5-turbo-0125";
            string model = defaultModel;

            // Build the URL to call
            string apiUrl = $"http://195.179.229.119/gpt/api.php?prompt={HttpUtility.UrlEncode(prompt)}&api_key={HttpUtility.UrlEncode(apiKey)}&model={HttpUtility.UrlEncode(model)}";

            // Initialize HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send the GET request
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Check if the request was successful
                    response.EnsureSuccessStatusCode();

                    // Read the response as a string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Print the response
                    Console.WriteLine(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
        }
    }
}
