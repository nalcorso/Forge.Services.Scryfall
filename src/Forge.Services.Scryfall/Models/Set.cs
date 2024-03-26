using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

public class Set : ResponseObjectBase
{
    [JsonPropertyName("id")] 
    public Guid Id { get; set; }
    
    [JsonPropertyName("code")] 
    public required string Code { get; set; }
    
    [JsonPropertyName("mtgo_code")] 
    public string? MtgoCode { get; set; }
    
    [JsonPropertyName("arena_code")]
    public string? ArenaCode { get; set; }
    
    [JsonPropertyName("tcgplayer_id")] 
    public long? TcgplayerId { get; set; }
    
    [JsonPropertyName("name")] 
    public required string Name { get; set; }
    
    [JsonPropertyName("set_type")] 
    public SetType SetType { get; set; }
    
    [JsonPropertyName("released_at")] 
    public DateTime? ReleasedAt { get; set; }
    
    [JsonPropertyName("block_code")] 
    public string? BlockCode { get; set; }
    
    [JsonPropertyName("block")] 
    public string? Block { get; set; }
    
    [JsonPropertyName("parent_set_code")] 
    public string? ParentSetCode { get; set; }
    
    [JsonPropertyName("card_count")] 
    public long CardCount { get; set; }
    
    [JsonPropertyName("printed_size")]
    public long? PrintedSize { get; set; }
    
    [JsonPropertyName("digital")] 
    public bool Digital { get; set; }
    
    [JsonPropertyName("foil_only")] 
    public bool FoilOnly { get; set; }
    
    [JsonPropertyName("nonfoil_only")] 
    public bool NonFoilOnly { get; set; }
    
    [JsonPropertyName("object")] 
    public ObjectType Object { get; set; }
    
    [JsonPropertyName("scryfall_uri")] 
    public required Uri ScryfallUri { get; set; }
    
    [JsonPropertyName("uri")] 
    public required Uri Uri { get; set; }
    
    [JsonPropertyName("icon_svg_uri")] 
    public required Uri IconSvgUri { get; set; }
    
    [JsonPropertyName("search_uri")]
    public required Uri SearchUri { get; set; }
}