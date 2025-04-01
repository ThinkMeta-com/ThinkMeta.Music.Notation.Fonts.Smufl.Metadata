# ThinkMeta.Music.Notation.Fonts.Smufl.Metadata

Provides classes for reading SMuFL font metadata.

# Usage

## Reading classes.json, glyphnames.json and ranges.json

<pre>
    // JSON files can be downloaded from GitHub
    var classes = await Classes.DeserializeFromFileAsync("classes.json");
    var glyphNames = await GlyphNames.DeserializeFromFileAsync("glyphnames.json");
    var ranges = await Ranges.DeserializeFromFileAsync("ranges.json");
</pre>

## Reading font metadata

<pre>
    // read metadata file for "Bravura"
    var fontMetadata = await FontMetadata.DeserializeFromFileAsync("bravura_metadata.json");
</pre>
