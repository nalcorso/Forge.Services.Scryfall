using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Converters;

/// <summary>
/// Represents a JSON converter that uses the <see cref="EnumMemberAttribute"/> to convert enum values to and from strings.
/// </summary>
internal class JsonEnumMemberStringEnumConverter : JsonConverterFactory
{
    private readonly JsonNamingPolicy? _namingPolicy;
    private readonly bool _allowIntegerValues;
    private readonly JsonStringEnumConverter _baseConverter;

    public JsonEnumMemberStringEnumConverter() : this(null, true) { }

    public JsonEnumMemberStringEnumConverter(JsonNamingPolicy? namingPolicy = null, bool allowIntegerValues = true)
    {
        _namingPolicy = namingPolicy;
        _allowIntegerValues = allowIntegerValues;
        _baseConverter = new JsonStringEnumConverter(namingPolicy, allowIntegerValues);
    }
    
    public override bool CanConvert(Type typeToConvert) => _baseConverter.CanConvert(typeToConvert);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var query = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
            let attr = field.GetCustomAttribute<JsonPropertyNameAttribute>()
            where attr != null && attr.Name != null
            select (field.Name, attr.Name);
        
        var dictionary = query.ToDictionary(p => p.Item1, p => p.Item2);
        
        if (dictionary.Count > 0)
            return new JsonStringEnumConverter(new DictionaryLookupNamingPolicy(dictionary, _namingPolicy), _allowIntegerValues).CreateConverter(typeToConvert, options);
        
        return _baseConverter.CreateConverter(typeToConvert, options);
    }
}