using System.Text.Json.Serialization;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Holds an array of glyph alternates.
/// </summary>
public class GlyphAlternates
{
    /// <summary>
    /// The array of glyph alternates.
    /// </summary>
    [JsonPropertyName("alternates")]
    public GlyphAlternate[]? Alternates { get; set; }
}