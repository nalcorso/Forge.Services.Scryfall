using System.Runtime.Serialization;
using System.Text.Json;

namespace ReForge.Scryfall.Converters;

internal class DictionaryLookupNamingPolicy : JsonNamingPolicyDecorator 
{
    readonly Dictionary<string, string> dictionary;

    public DictionaryLookupNamingPolicy(Dictionary<string, string> dictionary, JsonNamingPolicy? underlyingNamingPolicy) : base(underlyingNamingPolicy) => this.dictionary = dictionary ?? throw new ArgumentNullException();
    public override string ConvertName(string name)
    {
        if (dictionary.TryGetValue(name, out var value))
        {
            return value;
        }
        else
        {
            Console.WriteLine($"Unable to convert the name: {name}");
            return base.ConvertName(name);
        }
    }}