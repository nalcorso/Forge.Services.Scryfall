using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

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
    Set
}