using System.Text.Json.Serialization;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Information about a glyph alternate.
/// </summary>
public class GlyphAlternate
{
    /// <summary>
    /// The glyph code point.
    /// </summary>
    [JsonPropertyName("codepoint")]
    public string? CodePoint { get; set; }

    /// <summary>
    /// The glyph name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The parsed glyph code point.
    /// </summary>
    public int CodePointValue => CodePointParser.Parse(CodePoint);
}
