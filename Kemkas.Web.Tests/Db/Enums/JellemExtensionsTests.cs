using System.ComponentModel.DataAnnotations;
using Kemkas.Web.Db.Enums;

namespace Kemkas.Web.Tests.Db.Enums;

public class JellemExtensionsTests
{
    [Theory]
    [InlineData("TJ", Jellem.TorvenyesJo)]
    [InlineData("SJ", Jellem.Jo)]
    [InlineData("KJ", Jellem.KaotikusJo)]
    [InlineData("TS", Jellem.Torvenyes)]
    [InlineData("S", Jellem.Semleges)]
    [InlineData("KS", Jellem.Kaotikus)]
    [InlineData("TG", Jellem.TorvenyesGonosz)]
    [InlineData("SG", Jellem.Gonosz)]
    [InlineData("KG", Jellem.KaotikusGonosz)]
    public void Convert_StringToEnum_MapsCorrectly(string input, Jellem expected)
    {
        var result = JellemExtensions.Convert(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Jellem.TorvenyesJo, "TJ")]
    [InlineData(Jellem.Jo, "SJ")]
    [InlineData(Jellem.KaotikusJo, "KJ")]
    [InlineData(Jellem.Torvenyes, "TS")]
    [InlineData(Jellem.Semleges, "S")]
    [InlineData(Jellem.Kaotikus, "KS")]
    [InlineData(Jellem.TorvenyesGonosz, "TG")]
    [InlineData(Jellem.Gonosz, "SG")]
    [InlineData(Jellem.KaotikusGonosz, "KG")]
    public void Convert_EnumToString_MapsCorrectly(Jellem input, string expected)
    {
        var result = input.Convert();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Convert_StringToEnum_InvalidValue_ThrowsValidationException()
    {
        Assert.Throws<ValidationException>(() => JellemExtensions.Convert("invalid"));
    }
}

