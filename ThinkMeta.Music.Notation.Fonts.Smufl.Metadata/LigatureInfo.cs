using System.Text.Json.Serialization;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Provides information about a ligature.
/// </summary>
public class LigatureInfo
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
    /// The component glyphs.
    /// </summary>
    [JsonPropertyName("componentGlyphs")]
    public string[]? ComponentGlyphs { get; set; }

    /// <summary>
    /// The parsed glyph code point.
    /// </summary>
    public int CodePointValue => CodePointParser.Parse(CodePoint);
}
