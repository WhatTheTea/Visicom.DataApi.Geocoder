using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Visicom.DataApi.Geocoder;
using Visicom.DataApi.Geocoder.Enums;
using Xunit;

namespace Visicom.DataApi.Geocoder.Tests;

[TestSubject(typeof(IRequest))]
public class RequestTests
{
    
    [Fact]
    public async Task GetCoordinatesOfKyiv()
    {
        var options = new RequestOptionsBuilder() 
            .SetApiKey("apikey")
            .SetLanguage(Languages.Ukrainian)
            .Build();
        var httpClient = new HttpClient();
        var geocoder = new Geocoder(httpClient, options);
        
        var result = await geocoder.GetCoordinatesAsync("Kyiv");

        result.Should().Be();
    }
}