using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.BestPractices.Tests
{
    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        [AssertionDiagnostic("actual.ContainsKey(expected).Should().BeTrue();")]
        [NotImplemented]
        public void DictionaryShouldContainKey_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<DictionaryShouldContainKeyAnalyzer>(assertion);

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.ContainsKey(expected).Should().BeTrue();",
            newAssertion: "actual.Should().ContainKey(expected);")]
        [NotImplemented]
        public void DictionaryShouldContainKey_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<DictionaryShouldContainKeyCodeFix, DictionaryShouldContainKeyAnalyzer>(oldAssertion, newAssertion);

        [TestMethod]
        [AssertionDiagnostic("actual.ContainsKey(expected).Should().BeFalse();")]
        [NotImplemented]
        public void DictionaryShouldNotContainKey_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<DictionaryShouldNotContainKeyAnalyzer>(assertion);

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.ContainsKey(expected).Should().BeFalse();",
            newAssertion: "actual.Should().NotContainKey(expected);")]
        [NotImplemented]
        public void DictionaryShouldNotContainKey_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<DictionaryShouldNotContainKeyCodeFix, DictionaryShouldNotContainKeyAnalyzer>(oldAssertion, newAssertion);

        [TestMethod]
        [AssertionDiagnostic("actual.ContainsValue(expected).Should().BeTrue();")]
        [NotImplemented]
        public void DictionaryShouldContainValue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<DictionaryShouldContainValueAnalyzer>(assertion);

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.ContainsValue(expected).Should().BeTrue();",
            newAssertion: "actual.Should().ContainValue(expected);")]
        [NotImplemented]
        public void DictionaryShouldContainValue_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<DictionaryShouldContainValueCodeFix, DictionaryShouldContainValueAnalyzer>(oldAssertion, newAssertion);

        [TestMethod]
        [AssertionDiagnostic("actual.ContainsValue(expected).Should().BeFalse();")]
        [NotImplemented]
        public void DictionaryShouldNotContainValue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<DictionaryShouldNotContainValueAnalyzer>(assertion);

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.ContainsValue(expected).Should().BeFalse();",
            newAssertion: "actual.Should().NotContainValue(expected);")]
        [NotImplemented]
        public void DictionaryShouldNotContainValue_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<DictionaryShouldNotContainValueCodeFix, DictionaryShouldNotContainValueAnalyzer>(oldAssertion, newAssertion);

        [TestMethod]
        [AssertionDiagnostic("actual.Should().ContainKey(expectedKey).And.ContainValue(expectedValue);")]
        [NotImplemented]
        public void DictionaryShouldContainKeyAndValue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<DictionaryShouldContainKeyAndValueAnalyzer>(assertion);

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().ContainKey(expectedKey).And.ContainValue(expectedValue);",
            newAssertion: "actual.Should().Contain(expectedKey, expectedValue);")]
        [NotImplemented]
        public void DictionaryShouldContainKeyAndValue_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<DictionaryShouldContainKeyAndValueCodeFix, DictionaryShouldContainKeyAndValueAnalyzer>(oldAssertion, newAssertion);

        [TestMethod]
        [AssertionDiagnostic("actual.Should().ContainKey(expected.Key).And.ContainValue(expected.Value);")]
        [NotImplemented]
        public void DictionaryShouldContainPair_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<DictionaryShouldContainPairAnalyzer>(assertion);

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().ContainKey(expected.Key).And.ContainValue(expected.Value);",
            newAssertion: "actual.Should().Contain(expected);")]
        [NotImplemented]
        public void DictionaryShouldContainPair_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<DictionaryShouldContainPairCodeFix, DictionaryShouldContainPairAnalyzer>(oldAssertion, newAssertion);

        private void VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(string sourceAssersion) where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var source = GenerateCode.DictionaryAssertion(sourceAssersion);

            var type = typeof(TDiagnosticAnalyzer);
            var diagnosticId = (string)type.GetField("DiagnosticId").GetValue(null);
            var message = (string)type.GetField("Message").GetValue(null);

            DiagnosticVerifier.VerifyCSharpDiagnosticUsingAllAnalyzers(source, new DiagnosticResult
            {
                Id = diagnosticId,
                Message = string.Format(message, GenerateCode.ActualVariableName),
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 11,13)
                },
                Severity = DiagnosticSeverity.Info
            });
        }

        private void VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>(string oldSourceAssertion, string newSourceAssertion)
            where TCodeFixProvider : Microsoft.CodeAnalysis.CodeFixes.CodeFixProvider, new()
            where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var oldSource = GenerateCode.DictionaryAssertion(oldSourceAssertion);
            var newSource = GenerateCode.DictionaryAssertion(newSourceAssertion);

            DiagnosticVerifier.VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>(oldSource, newSource);
        }
    }
}