using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests;

[TestClass]
public class GlyphNamesTests
{
    [TestMethod]
    public void ValidateW3cJsonFile()
    {
        try {
            var dictionary = GetDictionary();
            Assert.IsNotNull(dictionary);
        }
        catch {
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ValidateW3cJsonFileCodePoints()
    {
        try {
            var dictionary = GetDictionary();
            Assert.IsNotNull(dictionary);

            foreach (var glyphName in dictionary!) {
                _ = glyphName.Value.CodePointValue;
                _ = glyphName.Value.AlternateCodePointValue;
            }
        }
        catch {
            Assert.Fail();
        }
    }

    private static Dictionary<string, GlyphNameInfo>? GetDictionary()
    {
        using var stream = GetResourceStream();
        var dictionary = GlyphNames.DeserializeFromStream(stream!);
        return dictionary;
    }

    [TestMethod]
    public async Task ValidateW3cJsonFileAsync()
    {
        try {
            var dictionary = await GetDictionaryAsync();
            Assert.IsNotNull(dictionary);
        }
        catch {
            Assert.Fail();
        }
    }

    [TestMethod]
    public async Task ValidateW3cJsonFileCodePointsAsync()
    {
        try {
            var dictionary = await GetDictionaryAsync();
            Assert.IsNotNull(dictionary);

            foreach (var glyphName in dictionary!) {
                _ = glyphName.Value.CodePointValue;
                _ = glyphName.Value.AlternateCodePointValue;
            }
        }
        catch {
            Assert.Fail();
        }
    }

    private static async Task<Dictionary<string, GlyphNameInfo>?> GetDictionaryAsync()
    {
        using var stream = GetResourceStream();
        var dictionary = await GlyphNames.DeserializeFromStreamAsync(stream!);
        return dictionary;
    }

    private static Stream? GetResourceStream() => Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(GlyphNamesTests).Namespace}.Resources.glyphnames.json");
}
