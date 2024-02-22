using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<RulingSource>))]
public enum RulingSource
{
    [JsonPropertyName("wotc")]
    WizardsOfTheCoast,
    [JsonPropertyName("scryfall")]
    Scryfall
}