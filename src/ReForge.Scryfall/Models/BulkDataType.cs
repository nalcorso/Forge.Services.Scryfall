using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<BulkDataType>))]
public enum BulkDataType
{
    [JsonPropertyName("oracle_cards")]
    OracleCards,
    [JsonPropertyName("unique_artwork")]
    UniqueArtwork,
    [JsonPropertyName("default_cards")]
    DefaultCards,
    [JsonPropertyName("all_cards")]
    AllCards,
    [JsonPropertyName("rulings")]
    Rulings
}

[JsonConverter(typeof(JsonStringEnumConverter<ContentEncoding>))]
public enum ContentEncoding
{
    [JsonPropertyName("gzip")]
    Gzip
}
