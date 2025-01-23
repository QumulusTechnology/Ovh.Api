using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class IpRoutingDetails
{
    [JsonPropertyName("network")]
    public string Network { get; set; }

    [JsonPropertyName("gateway")]
    public string Gateway { get; set; }

    [JsonPropertyName("ip")]
    public string Ip { get; set; }
}