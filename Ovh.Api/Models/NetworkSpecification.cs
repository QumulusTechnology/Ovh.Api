using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class NetworkSpecification
{
    [JsonPropertyName("ola")]
    public Ola Ola { get; set; }

    [JsonPropertyName("traffic")]
    public Traffic Traffic { get; set; }

    [JsonPropertyName("switching")]
    public Switching Switching { get; set; }

    [JsonPropertyName("routing")]
    public Routing Routing { get; set; }

    [JsonPropertyName("connection")]
    public Connection Connection { get; set; }

    [JsonPropertyName("vrack")]
    public Vrack Vrack { get; set; }

    [JsonPropertyName("bandwidth")]
    public Bandwidth Bandwidth { get; set; }

    [JsonPropertyName("vmac")]
    public Vmac Vmac { get; set; }
}