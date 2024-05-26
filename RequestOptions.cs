using Visicom.DataApi.Geocoder.Abstractions;
using Visicom.DataApi.Geocoder.Enums;

namespace Visicom.DataApi.Geocoder;

public class RequestOptions : IRequestOptions
{
    private string _apikey = string.Empty;

    public RequestOptions(Languages language, string apikey)
    {
        Language = language;
        ApiKey = apikey;
    }

    public string ApiKey
    {
        get => _apikey;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value was empty");
            }

            _apikey = value;
        }
    }

    public Languages Language { get; set; }
    public IEnumerable<Categories> Categories { get; set; } = [];
    public IEnumerable<Categories> ExcludeCategories { get; set; } = [];
    public string Text { get; set; } = string.Empty;
    public string WordText { get; set; } = string.Empty;
    public string Near { get; set; } = string.Empty;
    public string NearRadius { get; set; } = string.Empty;
    public Order Order { get; set; }
    public string IntersectionArea { get; set; } = string.Empty;
    public string ContainsArea { get; set; } = string.Empty;
    public string Zoom { get; set; } = string.Empty;
    public string Limit { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string CountryCodePriority { get; set; } = string.Empty;
}