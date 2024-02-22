using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

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