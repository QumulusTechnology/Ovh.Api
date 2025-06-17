using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Layout
{
    /// <summary>
    /// Partition extras parameters
    /// </summary>
    [JsonPropertyName("extras")]
    public LayoutExtras? Extras { get; set; }

    /// <summary>
    /// File system type
    /// </summary>
    [JsonPropertyName("fileSystem")]
    public required FileSystem FileSystem { get; set; }

    /// <summary>
    /// Mount point
    /// </summary>
    [JsonPropertyName("mountPoint")]
    public required string MountPoint { get; set; }

    /// <summary>
    /// Software raid type(default is 1)
    /// </summary>
    [JsonPropertyName("raidLevel")]
    public SoftwareRaidLevel? RaidLevel { get; set; }

    /// <summary>
    /// Partition size in MiB (default value is 0 which means to fill the disk with that partition)
    /// </summary>
    [JsonPropertyName("size")]
    public int? Size { get; set; }
}