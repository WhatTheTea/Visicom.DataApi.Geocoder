using Visicom.DataApi.Geocoder.Enums;

namespace Visicom.DataApi.Geocoder.Abstractions;

public interface IRequestOptions
{
    public string ApiKey { get; }
    public Languages Language { get; }
    public IEnumerable<Categories> Categories { get; }
    public IEnumerable<Categories> ExcludeCategories { get; }
    public string Text { get; }
    public string WordText { get; }
    public string Near { get; }
    public string NearRadius { get; }
    public Order Order { get; }
    public string IntersectionArea { get; }
    public string ContainsArea { get; }
    public string Zoom { get; }
    public string Limit { get; }
    /// <summary>
    /// ISO 3166-1 alpha-2
    /// </summary>
    public string CountryCode { get; }
    /// <summary>
    /// ISO 3166-1 alpha-2
    /// </summary>
    public string CountryCodePriority { get; }
}