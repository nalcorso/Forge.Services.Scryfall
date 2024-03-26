using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<MigrationStrategy>))]
public enum MigrationStrategy
{
    [JsonPropertyName("merge")]
    Merge,
    [JsonPropertyName("delete")]
    Delete,
}