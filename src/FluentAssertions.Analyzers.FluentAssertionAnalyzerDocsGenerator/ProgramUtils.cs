using System;
using System.Threading.Tasks;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

public static class ProgramUtils
{
    public static Task RunMain<TDocsGenerator, TDocsVerifier>(string[] args)
        where TDocsGenerator : DocsGenerator, new()
        where TDocsVerifier : DocsVerifier, new() => args switch
    {
        ["generate"] => new TDocsGenerator().Execute(),
        ["verify"] => new TDocsVerifier().Execute(),
        _ => throw new ArgumentException("Invalid arguments, use 'generate' or 'verify' as argument.")
    };
}