using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Bandwidth
{
    [JsonPropertyName("OvhToInternet")]
    public BandwidthDetail OvhToInternet { get; set; }

    [JsonPropertyName("InternetToOvh")]
    public BandwidthDetail InternetToOvh { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("OvhToOvh")]
    public BandwidthDetail OvhToOvh { get; set; }
}