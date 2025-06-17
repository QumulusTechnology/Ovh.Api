using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Partitioning
{
    /// <summary>
    /// Total number of disks in the disk group involved in the partitioning configuration (all disks of the disk group by default)
    /// </summary>
    [JsonPropertyName("disks")]
    public int? Disks { get; set; }

    /// <summary>
    /// Custom partitioning layout (default is the default layout of the operating system's default partitioning scheme)
    /// </summary>
    [JsonPropertyName("layout")]
    public Layout[]? Layout { get; set; }

    /// <summary>
    /// Partitioning scheme (if applicable with selected operating system)
    /// </summary>
    [JsonPropertyName("schemeName")]
    public string? SchemeName { get; set; }
}