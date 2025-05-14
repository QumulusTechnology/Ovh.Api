using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Traffic
{
    [JsonPropertyName("resetQuotaDate")]
    public required string  ResetQuotaDate { get; set; }

    [JsonPropertyName("inputQuotaUsed")]
    public required string InputQuotaUsed { get; set; }

    [JsonPropertyName("outputQuotaUsed")]
    public required string OutputQuotaUsed { get; set; }

    [JsonPropertyName("isThrottled")]
    public bool IsThrottled { get; set; }

    [JsonPropertyName("outputQuotaSize")]
    public required string OutputQuotaSize { get; set; }

    [JsonPropertyName("inputQuotaSize")]
    public required string InputQuotaSize { get; set; }
}