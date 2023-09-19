using System.Text.Json.Serialization;

namespace Models.Ipapi;

public record IpapiResult(
        [property: JsonPropertyName("ip")] string Ip,
        [property: JsonPropertyName("network")] string Network,
        [property: JsonPropertyName("version")] string Version,
        [property: JsonPropertyName("city")] string City,
        [property: JsonPropertyName("region")] string Region,
        [property: JsonPropertyName("region_code")] string RegionCode,
        [property: JsonPropertyName("country")] string Country,
        [property: JsonPropertyName("country_name")] string CountryName,
        [property: JsonPropertyName("country_code")] string CountryCode,
        [property: JsonPropertyName("country_code_iso3")] string CountryCodeIso3,
        [property: JsonPropertyName("country_capital")] string CountryCapital,
        [property: JsonPropertyName("country_tld")] string CountryTld,
        [property: JsonPropertyName("continent_code")] string ContinentCode,
        [property: JsonPropertyName("in_eu")] bool InEu,
        [property: JsonPropertyName("postal")] string Postal,
        [property: JsonPropertyName("latitude")] double Latitude,
        [property: JsonPropertyName("longitude")] double Longitude,
        [property: JsonPropertyName("timezone")] string Timezone,
        [property: JsonPropertyName("utc_offset")] string UtcOffset,
        [property: JsonPropertyName("country_calling_code")] string CountryCallingCode,
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("currency_name")] string CurrencyName,
        [property: JsonPropertyName("languages")] string Languages,
        [property: JsonPropertyName("country_area")] double CountryArea,
        [property: JsonPropertyName("country_population")] int CountryPopulation,
        [property: JsonPropertyName("asn")] string Asn,
        [property: JsonPropertyName("org")] string Org
    );