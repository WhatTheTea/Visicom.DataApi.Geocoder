using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Visicom.DataApi.Geocoder;
using Visicom.DataApi.Geocoder.Enums;
using WhatTheTea.SprotyvMap.Primitives;
using Xunit;

namespace Visicom.DataApi.Geocoder.Tests;

public class RequestTests
{
    
    [Fact]
    public async Task GetCoordinatesOfKyiv()
    {
        var options = new RequestOptions(Languages.Ukrainian, "apikey");
        var httpClient = new HttpClient();
        var geocoder = new BasicGeocoder(httpClient, options);
        
        var result = await geocoder.GetCoordinatesAsync("Kyiv");

        result.Should()
            .BeEquivalentTo(new MapPoint(50.4015698,30.2030564));
    }
}