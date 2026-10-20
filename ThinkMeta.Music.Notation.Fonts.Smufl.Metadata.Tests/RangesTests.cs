using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests;

[TestClass]
public class RangesTests
{
    [TestMethod]
    public void ValidateW3cJsonFile()
    {
        using var stream = GetResourceStream("ranges.json");
        var ranges = Ranges.DeserializeFromStream(stream);

        AssertRanges(ranges);
    }

    [TestMethod]
    public async Task ValidateW3cJsonFileAsync()
    {
        using var stream = GetResourceStream("ranges.json");
        var ranges = await Ranges.DeserializeFromStreamAsync(stream);

        AssertRanges(ranges);
    }

    [TestMethod]
    public void ValidateW3cJsonFileCodePoints()
    {
        using var stream = GetResourceStream("ranges.json");
        var ranges = Ranges.DeserializeFromStream(stream);
        Assert.IsNotNull(ranges);

        foreach (var range in ranges) {
            Assert.IsNotNull(range.Value.RangeStart, range.Key);
            Assert.IsNotNull(range.Value.RangeEnd, range.Key);
            Assert.IsGreaterThan(0, range.Value.RangeStartValue, range.Key);
            Assert.IsGreaterThanOrEqualTo(range.Value.RangeStartValue, range.Value.RangeEndValue, range.Key);
        }
    }

    [TestMethod]
    public void RangeGlyphsAreWithinRange()
    {
        using var rangesStream = GetResourceStream("ranges.json");
        var ranges = Ranges.DeserializeFromStream(rangesStream);
        using var glyphNamesStream = GetResourceStream("glyphnames.json");
        var glyphNames = GlyphNames.DeserializeFromStream(glyphNamesStream);

        Assert.IsNotNull(ranges);
        Assert.IsNotNull(glyphNames);

        foreach (var range in ranges) {
            foreach (var glyph in range.Value.Glyphs!) {
                Assert.IsTrue(glyphNames.TryGetValue(glyph, out var glyphNameInfo), $"{range.Key}: {glyph}");
                Assert.IsInRange(range.Value.RangeStartValue, range.Value.RangeEndValue, glyphNameInfo.CodePointValue, $"{range.Key}: {glyph}");
            }
        }
    }

    private static void AssertRanges(Dictionary<string, RangeInfo>? ranges)
    {
        Assert.IsNotNull(ranges);
        Assert.IsNotEmpty(ranges);

        var clefs = ranges["clefs"];
        Assert.AreEqual("Clefs", clefs.Description);
        Assert.AreEqual(0xE050, clefs.RangeStartValue);
        Assert.AreEqual(0xE07F, clefs.RangeEndValue);
        Assert.IsNotNull(clefs.Glyphs);
        Assert.Contains("gClef", clefs.Glyphs);
    }

    private static Stream GetResourceStream(string name) => Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(RangesTests).Namespace}.Resources.{name}")!;
}
