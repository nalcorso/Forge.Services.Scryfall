using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<BorderColor>))]
public enum BorderColor
{
    [JsonPropertyName("black")]
    Black,
    [JsonPropertyName("borderless")]
    Borderless,
    [JsonPropertyName("gold")]
    Gold,
    [JsonPropertyName("silver")]
    Silver,
    [JsonPropertyName("white")]
    White
}