using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions.Analyzers.Xunit;

namespace FluentAssertions.Analyzers.Tests.Tips
{
    [TestClass]
    public class XunitTests
    {
        [DataTestMethod]
        [DataRow("Assert.True(actual);")]
        [DataRow("Assert.True(actual, \"because it's possible\");")]
        [DataRow("Assert.True(bool.Parse(\"true\"));")]
        [DataRow("Assert.True(bool.Parse(\"true\"), \"because it's possible\");")]
        [Implemented]
        public void AssertTrue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertTrueAnalyzer>("bool actual", assertion);

        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.True(actual);",
            /* newAssertion: */ "actual.Should().BeTrue();")]
        [DataRow(
            /* oldAssertion: */ "Assert.True(actual, \"because it's possible\");",
            /* newAssertion: */ "actual.Should().BeTrue(\"because it's possible\");")]
        [DataRow(
            /* oldAssertion: */ "Assert.True(bool.Parse(\"true\"));",
            /* newAssertion: */ "bool.Parse(\"true\").Should().BeTrue();")]
        [DataRow(
            /* oldAssertion: */ "Assert.True(bool.Parse(\"true\"), \"because it's possible\");",
            /* newAssertion: */ "bool.Parse(\"true\").Should().BeTrue(\"because it's possible\");")]
        [Implemented]
        public void AssertTrue_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertTrueCodeFix, AssertTrueAnalyzer>("bool actual", oldAssertion, newAssertion);

        [DataTestMethod]
        [DataRow("Assert.False(actual);")]
        [DataRow("Assert.False(actual, \"because it's possible\");")]
        [DataRow("Assert.False(bool.Parse(\"false\"));")]
        [DataRow("Assert.False(bool.Parse(\"false\"), \"because it's possible\");")]
        [Implemented]
        public void AssertFalse_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertFalseAnalyzer>("bool actual", assertion);

        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.False(actual);",
            /* newAssertion: */ "actual.Should().BeFalse();")]
        [DataRow(
            /* oldAssertion: */ "Assert.False(actual, \"because it's possible\");",
            /* newAssertion: */ "actual.Should().BeFalse(\"because it's possible\");")]
        [DataRow(
            /* oldAssertion: */ "Assert.False(bool.Parse(\"false\"));",
            /* newAssertion: */ "bool.Parse(\"false\").Should().BeFalse();")]
        [DataRow(
            /* oldAssertion: */ "Assert.False(bool.Parse(\"false\"), \"because it's possible\");",
            /* newAssertion: */ "bool.Parse(\"false\").Should().BeFalse(\"because it's possible\");")]
        [Implemented]
        public void AssertFalse_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertFalseCodeFix, AssertFalseAnalyzer>("bool actual", oldAssertion, newAssertion);

        private void VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(string methodArguments, string assertion) where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var source = GenerateCode.XunitAssertion(methodArguments, assertion);

            var type = typeof(TDiagnosticAnalyzer);
            var diagnosticId = (string)type.GetField("DiagnosticId").GetValue(null);
            var message = (string)type.GetField("Message").GetValue(null);

            DiagnosticVerifier.VerifyCSharpDiagnosticUsingAllAnalyzers(source, new DiagnosticResult
            {
                Id = diagnosticId,
                Message = message,
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 12, 13)
                },
                Severity = DiagnosticSeverity.Info
            });
        }

        private void VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>(string methodArguments, string oldAssertion, string newAssertion)
            where TCodeFixProvider : Microsoft.CodeAnalysis.CodeFixes.CodeFixProvider, new()
            where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var oldSource = GenerateCode.XunitAssertion(methodArguments, oldAssertion);
            var newSource = GenerateCode.XunitAssertion(methodArguments, newAssertion);

            DiagnosticVerifier.VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>(oldSource, newSource);
        }
    }
}
