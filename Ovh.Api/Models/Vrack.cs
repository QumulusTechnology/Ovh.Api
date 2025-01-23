using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Vrack
{
    [JsonPropertyName("bandwidth")]
    public BandwidthDetail Bandwidth { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}