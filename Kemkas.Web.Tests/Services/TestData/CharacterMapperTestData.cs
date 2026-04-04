using Kemkas.Web.Db.Enums;
using Kemkas.Web.Db.Models;
using Kemkas.Web.ViewModels;

namespace Kemkas.Web.Tests.Services.TestData;

internal static class CharacterMapperTestData
{
    internal static Karakter1eDto Create1EDto() => new()
    {
        Name = "Aron",
        Nem = "fi",
        Kor = 22,
        Jellem = "TJ",
        Isten = "Darton",
        Faj = "f_ember",
        Osztaly = "o_harcos",
        Tulajdonsagok = new KarakterTulajdonsagokDto
        {
            Ero = 16,
            Ugy = 14,
            Egs = 13,
            Int = 12,
            Bol = 11,
            Kar = 10
        },
        Kepzettsegek = new List<string> { "k_alkimia", "k_hajozas" },
        Tolvajkepzettsegek = new List<string> { "k_osonas" },
        Szint = 4,
        HpRolls = new List<byte> { 7, 6, 5 },
        TulajdonsagNovelesek = new List<string> { "t_ero" },
        HarcosSpecializaciok = new List<string> { "hosszukard", "ij" },
        KalozKritikus = new List<string>(),
        Felszereles1E = new KarakterFelszereles1eDto
        {
            PancelId = "lancruha",
            PajzsId = "fa_pajzs",
            FegyverIds = new List<string> { "hosszukard", "tor" }
        },
        IsPublic = true
    };

    internal static Karakter2eDto Create2EDto() => new()
    {
        Nev = "Belia",
        Nem = "no",
        Kor = 25,
        Jellem = "TS",
        Isten = "Krad",
        Faj = "f_2e_ember",
        Tulajdonsagok = new KarakterTulajdonsagokDto
        {
            Ero = 11,
            Ugy = 12,
            Egs = 13,
            Int = 14,
            Bol = 15,
            Kar = 16
        },
        Kepzettsegek = new List<string> { "k_alkimia", "k_hamisitas" },
        Tolvajkepzettsegek = new List<string> { "k_osonas" },
        Szint = 2,
        Szintlepesek = new List<Szintlepes>
        {
            new()
            {
                Osztaly = "o_2e_harcos",
                HProll = 10,
                HarcosFegyver = "kard",
                KalozKritikus = null,
                TulajdonsagNoveles = null,
                TolvajExtraKepzettseg = null
            },
            new()
            {
                Osztaly = "o_2e_tengeresz",
                HProll = 6,
                HarcosFegyver = null,
                KalozKritikus = "szuras",
                TulajdonsagNoveles = "t_kar",
                TolvajExtraKepzettseg = "k_zarnyitas"
            }
        },
        Felszereles = new KarakterFelszereles2eDto
        {
            PancelId = "bor",
            PajzsId = "kis_pajzs",
            AranyTaller = 10,
            ElektrumTaller = 20,
            EzustTaller = 30,
            Fegyverek = new List<FelszerelesIdAndCount> { new() { Id = "kard", Count = 1 } },
            Viselt = new List<FelszerelesIdAndCount> { new() { Id = "sisak", Count = 1 } },
            Cipelt = new List<FelszerelesIdAndCount> { new() { Id = "kotel", Count = 2 } },
            Aprosagok = new List<FelszerelesIdAndCount> { new() { Id = "gyertya", Count = 5 } }
        },
        Varazslatok = new List<KarakterVarazslat2eDto>
        {
            new() { VarazslatId = "v_tuz", Bekeszitve = true, Osztaly = "o_2e_varazslo" }
        },
        IsPublic = false
    };

    internal static V1Karakter Create1EEntity() => new()
    {
        Nev = "Aron",
        Nem = "fi",
        Kor = 22,
        Jellem = Jellem.TorvenyesJo,
        Isten = "Darton",
        Faj = Faj1E.Ember,
        Osztaly = Osztaly1E.Harcos,
        Ero = 16,
        Ugyesseg = 14,
        Egeszseg = 13,
        Intelligencia = 12,
        Bolcsesseg = 11,
        Karizma = 10,
        Szint = 3,
        Pajzs = "fa_pajzs",
        Pancel = "lancruha",
        IsPublic = true,
        KarakterKepzettsegek = new List<V1KarakterKepzettseg>
        {
            new() { Kepzettseg = Kepzettseg1E.Alkimia, IsTolvajKepzettseg = false, Karakter = null! },
            new() { Kepzettseg = Kepzettseg1E.Osonas, IsTolvajKepzettseg = true, Karakter = null! }
        },
        Felszereles = new List<V1Felszereles>
        {
            new() { Name = "kard", IsFegyver = true, Karakter = null! },
            new() { Name = "kotel", IsFegyver = false, Karakter = null! }
        },
        Szintlepesek = new List<V1Szintlepes>
        {
            new() { KarakterSzint = 3, HpRoll = 5, FegyverSpecializacio = "ij", Karakter = null! },
            new() { KarakterSzint = 1, HpRoll = 10, FegyverSpecializacio = "kard", Karakter = null! },
            new() { KarakterSzint = 2, HpRoll = 7, TulajdonsagNoveles = Tulajdonsag.Ero, Karakter = null! }
        }
    };

    internal static V2Karakter Create2EEntity() => new()
    {
        Nev = "Belia",
        Nem = "no",
        Kor = 25,
        Jellem = Jellem.Torvenyes,
        Isten = "Krad",
        Faj = Faj2E.Ember,
        Ero = 11,
        Ugyesseg = 12,
        Egeszseg = 13,
        Intelligencia = 14,
        Bolcsesseg = 15,
        Karizma = 16,
        Szint = 2,
        Pajzs = "kis_pajzs",
        Pancel = "bor",
        AranyTaller = 10,
        ElektrumTaller = 20,
        EzustTaller = 30,
        IsPublic = false,
        KarakterKepzettsegek = new List<V2KarakterKepzettseg>
        {
            new() { Kepzettseg = Kepzettseg2E.Alkimia, IsTolvajKepzettseg = false, Karakter = null! },
            new() { Kepzettseg = Kepzettseg2E.Osonas, IsTolvajKepzettseg = true, Karakter = null! }
        },
        Felszereles = new List<V2Felszereles>
        {
            new() { TargyId = "kard", Count = 1, IsFegyver = true, Karakter = null! },
            new() { TargyId = "sisak", Count = 1, IsViselt = true, Karakter = null! },
            new() { TargyId = "kotel", Count = 2, IsCipelt = true, Karakter = null! },
            new() { TargyId = "gyertya", Count = 5, IsAprosag = true, Karakter = null! }
        },
        Szintlepesek = new List<V2Szintlepes>
        {
            new() { KarakterSzint = 2, Osztaly = Osztaly2E.Tengeresz, HpRoll = 6, FegyverSpecializacio = "szuras", TulajdonsagNoveles = Tulajdonsag.Karizma, TolvajExtraKepzettseg = Kepzettseg2E.Zarnyitas, Karakter = null! },
            new() { KarakterSzint = 1, Osztaly = Osztaly2E.Harcos, HpRoll = 10, FegyverSpecializacio = "kard", Karakter = null! }
        },
        Varazslatok = new HashSet<V2KarakterVarazslat>
        {
            new() { VarazslatId = "v_tuz", Bekeszitve = true, Osztaly = Osztaly2E.Varazslo, Karakter = null! }
        }
    };
}

