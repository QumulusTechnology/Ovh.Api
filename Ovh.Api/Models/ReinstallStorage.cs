using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class ReinstallStorage
{
    /// <summary>
    /// Disk group id (default is 0, meaning automatic)
    /// </summary>
    [JsonPropertyName("diskGroupId")]
    public int? DiskGroupId { get; set; }

    /// <summary>
    /// Hardware Raid configurations (if not specified, all disks of the chosen disk group id will be configured in JBOD mode)
    /// </summary>
    [JsonPropertyName("hardwareRaid")]
    public HardwareRaid[]? HardwareRaid { get; set; }

    /// <summary>
    /// Partitioning configuration
    /// </summary>
    [JsonPropertyName("partitioning")] 
    public Partitioning? Partitioning { get; set; }
}