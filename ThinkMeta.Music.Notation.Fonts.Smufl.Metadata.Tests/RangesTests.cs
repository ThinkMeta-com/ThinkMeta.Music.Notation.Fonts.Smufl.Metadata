using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests;

[TestClass]
public class RangesTests
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
                _ = glyphName.Value.RangeStartValue;
                _ = glyphName.Value.RangeEndValue;
            }
        }
        catch {
            Assert.Fail();
        }
    }

    private static Dictionary<string, RangeInfo>? GetDictionary()
    {
        using var stream = GetResourceStream();
        var dictionary = Ranges.DeserializeFromStream(stream!);
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
        using var stream = GetResourceStream();
        var dictionary = await Ranges.DeserializeFromStreamAsync(stream!);
        return dictionary;
    }

    private static Stream? GetResourceStream() => Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(RangesTests).Namespace}.Resources.ranges.json");
}
