using System.Text.Json;

namespace ReForge.Scryfall.Converters;

/// <summary>
/// Decorates a <see cref="JsonNamingPolicy"/> by applying an underlying naming policy.
/// </summary>
internal class JsonNamingPolicyDecorator : JsonNamingPolicy 
{
    private readonly JsonNamingPolicy? _underlyingNamingPolicy;
        
    /// <summary>
    /// Initializes a new instance of the <see cref="JsonNamingPolicyDecorator"/> class with the specified underlying naming policy.
    /// </summary>
    /// <param name="underlyingNamingPolicy">The underlying naming policy to apply.</param>
    public JsonNamingPolicyDecorator(JsonNamingPolicy? underlyingNamingPolicy) => this._underlyingNamingPolicy = underlyingNamingPolicy;
        
    /// <inheritdoc/>
    public override string ConvertName(string name) => _underlyingNamingPolicy?.ConvertName(name) ?? name;
}