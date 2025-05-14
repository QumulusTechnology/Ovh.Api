using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Switching
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
}