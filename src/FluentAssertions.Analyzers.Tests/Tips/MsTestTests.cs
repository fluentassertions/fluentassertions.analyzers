using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.Tests.Tips
{
    [TestClass]
    public class MsTestTests
    {
        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.IsTrue(actual{0});")]
        [AssertionDiagnostic("Assert.IsTrue(bool.Parse(\"true\"){0});")]
        [Implemented]
        public void AssertIsTrue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertIsTrueAnalyzer>("bool actual", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsTrue(actual{0});",
            newAssertion: "actual.Should().BeTrue({0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsTrue(bool.Parse(\"true\"){0});",
            newAssertion: "bool.Parse(\"true\").Should().BeTrue({0});")]
        [Implemented]
        public void AssertIsTrue_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertIsTrueCodeFix, AssertIsTrueAnalyzer>("bool actual", oldAssertion, newAssertion);

        private void VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(string methodArguments, string assertion) where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var source = GenerateCode.MsTestAssertion(methodArguments, assertion);

            var type = typeof(TDiagnosticAnalyzer);
            var diagnosticId = (string)type.GetField("DiagnosticId").GetValue(null);
            var message = (string)type.GetField("Message").GetValue(null);

            DiagnosticVerifier.VerifyCSharpDiagnosticUsingAllAnalyzers(source, new DiagnosticResult
            {
                Id = diagnosticId,
                Message = message,
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 11,13)
                },
                Severity = DiagnosticSeverity.Info
            });
        }

        private void VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>(string methodArguments, string oldAssertion, string newAssertion)
            where TCodeFixProvider : Microsoft.CodeAnalysis.CodeFixes.CodeFixProvider, new()
            where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var oldSource = GenerateCode.MsTestAssertion(methodArguments, oldAssertion);
            var newSource = GenerateCode.MsTestAssertion(methodArguments, newAssertion);

            DiagnosticVerifier.VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>(oldSource, newSource);
        }
    }
}
