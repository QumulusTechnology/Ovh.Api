using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class AvailableMode
{
    [JsonPropertyName("interfaces")]
    public List<Interface> Interfaces { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("default")]
    public bool Default { get; set; }
}