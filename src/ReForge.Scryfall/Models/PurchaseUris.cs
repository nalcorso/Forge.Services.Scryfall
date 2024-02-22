using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Models;

public class PurchaseUris
{
    [JsonPropertyName("tcgplayer")] 
    public Uri? TcgPlayer { get; set; }

    [JsonPropertyName("cardmarket")] 
    public Uri? CardMarket { get; set; }

    [JsonPropertyName("cardhoarder")] 
    public Uri? CardHoarder { get; set; }
}