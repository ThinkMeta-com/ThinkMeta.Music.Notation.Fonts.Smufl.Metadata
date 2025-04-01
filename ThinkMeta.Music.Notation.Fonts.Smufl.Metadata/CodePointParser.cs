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
        if (codePoint == null)
            return 0;

        var match = CodePointRegex().Match(codePoint);
        return int.Parse(match.Groups[1].Value, NumberStyles.HexNumber);
    }

    [GeneratedRegex(@"U\+([0-9a-fA-F]{4,5})")]
    private static partial Regex CodePointRegex();
}