using System.Text.Json;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Provides methods for deserializing a SMuFL "glyphnames.json" file.
/// </summary>
public static class GlyphNames
{
    /// <summary>
    /// Deserializes "glyphnames.json" from a file.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <returns>A dictionary with all glyph names and their information.</returns>
    public static Dictionary<string, GlyphNameInfo>? DeserializeFromFile(string path)
    {
        using var stream = File.OpenRead(path);
        return DeserializeFromStream(stream);
    }

    /// <summary>
    /// Deserializes "glyphnames.json" from a stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>A dictionary with all glyph names and their information.</returns>
    public static Dictionary<string, GlyphNameInfo>? DeserializeFromStream(Stream stream) => JsonSerializer.Deserialize<Dictionary<string, GlyphNameInfo>>(stream);

    /// <summary>
    /// Deserializes "glyphnames.json" from a file.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <returns>A dictionary with all glyph names and their information.</returns>
    public static async Task<Dictionary<string, GlyphNameInfo>?> DeserializeFromFileAsync(string path)
    {
        using var stream = File.OpenRead(path);
        return await DeserializeFromStreamAsync(stream).ConfigureAwait(false);
    }

    /// <summary>
    /// Deserializes "glyphnames.json" from a stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>A dictionary with all glyph names and their information.</returns>
    public static ValueTask<Dictionary<string, GlyphNameInfo>?> DeserializeFromStreamAsync(Stream stream) => JsonSerializer.DeserializeAsync<Dictionary<string, GlyphNameInfo>>(stream);
}
