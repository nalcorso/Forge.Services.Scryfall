using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

public class ManaCost : ResponseObjectBase
{
    [JsonPropertyName("object")] 
    public ObjectType Object { get; set; }
    
    [JsonPropertyName("cost")]
    public required string Cost { get; set; }
    
    [JsonPropertyName("cmc")]
    public decimal Cmc { get; set; }
    
    [JsonPropertyName("colors")]
    public required List<Color> Colors { get; set; }
    
    [JsonPropertyName("colorless")]
    public bool Colorless { get; set; }
    
    [JsonPropertyName("monocolored")]
    public bool MonoColored { get; set; }
    
    [JsonPropertyName("multicolored")]
    public bool Multicolored { get; set; }
}