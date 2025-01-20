using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Connection
{
    [JsonPropertyName("value")]
    public int Value { get; set; }

    [JsonPropertyName("unit")]
    public string Unit { get; set; }
}