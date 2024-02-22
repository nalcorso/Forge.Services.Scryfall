using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

public class Ruling : ResponseObjectBase
{
    [JsonPropertyName("oracle_id")] 
    public Guid OracleId { get; set; }
    
    [JsonPropertyName("source")] 
    public RulingSource Source { get; set; }
    
    [JsonPropertyName("object")] 
    public ObjectType Object { get; set; }
    
    [JsonPropertyName("published_at")] 
    public DateTime PublishedAt { get; set; }
    
    [JsonPropertyName("comment")] 
    public required string Comment { get; set; }
}