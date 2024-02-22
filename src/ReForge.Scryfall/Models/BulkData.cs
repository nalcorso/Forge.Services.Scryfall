using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

public class BulkData : ResponseObjectBase
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("uri")]
    public required Uri Uri { get; set; }
    
    [JsonPropertyName("type")] 
    public required string Type { get; set; }
    
    [JsonPropertyName("name")] 
    public required string Name { get; set; }
    
    [JsonPropertyName("description")] 
    public required string Description { get; set; }
    
    [JsonPropertyName("download_uri")] 
    public required Uri DownloadUri { get; set; }
    
    [JsonPropertyName("updated_at")] 
    public DateTime UpdatedAt { get; set; }
    
    [JsonPropertyName("size")] 
    public long Size { get; set; }
    
    [JsonPropertyName("content_type")] 
    public required string ContentType { get; set; }
    
    [JsonPropertyName("content_encoding")]
    public required string ContentEncoding { get; set; }
}