using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests;

[TestClass]
public class ClassesTests
{
    [TestMethod]
    public void ValidateW3cJsonFile()
    {
        using var stream = GetResourceStream("classes.json");
        var classes = Classes.DeserializeFromStream(stream);

        AssertClasses(classes);
    }

    [TestMethod]
    public async Task ValidateW3cJsonFileAsync()
    {
        using var stream = GetResourceStream("classes.json");
        var classes = await Classes.DeserializeFromStreamAsync(stream);

        AssertClasses(classes);
    }

    [TestMethod]
    public void AllClassGlyphsExistInGlyphNames()
    {
        using var classesStream = GetResourceStream("classes.json");
        var classes = Classes.DeserializeFromStream(classesStream);
        using var glyphNamesStream = GetResourceStream("glyphnames.json");
        var glyphNames = GlyphNames.DeserializeFromStream(glyphNamesStream);

        Assert.IsNotNull(classes);
        Assert.IsNotNull(glyphNames);

        var unknownGlyphs = classes.Values.SelectMany(glyphs => glyphs).Where(glyph => !glyphNames.ContainsKey(glyph)).Distinct().ToList();
        Assert.IsEmpty(unknownGlyphs, string.Join(", ", unknownGlyphs));
    }

    private static void AssertClasses(Dictionary<string, string[]>? classes)
    {
        Assert.IsNotNull(classes);
        Assert.IsNotEmpty(classes);
        Assert.Contains("accidentals", classes.Keys);
        Assert.Contains("accidentalSharp", classes["accidentals"]);

        foreach (var @class in classes)
            Assert.IsNotEmpty(@class.Value, @class.Key);
    }

    private static Stream GetResourceStream(string name) => Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(ClassesTests).Namespace}.Resources.{name}")!;
}
