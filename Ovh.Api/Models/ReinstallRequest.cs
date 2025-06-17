using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

/// <summary>
/// Represents the parameters for a server reinstall request.
/// </summary>
public class ReinstallRequest
{
    /// <summary>
    /// OS reinstallation customizations
    /// </summary>
    [JsonPropertyName("customizations")] 
    public ReinstallCustomizations? Customizations { get; set; }

    /// <summary>
    /// Operating System name to install (available values for this server can be retrieved using GET /dedicated/server/{serviceName}/install/compatibleTemplates)
    /// </summary>
    [JsonPropertyName("operatingSystem")]
    public required OperatingSystemTemplate OperatingSystemTemplate { get; set; }

    /// <summary>
    /// Arbitrary properties to pass to cloud-init's config drive datasource
    /// </summary>
    [JsonPropertyName("properties")] 
    public Dictionary<string, string> Properties { get; set; } = [];

    /// <summary>
    /// OS reinstallation storage configurations
    /// </summary>
    [JsonPropertyName("storage")]
    public List<ReinstallStorage> Storage { get; set; } = new ();
}