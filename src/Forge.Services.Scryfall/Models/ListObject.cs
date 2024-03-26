using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

public class ListObject<T> : ResponseObjectBase
{
    [JsonPropertyName("data")] 
    public required List<T> Data { get; set; }
    
    [JsonPropertyName("has_more")] 
    public bool HasMore { get; set; }
    
    [JsonPropertyName("next_page")] 
    public Uri? NextPage { get; set; }
    
    [JsonPropertyName("object")] 
    public ObjectType Object { get; set; }
    
    [JsonPropertyName("total_cards")] 
    public long? TotalCards { get; set; }
    
    [JsonPropertyName("warnings")]
    public List<string>? Warnings { get; set; }
}