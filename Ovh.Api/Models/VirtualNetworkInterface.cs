using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class VirtualNetworkInterface
{
    [JsonPropertyName("vrack")]
    public required string Vrack { get; set; }

    [JsonPropertyName("mode")]
    public required string Mode { get; set; }

    [JsonPropertyName("serverName")]
    public required string ServerName { get; set; }

    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    [JsonPropertyName("uuid")]
    public required string Uuid { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("networkInterfaceController")]
    public required List<string> NetworkInterfaceController { get; set; }
}