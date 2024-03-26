using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<SetType>))]
public enum SetType
{
    [JsonPropertyName("core")]
    Core,
    [JsonPropertyName("expansion")]
    Expansion,
    [JsonPropertyName("masters")]
    Masters,
    [JsonPropertyName("alchemy")]
    Alchemy,
    [JsonPropertyName("masterpiece")]
    Masterpiece,
    [JsonPropertyName("arsenal")]
    Arsenal,
    [JsonPropertyName("from_the_vault")]
    FromTheVault,
    [JsonPropertyName("spellbook")]
    Spellbook,
    [JsonPropertyName("premium_deck")]
    PremiumDeck,
    [JsonPropertyName("duel_deck")]
    DuelDeck,
    [JsonPropertyName("draft_innovation")]
    DraftInnovation,
    [JsonPropertyName("treasure_chest")]
    TreasureChest,
    [JsonPropertyName("commander")]
    Commander,
    [JsonPropertyName("planechase")]
    Planechase,
    [JsonPropertyName("archenemy")]
    Archenemy,
    [JsonPropertyName("vanguard")]
    Vanguard,
    [JsonPropertyName("funny")]
    Funny,
    [JsonPropertyName("starter")]
    Starter,
    [JsonPropertyName("box")]
    Box,
    [JsonPropertyName("promo")]
    Promo,
    [JsonPropertyName("token")]
    Token,
    [JsonPropertyName("memorabilia")]
    Memorabilia,
    [JsonPropertyName("minigame")]
    MiniGame
}