using Microsoft.EntityFrameworkCore;
using Models.Database;

namespace Database.Repositories.LangaugeRepository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly PopulationContext _populationContext;

        public LanguageRepository(PopulationContext populationContext)
        {
            _populationContext = populationContext;
        }

        public async Task<List<Language>> GetLanguages(IEnumerable<string> languages)
        {
            return await _populationContext.Languages
                .Include(l => l.Country)
                .Where(l => languages.Contains(l.Name))
                .ToListAsync();
        }
    }
}