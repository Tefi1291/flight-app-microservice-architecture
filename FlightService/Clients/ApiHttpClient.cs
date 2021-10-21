using System.Net.Http;
using System.Threading.Tasks;
using FlightService.Clients.Interfaces;

namespace FlightService.Clients
{
    public class ApiHttpClient : IApiHttpClient
    {
        public readonly HttpClient _httpClient;

        public ApiHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendPostAsync(string url, object requestBody)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();
        }
    }
}