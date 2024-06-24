using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

public class Card : ResponseObjectBase
{
    // Core Card Fields
    [JsonPropertyName("arena_id")] 
    public long? ArenaId { get; set; }
    
    [JsonPropertyName("id")] 
    public Guid Id { get; set; }
    
    [JsonPropertyName("lang")] 
    public Language Lang { get; set; }
    
    [JsonPropertyName("mtgo_id")] 
    public long? MtgoId { get; set; }

    [JsonPropertyName("mtgo_foil_id")] 
    public long? MtgoFoilId { get; set; }
    
    [JsonPropertyName("multiverse_ids")] 
    public List<long>? MultiverseIds { get; set; }
    
    [JsonPropertyName("object")] 
    public ObjectType Object { get; set; }

    [JsonPropertyName("tcgplayer_id")] 
    public long? TcgPlayerId { get; set; }
    
    [JsonPropertyName("tcgplayer_etched_id")] 
    public long? TcgPlayerEtchedId { get; set; }

    [JsonPropertyName("cardmarket_id")] 
    public long? CardMarketId { get; set; }
    
    [JsonPropertyName("layout")] 
    public Layout Layout { get; set; }
    
    [JsonPropertyName("oracle_id")] 
    public Guid? OracleId { get; set; }
    
    [JsonPropertyName("prints_search_uri")]
    public required Uri PrintsSearchUri { get; set; }
    
    [JsonPropertyName("rulings_uri")] 
    public required Uri RulingsUri { get; set; }
    
    [JsonPropertyName("scryfall_uri")] 
    public required Uri ScryfallUri { get; set; }
    
    [JsonPropertyName("uri")] 
    public required Uri Uri { get; set; }
    
    // Gameplay Fields
    [JsonPropertyName("all_parts")] 
    public List<RelatedCardObject>? AllParts { get; set; }
    
    [JsonPropertyName("card_faces")] 
    public List<CardFace>? CardFaces { get; set; }
    
    [JsonPropertyName("cmc")] 
    public double Cmc { get; set; }
    
    [JsonPropertyName("color_identity")] 
    public required List<Color> ColorIdentity { get; set; }
    
    [JsonPropertyName("color_indicator")] 
    public List<Color>? ColorIndicator { get; set; }
    
    [JsonPropertyName("colors")] 
    public List<Color>? Colors { get; set; }
    
    [JsonPropertyName("defense")]
    public string? Defense { get; set; }
    
    [JsonPropertyName("edhrec_rank")] 
    public long? EdhRecRank { get; set; }
    
    [JsonPropertyName("hand_modifier")]
    public string? HandModifier { get; set; }
    
    [JsonPropertyName("keywords")] 
    public required List<string> Keywords { get; set; }
    
    [JsonPropertyName("legalities")] 
    public required Legalities Legalities { get; set; }
    
    [JsonPropertyName("life_modifier")] 
    public string? LifeModifier { get; set; }
    
    [JsonPropertyName("loyalty")] 
    public string? Loyalty { get; set; }
    
    [JsonPropertyName("mana_cost")] 
    public string? ManaCost { get; set; }
    
    [JsonPropertyName("name")] 
    public required string Name { get; set; }
    
    [JsonPropertyName("oracle_text")] 
    public string? OracleText { get; set; }
    
    [JsonPropertyName("penny_rank")]
    public long? PennyRank { get; set; }
    
    [JsonPropertyName("power")] 
    public string? Power { get; set; }
    
    [JsonPropertyName("produced_mana")] 
    public List<Color>? ProducedMana { get; set; }
    
    [JsonPropertyName("reserved")] 
    public bool Reserved { get; set; }
    
    [JsonPropertyName("toughness")] 
    public string? Toughness { get; set; }
    
    [JsonPropertyName("type_line")] 
    public required string TypeLine { get; set; }
    
    // Print Fields
    [JsonPropertyName("artist")] 
    public string? Artist { get; set; }

    [JsonPropertyName("artist_ids")] 
    public List<Guid>? ArtistIds { get; set; }
    
    [JsonPropertyName("attraction_lights")]
    public List<int>? AttractionLights { get; set; }
    
