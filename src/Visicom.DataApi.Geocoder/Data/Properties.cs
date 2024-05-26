using System.Text.Json.Serialization;

namespace Visicom.DataApi.Geocoder.Data;

public record Properties(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("categories")] string Categories,
    [property: JsonPropertyName("country_code")] string CountryCode,
    [property: JsonPropertyName("country")] string Country,
    [property: JsonPropertyName("postal_code")] string PostalCode,
    [property: JsonPropertyName("street_id")] string StreetId,
    [property: JsonPropertyName("lang")] string Lang,
    [property: JsonPropertyName("street")] string Street,
    [property: JsonPropertyName("street_type")] string StreetType,
    [property: JsonPropertyName("settlement_id")] string SettlementId,
    [property: JsonPropertyName("settlement")] string Settlement,
    [property: JsonPropertyName("settlement_type")] string SettlementType,
    [property: JsonPropertyName("copyright")] string Copyright,
    [property: JsonPropertyName("relevance")] double Relevance,
    [property: JsonPropertyName("settlement_url")] string SettlementUrl,
    [property: JsonPropertyName("street_url")] string StreetUrl
);