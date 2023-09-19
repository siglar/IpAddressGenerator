namespace Models.ViewModels
{
    public record CountryViewModel(string Name, IEnumerable<LanguageSpeakersViewModel> LanguageSpeakers);
}