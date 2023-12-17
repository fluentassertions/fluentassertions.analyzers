using FluentAssertions.Analyzers.TestUtils;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.Tests
{
    [TestClass]
    public class DictionaryTests
    {
        [DataTestMethod]
        [AssertionDiagnostic("actual.ContainsKey(expectedKey).Should().BeTrue({0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).ContainsKey(expectedKey).Should().BeTrue({0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainKey_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.DictionaryShouldContainKey_ContainsKeyShouldBeTrue);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.ContainsKey(expectedKey).Should().BeTrue({0});",
            newAssertion: "actual.Should().ContainKey(expectedKey{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).ContainsKey(expectedKey).Should().BeTrue({0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(expectedKey{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainKey_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<FluentAssertionsCodeFix, FluentAssertionsOperationAnalyzer>(oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("actual.ContainsKey(expectedKey).Should().BeFalse({0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).ContainsKey(expectedKey).Should().BeFalse({0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldNotContainKey_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.DictionaryShouldNotContainKey_ContainsKeyShouldBeFalse);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.ContainsKey(expectedKey).Should().BeFalse({0});",
            newAssertion: "actual.Should().NotContainKey(expectedKey{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).ContainsKey(expectedKey).Should().BeFalse({0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().NotContainKey(expectedKey{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldNotContainKey_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<FluentAssertionsCodeFix, FluentAssertionsOperationAnalyzer>(oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("actual.ContainsValue(expectedValue).Should().BeTrue({0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).ContainsValue(expectedValue).Should().BeTrue({0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainValue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.DictionaryShouldContainValue_ContainsValueShouldBeTrue);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.ContainsValue(expectedValue).Should().BeTrue({0});",
            newAssertion: "actual.Should().ContainValue(expectedValue{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).ContainsValue(expectedValue).Should().BeTrue({0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainValue(expectedValue{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainValue_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<FluentAssertionsCodeFix, FluentAssertionsOperationAnalyzer>(oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("actual.ContainsValue(expectedValue).Should().BeFalse({0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).ContainsValue(expectedValue).Should().BeFalse({0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldNotContainValue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.DictionaryShouldNotContainValue_ContainsValueShouldBeFalse);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.ContainsValue(expectedValue).Should().BeFalse({0});",
            newAssertion: "actual.Should().NotContainValue(expectedValue{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).ContainsValue(expectedValue).Should().BeFalse({0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().NotContainValue(expectedValue{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldNotContainValue_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<FluentAssertionsCodeFix, FluentAssertionsOperationAnalyzer>(oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("actual.Should().ContainKey(expectedKey{0}).And.ContainValue(expectedValue);")]
        [AssertionDiagnostic("actual.Should().ContainKey(expectedKey).And.ContainValue(expectedValue{0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(expectedKey{0}).And.ContainValue(expectedValue).And.ToString();")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(expectedKey).And.ContainValue(expectedValue{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainKeyAndValue_ShouldContainKeyAndContainValue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.DictionaryShouldContainKeyAndValue_ShouldContainKeyAndContainValue);

        [DataTestMethod]
        [AssertionDiagnostic("actual.Should().ContainValue(expectedValue{0}).And.ContainKey(expectedKey);")]
        [AssertionDiagnostic("actual.Should().ContainValue(expectedValue).And.ContainKey(expectedKey{0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainValue(expectedValue{0}).And.ContainKey(expectedKey).And.ToString();")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainValue(expectedValue).And.ContainKey(expectedKey{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainKeyAndValue_ShouldContainValueAndContainKey_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.DictionaryShouldContainKeyAndValue_ShouldContainValueAndContainKey);

        [DataTestMethod]
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
        [AssertionCodeFix(
            oldAssertion: "actual.Should().ContainValue(expectedValue{0}).And.ContainKey(expectedKey);",
            newAssertion: "actual.Should().Contain(expectedKey, expectedValue{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainValue(expectedValue).And.ContainKey(expectedKey{0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().Contain(expectedKey, expectedValue{0}).And.ToString();")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().ContainValue(expectedValue).And.ContainKey(expectedKey{0});",
            newAssertion: "actual.Should().Contain(expectedKey, expectedValue{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainValue(expectedValue{0}).And.ContainKey(expectedKey).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().Contain(expectedKey, expectedValue{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainKeyAndValue_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<FluentAssertionsCodeFix, FluentAssertionsOperationAnalyzer>(oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("actual.Should().ContainKey(pair.Key{0}).And.ContainValue(pair.Value);")]
        [AssertionDiagnostic("actual.Should().ContainKey(pair.Key).And.ContainValue(pair.Value{0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(pair.Key{0}).And.ContainValue(pair.Value).And.ToString();")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(pair.Key).And.ContainValue(pair.Value{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainPair_ShouldContainKeyAndContainValue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.DictionaryShouldContainPair_ShouldContainKeyAndContainValue);

        [DataTestMethod]
        [AssertionDiagnostic("actual.Should().ContainValue(pair.Value{0}).And.ContainKey(pair.Key);")]
        [AssertionDiagnostic("actual.Should().ContainValue(pair.Value).And.ContainKey(pair.Key{0});")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainValue(pair.Value{0}).And.ContainKey(pair.Key).And.ToString();")]
        [AssertionDiagnostic("actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainValue(pair.Value).And.ContainKey(pair.Key{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainPair_ShouldContainValueAndContainKey_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.DictionaryShouldContainPair_ShouldContainValueAndContainKey);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().ContainKey(pair.Key{0}).And.ContainValue(pair.Value);",
            newAssertion: "actual.Should().Contain(pair{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(pair.Key{0}).And.ContainValue(pair.Value).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().Contain(pair{0}).And.ToString();")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().ContainKey(pair.Key).And.ContainValue(pair.Value{0});",
            newAssertion: "actual.Should().Contain(pair{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainKey(pair.Key).And.ContainValue(pair.Value{0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().Contain(pair{0}).And.ToString();")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().ContainValue(pair.Value{0}).And.ContainKey(pair.Key);",
            newAssertion: "actual.Should().Contain(pair{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainValue(pair.Value{0}).And.ContainKey(pair.Key).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().Contain(pair{0}).And.ToString();")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().ContainValue(pair.Value).And.ContainKey(pair.Key{0});",
            newAssertion: "actual.Should().Contain(pair{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().ContainValue(pair.Value).And.ContainKey(pair.Key{0}).And.ToString();",
            newAssertion: "actual.ToDictionary(p => p.Key, p=> p.Value).Should().Contain(pair{0}).And.ToString();")]
        [Implemented]
        public void DictionaryShouldContainPair_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<FluentAssertionsCodeFix, FluentAssertionsOperationAnalyzer>(oldAssertion, newAssertion);

        private void VerifyCSharpDiagnostic(string sourceAssersion, DiagnosticMetadata metadata)
        {
            var source = GenerateCode.GenericIDictionaryAssertion(sourceAssersion);

            DiagnosticVerifier.VerifyCSharpDiagnosticUsingAllAnalyzers(source, new DiagnosticResult
            {
                Id = FluentAssertionsOperationAnalyzer.DiagnosticId,
                Message = metadata.Message,
                VisitorName = metadata.Name,
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 12,13)
                },
                Severity = DiagnosticSeverity.Info
            });
        }

        private void VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>(string oldSourceAssertion, string newSourceAssertion)
            where TCodeFixProvider : Microsoft.CodeAnalysis.CodeFixes.CodeFixProvider, new()
            where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var oldSource = GenerateCode.GenericIDictionaryAssertion(oldSourceAssertion);
            var newSource = GenerateCode.GenericIDictionaryAssertion(newSourceAssertion);

            DiagnosticVerifier.VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>(oldSource, newSource);
        }
    }
}