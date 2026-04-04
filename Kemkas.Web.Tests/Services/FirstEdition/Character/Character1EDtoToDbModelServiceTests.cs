using System.ComponentModel.DataAnnotations;
using Kemkas.Web.Db.Enums;
using Kemkas.Web.Db.Models;
using Kemkas.Web.Services.FirstEdition.Character;
using Kemkas.Web.Tests.Services.TestData;

namespace Kemkas.Web.Tests.Services.FirstEdition.Character;

public class Character1EDtoToDbModelServiceTests
{
    private readonly Character1EDtoToDbModelService _sut = new();

    [Fact]
    public void Convert_MapsDtoToEntity()
    {
        var dto = CharacterMapperTestData.Create1EDto();

        var result = _sut.Convert(dto);

        Assert.Equal("Aron", result.Nev);
        Assert.Equal(Jellem.TorvenyesJo, result.Jellem);
        Assert.Equal(Faj1E.Ember, result.Faj);
        Assert.Equal(Osztaly1E.Harcos, result.Osztaly);
        Assert.Equal(3, result.KarakterKepzettsegek.Count());
        Assert.Equal(1, result.KarakterKepzettsegek.Count(x => x.IsTolvajKepzettseg));
        Assert.Equal(2, result.Felszereles.Count());
        Assert.All(result.Felszereles, x => Assert.True(x.IsFegyver));
        Assert.Equal(4, result.Szintlepesek.Count());
        Assert.Equal(10, result.Szintlepesek.Single(x => x.KarakterSzint == 1).HpRoll);
        Assert.Equal("ij", result.Szintlepesek.Single(x => x.KarakterSzint == 3).FegyverSpecializacio);
        Assert.Equal(Tulajdonsag.Ero, result.Szintlepesek.Single(x => x.KarakterSzint == 4).TulajdonsagNoveles);
    }

    [Fact]
    public void Convert_WithNotEnoughHpRolls_ThrowsValidationException()
    {
        var dto = CharacterMapperTestData.Create1EDto();
        dto.HpRolls = new List<byte> { 7 };

        Assert.Throws<ValidationException>(() => _sut.Convert(dto));
    }

    [Fact]
    public void Update_ReplacesMutableCollectionsAndScalarFields()
    {
        var dto = CharacterMapperTestData.Create1EDto();
        var original = new V1Karakter
        {
            Nev = "old",
            Jellem = Jellem.Semleges,
            Faj = Faj1E.Elf,
            Osztaly = Osztaly1E.Pap,
            KarakterKepzettsegek = new List<V1KarakterKepzettseg>
            {
                new() { Kepzettseg = Kepzettseg1E.Tudas, Karakter = null! }
            },
            Felszereles = new List<V1Felszereles>
            {
                new() { Name = "old_weapon", IsFegyver = true, Karakter = null! }
            },
            Szintlepesek = new List<V1Szintlepes>
            {
                new() { KarakterSzint = 1, HpRoll = 4, Karakter = null! }
            }
        };

        _sut.Update(original, dto);

        Assert.Equal("Aron", original.Nev);
        Assert.Equal(Jellem.TorvenyesJo, original.Jellem);
        Assert.Equal(Faj1E.Ember, original.Faj);
        Assert.Equal(Osztaly1E.Harcos, original.Osztaly);
        Assert.Equal(3, original.KarakterKepzettsegek.Count());
        Assert.DoesNotContain(original.Felszereles, x => x.Name == "old_weapon");
        Assert.Equal(4, original.Szintlepesek.Count());
    }
}

