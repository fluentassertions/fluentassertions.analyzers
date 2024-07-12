using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FluentAssertions.Analyzers.TestUtils;

public class CsProjectArguments
{
    public TargetFramework TargetFramework { get; set; } = TargetFramework.Net8_0;
    public string[] Sources { get; set; }
    public PackageReference[] PackageReferences { get; set; } = Array.Empty<PackageReference>();
    public string Language { get; set; } = LanguageNames.CSharp;
    public Dictionary<string, string> AnalyzerConfigOptions { get; } = new();

    public AnalyzerConfigOptionsProvider CreateAnalyzerConfigOptionsProvider() => new TestAnalyzerConfigOptionsProvider(AnalyzerConfigOptions);
}

public static class CsProjectArgumentsExtensions
{
    public static TCsProjectArguments WithTargetFramework<TCsProjectArguments>(this TCsProjectArguments arguments, TargetFramework targetFramework) where TCsProjectArguments : CsProjectArguments
    {
        arguments.TargetFramework = targetFramework;
        return arguments;
    }

    public static TCsProjectArguments WithSources<TCsProjectArguments>(this TCsProjectArguments arguments, params string[] sources) where TCsProjectArguments : CsProjectArguments
    {
        arguments.Sources = sources;
        return arguments;
    }

    public static TCsProjectArguments WithPackageReferences<TCsProjectArguments>(this TCsProjectArguments arguments, params PackageReference[] packageReferences) where TCsProjectArguments : CsProjectArguments
    {
        arguments.PackageReferences = packageReferences;
        return arguments;
    }

    public static TCsProjectArguments WithAnalyzerConfigOption<TCsProjectArguments>(this TCsProjectArguments arguments, string name, string value) where TCsProjectArguments : CsProjectArguments
    {
        arguments.AnalyzerConfigOptions[name] = value;
        return arguments;
    }
}