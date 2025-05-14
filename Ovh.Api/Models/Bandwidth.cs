using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Bandwidth
{
    [JsonPropertyName("OvhToInternet")]
    public required BandwidthDetail OvhToInternet { get; set; }

    [JsonPropertyName("InternetToOvh")]
    public required BandwidthDetail InternetToOvh { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("OvhToOvh")]
    public required BandwidthDetail OvhToOvh { get; set; }
}