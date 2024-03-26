using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

[JsonConverter(typeof(JsonStringEnumConverter<FrameEffects>))]
public enum FrameEffects
{
    [JsonPropertyName("legendary")]
    Legendary,
    [JsonPropertyName("miracle")]
    Miracle,
    [JsonPropertyName("nyxtouched")]
    Nyxtouched,
    [JsonPropertyName("draft")]
    Draft,
    [JsonPropertyName("devoid")]
    Devoid,
    [JsonPropertyName("tombstone")]
    Tombstone,
    [JsonPropertyName("colorshifted")]
    Colorshifted,
    [JsonPropertyName("inverted")]
    Inverted,
    [JsonPropertyName("sunmoondfc")]
    SunMoonDFC,
    [JsonPropertyName("compasslanddfc")]
    CompassLandDFC,
    [JsonPropertyName("originpwdfc")]
    OriginPWDFC,
    [JsonPropertyName("mooneldrazidfc")]
    MoonEldraziDFC,
    [JsonPropertyName("waxingandwaningmoondfc")]
    WaxingAndWaningMoonDFC,
    [JsonPropertyName("showcase")]
    Showcase,
    [JsonPropertyName("extendedart")]
    ExtendedArt,
    [JsonPropertyName("companion")]
    Companion,
    [JsonPropertyName("etched")]
    Etched,
    [JsonPropertyName("snow")]
    Snow,
    [JsonPropertyName("lesson")]
    Lesson,
    [JsonPropertyName("shatteredglass")]
    ShatteredGlass,
    [JsonPropertyName("convertdfc")]
    ConvertDFC,
    [JsonPropertyName("fandfc")]
    FAndFC,
    [JsonPropertyName("upsidedowndfc")]
    UpsideDownDFC
}