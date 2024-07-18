using System.Text.Json.Serialization;

namespace Kemkas.Web.ViewModels;

public class KarakterVarazslat2eDto
{
    [JsonPropertyName("id")]
    public string VarazslatId { get; set; }
    
    [JsonPropertyName("bekeszitve")]
    public bool Bekeszitve { get; set; }
}