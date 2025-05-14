using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Routing
{
    [JsonPropertyName("ipv4")]
    public required IpRoutingDetails Ipv4 { get; set; }

    [JsonPropertyName("ipv6")]
    public required IpRoutingDetails Ipv6 { get; set; }
}