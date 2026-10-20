using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests;

[TestClass]
public class GlyphNamesTests
{
    // SMuFL code points are located in the Private Use Area of the Basic Multilingual Plane
    private const int PrivateUseAreaStart = 0xE000;
    private const int PrivateUseAreaEnd = 0xF8FF;

    [TestMethod]
    public void ValidateW3cJsonFile()
    {
        using var stream = GetResourceStream();
        var glyphNames = GlyphNames.DeserializeFromStream(stream);

        AssertGlyphNames(glyphNames);
    }

    [TestMethod]
    public async Task ValidateW3cJsonFileAsync()
    {
        using var stream = GetResourceStream();
        var glyphNames = await GlyphNames.DeserializeFromStreamAsync(stream);

        AssertGlyphNames(glyphNames);
    }

    [TestMethod]
    public void ValidateW3cJsonFileCodePoints()
    {
        using var stream = GetResourceStream();
        var glyphNames = GlyphNames.DeserializeFromStream(stream);
        Assert.IsNotNull(glyphNames);

        foreach (var glyphName in glyphNames) {
            Assert.IsInRange(PrivateUseAreaStart, PrivateUseAreaEnd, glyphName.Value.CodePointValue, glyphName.Key);

            if (glyphName.Value.AlternateCodePoint is null)
                Assert.AreEqual(0, glyphName.Value.AlternateCodePointValue, glyphName.Key);
            else
                Assert.IsGreaterThan(0, glyphName.Value.AlternateCodePointValue, glyphName.Key);
        }
    }

    [TestMethod]
    public void ValidateW3cJsonFileCodePointsAreUnique()
    {
        using var stream = GetResourceStream();
        var glyphNames = GlyphNames.DeserializeFromStream(stream);
        Assert.IsNotNull(glyphNames);

        var duplicates = glyphNames.GroupBy(glyphName => glyphName.Value.CodePointValue).Where(group => group.Count() > 1).Select(group => group.Key.ToString("X4")).ToList();
        Assert.IsEmpty(duplicates, string.Join(", ", duplicates));
    }

    [TestMethod]
    public void InvalidCodePointThrowsFormatException()
    {
        var glyphNameInfo = new GlyphNameInfo { CodePoint = "invalid" };

        _ = Assert.ThrowsExactly<FormatException>(() => glyphNameInfo.CodePointValue);
    }

    private static void AssertGlyphNames(Dictionary<string, GlyphNameInfo>? glyphNames)
    {
        Assert.IsNotNull(glyphNames);
        Assert.IsNotEmpty(glyphNames);

        var gClef = glyphNames["gClef"];
        Assert.AreEqual("U+E050", gClef.CodePoint);
        Assert.AreEqual(0xE050, gClef.CodePointValue);
        Assert.AreEqual("U+1D11E", gClef.AlternateCodePoint);
        Assert.AreEqual(0x1D11E, gClef.AlternateCodePointValue);
        Assert.AreEqual("G clef", gClef.Description);
    }

    private static Stream GetResourceStream() => Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(GlyphNamesTests).Namespace}.Resources.glyphnames.json")!;
}
