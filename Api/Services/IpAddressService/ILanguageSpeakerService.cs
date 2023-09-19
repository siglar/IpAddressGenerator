using Models.ViewModels;

namespace Api.Services.IpAddressService
{
    public interface ILanguageSpeakerService
    {
        Task<IEnumerable<LanguageWithSpeakersViewModel>> GetLanguagesWithSpeakers();
    }
}