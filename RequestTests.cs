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
    // https://api.visicom.ua/data-api/5.0/uk/geocode.json?text=%D0%BC.%20%D0%9A%D0%B8%D1%97%D0%B2,%20%D0%B2%D1%83%D0%BB.%20%D0%A5%D1%80%D0%B5%D1%89%D0%B0%D1%82%D0%B8%D0%BA,%2026
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