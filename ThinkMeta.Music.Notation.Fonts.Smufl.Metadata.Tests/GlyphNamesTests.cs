using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests;

[TestClass]
public class GlyphNamesTests
{
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
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests.Resources.glyphnames.json");
        var dictionary = await GlyphNames.ReadFromStreamAsync(stream!);
        return dictionary;
    }
}
