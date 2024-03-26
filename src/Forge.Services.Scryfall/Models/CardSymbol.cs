using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

public class CardSymbol : ResponseObjectBase
{
    [JsonPropertyName("symbol")]
    public required string Symbol { get; set; }
    
    [JsonPropertyName("loose_variant")]
    public string? LooseVariant { get; set; }
    
    [JsonPropertyName("english")]
    public string? English { get; set; }
    
    [JsonPropertyName("transposable")]
    public bool Transposable { get; set; }
    
    [JsonPropertyName("represents_mana")]
    public bool RepresentsMana { get; set; }
    
    [JsonPropertyName("mana_value")]
    public double? ManaValue { get; set; }
    
    [JsonPropertyName("appears_in_mana_costs")]
    public bool AppearsInManaCosts { get; set; }
    
    [JsonPropertyName("funny")]
    public bool Funny { get; set; }
    
    [JsonPropertyName("colors")]
    public List<Color>? Colors { get; set; }
    
    [JsonPropertyName("hybrid")]
    public bool Hybrid { get; set; }
    
    [JsonPropertyName("phyrexian")]
    public bool Phyrexian { get; set; }
    
    [JsonPropertyName("gatherer_alternates")]
    public List<string>? GathererAlternates { get; set; }
    
    [JsonPropertyName("svg_uri")]
    public Uri? SvgUri { get; set; }
}