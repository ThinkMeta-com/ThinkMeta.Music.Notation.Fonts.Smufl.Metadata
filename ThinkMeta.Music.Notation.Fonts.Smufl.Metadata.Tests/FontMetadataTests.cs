using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests;

[TestClass]
public class FontMetadataTests
{
    [TestMethod]
    public void ValidateBravuraFontMetadata()
    {
        try {
            using var stream = GetResourceStream();
            var fontMetadata = FontMetadata.DeserialzeFromStream(stream!);
            Assert.IsNotNull(fontMetadata);
        }
        catch {
            Assert.Fail();
        }
    }

    [TestMethod]
    public async Task ValidateBravuraFontMetadataAsync()
    {
        try {
            using var stream = GetResourceStream();
            var fontMetadata = await FontMetadata.DeserialzeFromStreamAsync(stream!);
            Assert.IsNotNull(fontMetadata);
        }
        catch {
            Assert.Fail();
        }
    }

    private static Stream? GetResourceStream() => Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(FontMetadataTests).Namespace}.Resources.bravura_metadata.json");
}
