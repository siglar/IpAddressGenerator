namespace Models.Database
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Language> Languages { get; set; } = new List<Language>();
    }
}