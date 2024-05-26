using Visicom.DataApi.Geocoder.Data;

namespace Visicom.DataApi.Geocoder.Abstractions;

public interface IGeocoder
{
    void SetOptions(IRequestOptions options);
    Coordinates GetCoordinates(string searchTerm, bool isByWholeWord = false);
    
    Task<Coordinates> GetCoordinatesAsync(string searchTerm, bool isByWholeWord = false);
    
}