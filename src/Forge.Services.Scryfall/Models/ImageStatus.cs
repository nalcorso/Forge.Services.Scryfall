using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<ImageStatus>))]
public enum ImageStatus
{
    [JsonPropertyName("missing")]
    Missing,
    [JsonPropertyName("placeholder")]
    Placeholder,
    [JsonPropertyName("lowres")]
    LowRes,
    [JsonPropertyName("highres_scan")]
    HighRes
}