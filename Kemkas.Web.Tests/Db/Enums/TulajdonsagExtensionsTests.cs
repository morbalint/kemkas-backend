using System.ComponentModel.DataAnnotations;
using Kemkas.Web.Db.Enums;

namespace Kemkas.Web.Tests.Db.Enums;

public class TulajdonsagExtensionsTests
{
    [Theory]
    [InlineData("t_ero", Tulajdonsag.Ero)]
    [InlineData("t_ugy", Tulajdonsag.Ugyesseg)]
    [InlineData("t_egs", Tulajdonsag.Egeszseg)]
    [InlineData("t_int", Tulajdonsag.Intelligencia)]
    [InlineData("t_bol", Tulajdonsag.Bolcsesseg)]
    [InlineData("t_kar", Tulajdonsag.Karizma)]
    public void Convert_StringToEnum_MapsCorrectly(string input, Tulajdonsag expected)
    {
        var result = TulajdonsagExtensions.Convert(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Tulajdonsag.Ero, "t_ero")]
    [InlineData(Tulajdonsag.Ugyesseg, "t_ugy")]
    [InlineData(Tulajdonsag.Egeszseg, "t_egs")]
    [InlineData(Tulajdonsag.Intelligencia, "t_int")]
    [InlineData(Tulajdonsag.Bolcsesseg, "t_bol")]
    [InlineData(Tulajdonsag.Karizma, "t_kar")]
    public void Convert_EnumToString_MapsCorrectly(Tulajdonsag input, string expected)
    {
        var result = input.Convert();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Convert_StringToEnum_InvalidValue_ThrowsValidationException()
    {
        Assert.Throws<ValidationException>(() => TulajdonsagExtensions.Convert("invalid"));
    }

    [Fact]
    public void Convert_EnumToString_InvalidValue_ThrowsValidationException()
    {
        Assert.Throws<ValidationException>(() => ((Tulajdonsag)0).Convert());
    }
}

