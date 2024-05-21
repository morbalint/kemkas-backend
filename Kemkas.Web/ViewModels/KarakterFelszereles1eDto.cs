using System.Text.Json.Serialization;

namespace Kemkas.Web.ViewModels;

public class KarakterFelszereles1eDto
{
    [JsonPropertyName("pancelID")]
    public string? PancelId { get; set; }
    
    [JsonPropertyName("pajzsID")]
    public string? PajzsId { get; set; }
    
    [JsonPropertyName("fegyverIDk")]
    public IList<string> FegyverIds { get; set; }
}