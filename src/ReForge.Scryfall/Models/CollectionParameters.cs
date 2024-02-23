using System.Text.Json.Serialization;

namespace ReForge.Scryfall.APIs;

public class CollectionIdentifier
{
    [JsonPropertyName("id")] 
    public string? Id { get; set; }
    
    [JsonPropertyName("mtgo_id")]
    public string? MtgoId { get; set; }
    
    [JsonPropertyName("multiverse_id")]
    public string? MultiverseId { get; set; }
    
    [JsonPropertyName("oracle_id")]
    public string? OracleId { get; set; }
    
    [JsonPropertyName("illustration_id")]
    public string? IllustrationId { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("set")]
    public string? Set { get; set; }
    
    [JsonPropertyName("collector_number")]
    public string? CollectorNumber { get; set; }
}

public class CollectionParameters
{
    [JsonPropertyName("identifiers")] 
    public List<CollectionIdentifier> Identifiers { get; set; } = new();
}