using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

public class Program
{
    public static Task Main(string[] args) => ProgramUtils.RunMain<XunitDocsGenerator, XunitDocsVerifier>(args);

    private class XunitDocsGenerator : DocsGenerator
    {
        protected override Assembly TestAssembly { get; } = typeof(Program).Assembly;
        protected override string TestAttribute => "Fact"; // Xunit.FactAttribute
        protected override string TestFile => Path.Join(Environment.CurrentDirectory, "XunitAnalyzerTests.cs");
    }
    private class XunitDocsVerifier : DocsVerifier
    {
        protected override string TestAttribute => "Fact"; // Xunit.FactAttribute
        protected override string TestFile => Path.Join(Environment.CurrentDirectory, "XunitAnalyzerTests.cs");
    }
}