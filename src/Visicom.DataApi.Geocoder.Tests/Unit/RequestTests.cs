using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Web;
using RichardSzalay.MockHttp;
using Visicom.DataApi.Geocoder.Enums;

namespace Visicom.DataApi.Geocoder.Tests.Unit;

public class RequestTests : RequestTestsBase
{
    private const string ApiKey = "API_KEY";
    private const string RequestFormat = "https://api.visicom.ua/data-api/5.0/uk/geocode.json?key={0}&t={1}&order=relevance";
    private const string TestResponsePath = "TestData/IdealResponse.json";
    private const string ApiKeyInvalidResponsePath = "TestData/ApiKeyInvalidResponse.json";
    private const string NotFoundResponsePath = "TestData/NotFoundResponse.json";
    public RequestTests()
    {
        var httpMock = new MockHttpMessageHandler();
        AddIdealMock();
        AddNotFoundMock();
        AddApiKeyInvalidMock();
        
        Geocoder = BuildGeocoder(httpMock.ToHttpClient());
        return;

        void AddNotFoundMock()
        {
            var notFoundResponse = File.ReadAllText(NotFoundResponsePath);
            httpMock.When("*")
                .With(x => HttpUtility.UrlDecode(x.RequestUri?.ToString()) == string.Format(RequestFormat, ApiKey, "ABCDEFGH"))
                .Respond(MediaTypeNames.Application.Json ,notFoundResponse);
        }

        void AddApiKeyInvalidMock()
        {
            var apiKeyInvalidResponse = File.ReadAllText(ApiKeyInvalidResponsePath);
            httpMock.When("*")
                .With(x => HttpUtility.UrlDecode(x.RequestUri?.ToString()) == string.Format(RequestFormat, "ABCDEFGH", KyivSearchTerm))
                .Respond(MediaTypeNames.Application.Json, apiKeyInvalidResponse);
        }

        void AddIdealMock()
        {
            var testResponse = File.ReadAllText(TestResponsePath);
            httpMock.When("*")
                .With(x => HttpUtility.UrlDecode(x.RequestUri?.ToString()) == string.Format(RequestFormat, ApiKey, KyivSearchTerm))
                .Respond(MediaTypeNames.Application.Json, testResponse);
        }
    }

    private static BasicGeocoder BuildGeocoder(HttpClient httpClient)
    {
        var options = new RequestOptions(Languages.Ukrainian, ApiKey);
        return new BasicGeocoder(httpClient, options);
    }
}