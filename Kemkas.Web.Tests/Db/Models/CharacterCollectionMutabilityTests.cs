using Kemkas.Web.Db.Enums;
using Kemkas.Web.Db.Models;

namespace Kemkas.Web.Tests.Db.Models;

public class CharacterCollectionMutabilityTests
{
    [Fact]
    public void V1Karakter_CollectionsAreMutableForEfMaterialization()
    {
        var karakter = new V1Karakter { Nev = "Aron" };

        Assert.False(karakter.KarakterKepzettsegek.GetType().IsArray);
        Assert.False(karakter.Szintlepesek.GetType().IsArray);
        Assert.False(karakter.Felszereles.GetType().IsArray);

        karakter.KarakterKepzettsegek.Add(new V1KarakterKepzettseg
        {
            Kepzettseg = Kepzettseg1E.Alkimia,
            Karakter = null!
        });
        karakter.Szintlepesek.Add(new V1Szintlepes
        {
            KarakterSzint = 1,
            HpRoll = 8,
            Karakter = null!
        });
        karakter.Felszereles.Add(new V1Felszereles
        {
            Name = "kard",
            Karakter = null!
        });

        Assert.Single(karakter.KarakterKepzettsegek);
        Assert.Single(karakter.Szintlepesek);
        Assert.Single(karakter.Felszereles);
    }

    [Fact]
    public void V2Karakter_CollectionsAreMutableForEfMaterialization()
    {
        var karakter = new V2Karakter { Nev = "Belia" };

        Assert.False(karakter.KarakterKepzettsegek.GetType().IsArray);
        Assert.False(karakter.Szintlepesek.GetType().IsArray);
        Assert.False(karakter.Felszereles.GetType().IsArray);
        Assert.False(karakter.Varazslatok.GetType().IsArray);

        karakter.KarakterKepzettsegek.Add(new V2KarakterKepzettseg
        {
            Kepzettseg = Kepzettseg2E.Alkimia,
            Karakter = null!
        });
        karakter.Szintlepesek.Add(new V2Szintlepes
        {
            KarakterSzint = 1,
            Osztaly = Osztaly2E.Harcos,
            HpRoll = 9,
            Karakter = null!
        });
        karakter.Felszereles.Add(new V2Felszereles
        {
            TargyId = "kard",
            Count = 1,
            Karakter = null!
        });
        karakter.Varazslatok.Add(new V2KarakterVarazslat
        {
            VarazslatId = "v_tuz",
            Osztaly = Osztaly2E.Varazslo,
            Karakter = null!
        });

        Assert.Single(karakter.KarakterKepzettsegek);
        Assert.Single(karakter.Szintlepesek);
        Assert.Single(karakter.Felszereles);
        Assert.Single(karakter.Varazslatok);
    }
}

