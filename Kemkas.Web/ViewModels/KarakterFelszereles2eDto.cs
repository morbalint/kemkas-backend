using System.Text.Json.Serialization;

namespace Kemkas.Web.ViewModels;

public class KarakterFelszereles2eDto
{
    [JsonPropertyName("pancelID")]
    public string? PancelId { get; set; }
    
    [JsonPropertyName("pajzsID")]
    public string? PajzsId { get; set; }
    
    [JsonPropertyName("fegyverek")]
    public IList<FelszerelesIdAndCount> Fegyverek { get; set; } = new List<FelszerelesIdAndCount>();
    
    [JsonPropertyName("viselt")]
    public IList<FelszerelesIdAndCount> Viselt { get; set; } = new List<FelszerelesIdAndCount>();
    
    [JsonPropertyName("cipelt")]
    public IList<FelszerelesIdAndCount> Cipelt { get; set; } = new List<FelszerelesIdAndCount>();
    
    [JsonPropertyName("aprosagok")]
    public IList<FelszerelesIdAndCount> Aprosagok { get; set; } = new List<FelszerelesIdAndCount>();
    
    [JsonPropertyName("at")]
    public int AranyTaller { get; set; }

    [JsonPropertyName("el")]
    public int ElektrumTaller { get; set; }

    [JsonPropertyName("et")]
    public int EzustTaller { get; set; }
}