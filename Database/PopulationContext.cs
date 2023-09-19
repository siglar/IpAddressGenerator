using Microsoft.EntityFrameworkCore;
using Models.Database;

namespace Database
{
    public class PopulationContext : DbContext
    {
        public PopulationContext(DbContextOptions<PopulationContext> options) : base(options)
        { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}