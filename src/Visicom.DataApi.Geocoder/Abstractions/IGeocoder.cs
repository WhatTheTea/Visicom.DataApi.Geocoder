using WhatTheTea.SprotyvMap.Data;
using WhatTheTea.SprotyvMap.Data.Primitives;

namespace Visicom.DataApi.Geocoder.Abstractions;

public interface IGeocoder
{
    void SetOptions(IRequestOptions options);
    MapPoint GetCoordinates(string searchTerm, bool isByWholeWord = false);
    
    Task<MapPoint> GetCoordinatesAsync(string searchTerm, bool isByWholeWord = false);
    
}