    [JsonPropertyName("booster")] 
    public bool Booster { get; set; }
    
    [JsonPropertyName("border_color")] 
    public BorderColor BorderColor { get; set; }
    
    [JsonPropertyName("card_back_id")] 
    public Guid CardBackId { get; set; }
    
    [JsonPropertyName("collector_number")] 
    public required string CollectorNumber { get; set; }
    
    [JsonPropertyName("content_warning")] 
    public bool? ContentWarning { get; set; }
    
    [JsonPropertyName("digital")] 
    public bool Digital { get; set; }
    
    [JsonPropertyName("finishes")] 
    public required List<Finish> Finishes { get; set; }
    
    [JsonPropertyName("flavor_name")] 
    public string? FlavorName { get; set; }
    
    [JsonPropertyName("flavor_text")] 
    public string? FlavorText { get; set; }
    
    [JsonPropertyName("frame_effects")] 
    public List<FrameEffects>? FrameEffects { get; set; }
    
    [JsonPropertyName("frame")] 
    public Frame Frame { get; set; }
    
    [JsonPropertyName("full_art")] 
    public bool FullArt { get; set; }
    
    [JsonPropertyName("games")] 
    public required List<Games> Games { get; set; }
    
    [JsonPropertyName("highres_image")] 
    public bool HighResImage { get; set; }
    
    [JsonPropertyName("illustration_id")] 
    public Guid? IllustrationId { get; set; }
    
    [JsonPropertyName("image_status")]
    public ImageStatus ImageStatus { get; set; }
    
    [JsonPropertyName("image_uris")] 
    public CardImagery? ImageUris { get; set; }
    
    [JsonPropertyName("oversized")] 
    public bool OverSized { get; set; }
    
    [JsonPropertyName("prices")] 
    public required Prices Prices { get; set; }
    
    [JsonPropertyName("printed_name")] 
    public string? PrintedName { get; set; }

    [JsonPropertyName("printed_text")] 
    public string? PrintedText { get; set; }
    
    [JsonPropertyName("printed_type_line")]
    public string? PrintedTypeLine { get; set; }

    [JsonPropertyName("promo")] 
    public bool Promo { get; set; }
    
    [JsonPropertyName("promo_types")] 
    public List<string>? PromoTypes { get; set; }
    
    [JsonPropertyName("purchase_uris")]
    public PurchaseUris? PurchaseUris { get; set; }
    
    [JsonPropertyName("rarity")] 
    public Rarity Rarity { get; set; }
    
    [JsonPropertyName("related_uris")] 
    public required RelatedUris RelatedUris { get; set; }
    
    [JsonPropertyName("released_at")] 
    public DateTime ReleasedAt { get; set; }
    
    [JsonPropertyName("reprint")] 
    public bool Reprint { get; set; }
    
    [JsonPropertyName("scryfall_set_uri")] 
    public required Uri ScryfallSetUri { get; set; }
    
    [JsonPropertyName("set_name")] 
    public required string SetName { get; set; }
    
    [JsonPropertyName("set_search_uri")] 
    public required Uri SetSearchUri { get; set; }
    
    [JsonPropertyName("set_type")] 
    public SetType SetType { get; set; }

    [JsonPropertyName("set_uri")] 
    public required Uri SetUri { get; set; }
    
    [JsonPropertyName("set")] 
    public required string Set { get; set; }
    
    [JsonPropertyName("set_id")]
    public Guid SetId { get; set; }
    
    [JsonPropertyName("story_spotlight")] 
    public bool StorySpotlight { get; set; }
    
    [JsonPropertyName("textless")] 
    public bool Textless { get; set; }
    
    [JsonPropertyName("variation")] 
    public bool Variation { get; set; }
    
    [JsonPropertyName("variation_of")] 
    public Guid? VariationOf { get; set; }
    
    [JsonPropertyName("security_stamp")]
    public SecurityStamp? SecurityStamp { get; set; }
    
    [JsonPropertyName("watermark")] 
    public string? Watermark { get; set; }
    
    [JsonPropertyName("preview")] 
    public Preview? Preview { get; set; }
}