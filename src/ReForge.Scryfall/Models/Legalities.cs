using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

public class Legalities
{
    [JsonPropertyName("standard")] 
    public Legality Standard { get; set; }

    [JsonPropertyName("future")] 
    public Legality Future { get; set; }

    [JsonPropertyName("historic")] 
    public Legality Historic { get; set; }

    [JsonPropertyName("gladiator")] 
    public Legality Gladiator { get; set; }

    [JsonPropertyName("pioneer")] 
    public Legality Pioneer { get; set; }

    [JsonPropertyName("modern")] 
    public Legality Modern { get; set; }

    [JsonPropertyName("legacy")] 
    public Legality Legacy { get; set; }

    [JsonPropertyName("pauper")] 
    public Legality Pauper { get; set; }

    [JsonPropertyName("vintage")] 
    public Legality Vintage { get; set; }

    [JsonPropertyName("penny")] 
    public Legality Penny { get; set; }

    [JsonPropertyName("commander")] 
    public Legality Commander { get; set; }

    [JsonPropertyName("brawl")] 
    public Legality Brawl { get; set; }

    [JsonPropertyName("duel")] 
    public Legality Duel { get; set; }

    [JsonPropertyName("oldschool")] 
    public Legality OldSchool { get; set; }

    [JsonPropertyName("premodern")] 
    public Legality PreModern { get; set; }
}