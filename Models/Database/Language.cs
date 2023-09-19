namespace Models.Database
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AmountOfSpeakers { get; set; }
        public Country Country { get; set; } = new Country();
        public int CountryId { get; set; }
    }
}