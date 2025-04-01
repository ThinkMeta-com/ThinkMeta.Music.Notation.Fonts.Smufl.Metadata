using System.Text.Json.Serialization;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// The "engravingDefaults" structure contains key/value pairs defining recommended defaults for line widths etc.
/// with all measurements expressed in staff spaces
/// </summary>
public class EngravingDefaults
{
    /// <summary>
    /// An array containing the text font family (or families, in descending order of preference)
    /// that are ideally paired with this music font; this list may also use the generic font
    /// family values defined in <seealso href="https://www.w3.org/TR/CSS2/fonts.html#generic-font-families">CSS</seealso>, i.e. serif, sans-serif, cursive, fantasy, and
    /// monospace. Generic font family names should be listed after specific font families.
    /// </summary>
    [JsonPropertyName("textFontFamily")]
    public string[]? TextFontFamily { get; set; }

    /// <summary>
    /// The thickness of each staff line.
    /// </summary>
    [JsonPropertyName("staffLineThickness")]
    public double StaffLineThickness { get; set; }

    /// <summary>
    /// The thickness of a stem.
    /// </summary>
    [JsonPropertyName("stemThickness")]
    public double StemThickness { get; set; }

    /// <summary>
    /// The thickness of a beam.
    /// </summary>
    [JsonPropertyName("beamThickness")]
    public double BeamThickness { get; set; }

    /// <summary>
    /// The distance between the inner edge of the primary and outer edge of subsequent
    /// secondary beams.
    /// </summary>
    [JsonPropertyName("beamSpacing")]
    public double BeamSpacing { get; set; }

    /// <summary>
    /// The thickness of a leger line (normally somewhat thicker than a staff line).
    /// </summary>
    [JsonPropertyName("legerLineThickness")]
    public double LegerLineThickness { get; set; }

    /// <summary>
    /// The amount by which a leger line should extend either side of a notehead, scaled
    /// proportionally with the notehead's size, e.g. when scaled down as a grace note.
    /// </summary>
    [JsonPropertyName("legerLineExtension")]
    public double LegerLineExtension { get; set; }

    /// <summary>
    /// The thickness of the end of a slur.
    /// </summary>
    [JsonPropertyName("slurEndpointThickness")]
    public double SlurEndpointThickness { get; set; }

    /// <summary>
    /// The thickness of the mid-point of a slur (i.e. its thickest point).
    /// </summary>
    [JsonPropertyName("slurMidpointThickness")]
    public double SlurMidpointThickness { get; set; }

    /// <summary>
    /// The thickness of the end of a tie.
    /// </summary>
    [JsonPropertyName("tieEndpointThickness")]
    public double TieEndpointThickness { get; set; }

    /// <summary>
    /// The thickness of the mid-point of a tie.
    /// </summary>
    [JsonPropertyName("tieMidpointThickness")]
    public double TieMidpointThickness { get; set; }

    /// <summary>
    /// The thickness of a thin barline, e.g. a normal barline, or each of the lines of a double
    /// barline.
    /// </summary>
    [JsonPropertyName("thinBarlineThickness")]
    public double ThinBarlineThickness { get; set; }

    /// <summary>
    /// The thickness of a thick barline, e.g. in a final barline or a repeat barline.
    /// </summary>
    [JsonPropertyName("thickBarlineThickness")]
    public double ThickBarlineThickness { get; set; }

    /// <summary>
    /// The thickness of a dashed barline.
    /// </summary>
    [JsonPropertyName("dashedBarlineThickness")]
    public double DashedBarlineThickness { get; set; }

    /// <summary>
    /// The length of the dashes to be used in a dashed barline.
    /// </summary>
    [JsonPropertyName("dashedBarlineDashLength")]
    public double DashedBarlineDashLength { get; set; }

    /// <summary>
    /// The length of the gap between dashes in a dashed barline.
    /// </summary>
    [JsonPropertyName("dashedBarlineGapLength")]
    public double DashedBarlineGapLength { get; set; }

    /// <summary>
    /// The default distance between multiple thin barlines when locked together, e.g.
    /// between two thin barlines making a double barline, measured from the right-hand
    /// edge of the left barline to the left-hand edge of the right barline.
    /// </summary>
    [JsonPropertyName("barlineSeparation")]
    public double BarlineSeparation { get; set; }

    /// <summary>
    /// The default distance between a pair of thin and thick barlines when locked together,
    /// e.g. between the thin and thick barlines making a final barline, or between the thick
    /// and thin barlines making a start repeat barline.
    /// </summary>
    [JsonPropertyName("thinThickBarlineSeparation")]
    public double ThinThickBarlineSeparation { get; set; }

    /// <summary>
    /// The default horizontal distance between the dots and the inner barline of a repeat
    /// barline, measured from the edge of the dots to the edge of the barline.
    /// </summary>
    [JsonPropertyName("repeatBarlineDotSeparation")]
    public double RepeatBarlineDotSeparation { get; set; }

    /// <summary>
    /// The thickness of the vertical line of a bracket grouping staves together.
    /// </summary>
    [JsonPropertyName("bracketThickness")]
    public double BracketThickness { get; set; }

    /// <summary>
    /// The thickness of the vertical line of a sub-bracket grouping staves belonging to the
    /// same instrument together.
    /// </summary>
    [JsonPropertyName("subBracketThickness")]
    public double SubBracketThickness { get; set; }

    /// <summary>
    /// The thickness of a crescendo/diminuendo hairpin.
    /// </summary>
    [JsonPropertyName("hairpinThickness")]
    public double HairpinThickness { get; set; }

    /// <summary>
    /// The thickness of the dashed line used for an octave line.
    /// </summary>
    [JsonPropertyName("octaveLineThickness")]
    public double OctaveLineThickness { get; set; }

    /// <summary>
    /// The thickness of the line used for piano pedaling.
    /// </summary>
    [JsonPropertyName("pedalLineThickness")]
    public double PedalLineThickness { get; set; }

    /// <summary>
    /// The thickness of the brackets drawn to indicate repeat endings.
    /// </summary>
    [JsonPropertyName("repeatEndingLineThickness")]
    public double RepeatEndingLineThickness { get; set; }

    /// <summary>
    /// The thickness of the line used for the shaft of an arrow.
    /// </summary>
    [JsonPropertyName("arrowShaftThickness")]
    public double ArrowShaftThickness { get; set; }

    /// <summary>
    /// The thickness of the lyric extension line to indicate a melisma in vocal music.
    /// </summary>
    [JsonPropertyName("lyricLineThickness")]
    public double LyricLineThickness { get; set; }

    /// <summary>
    /// The thickness of a box drawn around text instructions (e.g. rehearsal marks)
    /// </summary>
    [JsonPropertyName("textEnclosureThickness")]
    public double TextEnclosureThickness { get; set; }

    /// <summary>
    /// The thickness of the brackets drawn either side of tuplet numbers.
    /// </summary>
    [JsonPropertyName("tupletBracketThickness")]
    public double TupletBracketThickness { get; set; }

    /// <summary>
    /// The thickness of the horizontal line drawn between two vertical lines, known as the H-bar,
    /// in a multi-bar rest.
    /// </summary>
    [JsonPropertyName("hBarThickness")]
    public double HorizontalBarThickness { get; set; }
}