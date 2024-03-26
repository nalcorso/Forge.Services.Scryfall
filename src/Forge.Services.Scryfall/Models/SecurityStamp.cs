using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<SecurityStamp>))]
public enum SecurityStamp
{
    [JsonPropertyName("oval")]
    Oval,
    [JsonPropertyName("triangle")]
    Triangle,
    [JsonPropertyName("acorn")]
    Acorn,
    [JsonPropertyName("circle")]
    Circle,
    [JsonPropertyName("arena")]
    Arena,
    [JsonPropertyName("heart")]
    Heart
}