using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Vrack
{
    [JsonPropertyName("bandwidth")]
    public required BandwidthDetail Bandwidth { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }
}