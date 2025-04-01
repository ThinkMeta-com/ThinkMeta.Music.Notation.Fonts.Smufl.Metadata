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
    public static async Task<Dictionary<string, GlyphNameInfo>?> ReadFromFileAsync(string path)
    {
        using var stream = File.OpenRead(path);
        return await ReadFromStreamAsync(stream);
    }

    /// <summary>
    /// Deserializes "glyphnames.json" from a stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>A dictionary with all glyph names and their information.</returns>
    public static ValueTask<Dictionary<string, GlyphNameInfo>?> ReadFromStreamAsync(Stream stream) => JsonSerializer.DeserializeAsync<Dictionary<string, GlyphNameInfo>>(stream);
}
