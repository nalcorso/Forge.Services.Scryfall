using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Finish>))]
public enum Finish
{
    [JsonPropertyName("foil")]
    Foil,
    [JsonPropertyName("nonfoil")]
    NonFoil,
    [JsonPropertyName("etched")]
    Etched
}