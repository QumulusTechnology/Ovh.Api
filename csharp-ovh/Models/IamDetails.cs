using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class IamDetails
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("urn")]
    public string Urn { get; set; }
}