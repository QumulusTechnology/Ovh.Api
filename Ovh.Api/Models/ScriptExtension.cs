using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public enum ScriptExtension
{
    [JsonStringEnumMemberName("cmd")]
    Cmd=1,
    [JsonStringEnumMemberName("ps1")]
    Ps1
}