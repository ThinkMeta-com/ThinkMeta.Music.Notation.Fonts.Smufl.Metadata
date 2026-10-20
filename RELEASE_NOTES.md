# Release Notes

## 1.0.6
- Updated SMuFL metadata (glyph names, classes and ranges) to the latest W3C SMuFL release
- Fixed RangeInfo.RangeEnd not being deserialized (wrong JSON property name)
- Renamed FontMetadata.DeserialzeFromStream(Async) to DeserializeFromStream(Async) (breaking change)
- CodePointParser throws a descriptive FormatException for invalid code points
- Generator escapes XML characters in documentation comments

## 1.0.5
- Added support for .NET 10.0
