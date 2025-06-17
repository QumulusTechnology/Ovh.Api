using System.Text.Json.Serialization;

namespace Ovh.Api.Models
{
    /// <summary>
    /// Represents available operating system templates.
    /// </summary>
    public enum OperatingSystemTemplate
    {
        [JsonStringEnumMemberName("alma8-cpanel-latest_64")]
        Alma8CpanelLatest64,

        [JsonStringEnumMemberName("alma8-plesk18_64")]
        // ReSharper disable InconsistentNaming
        Alma8Plesk18_64,

        [JsonStringEnumMemberName("alma8_64")]
        Alma8_64,

        [JsonStringEnumMemberName("alma9-cpanel-latest_64")]
        Alma9CpanelLatest64,

        [JsonStringEnumMemberName("alma9-plesk18_64")]
        Alma9Plesk18_64,

        [JsonStringEnumMemberName("alma9_64")]
        Alma9_64,

        [JsonStringEnumMemberName("byoi_64")]
        ByoImage64,

        [JsonStringEnumMemberName("byolinux_64")]
        ByoLinux64,

        [JsonStringEnumMemberName("debian11_64")]
        Debian11_64,

        [JsonStringEnumMemberName("debian12-plesk18_64")]
        Debian12Plesk18_64,

        [JsonStringEnumMemberName("debian12_64")]
        Debian12_64,

        [JsonStringEnumMemberName("fedora41_64")]
        Fedora41_64,

        [JsonStringEnumMemberName("fedora42_64")]
        Fedora42_64,

        [JsonStringEnumMemberName("proxmox-bs2_64")]
        ProxmoxBs2_64,

        [JsonStringEnumMemberName("proxmox-bs3_64")]
        ProxmoxBs3_64,

        [JsonStringEnumMemberName("proxmox7_64")]
        Proxmox7_64,

        [JsonStringEnumMemberName("proxmox8_64")]
        Proxmox8_64,

        [JsonStringEnumMemberName("rocky8_64")]
        Rocky8_64,

        [JsonStringEnumMemberName("rocky9_64")]
        Rocky9_64,
        // ReSharper restore InconsistentNaming

        [JsonStringEnumMemberName("ubuntu2204-server_64")]
        Ubuntu2204Server64,

        [JsonStringEnumMemberName("ubuntu2404-server_64")]
        Ubuntu2404Server64,

        [JsonStringEnumMemberName("ubuntu2410-server_64")]
        Ubuntu2410Server64,

        [JsonStringEnumMemberName("ubuntu2504-server_64")]
        Ubuntu2504Server64,

        [JsonStringEnumMemberName("win2016-hyperv_64")]
        Win2016HyperV64,

        [JsonStringEnumMemberName("win2019-hyperv_64")]
        Win2019HyperV64
    }
}
