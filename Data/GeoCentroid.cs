using System.Text.Json.Serialization;

namespace Visicom.DataApi.Geocoder.Data;

public record GeoCentroid(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("coordinates")] IReadOnlyList<double> Coordinates
);