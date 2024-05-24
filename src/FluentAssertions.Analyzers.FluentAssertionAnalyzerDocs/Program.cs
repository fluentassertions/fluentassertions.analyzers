using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

public class Program
{
    public static async Task Main(string[] args)
    {
        await Task.WhenAll(
            ProgramUtils.RunMain<MsTestDocsGenerator, MsTestDocsVerifier>(args),
            ProgramUtils.RunMain<FluentAssertionsDocsGenerator, FluentAssertionsDocsVerifier>(args)
        );
    }

    private abstract class BaseDocsDocsGenerator : DocsGenerator
    {
        protected override Assembly TestAssembly { get; } = typeof(Program).Assembly;
        protected override string TestAttribute => "TestMethod"; // Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute
    }

    private class MsTestDocsGenerator : BaseDocsDocsGenerator
    {
        protected override string TestFile => Path.Join(Environment.CurrentDirectory, "MsTestAnalyzerTests.cs");
    }
    private class FluentAssertionsDocsGenerator : BaseDocsDocsGenerator
    {
        protected override string TestFile => Path.Join(Environment.CurrentDirectory, "FluentAssertionsAnalyzerTests.cs");
    }


    private abstract class BaseDocsVerifier : DocsVerifier
    {
        protected override string TestAttribute => "TestMethod"; // Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute
    }

    private class MsTestDocsVerifier : BaseDocsVerifier
    {
        protected override string TestFile => Path.Join(Environment.CurrentDirectory, "MsTestAnalyzerTests.cs");
    }
    private class FluentAssertionsDocsVerifier : BaseDocsVerifier
    {
        protected override string TestFile => Path.Join(Environment.CurrentDirectory, "FluentAssertionsAnalyzerTests.cs");
    }
}