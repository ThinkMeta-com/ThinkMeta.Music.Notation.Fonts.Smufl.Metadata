using System.Text.Json.Serialization;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Represents a glyph set.
/// <seealso href="https://w3c.github.io/smufl/latest/specification/sets.html"/>
/// </summary>
public class GlyphSet
{
    /// <summary>
    /// The description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The set type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The glyph information.
    /// </summary>
    [JsonPropertyName("glyphs")]
    public GlyphSetGlyphInfo[]? Glyphs { get; set; }
}
