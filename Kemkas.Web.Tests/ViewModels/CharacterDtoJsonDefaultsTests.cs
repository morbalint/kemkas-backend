using System.Text.Json;
using Kemkas.Web.ViewModels;

namespace Kemkas.Web.Tests.ViewModels;

public class CharacterDtoJsonDefaultsTests
{
    [Fact]
    public void Deserialize1E_WithMissingArrayFields_UsesEmptyCollectionDefaults()
    {
        const string json = """
                            {
                              "name": "Aron",
                              "jellem": "TJ",
                              "faj": "f_ember",
                              "osztaly": "o_harcos",
                              "tulajdonsagok": {
                                "t_ero": 10,
                                "t_ugy": 10,
                                "t_egs": 10,
                                "t_int": 10,
                                "t_bol": 10,
                                "t_kar": 10
                              },
                              "felszereles": {
                                "pancelID": "lancruha",
                                "pajzsID": "fa_pajzs"
                              }
                            }
                            """;

        var dto = JsonSerializer.Deserialize<Karakter1eDto>(json);

        Assert.NotNull(dto);
        Assert.Empty(dto.Kepzettsegek);
        Assert.Null(dto.Tolvajkepzettsegek);
        Assert.Empty(dto.HpRolls);
        Assert.Empty(dto.TulajdonsagNovelesek);
        Assert.Empty(dto.HarcosSpecializaciok);
        Assert.Empty(dto.KalozKritikus);
        Assert.Empty(dto.Felszereles1E.FegyverIds);
    }

    [Fact]
    public void Deserialize2E_WithMissingArrayFields_UsesEmptyCollectionDefaults()
    {
        const string json = """
                            {
                              "nev": "Belia",
                              "jellem": "TS",
                              "faj": "f_2e_ember",
                              "tulajdonsagok": {
                                "t_ero": 10,
                                "t_ugy": 10,
                                "t_egs": 10,
                                "t_int": 10,
                                "t_bol": 10,
                                "t_kar": 10
                              },
                              "felszereles": {
                                "pancelID": "bor",
                                "pajzsID": "kis_pajzs",
                                "at": 10,
                                "el": 20,
                                "et": 30
                              }
                            }
                            """;

        var dto = JsonSerializer.Deserialize<Karakter2eDto>(json);

        Assert.NotNull(dto);
        Assert.Empty(dto.Kepzettsegek);
        Assert.Null(dto.Tolvajkepzettsegek);
        Assert.Empty(dto.Szintlepesek);
        Assert.Empty(dto.Felszereles.Fegyverek);
        Assert.Empty(dto.Felszereles.Viselt);
        Assert.Empty(dto.Felszereles.Cipelt);
        Assert.Empty(dto.Felszereles.Aprosagok);
        Assert.Null(dto.Varazslatok);
    }
}

