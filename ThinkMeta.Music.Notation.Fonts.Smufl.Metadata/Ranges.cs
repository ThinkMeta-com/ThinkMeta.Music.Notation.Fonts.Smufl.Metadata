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
    public static async Task<Dictionary<string, RangeInfo>?> DeserializeFromFileAsync(string path)
    {
        using var stream = File.OpenRead(path);
        return await DeserializeFromStreamAsync(stream);
    }

    /// <summary>
    /// Deserializes "ranges.json" from a stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>A dictionary with all ranges.</returns>
    public static ValueTask<Dictionary<string, RangeInfo>?> DeserializeFromStreamAsync(Stream stream) => JsonSerializer.DeserializeAsync<Dictionary<string, RangeInfo>>(stream);
}
