using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

public class Preview
{
    [JsonPropertyName("previewed_at")] 
    public DateTime? PreviewedAt { get; set; }
    
    [JsonPropertyName("source_uri")] 
    public Uri? SourceUri { get; set; }
    
    [JsonPropertyName("source")] 
    public string? Source { get; set; }
}