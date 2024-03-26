using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Layout>))]
public enum Layout
{
    [JsonPropertyName("normal")]
    Normal,
    [JsonPropertyName("split")]
    Split,
    [JsonPropertyName("flip")]
    Flip,
    [JsonPropertyName("transform")]
    Transform,
    [JsonPropertyName("modal_dfc")]
    ModalDfc,
    [JsonPropertyName("meld")]
    Meld,
    [JsonPropertyName("leveler")]
    Leveler,
    [JsonPropertyName("class")]
    Class,
    [JsonPropertyName("case")]
    Case,
    [JsonPropertyName("saga")]
    Saga,
    [JsonPropertyName("adventure")]
    Adventure,
    [JsonPropertyName("mutate")]
    Mutate,
    [JsonPropertyName("prototype")]
    Prototype,
    [JsonPropertyName("battle")]
    Battle,
    [JsonPropertyName("planar")]
    Planar,
    [JsonPropertyName("scheme")]
    Scheme,
    [JsonPropertyName("vanguard")]
    Vanguard,
    [JsonPropertyName("token")]
    Token,
    [JsonPropertyName("double_faced_token")]
    DoubleFacedToken,
    [JsonPropertyName("emblem")]
    Emblem,
    [JsonPropertyName("augment")]
    Augment,
    [JsonPropertyName("host")]
    Host,
    [JsonPropertyName("art_series")]
    ArtSeries,
    [JsonPropertyName("reversible_card")]
    ReversibleCard
}