using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public enum CheckSumType
{
    [JsonStringEnumMemberName("md5")] Md5,
    [JsonStringEnumMemberName("sha1")] Sha1,
    [JsonStringEnumMemberName("sha256")] Sha256,
    [JsonStringEnumMemberName("sha512")] Sha512
}