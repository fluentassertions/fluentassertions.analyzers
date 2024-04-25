using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

public static class FluentAssertionAnalyzerDocsUtils
{
    private static readonly string _fluentAssertionsAnalyzersDocs = "FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs";
    private static readonly string _fluentAssertionsAnalyzersDocsDirectory = Path.Combine("..", _fluentAssertionsAnalyzersDocs);
    private static readonly string _fluentAssertionsAnalyzersProjectPath = Path.Combine(_fluentAssertionsAnalyzersDocsDirectory, _fluentAssertionsAnalyzersDocs + ".csproj");
    private static readonly char _unixDirectorySeparator = '/';

    public static async Task<Compilation> GetFluentAssertionAnalyzerDocsCompilation()
    {
        MSBuildLocator.RegisterDefaults();

        using var workspace = MSBuildWorkspace.Create();

        var project = await workspace.OpenProjectAsync(_fluentAssertionsAnalyzersProjectPath);

        return await project.GetCompilationAsync();
    }

    public static string ReplaceStackTrace(string messageIncludingStacktrace)
    {
        var currentFullPath = Path.GetFullPath(_fluentAssertionsAnalyzersDocsDirectory) + Path.DirectorySeparatorChar;
        var repoRootIndex = currentFullPath.LastIndexOf(Path.DirectorySeparatorChar + "fluentassertions.analyzers" + Path.DirectorySeparatorChar, StringComparison.Ordinal);
        var unixFullPath = currentFullPath
            .Replace(currentFullPath.Substring(0, repoRootIndex), "/Users/runner/work")
            .Replace(Path.DirectorySeparatorChar, _unixDirectorySeparator);

        return messageIncludingStacktrace.Replace(currentFullPath, unixFullPath);
    }
}
