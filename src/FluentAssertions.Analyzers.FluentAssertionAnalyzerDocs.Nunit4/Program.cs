using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

public class Program
{
    public static Task Main(string[] args) => new Nunit4DocsGenerator().Execute();

    private class Nunit4DocsGenerator : DocsGenerator
    {
        protected override Assembly TestAssembly { get; } = typeof(Program).Assembly;
        protected override string TestAttribute => "Test"; // NUnit.Framework.TestAttribute
        protected override string TestFile => Path.Join(Environment.CurrentDirectory, "Nunit4AnalyzerTests.cs");

        protected override void ResetTestFramework()
        {
            var testContext = typeof(NUnit.Framework.Internal.TestExecutionContext);
            testContext.GetProperty("CurrentContext").SetValue(null, new NUnit.Framework.Internal.TestExecutionContext.AdhocContext());

            NUnit.Framework.Internal.TestExecutionContext.CurrentContext.CurrentResult.AssertionResults.Clear();
        }
    }
}