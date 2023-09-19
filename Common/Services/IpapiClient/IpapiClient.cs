using Models.Ipapi;
using System.Net;
using System.Net.Http.Json;

namespace Common.Services.IpapiClient
{
    public class IpapiClient : IIpapiClient
    {
        private readonly HttpClient _httpClient;

        public IpapiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://ipapi.co/");
        }

        public async Task<IpapiResult> GetLocationInformation(IPAddress ipAddress)
        {
            var result = await _httpClient.GetFromJsonAsync<IpapiResult>($"{ipAddress}/json");

            ArgumentNullException.ThrowIfNull(result);

            return result;
        }
    }
}