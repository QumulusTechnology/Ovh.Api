using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public enum DisplayLanguage
{
    [JsonStringEnumMemberName("cs-cz")]
    CsCz = 1,
    [JsonStringEnumMemberName("de-de")]
    DeDe,
    [JsonStringEnumMemberName("en-us")]
    EnUs,
    [JsonStringEnumMemberName("es-es")]
    EsEs,
    [JsonStringEnumMemberName("fr-fr")]
    FrFr,
    [JsonStringEnumMemberName("it-it")]
    ItIt,
    [JsonStringEnumMemberName("nl-nl")]
    NlNl,
    [JsonStringEnumMemberName("pl-pl")]
    PlPl,
    [JsonStringEnumMemberName("pt-pt")]
    PtPt
}