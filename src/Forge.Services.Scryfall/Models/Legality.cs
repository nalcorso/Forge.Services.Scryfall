using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

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