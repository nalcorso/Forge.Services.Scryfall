using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Games>))]
public enum Games
{
    [JsonPropertyName("paper")]
    Paper,
    [JsonPropertyName("arena")]
    Arena,
    [JsonPropertyName("mtgo")]
    Mtgo
}