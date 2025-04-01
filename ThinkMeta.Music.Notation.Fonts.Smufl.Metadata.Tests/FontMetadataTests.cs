using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests;

[TestClass]
public class FontMetadataTests
{
    [TestMethod]
    public async Task ValidateBravuraFontMetadataAsync()
    {
        try {
            var fontMetadata = await GetMetadataAsync();
            Assert.IsNotNull(fontMetadata);
        }
        catch {
            Assert.Fail();
        }
    }

    private static async Task<FontMetadata?> GetMetadataAsync()
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Tests.Resources.bravura_metadata.json");
        var fontMetadata = await FontMetadata.DeserialzeFromStreamAsync(stream!);
        return fontMetadata;
    }
}
