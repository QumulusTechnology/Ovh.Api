using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Interface
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("aggregation")]
    public bool Aggregation { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}