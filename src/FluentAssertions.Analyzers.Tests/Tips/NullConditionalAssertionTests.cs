using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace FluentAssertions.Analyzers.Tests.Tips
{
    [TestClass]
    public class NullConditionalAssertionTests
    {
        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual?.Should().Be(expected{0});")]
        [AssertionDiagnostic("actual?.MyProperty.Should().Be(\"test\"{0});")]
        [AssertionDiagnostic("actual.MyProperty?.Should().Be(\"test\"{0});")]
        [AssertionDiagnostic("(actual.MyProperty)?.Should().Be(\"test\"{0});")]
        [AssertionDiagnostic("(actual?.MyProperty)?.Should().Be(\"test\"{0});")]
        [AssertionDiagnostic("((actual?.MyProperty)?.Should().Be(\"test\"{0})).And.NotBe(\"alternative\");")]
        [Implemented]
        public void NullConditionalMayNotExecuteTest(string assertion) => VerifyCSharpDiagnostic(assertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("(actual?.MyProperty).Should().Be(\"test\"{0});")]
        [AssertionDiagnostic("((actual?.MyProperty).Should().Be(\"test\"{0})).And.NotBe(\"alternative\");")]
        [Implemented]
        public void NullConditionalWillStillExecuteTest(string assertion) => VerifyCSharpDiagnosticPass(assertion);

        private static string Code(string assertion) =>
            new StringBuilder()
                .AppendLine("using System;")
                .AppendLine("using FluentAssertions;using FluentAssertions.Extensions;")
                .AppendLine("namespace TestNamespace")
                .AppendLine("{")
                .AppendLine("    class TestClass")
                .AppendLine("    {")
                .AppendLine("        void TestMethod(MyClass actual, MyClass expected)")
                .AppendLine("        {")
                .AppendLine($"            {assertion}")
                .AppendLine("        }")
                .AppendLine("    }")
                .AppendLine("    class MyClass")
                .AppendLine("    {")
                .AppendLine("        public string MyProperty { get; set; }")
                .AppendLine("    }")
                .AppendLine("    class Program")
                .AppendLine("    {")
                .AppendLine("        public static void Main()")
                .AppendLine("        {")
                .AppendLine("        }")
                .AppendLine("    }")
                .AppendLine("}")
                .ToString();

        private static void VerifyCSharpDiagnosticPass(string assertion)
            => DiagnosticVerifier.VerifyCSharpDiagnostic<NullConditionalAssertionAnalyzer>(Code(assertion));

        private static void VerifyCSharpDiagnostic(string assertion)
            => DiagnosticVerifier.VerifyCSharpDiagnostic<NullConditionalAssertionAnalyzer>(Code(assertion), new DiagnosticResult
            {
                Id = NullConditionalAssertionAnalyzer.DiagnosticId,
                Message = NullConditionalAssertionAnalyzer.Message,
                Severity = Microsoft.CodeAnalysis.DiagnosticSeverity.Warning,
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 9, 13)
                }
            });
    }
}
