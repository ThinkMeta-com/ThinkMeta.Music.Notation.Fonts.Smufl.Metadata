using System.Globalization;
using System.Text.RegularExpressions;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata;

/// <summary>
/// Parses a string code point into an integer.
/// </summary>
internal static partial class CodePointParser
{
    public static int Parse(string? codePoint)
    {
        if (codePoint is null)
            return 0;

        var match = CodePointRegex().Match(codePoint);
        return match.Success
            ? int.Parse(match.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture)
            : throw new FormatException($"Invalid code point \"{codePoint}\".");
    }

    [GeneratedRegex(@"U\+([0-9a-fA-F]{4,5})")]
    private static partial Regex CodePointRegex();
}