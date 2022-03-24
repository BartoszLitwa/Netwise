using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
            try
            {
                var response = await client.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    return default;
                }

                // Read responeses Content as stream
                var content = await response.Content.ReadAsStringAsync();
                // Deserialize Json Object
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception ex)
            {
                // We should log that message for debugging purposes
                return default;
            }
        }

        public void SetupClient(string baseAddress)
        {
            client.BaseAddress = new Uri(baseAddress);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("accept-language", "pl-PL,pl;q=0.9,en-US;q=0.8,en;q=0.7");
        }
    }
}
