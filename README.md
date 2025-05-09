# ThinkMeta.Music.Notation.Fonts.Smufl.Metadata

Provides classes for reading SMuFL font metadata.

[![NuGet Package](https://img.shields.io/nuget/v/ThinkMeta.Music.Notation.Fonts.Smufl.Metadata)](https://www.nuget.org/packages/ThinkMeta.Music.Notation.Fonts.Smufl.Metadata) ThinkMeta.Music.Notation.Fonts.Smufl.Metadata<br>
[![NuGet Package](https://img.shields.io/nuget/v/ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Generated)](https://www.nuget.org/packages/ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Generated) ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Generated

# Usage

## Reading classes.json, glyphnames.json and ranges.json

```cs
// JSON files can be downloaded from GitHub

// async methods
var classes = await Classes.DeserializeFromFileAsync("classes.json");
var glyphNames = await GlyphNames.DeserializeFromFileAsync("glyphnames.json");
var ranges = await Ranges.DeserializeFromFileAsync("ranges.json");

// sync methods
var classes = Classes.DeserializeFromFile("classes.json");
var glyphNames = GlyphNames.DeserializeFromFile("glyphnames.json");
var ranges = Ranges.DeserializeFromFile("ranges.json");
```

## Reading font metadata

```cs
// read metadata file for "Bravura"
var fontMetadata = await FontMetadata.DeserializeFromFileAsync("bravura_metadata.json");
```

# Using code-generated metadata

The nuget package [ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Generated](https://www.nuget.org/packages/ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Generated/) provides processed metadata from *classes.json* and *glyphnames.json* as .NET classes.

## Examples

```cs
// get glyph name
var glyphName = GlyphNames.GClef;

// get glyph enum
var glyph = GlyphName.GClef;

// get glyph description
var description = GlyphNameDescriptions.GClef;

// get glyph code point
var codePoint = GlyphNameCodePoints.GClef;

// get alternate glyph code point
var alternateCodePoint = GlyphNameAlternateCodePoints.GClef;

// get glyph name from enum
var glyphNameFromEnum = GlyphNameMappings.GlyphName2StringMap[glyph];
```
