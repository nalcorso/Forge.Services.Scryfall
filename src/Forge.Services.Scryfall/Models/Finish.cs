using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

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