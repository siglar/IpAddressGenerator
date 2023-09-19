using Models.Database;

namespace Database.Repositories.LangaugeRepository
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetLanguages(IEnumerable<string> languages);
    }
}