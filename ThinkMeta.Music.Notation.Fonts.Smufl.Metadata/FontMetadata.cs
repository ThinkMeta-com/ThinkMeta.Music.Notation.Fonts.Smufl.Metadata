using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Provides metadata for SMuFL fonts.
/// </summary>
public class FontMetadata
{
    /// <summary>
    /// Deserializes metadata from a JSON file.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <returns>The metadata object.</returns>
    public static async Task<FontMetadata?> DeserializeFromFileAsync(string path)
    {
        using var stream = File.OpenRead(path);
        return await DeserialzeFromStreamAsync(stream);
    }

    /// <summary>
    /// Deserializes metadata from a stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>The metadata object.</returns>
    public static ValueTask<FontMetadata?> DeserialzeFromStreamAsync(Stream stream) => JsonSerializer.DeserializeAsync<FontMetadata>(stream, new JsonSerializerOptions { Converters = { new GlyphPointConverter() } });

    /// <summary>
    /// The name of the font to which the metadata applies.
    /// </summary>
    [JsonPropertyName("fontName")]
    public string? FontName { get; set; }

    /// <summary>
    /// The version number of the font to which the metadata applies.
    /// </summary>
    [JsonPropertyName("fontVersion")]
    public decimal FontVersion { get; set; }

    /// <summary>
    /// The engraving defaults.
    /// </summary>
    [JsonPropertyName("engravingDefaults")]
    public EngravingDefaults? EngravingDefaults { get; set; }

    /// <summary>
    /// The glyph advance widths.
    /// </summary>
    [JsonPropertyName("glyphAdvanceWidths")]
    public Dictionary<string, double>? GlyphAdvanceWidths { get; set; }

    /// <summary>
    /// The glyph bounding boxes.
    /// </summary>
    [JsonPropertyName("glyphBBoxes")]
    public Dictionary<string, Dictionary<string, GlyphPoint>>? GlyphBoundingBoxes { get; set; }

    /// <summary>
    /// The glyph anchors.
    /// </summary>
    [JsonPropertyName("glyphsWithAnchors")]
    public Dictionary<string, Dictionary<string, GlyphPoint>>? GlyphsWithAnchors { get; set; }

    /// <summary>
    /// The glyph alternates.
    /// </summary>
    [JsonPropertyName("glyphsWithAlternates")]
    public Dictionary<string, GlyphAlternates>? GlyphsWithAlternates { get; set; }

    /// <summary>
    /// The ligatures.
    /// </summary>
    [JsonPropertyName("ligatures")]
    public Dictionary<string, LigatureInfo>? Ligatures { get; set; }

    /// <summary>
    /// The optional glyphs.
    /// </summary>
    [JsonPropertyName("optionalGlyphs")]
    public Dictionary<string, OptionalGlyphInfo>? OptionalGlyphs { get; set; }

    /// <summary>
    /// The glyph sets.
    /// </summary>
    [JsonPropertyName("sets")]
    public Dictionary<string, GlyphSet>? GlyphSets { get; set; }
}
