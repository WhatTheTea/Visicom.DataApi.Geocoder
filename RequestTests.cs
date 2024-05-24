using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using FluentAssertions;
using RichardSzalay.MockHttp;
using Visicom.DataApi.Geocoder;
using Visicom.DataApi.Geocoder.Abstractions;
using Visicom.DataApi.Geocoder.Enums;
using WhatTheTea.SprotyvMap.Primitives;
using Xunit;

namespace Visicom.DataApi.Geocoder.Tests;

public class RequestTests
{
    private const string ApiKey = "API_KEY";
    private const string TestResponsePath = "TestData/IdealResponse.json";
    private const string KyivRequest = $"https://api.visicom.ua/data-api/5.0/uk/geocode.json?key={ApiKey}&t=м. Київ, вул. Хрещатик, 26&order=relevance";
    
    private IGeocoder Geocoder { get; }
    public RequestTests()
    {
        var httpMock = new MockHttpMessageHandler();
        var testResponse = File.ReadAllText(TestResponsePath);
        httpMock.When("*")
            .With(x => HttpUtility.UrlDecode(x.RequestUri?.ToString()) == KyivRequest)
            .Respond(MediaTypeNames.Application.Json, testResponse);
        
        var options = new RequestOptions(Languages.Ukrainian, ApiKey);
        Geocoder = new BasicGeocoder(httpMock.ToHttpClient(), options);
    }

    [Fact]
    public async Task GetCoordinatesOfKyiv()
    {
        var result = await Geocoder.GetCoordinatesAsync("м. Київ, вул. Хрещатик, 26");

        result.Should()
            .BeEquivalentTo(new MapPoint(50.448847,30.521626));
    }
}