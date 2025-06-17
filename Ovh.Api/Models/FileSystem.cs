using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

/// <summary>
/// Represents supported file system types.
/// </summary>
public enum FileSystem
{
    /// <summary>
    /// Btrfs file system
    /// </summary>
    [JsonStringEnumMemberName("btrfs")]
    Btrfs,

    /// <summary>
    /// Ext3 file system
    /// </summary>
    [JsonStringEnumMemberName("ext3")]
    Ext3,

    /// <summary>
    /// Ext4 file system
    /// </summary>
    [JsonStringEnumMemberName("ext4")]
    Ext4,

    /// <summary>
    /// FAT16 file system
    /// </summary>
    [JsonStringEnumMemberName("fat16")]
    Fat16,

    /// <summary>
    /// No file system
    /// </summary>
    [JsonStringEnumMemberName("none")]
    None,

    /// <summary>
    /// NTFS file system
    /// </summary>
    [JsonStringEnumMemberName("ntfs")]
    Ntfs,

    /// <summary>
    /// ReiserFS file system
    /// </summary>
    [JsonStringEnumMemberName("reiserfs")]
    Reiserfs,

    /// <summary>
    /// Swap file system
    /// </summary>
    [JsonStringEnumMemberName("swap")]
    Swap,

    /// <summary>
    /// UFS file system
    /// </summary>
    [JsonStringEnumMemberName("ufs")]
    Ufs,

    /// <summary>
    /// VMFS5 file system
    /// </summary>
    [JsonStringEnumMemberName("vmfs5")]
    Vmfs5,

    /// <summary>
    /// VMFS6 file system
    /// </summary>
    [JsonStringEnumMemberName("vmfs6")]
    Vmfs6,

    /// <summary>
    /// VMFSL file system
    /// </summary>
    [JsonStringEnumMemberName("vmfsl")]
    Vmfsl,

    /// <summary>
    /// XFS file system
    /// </summary>
    [JsonStringEnumMemberName("xfs")]
    Xfs,

    /// <summary>
    /// ZFS file system
    /// </summary>
    [JsonStringEnumMemberName("zfs")]
    Zfs
}