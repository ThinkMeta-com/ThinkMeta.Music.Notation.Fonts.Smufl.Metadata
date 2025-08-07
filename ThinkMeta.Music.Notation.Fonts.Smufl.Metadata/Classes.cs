using System.Text.Json;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Provides methods for deserializing a SMuFL "classes.json" file.
/// </summary>
public static class Classes
{
    /// <summary>
    /// Deserializes "classes.json" from a file.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <returns>A dictionary with all classes and their glyphs.</returns>
    public static Dictionary<string, string[]>? DeserializeFromFile(string path)
    {
        using var stream = File.OpenRead(path);
        return DeserializeFromStream(stream);
    }

    /// <summary>
    /// Deserializes "classes.json" from a stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>A dictionary with all classes and their glyphs.</returns>
    public static Dictionary<string, string[]>? DeserializeFromStream(Stream stream) => JsonSerializer.Deserialize<Dictionary<string, string[]>>(stream);

    /// <summary>
    /// Deserializes "classes.json" from a file.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <returns>A dictionary with all classes and their glyphs.</returns>
    public static async Task<Dictionary<string, string[]>?> DeserializeFromFileAsync(string path)
    {
        using var stream = File.OpenRead(path);
        return await DeserializeFromStreamAsync(stream).ConfigureAwait(false);
    }

    /// <summary>
    /// Deserializes "classes.json" from a stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>A dictionary with all classes and their glyphs.</returns>
    public static ValueTask<Dictionary<string, string[]>?> DeserializeFromStreamAsync(Stream stream) => JsonSerializer.DeserializeAsync<Dictionary<string, string[]>>(stream);
}
