using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Kemkas.Web.ViewModels;

public class Karakter1eDto
{
    [Required]
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    
    [JsonPropertyName("nem")]
    public string? Nem { get; set; }
    
    [JsonPropertyName("kor")]
    public double? Kor { get; set; }
    
    [JsonPropertyName("jellem")]
    public required string Jellem { get; set; }
    
    [JsonPropertyName("isten")]
    public string? Isten { get; set; }
    
    [JsonPropertyName("faj")]
    public required string Faj { get; set; }
    
    [JsonPropertyName("osztaly")]
    public required string Osztaly { get; set; }
    
    [JsonPropertyName("tulajdonsagok")]
    public required KarakterTulajdonsagokDto Tulajdonsagok { get; set; }
    
    [JsonPropertyName("kepzettsegek")]
    public IList<string> Kepzettsegek { get; set; } = [];
    
    [JsonPropertyName("tolvajkepzettsegek")]
    public IList<string>? Tolvajkepzettsegek { get; set; } 
    
    [JsonPropertyName("szint")]
    public byte Szint { get; set; }
    
    [JsonPropertyName("hpRolls")]
    public IList<byte> HpRolls { get; set; } = new List<byte>();
    
    [JsonPropertyName("tulajdonsagNovelesek")]
    public IList<string> TulajdonsagNovelesek { get; set; } = new List<string>();
    
    [JsonPropertyName("harcosSpecializaciok")]
    public IList<string> HarcosSpecializaciok { get; set; } = new List<string>();
    
    [JsonPropertyName("kalozKritikus")]
    public IList<string> KalozKritikus { get; set; } = new List<string>();
    
    [JsonPropertyName("felszereles")]
    public required KarakterFelszereles1eDto Felszereles1E { get; set; }

    public bool? IsPublic { get; set; }
}