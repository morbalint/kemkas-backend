using Kemkas.Web.Db.Enums;

namespace Kemkas.Web.Tests.Db.Enums;

public class FajExtensionsTests
{
    [Theory]
    [InlineData("f_ember", Faj1E.Ember)]
    [InlineData("f_etuniai", Faj1E.Etuniai)]
    [InlineData("f_felszerzet", Faj1E.Felszerzet)]
    public void Convert1E_StringToEnum_MapsCorrectly(string input, Faj1E expected)
    {
        var result = FajExtensions.Convert1E(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Faj1E.Ember, "f_ember")]
    [InlineData(Faj1E.Etuniai, "f_etuniai")]
    [InlineData(Faj1E.Felszerzet, "f_felszerzet")]
    public void Convert1E_EnumToString_MapsCorrectly(Faj1E input, string expected)
    {
        var result = input.Convert();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("f_2e_ember", Faj2E.Ember)]
    [InlineData("f_2e_nomad", Faj2E.Nomad)]
    [InlineData("f_2e_felszerzet", Faj2E.Felszerzet)]
    public void Convert2E_StringToEnum_MapsCorrectly(string input, Faj2E expected)
    {
        var result = FajExtensions.Convert2E(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Faj2E.Ember, "f_2e_ember")]
    [InlineData(Faj2E.Nomad, "f_2e_nomad")]
    [InlineData(Faj2E.Felszerzet, "f_2e_felszerzet")]
    public void Convert2E_EnumToString_MapsCorrectly(Faj2E input, string expected)
    {
        var result = input.Convert();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Convert1E_StringToEnum_InvalidValue_ThrowsException()
    {
        Assert.Throws<Exception>(() => FajExtensions.Convert1E("invalid"));
    }

    [Fact]
    public void Convert2E_StringToEnum_InvalidValue_ThrowsException()
    {
        Assert.Throws<Exception>(() => FajExtensions.Convert2E("invalid"));
    }
}

