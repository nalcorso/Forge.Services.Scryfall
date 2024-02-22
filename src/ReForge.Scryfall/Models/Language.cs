using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Language>))]
public enum Language
{
    [JsonPropertyName("en")]
    English,
    [JsonPropertyName("es")]
    Spanish,
    [JsonPropertyName("fr")]
    French,
    [JsonPropertyName("de")]
    German,
    [JsonPropertyName("it")]
    Italian,
    [JsonPropertyName("pt")]
    Portuguese,
    [JsonPropertyName("ja")]
    Japanese,
    [JsonPropertyName("ko")]
    Korean,
    [JsonPropertyName("ru")]
    Russian,
    [JsonPropertyName("zhs")]
    SimplifiedChinese,
    [JsonPropertyName("zht")]
    TraditionalChinese,
    [JsonPropertyName("he")]
    Hebrew,
    [JsonPropertyName("la")]
    Latin,
    [JsonPropertyName("grc")]
    AncientGreek,
    [JsonPropertyName("ar")]
    Arabic,
    [JsonPropertyName("sa")]
    Sanskrit,
    [JsonPropertyName("phy")]
    Phyrexian
}