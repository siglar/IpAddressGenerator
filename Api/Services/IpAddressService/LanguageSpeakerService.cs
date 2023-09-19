using Common.Helpers.IpAddressHelper;
using Common.Services.IpapiClient;
using Common.Services.RestCountriesClient;
using Database.Repositories.LangaugeRepository;
using Models.Ipapi;
using Models.RestCountries;
using Models.ViewModels;
using System.Net;

namespace Api.Services.IpAddressService
{
    public class LanguageSpeakerService : ILanguageSpeakerService
    {
        private readonly IIpapiClient _ipapiClient;
        private readonly IRestCountriesClient _restCountriesClient;
        private readonly ILanguageRepository _languageRepository;

        public LanguageSpeakerService(IIpapiClient ipapiClient, IRestCountriesClient restCountriesClient, ILanguageRepository languageRepository)
        {
            _ipapiClient = ipapiClient;
            _restCountriesClient = restCountriesClient;
            _languageRepository = languageRepository;
        }

        public async Task<IEnumerable<LanguageWithSpeakersViewModel>> GetLanguagesWithSpeakers()
        {
            var addresses = IpAddressHelper.GetAddresses();

            var locationInformationList = await GetLocationInformations(addresses);

            ArgumentNullException.ThrowIfNull(locationInformationList);

            var countriesWithLanguages = await GetCountriesWithLanguages(locationInformationList);

            ArgumentNullException.ThrowIfNull(countriesWithLanguages);

            var languages = countriesWithLanguages.SelectMany (c => c.Languages).Distinct();

            var databaseLanguages = await _languageRepository.GetLanguages(languages);

            ArgumentNullException.ThrowIfNull(databaseLanguages);

            var result = databaseLanguages.Select(dl => new LanguageWithSpeakersViewModel(dl.Name, dl.AmountOfSpeakers));

            result = result.OrderByDescending(r => r.AmountOfSpeakers);

            return result;
        }

        private async Task<IEnumerable<IpapiResult>> GetLocationInformations(IEnumerable<IPAddress> addresses)
        {
            var ipapiTaskList = new List<Task<IpapiResult>>();

            foreach (var address in addresses)
            {
                var task = _ipapiClient.GetLocationInformation(address);
                ipapiTaskList.Add(task);
            }

            return (await Task.WhenAll(ipapiTaskList)).ToList();
        }

        private async Task<IEnumerable<RestCountriesResult>> GetCountriesWithLanguages(IEnumerable<IpapiResult> locationInformations)
        {
            var restCountriesTaskList = new List<Task<RestCountriesResult>>();

            foreach (var locationInformation in locationInformations)
            {
                var task = _restCountriesClient.GetLanguagesForCountry(locationInformation.CountryName.ToLower());
                restCountriesTaskList.Add(task);
            }

            return (await Task.WhenAll(restCountriesTaskList)).ToList();
        }
    }
}