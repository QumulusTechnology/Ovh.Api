using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Traffic
{
    [JsonPropertyName("resetQuotaDate")]
    public string ResetQuotaDate { get; set; }

    [JsonPropertyName("inputQuotaUsed")]
    public string InputQuotaUsed { get; set; }

    [JsonPropertyName("outputQuotaUsed")]
    public string OutputQuotaUsed { get; set; }

    [JsonPropertyName("isThrottled")]
    public bool IsThrottled { get; set; }

    [JsonPropertyName("outputQuotaSize")]
    public string OutputQuotaSize { get; set; }

    [JsonPropertyName("inputQuotaSize")]
    public string InputQuotaSize { get; set; }
}