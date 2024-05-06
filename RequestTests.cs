using System.Net.Http;
using System.Threading.Tasks;
using Visicom.DataApi.Geocoder;
using Visicom.DataApi.Geocoder.Enums;
using Xunit;

namespace Visicom.DataApi.Geocoder.Tests;

public class RequestTests
{
    
    [Fact]
    public async Task GetCoordinatesOfKyiv()
    {
        var options = new RequestOptions(Languages.Ukrainian, "apikey");
        var httpClient = new HttpClient();
        var geocoder = new Geocoder(httpClient, options);
        
        var result = await geocoder.GetCoordinatesAsync("Kyiv");

        result.Should().Be();
    }
}