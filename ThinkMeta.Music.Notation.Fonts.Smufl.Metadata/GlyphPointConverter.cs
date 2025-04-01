using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Custom JSON de/serialization for <see cref="GlyphPoint"/>.
/// </summary>
internal class GlyphPointConverter : JsonConverter<GlyphPoint>
{
    public override GlyphPoint Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        _ = reader.Read();
        var first = reader.GetDouble();

        _ = reader.Read();
        var second = reader.GetDouble();

        _ = reader.Read();
        if (reader.TokenType != JsonTokenType.EndArray)
            throw new JsonException();

        return new GlyphPoint { X = first, Y = second };
    }

    public override void Write(Utf8JsonWriter writer, GlyphPoint value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        writer.WriteNumberValue(value.X);
        writer.WriteNumberValue(value.Y);
        writer.WriteEndArray();
    }
}