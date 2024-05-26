namespace Visicom.DataApi.Geocoder.Enums;

public enum Languages
{
    Ukrainian,
    English,
    Russian,
}

public static class LanguagesExtensions
{
    public static string ToRequestString(this Languages language) => language switch
    {
        Languages.Ukrainian => "uk",
        Languages.English => "en",
        Languages.Russian => "ru",
        _ => throw new ArgumentOutOfRangeException(nameof(language), language, null)
    };
}