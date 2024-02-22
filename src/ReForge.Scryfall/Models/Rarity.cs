using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Rarity>))]
public enum Rarity
{
    [JsonPropertyName("common")]
    Common,
    [JsonPropertyName("uncommon")]
    Uncommon,
    [JsonPropertyName("rare")]
    Rare,
    [JsonPropertyName("special")]
    Special,
    [JsonPropertyName("mythic")]
    Mythic,
    [JsonPropertyName("bonus")]
    Bonus
}