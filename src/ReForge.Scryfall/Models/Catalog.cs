using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

public class Catalog : ResponseObjectBase
{
    [JsonPropertyName("uri")] 
    public required Uri Uri { get; set; }
    
    [JsonPropertyName("total_values")] 
    public long TotalValues { get; set; }
    
    [JsonPropertyName("data")] 
    public required List<string> Data { get; set; }
}