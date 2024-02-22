using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

public class CardMigration : ResponseObjectBase
{
    [JsonPropertyName("uri")] 
    public required Uri Uri { get; set; }
    
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("performed_at")]
    public DateTime PerformedAt { get; set; }
    
    [JsonPropertyName("migration_strategy")]
    public MigrationStrategy MigrationStrategy { get; set; }
    
    [JsonPropertyName("old_scryfall_id")]
    public Guid OldScryfallId { get; set; }
    
    [JsonPropertyName("new_scryfall_id")]
    public Guid? NewScryfallId { get; set; }
    
    [JsonPropertyName("note")] 
    public required string Note { get; set; }
    
    [JsonPropertyName("metadata")] 
    public required List<string> MetaData { get; set; }
}