using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class BandwidthDetail
{
    [JsonPropertyName("value")]
    public int Value { get; set; }

    [JsonPropertyName("unit")]
    public required string Unit { get; set; }
}