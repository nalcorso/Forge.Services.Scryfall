using System.Text.Json;

namespace Forge.Services.Scryfall.Converters;

/// <summary>
/// Represents a naming policy decorator that performs dictionary lookup for name conversion.
/// </summary>
internal class DictionaryLookupNamingPolicy : JsonNamingPolicyDecorator 
{
    private readonly Dictionary<string, string> _dictionary;

    /// <summary>
    /// Initializes a new instance of the <see cref="DictionaryLookupNamingPolicy"/> class with the specified dictionary and underlying naming policy.
    /// </summary>
    /// <param name="dictionary">The dictionary used for name conversion.</param>
    /// <param name="underlyingNamingPolicy">The underlying naming policy to be used if a name is not found in the dictionary.</param>
    public DictionaryLookupNamingPolicy(Dictionary<string, string> dictionary, JsonNamingPolicy? underlyingNamingPolicy) : base(underlyingNamingPolicy) => this._dictionary = dictionary ?? throw new ArgumentNullException();

    /// <summary>
    /// Converts the specified name by performing dictionary lookup.
    /// </summary>
    /// <param name="name">The name to be converted.</param>
    /// <returns>The converted name if found in the dictionary; otherwise, the converted name using the underlying naming policy.</returns>
    public override string ConvertName(string name)
    {
        if (_dictionary.TryGetValue(name, out var value))
        {
            return value;
        }
        else
        {
            Console.WriteLine($"Unable to convert the name: {name}");
            return base.ConvertName(name);
        }
    }
}
