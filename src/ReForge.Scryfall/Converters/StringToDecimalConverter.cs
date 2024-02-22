using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReForge.Scryfall.Converters;

public class StringToDecimalConverter : JsonConverter<decimal?> {
    public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();
        if (value is null) {
            return null;
        }
        return decimal.Parse(value, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"));
    }

    public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options) {
        writer.WriteStringValue(value?.ToString());
    }
}