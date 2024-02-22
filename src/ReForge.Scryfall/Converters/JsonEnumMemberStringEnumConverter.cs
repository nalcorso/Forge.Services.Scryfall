using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Converters;

public class JsonEnumMemberStringEnumConverter : JsonConverterFactory
{
    private readonly JsonNamingPolicy? namingPolicy;
    private readonly bool allowIntegerValues;
    private readonly JsonStringEnumConverter baseConverter;

    public JsonEnumMemberStringEnumConverter() : this(null, true) { }

    public JsonEnumMemberStringEnumConverter(JsonNamingPolicy? namingPolicy = null, bool allowIntegerValues = true)
    {
        this.namingPolicy = namingPolicy;
        this.allowIntegerValues = allowIntegerValues;
        this.baseConverter = new JsonStringEnumConverter(namingPolicy, allowIntegerValues);
    }
    
    public override bool CanConvert(Type typeToConvert) => baseConverter.CanConvert(typeToConvert);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var query = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
            let attr = field.GetCustomAttribute<JsonPropertyNameAttribute>()
            where attr != null && attr.Name != null
            select (field.Name, attr.Name);
        var dictionary = query.ToDictionary(p => p.Item1, p => p.Item2);
        if (dictionary.Count > 0)
            return new JsonStringEnumConverter(new DictionaryLookupNamingPolicy(dictionary, namingPolicy), allowIntegerValues).CreateConverter(typeToConvert, options);
        else
            return baseConverter.CreateConverter(typeToConvert, options);
    }
}