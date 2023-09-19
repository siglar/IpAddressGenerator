using Models.RestCountries;
using System.Net.Http.Json;

namespace Common.Services.RestCountriesClient
{
    public class RestCountriesClient : IRestCountriesClient
    {
        private readonly HttpClient _httpClient;

        public RestCountriesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://restcountries.com/");
        }

        public async Task<RestCountriesResult> GetLanguagesForCountry(string country)
        {
            var result = await _httpClient.GetFromJsonAsync<dynamic?>($"v3.1/name/{country}?fields=languages");

            ArgumentNullException.ThrowIfNull(result);

            return result;
        }
    }
}