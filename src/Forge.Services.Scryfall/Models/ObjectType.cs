using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<ObjectType>))]
public enum ObjectType
{
    [JsonPropertyName("card")]
    Card,
    [JsonPropertyName("error")]
    Error,
    [JsonPropertyName("list")]
    List,
    [JsonPropertyName("ruling")]
    Ruling,
    [JsonPropertyName("set")]
    Set,
    [JsonPropertyName("catalog")]
    Catalog,
    [JsonPropertyName("mana_cost")]
    ManaCost,
}