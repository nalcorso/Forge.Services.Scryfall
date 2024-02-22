using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Legality>))]
public enum Legality
{
    [JsonPropertyName("legal")]
    Legal,
    [JsonPropertyName("not_legal")]
    NotLegal,
    [JsonPropertyName("restricted")]
    Restricted,
    [JsonPropertyName("banned")]
    Banned
}