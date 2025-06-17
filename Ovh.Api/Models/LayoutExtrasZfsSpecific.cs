using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class LayoutExtrasZfsSpecific
{
    /// <summary>
    /// zpool name(generated automatically if not specified, note that multiple ZFS partitions with same zpool names will be configured as multiple datasets belonging to the same zpool if compatible)
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}