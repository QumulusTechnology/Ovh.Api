using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public enum TaskStatus
{
    [JsonStringEnumMemberName("cancelled")]
    Cancelled,
    [JsonStringEnumMemberName("customerError")]
    CustomerError,
    [JsonStringEnumMemberName("doing")]
    Doing,
    [JsonStringEnumMemberName("done")]
    Done,
    [JsonStringEnumMemberName("init")]
    Init,
    [JsonStringEnumMemberName("ovhError")]
    OvhError,
    [JsonStringEnumMemberName("todo")]
    Todo
}