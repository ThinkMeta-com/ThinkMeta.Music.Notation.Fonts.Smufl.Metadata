using System.Text.Json.Serialization;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Provides information about a glyph in a set.
/// </summary>
public class GlyphSetGlyphInfo
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
    /// The name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The name of the character for which this is an alternate.
    /// </summary>
    [JsonPropertyName("alternateFor")]
    public string? AlternateFor { get; set; }

    /// <summary>
    /// The parsed glyph code point.
    /// </summary>
    public int CodePointValue => CodePointParser.Parse(CodePoint);

}