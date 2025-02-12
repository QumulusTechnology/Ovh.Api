using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class Server
{
    [JsonPropertyName("reverse")]
    public string Reverse { get; set; }

    [JsonPropertyName("powerState")]
    public string PowerState { get; set; }

    [JsonPropertyName("rescueMail")]
    public string RescueMail { get; set; }

    [JsonPropertyName("efiBootloaderPath")]
    public string EfiBootloaderPath { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("serverId")]
    public int ServerId { get; set; }

    [JsonPropertyName("professionalUse")]
    public bool ProfessionalUse { get; set; }

    [JsonPropertyName("newUpgradeSystem")]
    public bool NewUpgradeSystem { get; set; }

    [JsonPropertyName("linkSpeed")]
    public int LinkSpeed { get; set; }

    [JsonPropertyName("os")]
    public string Os { get; set; }

    [JsonPropertyName("rootDevice")]
    public string RootDevice { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("ip")]
    public string Ip { get; set; }

    [JsonPropertyName("noIntervention")]
    public bool NoIntervention { get; set; }

    [JsonPropertyName("rack")]
    public string Rack { get; set; }

    [JsonPropertyName("bootId")]
    public int BootId { get; set; }

    [JsonPropertyName("availabilityZone")]
    public string AvailabilityZone { get; set; }

    [JsonPropertyName("monitoring")]
    public bool Monitoring { get; set; }

    [JsonPropertyName("rescueSshKey")]
    public string RescueSshKey { get; set; }

    [JsonPropertyName("datacenter")]
    public string Datacenter { get; set; }

    [JsonPropertyName("commercialRange")]
    public string CommercialRange { get; set; }

    [JsonPropertyName("bootScript")]
    public string BootScript { get; set; }

    [JsonPropertyName("supportLevel")]
    public string SupportLevel { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("iam")]
    public IamDetails? Iam { get; set; }

    public List<(string Mac, string Mode)>? NetworkInterfaceControllers{ get; set; }

    public string? Gateway { get; set; }

    public string? Mac { get; set; }
}