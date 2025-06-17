using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class LayoutExtrasLvmSpecific
{
    /// <summary>
    /// Logical volume name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}