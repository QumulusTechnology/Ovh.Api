using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public enum ImageType
{
    [JsonStringEnumMemberName("raw")] Raw = 1,
    [JsonStringEnumMemberName("qcow2")] Qcow2
}