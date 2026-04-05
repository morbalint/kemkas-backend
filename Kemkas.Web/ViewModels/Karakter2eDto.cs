using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Kemkas.Web.ViewModels;

public class Karakter2eDto
{
    [Required]
    [JsonPropertyName("nev")]
    public required string Nev { get; set; }
    
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
    
    [JsonPropertyName("tulajdonsagok")]
    public required KarakterTulajdonsagokDto Tulajdonsagok { get; set; }
    
    [JsonPropertyName("kepzettsegek")]
    public IList<string> Kepzettsegek { get; set; } = [];
    
    [JsonPropertyName("tolvajkepzettsegek")]
    public IList<string>? Tolvajkepzettsegek { get; set; } 
    
    [JsonPropertyName("szint")]
    public byte Szint { get; set; }
 
    [JsonPropertyName("szintlepesek")]
    public IList<Szintlepes> Szintlepesek { get; set; } = [];
    
    [JsonPropertyName("felszereles")]
    public required KarakterFelszereles2eDto Felszereles { get; set; }
    
    [JsonPropertyName("varazslatok")]
    public IList<KarakterVarazslat2eDto>? Varazslatok { get; set; }

    public bool? IsPublic { get; set; }
}