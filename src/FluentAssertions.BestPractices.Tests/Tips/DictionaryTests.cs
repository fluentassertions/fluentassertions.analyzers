using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.BestPractices.Tests
{
    [TestClass]
    public class DictionaryTests
    {
        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.ContainsKey(expectedKey).Should().BeTrue({0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).ContainsKey(expectedKey).Should().BeTrue({0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainKey_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<DictionaryShouldContainKeyAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.ContainsKey(expectedKey).Should().BeTrue({0});",
            newAssertion: "actual.Should().ContainKey(expectedKey{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).ContainsKey(expectedKey).Should().BeTrue({0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(expectedKey{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainKey_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<DictionaryShouldContainKeyCodeFix, DictionaryShouldContainKeyAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.ContainsKey(expectedKey).Should().BeFalse({0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).ContainsKey(expectedKey).Should().BeFalse({0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldNotContainKey_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<DictionaryShouldNotContainKeyAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.ContainsKey(expectedKey).Should().BeFalse({0});",
            newAssertion: "actual.Should().NotContainKey(expectedKey{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).ContainsKey(expectedKey).Should().BeFalse({0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().NotContainKey(expectedKey{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldNotContainKey_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<DictionaryShouldNotContainKeyCodeFix, DictionaryShouldNotContainKeyAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.ContainsValue(expectedValue).Should().BeTrue({0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).ContainsValue(expectedValue).Should().BeTrue({0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainValue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<DictionaryShouldContainValueAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.ContainsValue(expectedValue).Should().BeTrue({0});",
            newAssertion: "actual.Should().ContainValue(expectedValue{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).ContainsValue(expectedValue).Should().BeTrue({0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainValue(expectedValue{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainValue_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<DictionaryShouldContainValueCodeFix, DictionaryShouldContainValueAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.ContainsValue(expectedValue).Should().BeFalse({0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).ContainsValue(expectedValue).Should().BeFalse({0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldNotContainValue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<DictionaryShouldNotContainValueAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.ContainsValue(expectedValue).Should().BeFalse({0});",
            newAssertion: "actual.Should().NotContainValue(expectedValue{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).ContainsValue(expectedValue).Should().BeFalse({0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().NotContainValue(expectedValue{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldNotContainValue_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<DictionaryShouldNotContainValueCodeFix, DictionaryShouldNotContainValueAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Should().ContainKey(expectedKey{0}).And.ContainValue(expectedValue{0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(expectedKey{0}).And.ContainValue(expectedValue{0}).And.ToString();")]
        [NotImplemented]
        public void DictionaryShouldContainKeyAndValue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<DictionaryShouldContainKeyAndValueAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().ContainKey(expectedKey{0}).And.ContainValue(expectedValue);",
            newAssertion: "actual.Should().Contain(expectedKey, expectedValue{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(expectedKey{0}).And.ContainValue(expectedValue).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().Contain(expectedKey, expectedValue{0}).And.ToString();")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().ContainKey(expectedKey).And.ContainValue(expectedValue{0});",
            newAssertion: "actual.Should().Contain(expectedKey, expectedValue{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(expectedKey).And.ContainValue(expectedValue{0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().Contain(expectedKey, expectedValue{0}).And.ToString();")]
        [NotImplemented]
        public void DictionaryShouldContainKeyAndValue_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<DictionaryShouldContainKeyAndValueCodeFix, DictionaryShouldContainKeyAndValueAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Should().ContainKey(expected.Key{0}).And.ContainValue(expected.Value);")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(expected.Key{0}).And.ContainValue(expected.Value).And.ToString();")]
        [NotImplemented]
        public void DictionaryShouldContainPair_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<DictionaryShouldContainPairAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().ContainKey(expected.Key{0}).And.ContainValue(expected.Value);",
            newAssertion: "actual.Should().Contain(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(expected.Key{0}).And.ContainValue(expected.Value).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().Contain(expected{0}).And.ToString();")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().ContainKey(expected.Key).And.ContainValue(expected.Value{0});",
            newAssertion: "actual.Should().Contain(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(expected.Key).And.ContainValue(expected.Value{0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().Contain(expected{0}).And.ToString();")]
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