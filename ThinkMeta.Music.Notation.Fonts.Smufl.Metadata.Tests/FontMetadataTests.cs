using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests;

[TestClass]
public class FontMetadataTests
{
    [TestMethod]
    public void ValidateBravuraFontMetadata()
    {
        using var stream = GetResourceStream();
        var fontMetadata = FontMetadata.DeserializeFromStream(stream);

        AssertBravuraFontMetadata(fontMetadata);
    }

    [TestMethod]
    public async Task ValidateBravuraFontMetadataAsync()
    {
        using var stream = GetResourceStream();
        var fontMetadata = await FontMetadata.DeserializeFromStreamAsync(stream);

        AssertBravuraFontMetadata(fontMetadata);
    }

    private static void AssertBravuraFontMetadata(FontMetadata? fontMetadata)
    {
        Assert.IsNotNull(fontMetadata);
        Assert.AreEqual("Bravura", fontMetadata.FontName);
        Assert.IsGreaterThan(0m, fontMetadata.FontVersion);

        var engravingDefaults = fontMetadata.EngravingDefaults;
        Assert.IsNotNull(engravingDefaults);
        Assert.IsNotNull(engravingDefaults.TextFontFamily);
        Assert.IsNotEmpty(engravingDefaults.TextFontFamily);
        Assert.IsGreaterThan(0d, engravingDefaults.StaffLineThickness);
        Assert.IsGreaterThan(0d, engravingDefaults.ThinThickBarlineSeparation);
        Assert.IsGreaterThan(0d, engravingDefaults.HorizontalBarThickness);

        Assert.IsNotNull(fontMetadata.GlyphAdvanceWidths);
        Assert.IsGreaterThan(0d, fontMetadata.GlyphAdvanceWidths["gClef"]);

        Assert.IsNotNull(fontMetadata.GlyphBoundingBoxes);
        var gClefBoundingBox = fontMetadata.GlyphBoundingBoxes["gClef"];
        Assert.IsLessThan(gClefBoundingBox["bBoxNE"].X, gClefBoundingBox["bBoxSW"].X);
        Assert.IsLessThan(gClefBoundingBox["bBoxNE"].Y, gClefBoundingBox["bBoxSW"].Y);

        Assert.IsNotNull(fontMetadata.GlyphsWithAnchors);
        Assert.Contains("stemUpSE", fontMetadata.GlyphsWithAnchors["noteheadBlack"].Keys);

        Assert.IsNotNull(fontMetadata.GlyphsWithAlternates);
        var alternates = fontMetadata.GlyphsWithAlternates["4stringTabClef"].Alternates;
        Assert.IsNotNull(alternates);
        Assert.IsNotEmpty(alternates);
        Assert.IsGreaterThan(0, alternates[0].CodePointValue);
        Assert.IsNotNull(alternates[0].Name);

        Assert.IsNotNull(fontMetadata.Ligatures);
        var ligature = fontMetadata.Ligatures["accidentalDoubleFlatParens"];
        Assert.IsGreaterThan(0, ligature.CodePointValue);
        Assert.IsNotNull(ligature.ComponentGlyphs);
        Assert.HasCount(3, ligature.ComponentGlyphs);

        Assert.IsNotNull(fontMetadata.OptionalGlyphs);
        var optionalGlyph = fontMetadata.OptionalGlyphs["4stringTabClefSerif"];
        Assert.IsGreaterThan(0, optionalGlyph.CodePointValue);
        Assert.IsNotNull(optionalGlyph.Classes);
        Assert.Contains("clefs", optionalGlyph.Classes);

        Assert.IsNotNull(fontMetadata.GlyphSets);
        var glyphSet = fontMetadata.GlyphSets["ss01"];
        Assert.IsNotNull(glyphSet.Description);
        Assert.IsNotNull(glyphSet.Glyphs);
        Assert.IsNotEmpty(glyphSet.Glyphs);
        Assert.IsNotNull(glyphSet.Glyphs[0].AlternateFor);
        Assert.IsGreaterThan(0, glyphSet.Glyphs[0].CodePointValue);
    }

    private static Stream GetResourceStream() => Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(FontMetadataTests).Namespace}.Resources.bravura_metadata.json")!;
}
