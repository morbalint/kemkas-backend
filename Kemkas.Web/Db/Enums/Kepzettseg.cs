namespace Kemkas.Web.Db.Enums;

public enum Kepzettseg1E
{
    Alkimia = 1,
    Alcazas = 2,
    Allatidomitas = 3,
    Csapdak = 4,
    Csillagjoslas = 5,
    Egyensulyozas = 6,
    Eloadas = 7,
    Ertekbecsles = 8,
    Gyogyitas = 9,
    Hajozas = 10,
    Hallgatozas = 11,
    Hamisitas = 12,
    JelekOlvasasa = 13,
    Koncentracio = 14,
    Lovaglas = 15,
    Maszas = 16,
    Megfigyeles = 17,
    Meregkeveres = 18,
    Mesterseg = 19,
    Nyomkereses = 20,
    Osonas = 21,
    Rejtozes = 22,
    Szabadulomuveszet = 23,
    Tudas = 24,
    Ugras = 25,
    Uszas = 26,
    Varazslatismeret = 27,
    Zarnyitas = 28,
    Zsebmetszes = 29,
}

// offset by 200 to make it more different from 1e karakter kepzettsegek
// I don't plan to mix them, but let's make it obvious which one is which.
// But it could be useful in one-time character conversions in the future.
public enum Kepzettseg2E
{
    Alkimia = 201,
    Alcazas = 202,
    Allatidomitas = 203,
    Csapdak = 204,
    Csillagjoslas = 205,
    Egyensulyozas = 206,
    Eloadas = 207,
    Ertekbecsles = 208,
    Gyogyitas = 209,
    Hajozas = 210,
    Hallgatozas = 211,
    Hamisitas = 212,
    JelekOlvasasa = 213,
    Herbalizmus = 601,
    Historia = 602,
    Lovaglas = 215,
    Maszas = 216,
    Megfigyeles = 217,
    Meregkeveres = 218,
    Mesterseg = 219,
    Nyomkereses = 220,
    Okkultizmus = 666, // inside joke
    Osonas = 221,
    Szabadulomuveszet = 223,
    Ugras = 225,
    Uszas = 226,
    Vadonjaras = 603,
    Zarnyitas = 228,
    Zsebmetszes = 229,
}