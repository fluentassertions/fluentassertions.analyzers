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
            ProgramUtils.RunMain<Nunit3DocsGenerator, Nunit3DocsVerifier>(args),
            ProgramUtils.RunMain<MsTestDocsGenerator, MsTestDocsVerifier>(args),
            ProgramUtils.RunMain<FluentAssertionsDocsGenerator, FluentAssertionsDocsVerifier>(args)
        );
    }

    private abstract class BaseDocsDocsGenerator : DocsGenerator
    {
        protected override Assembly TestAssembly { get; } = typeof(Program).Assembly;
        protected override string TestAttribute => "TestMethod"; // Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute
    }

    private class Nunit3DocsGenerator : BaseDocsDocsGenerator
    {
        protected override string TestFile => Path.Join(Environment.CurrentDirectory, "Nunit3AnalyzerTests.cs");

        protected override void ResetTestFramework()
        {
            var testContext = typeof(NUnit.Framework.Internal.TestExecutionContext);
            testContext.GetProperty("CurrentContext").SetValue(null, new NUnit.Framework.Internal.TestExecutionContext.AdhocContext());

            NUnit.Framework.Internal.TestExecutionContext.CurrentContext.CurrentResult.AssertionResults.Clear();
        }
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

    private class Nunit3DocsVerifier : BaseDocsVerifier
    {
        protected override string TestFile => Path.Join(Environment.CurrentDirectory, "Nunit3AnalyzerTests.cs");
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