using System;
using System.Threading.Tasks;
using FluentAssertions;
using Visicom.DataApi.Geocoder.Abstractions;
using Visicom.DataApi.Geocoder.Data;
using Visicom.DataApi.Geocoder.Enums;
using Xunit;

namespace Visicom.DataApi.Geocoder.Tests;

public abstract class RequestTestsBase
{
    public const string KyivSearchTerm = "м. Київ, вул. Хрещатик, 26"; 
    protected IGeocoder Geocoder { get; init; }
    
    [Fact]
    public async Task GetCoordinatesOfKyiv()
    {
        var result = await Geocoder.GetCoordinatesAsync(KyivSearchTerm);

        result.Should()
            .BeEquivalentTo(new Coordinates(50.448847,30.521626));
    }

    [Fact]
    public async Task ThrowExceptionOnFaultyApiKey()
    {
        Geocoder.SetOptions(new RequestOptions(Languages.Ukrainian, "NOT_AN_APIKEY"));

        var task = () => Geocoder.GetCoordinatesAsync(KyivSearchTerm);

        await task.Should().ThrowAsync<ArgumentException>().WithMessage("API key is not valid");
    }

    [Fact]
    public async Task DefaultReturnedOnNotFound()
    {
        var result = await Geocoder.GetCoordinatesAsync("ABCDEFGH");

        result.Should().BeEquivalentTo(default(Coordinates));
    }
}