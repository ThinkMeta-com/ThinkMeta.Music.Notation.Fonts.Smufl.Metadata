using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests;

[TestClass]
public class RangesTests
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
                _ = glyphName.Value.RangeStartValue;
                _ = glyphName.Value.RangeEndValue;
            }
        }
        catch {
            Assert.Fail();
        }
    }

    private static async Task<Dictionary<string, RangeInfo>?> GetDictionaryAsync()
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(RangesTests).Namespace}.Resources.ranges.json");
        var dictionary = await Ranges.DeserializeFromStreamAsync(stream!);
        return dictionary;
    }
}
