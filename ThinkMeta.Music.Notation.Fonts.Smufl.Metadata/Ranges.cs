using System.Text.Json;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Provides methods for deserializing a SMuFL "ranges.json" file.
/// </summary>
public static class Ranges
{
    /// <summary>
    /// Deserializes "ranges.json" from a file.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <returns>A dictionary with all ranges.</returns>
    public static Dictionary<string, RangeInfo>? DeserializeFromFile(string path)
    {
        using var stream = File.OpenRead(path);
        return DeserializeFromStream(stream);
    }

    /// <summary>
    /// Deserializes "ranges.json" from a stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>A dictionary with all ranges.</returns>
    public static Dictionary<string, RangeInfo>? DeserializeFromStream(Stream stream) => JsonSerializer.Deserialize<Dictionary<string, RangeInfo>>(stream);

    /// <summary>
    /// Deserializes "ranges.json" from a file.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <returns>A dictionary with all ranges.</returns>
    public static async Task<Dictionary<string, RangeInfo>?> DeserializeFromFileAsync(string path)
    {
        using var stream = File.OpenRead(path);
        return await DeserializeFromStreamAsync(stream).ConfigureAwait(false);
    }

    /// <summary>
    /// Deserializes "ranges.json" from a stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>A dictionary with all ranges.</returns>
    public static ValueTask<Dictionary<string, RangeInfo>?> DeserializeFromStreamAsync(Stream stream) => JsonSerializer.DeserializeAsync<Dictionary<string, RangeInfo>>(stream);
}
