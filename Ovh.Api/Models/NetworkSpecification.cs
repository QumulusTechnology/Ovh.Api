using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class NetworkSpecification
{
    [JsonPropertyName("ola")]
    public required Ola Ola { get; set; }

    [JsonPropertyName("traffic")]
    public required Traffic Traffic { get; set; }

    [JsonPropertyName("switching")]
    public required Switching Switching { get; set; }

    [JsonPropertyName("routing")]
    public required Routing Routing { get; set; }

    [JsonPropertyName("connection")]
    public required Connection Connection { get; set; }

    [JsonPropertyName("vrack")]
    public required Vrack Vrack { get; set; }

    [JsonPropertyName("bandwidth")]
    public required Bandwidth Bandwidth { get; set; }

    [JsonPropertyName("vmac")]
    public required Vmac Vmac { get; set; }
}