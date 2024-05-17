using FluentAssertions;
using Visicom.DataApi.Geocoder;
using Visicom.DataApi.Geocoder.Enums;
using WhatTheTea.SprotyvMap.Primitives;
using Xunit;

namespace Visicom.DataApi.Geocoder.Tests;

public class EnumTests
{
    [Fact]
    public void ToStringReturnsCorrectArm()
    {
        const string correctArm = "poi_statue";
        var category = Categories.Statue;

        var arm = category.ToRequestString();

        arm.Should().Be(correctArm);
    }
}