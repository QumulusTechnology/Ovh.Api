using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class LayoutExtras
{
    /// <summary>
    /// LVM-specific parameters
    /// </summary>
    [JsonPropertyName("lv")]
    public LayoutExtrasLvmSpecific? Lv { get; set; }
    /// <summary>
    /// ZFS-specific parameters
    /// </summary>
    [JsonPropertyName("zp")]
    public LayoutExtrasZfsSpecific? Zp { get; set; }
}