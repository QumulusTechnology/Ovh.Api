using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class TaskTag
{
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("value")]
    public required string Value { get; set; }
}