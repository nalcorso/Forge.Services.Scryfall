using System.Text.Json.Serialization;
using Forge.Services.Scryfall.Converters;

namespace Forge.Services.Scryfall.Models;

public class Prices
{
    [JsonConverter(typeof(StringToDecimalConverter))]
    [JsonPropertyName("usd")] 
    public decimal? Usd { get; set; }

    [JsonConverter(typeof(StringToDecimalConverter))]
    [JsonPropertyName("usd_foil")] 
    public decimal? UsdFoil { get; set; }

    [JsonConverter(typeof(StringToDecimalConverter))]
    [JsonPropertyName("usd_etched")] 
    public decimal? UsdEtched { get; set; }

    [JsonConverter(typeof(StringToDecimalConverter))]
    [JsonPropertyName("eur")] 
    public decimal? Eur { get; set; }

    [JsonConverter(typeof(StringToDecimalConverter))]
    [JsonPropertyName("eur_foil")] 
    public decimal? EurFoil { get; set; }
    
    [JsonConverter(typeof(StringToDecimalConverter))]
    [JsonPropertyName("eur_etched")]
    public decimal? EurEtched { get; set; }

    [JsonConverter(typeof(StringToDecimalConverter))]
    [JsonPropertyName("tix")] 
    public decimal? Tix { get; set; }
}