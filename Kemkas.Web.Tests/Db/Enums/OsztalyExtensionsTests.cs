using System.ComponentModel.DataAnnotations;
using Kemkas.Web.Db.Enums;

namespace Kemkas.Web.Tests.Db.Enums;

public class OsztalyExtensionsTests
{
    [Theory]
    [InlineData("o_harcos", Osztaly1E.Harcos)]
    [InlineData("o_kaloz", Osztaly1E.Kaloz)]
    [InlineData("o_illuzionista", Osztaly1E.Illuzionista)]
    public void Convert1E_StringToEnum_MapsCorrectly(string input, Osztaly1E expected)
    {
        var result = OsztalyExtensions.Convert1E(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Osztaly1E.Harcos, "o_harcos")]
    [InlineData(Osztaly1E.Kaloz, "o_kaloz")]
    [InlineData(Osztaly1E.Illuzionista, "o_illuzionista")]
    public void Convert1E_EnumToString_MapsCorrectly(Osztaly1E input, string expected)
    {
        var result = input.Convert();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("o_2e_harcos", Osztaly2E.Harcos)]
    [InlineData("o_2e_tengeresz", Osztaly2E.Tengeresz)]
    [InlineData("o_2e_vandor", Osztaly2E.Vandor)]
    public void Convert2E_StringToEnum_MapsCorrectly(string input, Osztaly2E expected)
    {
        var result = OsztalyExtensions.Convert2E(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Osztaly2E.Harcos, "o_2e_harcos")]
    [InlineData(Osztaly2E.Tengeresz, "o_2e_tengeresz")]
    [InlineData(Osztaly2E.Vandor, "o_2e_vandor")]
    public void Convert2E_EnumToString_MapsCorrectly(Osztaly2E input, string expected)
    {
        var result = input.Convert();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Convert1E_StringToEnum_InvalidValue_ThrowsValidationException()
    {
        Assert.Throws<ValidationException>(() => OsztalyExtensions.Convert1E("invalid"));
    }

    [Fact]
    public void Convert2E_StringToEnum_InvalidValue_ThrowsValidationException()
    {
        Assert.Throws<ValidationException>(() => OsztalyExtensions.Convert2E("invalid"));
    }
}

