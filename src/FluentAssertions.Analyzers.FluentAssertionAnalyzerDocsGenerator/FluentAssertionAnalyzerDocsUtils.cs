using System;
using System.IO;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

public static class FluentAssertionAnalyzerDocsUtils
{
    private static readonly string _fluentAssertionsAnalyzersDocs = "FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs";
    private static readonly string _fluentAssertionsAnalyzersDocsDirectory = Path.Combine("..", _fluentAssertionsAnalyzersDocs);
    private static readonly string _fluentAssertionsAnalyzersProjectPath = Path.Combine(_fluentAssertionsAnalyzersDocsDirectory, _fluentAssertionsAnalyzersDocs + ".csproj");
    private static readonly char _unixDirectorySeparator = '/';
    private static readonly string _unixNewLine = "\n";

    public static string ReplaceStackTrace(string messageIncludingStacktrace)
    {
        var currentFullPath = Path.GetFullPath(_fluentAssertionsAnalyzersDocsDirectory) + Path.DirectorySeparatorChar;
        var repoRootIndex = currentFullPath.LastIndexOf(Path.DirectorySeparatorChar + "fluentassertions.analyzers" + Path.DirectorySeparatorChar, StringComparison.Ordinal);
        var unixFullPath = currentFullPath
            .Replace(currentFullPath.Substring(0, repoRootIndex), "/Users/runner/work")
            .Replace(Path.DirectorySeparatorChar, _unixDirectorySeparator);

        return messageIncludingStacktrace
            .Replace(currentFullPath, unixFullPath)
            .Replace(Environment.NewLine, _unixNewLine);
    }
}
