using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests;

[TestClass]
public class ClassesTests
{
    [TestMethod]
    public void ValidateW3cJsonFile()
    {
        try {
            using var stream = GetResourceStream();
            var dictionary = Classes.DeserializeFromStream(stream!);
            Assert.IsNotNull(dictionary);
        }
        catch {
            Assert.Fail();
        }
    }

    [TestMethod]
    public async Task ValidateW3cJsonFileAsync()
    {
        try {
            using var stream = GetResourceStream();
            var dictionary = await Classes.DeserializeFromStreamAsync(stream!);
            Assert.IsNotNull(dictionary);
        }
        catch {
            Assert.Fail();
        }
    }

    private static Stream? GetResourceStream() => Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(ClassesTests).Namespace}.Resources.classes.json");
}
