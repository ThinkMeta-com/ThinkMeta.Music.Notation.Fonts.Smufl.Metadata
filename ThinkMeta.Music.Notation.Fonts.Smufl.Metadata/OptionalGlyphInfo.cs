using System.Text.Json.Serialization;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Provides information about an optional glyph.
/// </summary>
public class OptionalGlyphInfo
{
    /// <summary>
    /// The code point.
    /// </summary>
    [JsonPropertyName("codepoint")]
    public string? CodePoint { get; set; }

    /// <summary>
    /// The description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The classes.
    /// </summary>
    [JsonPropertyName("classes")]
    public string[]? Classes { get; set; }

    /// <summary>
    /// The parsed glyph code point.
    /// </summary>
    public int CodePointValue => CodePointParser.Parse(CodePoint);
}