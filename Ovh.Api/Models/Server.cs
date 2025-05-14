using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Server
{
    [JsonPropertyName("reverse")]
    public required string Reverse { get; set; }

    [JsonPropertyName("powerState")]
    public required string PowerState { get; set; }

    [JsonPropertyName("rescueMail")]
    public required string RescueMail { get; set; }

    [JsonPropertyName("efiBootloaderPath")]
    public required string EfiBootloaderPath { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("serverId")]
    public required int ServerId { get; set; }

    [JsonPropertyName("professionalUse")]
    public required bool ProfessionalUse { get; set; }

    [JsonPropertyName("newUpgradeSystem")]
    public required bool NewUpgradeSystem { get; set; }

    [JsonPropertyName("linkSpeed")]
    public required int LinkSpeed { get; set; }

    [JsonPropertyName("os")]
    public required string Os { get; set; }

    [JsonPropertyName("rootDevice")]
    public required string RootDevice { get; set; }

    [JsonPropertyName("state")]
    public required string State { get; set; }

    [JsonPropertyName("ip")]
    public required string Ip { get; set; }

    [JsonPropertyName("noIntervention")]
    public bool NoIntervention { get; set; }

    [JsonPropertyName("rack")]
    public required string Rack { get; set; }

    [JsonPropertyName("bootId")]
    public int BootId { get; set; }

    [JsonPropertyName("availabilityZone")]
    public required string AvailabilityZone { get; set; }

    [JsonPropertyName("monitoring")]
    public bool Monitoring { get; set; }

    [JsonPropertyName("rescueSshKey")]
    public required string RescueSshKey { get; set; }

    [JsonPropertyName("datacenter")]
    public required string Datacenter { get; set; }

    [JsonPropertyName("commercialRange")]
    public required string CommercialRange { get; set; }

    [JsonPropertyName("bootScript")]
    public required string BootScript { get; set; }

    [JsonPropertyName("supportLevel")]
    public required string SupportLevel { get; set; }

    [JsonPropertyName("region")]
    public required string Region { get; set; }

    [JsonPropertyName("iam")]
    public IamDetails? Iam { get; set; }

    public List<(string Mac, string Mode)>? NetworkInterfaceControllers{ get; set; }

    public string? Gateway { get; set; }

    public string? Mac { get; set; }
}