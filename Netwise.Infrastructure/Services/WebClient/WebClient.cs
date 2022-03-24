using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Netwise.Infrastructure.Services.WebClient
{
    public class WebClient : IWebClient
    {
        private readonly HttpClient client;

        public WebClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<T> GetJsonResponse<T>(string endpoint)
        {
            var response = await client.GetAsync(endpoint);

            if(response == null)
            {
                return default;
            }

            // Read responeses Content as stream
            using var stream = await response.Content.ReadAsStreamAsync();
            // Deserialize Json Object
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }

        public void SetupClient(string baseAddress)
        {
            client.BaseAddress = new Uri(baseAddress);

            client.DefaultRequestHeaders.Add("accept", "text/html,application/json");
            client.DefaultRequestHeaders.Add("accept-language", "pl-PL,pl;en-US,en;");
        }
    }
}
