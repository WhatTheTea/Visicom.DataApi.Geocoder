using System.Text.Json.Serialization;

namespace Visicom.DataApi.Geocoder.Data;

public record Response(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("properties")] Properties Properties,
    [property: JsonPropertyName("bbox")] IReadOnlyList<double> Bbox,
    [property: JsonPropertyName("geo_centroid")] GeoCentroid GeoCentroid,
    [property: JsonPropertyName("url")] string Url
);