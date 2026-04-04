using Kemkas.Web.Services.FirstEdition.Character;
using Kemkas.Web.Tests.Services.TestData;

namespace Kemkas.Web.Tests.Services.FirstEdition.Character;

public class CharacterDbModelToDto1EServiceTests
{
    private readonly CharacterDbModelToDto1EService _sut = new();

    [Fact]
    public void Convert_MapsEntityToDtoWithExpectedOrderingAndSplits()
    {
        var entity = CharacterMapperTestData.Create1EEntity();

        var result = _sut.Convert(entity);

        Assert.Equal("Aron", result.Name);
        Assert.Equal("TJ", result.Jellem);
        Assert.Equal("f_ember", result.Faj);
        Assert.Equal("o_harcos", result.Osztaly);
        Assert.Equal(new List<string> { "k_alkimia" }, result.Kepzettsegek);
        Assert.Equal(new List<string> { "k_osonas" }, result.Tolvajkepzettsegek);
        Assert.Equal(new List<byte> { 7, 5 }, result.HpRolls);
        Assert.Equal(new List<string> { "t_ero" }, result.TulajdonsagNovelesek);
        Assert.Equal(new List<string> { "kard", "ij" }, result.HarcosSpecializaciok);
        Assert.Empty(result.KalozKritikus);
        Assert.Equal(new List<string> { "kard" }, result.Felszereles1E.FegyverIds);
        Assert.True(result.IsPublic);
    }
}

