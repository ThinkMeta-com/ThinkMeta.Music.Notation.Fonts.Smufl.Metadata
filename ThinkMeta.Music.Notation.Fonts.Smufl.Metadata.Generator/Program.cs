﻿using System.Reflection;
using System.Text;

namespace ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Generator;

internal static class Program
{
    private const string TargetNamespace = "ThinkMeta.Music.Notation.Fonts.Smufl.Metadata.Generated";
    private const string Indent1 = "    ";
    private const string Indent2 = "        ";
    private const string Indent3 = "            ";

    private static async Task Main(string[] args)
    {
        await WriteGlyphNamesFileAsync(args[0]);
        await WriteClassesFileAsync(args[0]);
    }

    private static async Task WriteGlyphNamesFileAsync(string path)
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(Program).Namespace}.Resources.glyphnames.json");
        var glyphNames = await GlyphNames.DeserializeFromStreamAsync(stream!);

        var stringBuilder = new StringBuilder();
        _ = stringBuilder
            .AppendLine($"// generated by {typeof(Program).Namespace}")
            .AppendLine($"namespace {TargetNamespace};")
            .AppendLine()
            .AppendSummary("All glyph names")
            .AppendLine("public static class GlyphNames")
            .AppendLine("{")
            .AppendItemsWithSummary(Indent1, glyphNames!, glyphName => $"public const string {ToPascalCase(glyphName.Key)} = \"{glyphName.Key}\";")
            .AppendLine("}");

        _ = stringBuilder
            .AppendLine()
            .AppendSummary("Glyph names as enums")
            .AppendLine("public enum GlyphName")
            .AppendLine("{")
            .AppendItemsWithSummary(Indent1, glyphNames!, glyphName => $"{ToPascalCase(glyphName.Key)},")
            .AppendLine("}");

        _ = stringBuilder
            .AppendLine()
            .AppendSummary("All glyph name descriptions")
            .AppendLine("public static class GlyphNameDescriptions")
            .AppendLine("{")
            .AppendItemsWithSummary(Indent1, glyphNames!, glyphName => $"public const string {ToPascalCase(glyphName.Key)} = \"{Escape(glyphName.Value.Description!)}\";")
            .AppendLine("}");

        _ = stringBuilder
            .AppendLine()
            .AppendSummary("All glyph name code points")
            .AppendLine("public static class GlyphNameCodePoints")
            .AppendLine("{")
            .AppendItemsWithSummary(Indent1, glyphNames!, glyphName => $"public const int {ToPascalCase(glyphName.Key)} = {glyphName.Value.CodePointValue};")
            .AppendLine("}");

        _ = stringBuilder
            .AppendLine()
            .AppendSummary("All glyph name alternate code points")
            .AppendLine("public static class GlyphNameAlternateCodePoints")
            .AppendLine("{")
            .AppendItemsWithSummary(Indent1, glyphNames!.Where(g => g.Value.AlternateCodePointValue != 0), glyphName => $"public const int {ToPascalCase(glyphName.Key)} = {glyphName.Value.AlternateCodePointValue};")
            .AppendLine("}");

        _ = stringBuilder
            .AppendLine()
            .AppendSummary("Provides glyph name mappings")
            .AppendLine("public static class GlyphNameMappings")
            .AppendLine("{");

        _ = stringBuilder
            .AppendSummary("Glyph name enums to string mappings", Indent1)
            .Append(Indent1)
            .AppendLine("public static IReadOnlyDictionary<GlyphName, string> GlyphName2StringMap { get; } = new Dictionary<GlyphName, string> {")
            .AppendItems(Indent2, glyphNames!, glyphName => $"[GlyphName.{ToPascalCase(glyphName.Key)}] = GlyphNames.{ToPascalCase(glyphName.Key)},")
            .Append(Indent1)
            .AppendLine("};");

        _ = stringBuilder
            .AppendLine()
            .AppendSummary("Maps glyph name enums to their corresponding code points", Indent1)
            .Append(Indent1)
            .AppendLine("public static IReadOnlyDictionary<GlyphName, int> GlyphName2CodePointMap { get; } = new Dictionary<GlyphName, int> {")
            .AppendItems(Indent2, glyphNames!, glyphName => $"[GlyphName.{ToPascalCase(glyphName.Key)}] = GlyphNameCodePoints.{ToPascalCase(glyphName.Key)},")
            .Append(Indent1)
            .AppendLine("};");

        _ = stringBuilder
            .AppendLine()
            .AppendSummary("Maps glyph name enums to their corresponding alternate code points", Indent1)
            .Append(Indent1)
            .AppendLine("public static IReadOnlyDictionary<GlyphName, int> GlyphName2AlternateCodePointMap { get; } = new Dictionary<GlyphName, int> {")
            .AppendItems(Indent2, glyphNames!.Where(g => g.Value.AlternateCodePointValue != 0), glyphName => $"[GlyphName.{ToPascalCase(glyphName.Key)}] = GlyphNameAlternateCodePoints.{ToPascalCase(glyphName.Key)},")
            .Append(Indent1)
            .AppendLine("};");

        _ = stringBuilder
            .AppendLine()
            .AppendSummary("Maps glyph name enums to their corresponding descriptions", Indent1)
            .Append(Indent1)
            .AppendLine("public static IReadOnlyDictionary<GlyphName, string> GlyphName2DescriptionMap { get; } = new Dictionary<GlyphName, string> {")
            .AppendItems(Indent2, glyphNames!, glyphName => $"[GlyphName.{ToPascalCase(glyphName.Key)}] = GlyphNameDescriptions.{ToPascalCase(glyphName.Key)},")
            .Append(Indent1)
            .AppendLine("};");

        _ = stringBuilder.AppendLine("}");

        var outputPath = Path.Combine(path, "GlyphNames.cs");
        await File.WriteAllTextAsync(outputPath, stringBuilder.ToString());
    }

    private static async Task WriteClassesFileAsync(string path)
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(Program).Namespace}.Resources.classes.json");
        var classes = await Classes.DeserializeFromStreamAsync(stream!);

        var stringBuilder = new StringBuilder();
        _ = stringBuilder
            .AppendLine($"// generated by {typeof(Program).Namespace}")
            .AppendLine($"namespace {TargetNamespace};")
            .AppendLine()
            .AppendSummary("All class names")
            .AppendLine("public static class ClassNames")
            .AppendLine("{")
            .AppendItemsWithSummary(Indent1, classes!, @class => $"public const string {ToPascalCase(@class.Key)} = \"{@class.Key}\";")
            .AppendLine("}");

        _ = stringBuilder
            .AppendLine()
            .AppendSummary("Class names as enums")
            .AppendLine("public enum ClassName")
            .AppendLine("{")
            .AppendItemsWithSummary(Indent1, classes!, @class => $"{ToPascalCase(@class.Key)},")
            .AppendLine("}");

        _ = stringBuilder
            .AppendLine()
            .AppendSummary("Provides all classes as arrays")
            .AppendLine("public static class Classes")
            .AppendLine("{");

        foreach (var @class in classes!) {
            _ = stringBuilder
                .AppendSummary($"\"{ToPascalCase(@class.Key)}\" class", Indent1)
                .Append(Indent1)
                .AppendLine($"public static IReadOnlyList<GlyphName> {ToPascalCase(@class.Key)} => [")
                .AppendItems(Indent2, @class.Value, c => $"GlyphName.{ToPascalCase(c)},")
                .Append(Indent1)
                .AppendLine("];");
        }

        _ = stringBuilder
            .AppendLine()
            .AppendSummary("All classes in a dictionary", Indent1)
            .Append(Indent1)
            .AppendLine("public static IReadOnlyDictionary<ClassName, IReadOnlyList<GlyphName>> AllClasses { get; } = new Dictionary<ClassName, IReadOnlyList<GlyphName>> {");

        foreach (var @class in classes!) {
            _ = stringBuilder
                .Append(Indent2)
                .AppendLine($"[ClassName.{ToPascalCase(@class.Key)}] = [")
                .AppendItems(Indent3, @class.Value, c => $"GlyphName.{ToPascalCase(c)},")
                .Append(Indent2)
                .AppendLine("],");
        }

        _ = stringBuilder
            .Append(Indent1)
            .AppendLine("};");

        _ = stringBuilder
            .AppendLine("}");

        _ = stringBuilder
            .AppendLine()
            .AppendSummary("Provides class mappings")
            .AppendLine("public static class ClassMappings")
            .AppendLine("{");

        _ = stringBuilder
            .AppendSummary("Class name enums to string mappings", Indent1)
            .Append(Indent1)
            .AppendLine("public static IReadOnlyDictionary<ClassName, string> ClassName2StringMap { get; } = new Dictionary<ClassName, string> {")
            .AppendItems(Indent2, classes!.Keys, @class => $"[ClassName.{ToPascalCase(@class)}] = ClassNames.{ToPascalCase(@class)},")
            .Append(Indent1)
            .AppendLine("};");

        _ = stringBuilder
            .AppendLine("}");

        var outputPath = Path.Combine(path, "Classes.cs");
        await File.WriteAllTextAsync(outputPath, stringBuilder.ToString());
    }

    private static StringBuilder AppendSummary(this StringBuilder stringBuilder, string summary, string indent = "")
    {
        return stringBuilder
            .Append(indent)
            .AppendLine("/// <summary>")
            .Append(indent)
            .AppendLine($"/// {summary}.")
            .Append(indent)
            .AppendLine("/// </summary>");
    }

    private static StringBuilder AppendItems(this StringBuilder stringBuilder, string indent, IEnumerable<KeyValuePair<string, GlyphNameInfo>> glyphNames, Func<KeyValuePair<string, GlyphNameInfo>, string> itemString)
    {
        foreach (var glyphName in glyphNames) {
            _ = stringBuilder
                .Append(indent)
                .AppendLine(itemString(glyphName));
        }

        return stringBuilder;
    }

    private static StringBuilder AppendItems(this StringBuilder stringBuilder, string indent, IEnumerable<string> classItems, Func<string, string> itemString)
    {
        foreach (var item in classItems) {
            _ = stringBuilder
                .Append(indent)
                .AppendLine(itemString(item));
        }

        return stringBuilder;
    }

    private static StringBuilder AppendItemsWithSummary(this StringBuilder stringBuilder, string indent, IEnumerable<KeyValuePair<string, GlyphNameInfo>> glyphNames, Func<KeyValuePair<string, GlyphNameInfo>, string> itemString)
    {
        foreach (var glyphName in glyphNames) {
            _ = stringBuilder
                .AppendSummary(glyphName.Value.Description!, indent)
                .Append(indent)
                .AppendLine(itemString(glyphName));
        }

        return stringBuilder;
    }

    private static StringBuilder AppendItemsWithSummary(this StringBuilder stringBuilder, string indent, IEnumerable<KeyValuePair<string, string[]>> classes, Func<KeyValuePair<string, string[]>, string> itemString)
    {
        foreach (var @class in classes) {
            _ = stringBuilder
                .AppendSummary(ToPascalCase(@class.Key), indent)
                .Append(indent)
                .AppendLine(itemString(@class));
        }

        return stringBuilder;
    }

    private static string ToPascalCase(string glyphName)
    {
        return glyphName[0] switch {
            '4' => $"Four{char.ToUpperInvariant(glyphName[1])}{glyphName[2..]}",
            '6' => $"Six{char.ToUpperInvariant(glyphName[1])}{glyphName[2..]}",
            _ => $"{char.ToUpperInvariant(glyphName[0])}{glyphName[1..]}"
        };
    }

    private static string Escape(string s) => s.Replace("\"", "\\\"");
}
