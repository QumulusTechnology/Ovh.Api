using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class VirtualNetworkInterface
{
    [JsonPropertyName("vrack")]
    public string Vrack { get; set; }

    [JsonPropertyName("mode")]
    public string Mode { get; set; }

    [JsonPropertyName("serverName")]
    public string ServerName { get; set; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("networkInterfaceController")]
    public List<string> NetworkInterfaceController { get; set; }
}