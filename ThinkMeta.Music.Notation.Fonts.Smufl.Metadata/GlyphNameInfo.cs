using System.Text.Json.Serialization;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Provides information about a glyph name.
/// </summary>
public partial class GlyphNameInfo
{
    /// <summary>
    /// The code point.
    /// </summary>
    [JsonPropertyName("codepoint")]
    public string? CodePoint { get; set; }

    /// <summary>
    /// The alternate code point.
    /// </summary>
    [JsonPropertyName("alternateCodepoint")]
    public string? AlternateCodePoint { get; set; }

    /// <summary>
    /// The description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The parsed glyph code point.
    /// </summary>
    public int CodePointValue => CodePointParser.Parse(CodePoint);

    /// <summary>
    /// The parsed code point of the altenate glyph.
    /// </summary>
    public int AlternateCodePointValue => CodePointParser.Parse(AlternateCodePoint);
}
