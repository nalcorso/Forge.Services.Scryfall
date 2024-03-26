using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

public class RelatedUris
{
    [JsonPropertyName("gatherer")] 
    public Uri? Gatherer { get; set; }

    [JsonPropertyName("tcgplayer_decks")] 
    public Uri? TcgPlayerDecks { get; set; }

    [JsonPropertyName("edhrec")] 
    public Uri? EdhRec { get; set; }

    [JsonPropertyName("mtgtop8")] 
    public Uri? MtgTop8 { get; set; }
}