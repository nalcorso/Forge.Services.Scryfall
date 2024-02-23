using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

public class MigrationMetadata
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("lang")] 
    public Language Lang { get; set; }
    
    [JsonPropertyName("name")] 
    public required string Name { get; set; }
    
    [JsonPropertyName("set_code")] 
    public required string SetCode { get; set; }
    
    [JsonPropertyName("oracle_id")] 
    public Guid OracleId { get; set; }
    
    [JsonPropertyName("collector_number")] 
    public required string CollectorNumber { get; set; }
}