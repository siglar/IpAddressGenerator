using Models.RestCountries;

namespace Common.Services.RestCountriesClient
{
    public interface IRestCountriesClient
    {
        Task<RestCountriesResult> GetLanguagesForCountry(string country);
    }
}