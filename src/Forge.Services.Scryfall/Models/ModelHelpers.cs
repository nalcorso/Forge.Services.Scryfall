using System.Reflection;
using System.Text.Json.Serialization;

namespace Forge.Services.Scryfall.Models;

public static class ModelHelpers
{
    public static string GetJsonPropertyName(Enum value)
    {
        return value.GetType()
            .GetMember(value.ToString())
            .First()
            .GetCustomAttribute<JsonPropertyNameAttribute>()?
            .Name ?? value.ToString();
    }
}