using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<RulingSource>))]
public enum RulingSource
{
    [JsonPropertyName("wotc")]
    WizardsOfTheCoast,
    [JsonPropertyName("scryfall")]
    Scryfall
}