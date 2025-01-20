using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Vmac
{
    [JsonPropertyName("supported")]
    public bool Supported { get; set; }

    [JsonPropertyName("quota")]
    public int Quota { get; set; }
}