using FluentAssertions;
using Visicom.DataApi.Geocoder.Enums;
using Xunit;

namespace Visicom.DataApi.Geocoder.Tests.Unit;

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