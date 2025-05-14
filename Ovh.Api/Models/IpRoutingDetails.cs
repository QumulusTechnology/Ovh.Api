using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class IpRoutingDetails
{
    [JsonPropertyName("network")]
    public required string Network { get; set; }

    [JsonPropertyName("gateway")]
    public required string Gateway { get; set; }

    [JsonPropertyName("ip")]
    public required string Ip { get; set; }
}