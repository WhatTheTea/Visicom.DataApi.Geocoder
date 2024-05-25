using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Web;
using RichardSzalay.MockHttp;
using WhatTheTea.Visicom.Geocoder;
using WhatTheTea.Visicom.Geocoder.Enums;

namespace Visicom.DataApi.Geocoder.Tests.Unit;

public class RequestTests : RequestTestsBase
{
    private const string ApiKey = "API_KEY";
    private const string TestResponsePath = "TestData/IdealResponse.json";
    private const string KyivRequest = $"https://api.visicom.ua/data-api/5.0/uk/geocode.json?key={ApiKey}&t=м. Київ, вул. Хрещатик, 26&order=relevance";
    public RequestTests()
    {
        var httpMock = new MockHttpMessageHandler();
        var testResponse = File.ReadAllText(TestResponsePath);
        httpMock.When("*")
            .With(x => HttpUtility.UrlDecode(x.RequestUri?.ToString()) == KyivRequest)
            .Respond(MediaTypeNames.Application.Json, testResponse);
        
        Geocoder = BuildGeocoder(httpMock.ToHttpClient());
    }

    private static BasicGeocoder BuildGeocoder(HttpClient httpClient)
    {
        var options = new RequestOptions(Languages.Ukrainian, ApiKey);
        return new BasicGeocoder(httpClient, options);
    }
}