using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class HardwareRaid
{
    /// <summary>
    /// Number of arrays (default is 1)
    /// </summary>
    [JsonPropertyName("arrays")]
    public int? Arrays { get; set; }

    /// <summary>
    /// Total number of disks in the disk group involved in the hardware raid configuration (all disks of the disk group by default)
    /// </summary>
    [JsonPropertyName("disks")]
    public int? Disks { get; set; }

    /// <summary>
    /// Hardware raid type (default is 1)
    /// </summary>
    [JsonPropertyName("raidLevel")]
    public HardwareRaidLevel? RaidLevel { get; set; }

    /// <summary>
    /// Number of disks in the disk group involved in the spare (default is 0)
    /// </summary>
    [JsonPropertyName("spares")]
    public string? Spares { get; set; }
}