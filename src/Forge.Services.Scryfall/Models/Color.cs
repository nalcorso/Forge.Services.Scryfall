using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Color>))]
public enum Color
{
    [JsonPropertyName("W")]
    White,
    [JsonPropertyName("U")]
    Blue,
    [JsonPropertyName("B")]
    Black,
    [JsonPropertyName("R")]
    Red,
    [JsonPropertyName("G")]
    Green,
    [JsonPropertyName("C")]
    Colorless
}