namespace Visicom.DataApi.Geocoder.Enums;

public enum Order
{
    Relevance,
    Distance
}

public static class OrderExtensions
{
    public static string ToRequestString(this Order order) 
        => order.ToString().ToLower();
}