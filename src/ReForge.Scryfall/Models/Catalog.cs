using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

public class Catalog : ResponseObjectBase
{
    [JsonPropertyName("object")] 
    public ObjectType Object { get; set; }
    
    [JsonPropertyName("uri")] 
    public Uri? Uri { get; set; }
    
    [JsonPropertyName("total_values")] 
    public long TotalValues { get; set; }
    
    [JsonPropertyName("data")] 
    public required List<string> Data { get; set; }
}