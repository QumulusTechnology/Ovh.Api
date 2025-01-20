using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Ola
{
    [JsonPropertyName("availableModes")]
    public List<AvailableMode> AvailableModes { get; set; }

    [JsonPropertyName("supportedModes")]
    public List<string> SupportedModes { get; set; }

    [JsonPropertyName("available")]
    public bool Available { get; set; }
}