using Kemkas.Web.Services.SecondEdition.Character;
using Kemkas.Web.Tests.Services.TestData;

namespace Kemkas.Web.Tests.Services.SecondEdition.Character;

public class CharacterDbModelToDto2EServiceTests
{
    private readonly CharacterDbModelToDto2EService _sut = new();

    [Fact]
    public void Convert_MapsEntityToDto()
    {
        var entity = CharacterMapperTestData.Create2EEntity();

        var result = _sut.Convert(entity);

        Assert.Equal("Belia", result.Nev);
        Assert.Equal("TS", result.Jellem);
        Assert.Equal("f_2e_ember", result.Faj);
        Assert.Equal(new List<string> { "k_alkimia" }, result.Kepzettsegek);
        Assert.Equal(new List<string> { "k_osonas" }, result.Tolvajkepzettsegek);
        Assert.Equal("kard", result.Felszereles.Fegyverek.Single().Id);
        Assert.Equal("sisak", result.Felszereles.Viselt.Single().Id);
        Assert.Equal("kotel", result.Felszereles.Cipelt.Single().Id);
        Assert.Equal("gyertya", result.Felszereles.Aprosagok.Single().Id);
        Assert.Equal(2, result.Szintlepesek.Count);
        Assert.Equal("o_2e_harcos", result.Szintlepesek[0].Osztaly);
        Assert.Equal("kard", result.Szintlepesek[0].HarcosFegyver);
        Assert.Null(result.Szintlepesek[0].KalozKritikus);
        Assert.Equal("o_2e_tengeresz", result.Szintlepesek[1].Osztaly);
        Assert.Equal("szuras", result.Szintlepesek[1].KalozKritikus);
        Assert.Null(result.Szintlepesek[1].HarcosFegyver);
        Assert.Equal("t_kar", result.Szintlepesek[1].TulajdonsagNoveles);
        Assert.Equal("k_zarnyitas", result.Szintlepesek[1].TolvajExtraKepzettseg);
        Assert.NotNull(result.Varazslatok);
        Assert.Single(result.Varazslatok);
        Assert.Equal("v_tuz", result.Varazslatok[0].VarazslatId);
        Assert.False(result.IsPublic ?? true);
    }
}


