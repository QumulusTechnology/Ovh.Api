using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class ReinstallCustomizations
{
    [JsonPropertyName("configDriveUserData")]
    public string ConfigDriveUserData { get; set; } = string.Empty;

    [JsonPropertyName("efiBootloaderPath")]
    public required string EfiBootloaderPath { get; set; }

    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    [JsonPropertyName("httpHeaders")] 
    public Dictionary<string, string> HttpHeaders { get; set; } = [];

    [JsonPropertyName("imageCheckSum")] 
    public string ImageCheckSum { get; set; } = string.Empty;

    [JsonPropertyName("imageCheckSumType")]
    public CheckSumType ImageCheckSumType { get; set; }

    [JsonPropertyName("imageType")]
    public ImageType? ImageType { get; set; }

    [JsonPropertyName("imageURL")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("language")]
    public DisplayLanguage? Language { get; set; }

    [JsonPropertyName("postInstallationScript")]
    public string? PostInstallationScript { get; set; }

    [JsonPropertyName("postInstallationScriptExtension")]
    public ScriptExtension? PostInstallationScriptExtension { get; set; }

    [JsonPropertyName("sshKey")]
    public string? SshKey { get; set; }


}