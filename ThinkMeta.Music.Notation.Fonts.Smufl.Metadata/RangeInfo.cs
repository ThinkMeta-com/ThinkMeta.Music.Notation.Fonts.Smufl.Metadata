using System.Text.Json.Serialization;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Provides information about a range.
/// </summary>
public class RangeInfo
{
    /// <summary>
    /// The description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The glyphs.
    /// </summary>
    [JsonPropertyName("glyphs")]
    public string[]? Glyphs { get; set; }

    /// <summary>
    /// The start code point.
    /// </summary>
    [JsonPropertyName("range_start")]
    public string? RangeStart { get; set; }

    /// <summary>
    /// The end code point.
    /// </summary>
    [JsonPropertyName("end")]
    public string? RangeEnd { get; set; }

    /// <summary>
    /// The parsed start code point.
    /// </summary>
    public int RangeStartValue => CodePointParser.Parse(RangeStart);

    /// <summary>
    /// The parsed end code point.
    /// </summary>
    public int RangeEndValue => CodePointParser.Parse(RangeEnd);
}
