using System.Text.Json.Serialization;

namespace Kemkas.Web.ViewModels;

public class FelszerelesIdAndCount
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}