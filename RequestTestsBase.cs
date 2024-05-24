using System.Threading.Tasks;
using FluentAssertions;
using Visicom.DataApi.Geocoder.Abstractions;
using WhatTheTea.SprotyvMap.Data;
using Xunit;

namespace Visicom.DataApi.Geocoder.Tests;

public abstract class RequestTestsBase
{
    protected IGeocoder Geocoder { get; init; }
    
    [Fact]
    public async Task GetCoordinatesOfKyiv()
    {
        var result = await Geocoder.GetCoordinatesAsync("м. Київ, вул. Хрещатик, 26");

        result.Should()
            .BeEquivalentTo(new MapPoint(50.448847,30.521626));
    }
}