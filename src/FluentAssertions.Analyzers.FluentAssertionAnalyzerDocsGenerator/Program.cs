using System;
using System.Threading.Tasks;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

public class Program
{
    public static Task Main(string[] args) => args switch
    {
        ["generate"] => new DocsGenerator().Execute(),
        ["verify"] => new DocsVerifier().Execute(),
        _ => throw new ArgumentException("Invalid arguments, use 'generate' or 'verify' as argument.")
    };
}