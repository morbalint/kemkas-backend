using Kemkas.Web.Db.Enums;
using Kemkas.Web.Db.Models;
using Kemkas.Web.Services.SecondEdition.Character;
using Kemkas.Web.Tests.Services.TestData;

namespace Kemkas.Web.Tests.Services.SecondEdition.Character;

public class Character2EDtoToDbModelServiceTests
{
    private readonly Character2EDtoToDbModelService _sut = new();

    [Fact]
    public void Convert_MapsDtoToEntity()
    {
        var dto = CharacterMapperTestData.Create2EDto();

        var result = _sut.Convert(dto);

        Assert.Equal("Belia", result.Nev);
        Assert.Equal(Jellem.Torvenyes, result.Jellem);
        Assert.Equal(Faj2E.Ember, result.Faj);
        Assert.Equal(3, result.KarakterKepzettsegek.Count());
        Assert.Equal(1, result.KarakterKepzettsegek.Count(x => x.IsTolvajKepzettseg));
        Assert.Equal(4, result.Felszereles.Count());
        Assert.Single(result.Felszereles, x => x.IsFegyver);
        Assert.Single(result.Felszereles, x => x.IsViselt);
        Assert.Single(result.Felszereles, x => x.IsCipelt);
        Assert.Single(result.Felszereles, x => x.IsAprosag);
        Assert.Equal(2, result.Szintlepesek.Count());
        Assert.Equal("kard", result.Szintlepesek.Single(x => x.KarakterSzint == 1).FegyverSpecializacio);
        Assert.Equal("szuras", result.Szintlepesek.Single(x => x.KarakterSzint == 2).FegyverSpecializacio);
        Assert.Equal(Tulajdonsag.Karizma, result.Szintlepesek.Single(x => x.KarakterSzint == 2).TulajdonsagNoveles);
        Assert.Single(result.Varazslatok);
        Assert.Equal("v_tuz", result.Varazslatok.Single().VarazslatId);
    }

    [Fact]
    public void Update_WhenDtoVarazslatokIsNull_ClearsSpells()
    {
        var dto = CharacterMapperTestData.Create2EDto();
        dto.Varazslatok = null;
        var original = CharacterMapperTestData.Create2EEntity();

        _sut.Update(original, dto);

        Assert.Empty(original.Varazslatok);
    }

    [Fact]
    public void Update_ReplacesScalarFieldsAndCollections()
    {
        var dto = CharacterMapperTestData.Create2EDto();
        var original = new V2Karakter
        {
            Nev = "old",
            Jellem = Jellem.Semleges,
            Faj = Faj2E.Torpe,
            KarakterKepzettsegek = new List<V2KarakterKepzettseg>
            {
                new() { Kepzettseg = Kepzettseg2E.Historia, Karakter = null! }
            },
            Felszereles = new List<V2Felszereles>
            {
                new() { TargyId = "old", Count = 1, IsFegyver = true, Karakter = null! }
            },
            Szintlepesek = new List<V2Szintlepes>
            {
                new() { KarakterSzint = 1, Osztaly = Osztaly2E.Pap, HpRoll = 5, Karakter = null! }
            },
            Varazslatok = new HashSet<V2KarakterVarazslat>()
        };

        _sut.Update(original, dto);

        Assert.Equal("Belia", original.Nev);
        Assert.Equal(Jellem.Torvenyes, original.Jellem);
        Assert.Equal(Faj2E.Ember, original.Faj);
        Assert.Equal(3, original.KarakterKepzettsegek.Count());
        Assert.DoesNotContain(original.Felszereles, x => x.TargyId == "old");
        Assert.Equal(2, original.Szintlepesek.Count());
    }
}


