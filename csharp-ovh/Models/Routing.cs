using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Routing
{
    [JsonPropertyName("ipv4")]
    public IpRoutingDetails Ipv4 { get; set; }

    [JsonPropertyName("ipv6")]
    public IpRoutingDetails Ipv6 { get; set; }
}