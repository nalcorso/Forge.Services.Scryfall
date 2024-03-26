using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

public class RelatedCardObject
{
    [JsonPropertyName("id")] 
    public Guid? Id { get; set; }
    
    [JsonPropertyName("object")] 
    public string? Object { get; set; }
    
    [JsonPropertyName("component")] 
    public string? Component { get; set; }

    [JsonPropertyName("name")] 
    public string? Name { get; set; }

    [JsonPropertyName("type_line")] 
    public string? TypeLine { get; set; }

    [JsonPropertyName("uri")] 
    public Uri? Uri { get; set; }
}