using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class IamDetails
{
    [JsonPropertyName("displayName")]
    public required string DisplayName { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("urn")]
    public required string Urn { get; set; }
}