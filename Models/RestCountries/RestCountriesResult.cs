using System.Text.Json.Serialization;

namespace Models.RestCountries
{
    public record RestCountriesResult(
        [property: JsonPropertyName("languages")] IReadOnlyList<string> Languages
    );
}