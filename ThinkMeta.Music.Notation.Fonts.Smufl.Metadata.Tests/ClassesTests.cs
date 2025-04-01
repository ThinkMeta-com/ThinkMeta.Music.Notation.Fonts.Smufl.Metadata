using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests;

[TestClass]
public class ClassesTests
{
    [TestMethod]
    public async Task ValidateW3cJsonFileAsync()
    {
        try {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests.Resources.classes.json");
            var dictionary = await Classes.ReadFromStreamAsync(stream!);
            Assert.IsNotNull(dictionary);
        }
        catch {
            Assert.Fail();
        }
    }
}
