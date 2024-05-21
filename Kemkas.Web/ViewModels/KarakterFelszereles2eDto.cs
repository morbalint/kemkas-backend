using System.Text.Json.Serialization;

namespace Kemkas.Web.ViewModels;

public class KarakterFelszereles2eDto
{
    [JsonPropertyName("pancelID")]
    public string? PancelId { get; set; }
    
    [JsonPropertyName("pajzsID")]
    public string? PajzsId { get; set; }
    
    [JsonPropertyName("fegyverek")]
    public IList<FelszerelesIdAndCount> Fegyverek { get; set; }
    
    [JsonPropertyName("viselt")]
    public IList<FelszerelesIdAndCount> Viselt { get; set; }
    
    [JsonPropertyName("cipelt")]
    public IList<FelszerelesIdAndCount> Cipelt { get; set; }
    
    [JsonPropertyName("aprosagok")]
    public IList<FelszerelesIdAndCount> Aprosagok { get; set; }
}