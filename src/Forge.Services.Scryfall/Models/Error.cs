using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

public class Error : ResponseObjectBase
{
    [JsonPropertyName("status")] 
    public long Status { get; set; }
    
    [JsonPropertyName("code")] 
    public required string Code { get; set; }
    
    [JsonPropertyName("details")] 
    public required string Details { get; set; }
    
    [JsonPropertyName("object")] 
    public ObjectType Object { get; set; }
    
    [JsonPropertyName("type")] 
    public string? Type { get; set; }
    
    [JsonPropertyName("warnings")]
    public List<string>? Warnings { get; set; }
}