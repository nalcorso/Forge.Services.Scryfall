using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<MigrationStrategy>))]
public enum MigrationStrategy
{
    [JsonPropertyName("merge")]
    Merge,
    [JsonPropertyName("delete")]
    Delete,
}