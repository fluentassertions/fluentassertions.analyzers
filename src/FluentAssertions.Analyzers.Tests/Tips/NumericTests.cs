using FluentAssertions.Analyzers.TestUtils;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.Tests
{
    [TestClass]
    public class NumericTests
    {
        [DataTestMethod]
        [AssertionDiagnostic("actual.Should().BeGreaterThan(0{0});")]
        [AssertionDiagnostic("actual.Should().BeGreaterThan(0{0}).ToString();")]
        [Implemented]
        public void NumericShouldBePositive_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.NumericShouldBePositive_ShouldBeGreaterThan);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().BeGreaterThan(0{0});",
            newAssertion: "actual.Should().BePositive({0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().BeGreaterThan(0{0}).ToString();",
            newAssertion: "actual.Should().BePositive({0}).ToString();")]
        [Implemented]
        public void NumericShouldBePositive_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix(oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("actual.Should().BeLessThan(0{0});")]
        [AssertionDiagnostic("actual.Should().BeLessThan(0{0}).ToString();")]
        [Implemented]
        public void NumericShouldBeNegative_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.NumericShouldBeNegative_ShouldBeLessThan);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().BeLessThan(0{0});",
            newAssertion: "actual.Should().BeNegative({0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().BeLessThan(0{0}).ToString();",
            newAssertion: "actual.Should().BeNegative({0}).ToString();")]
        [Implemented]
        public void NumericShouldBeNegative_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix(oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("actual.Should().BeGreaterOrEqualTo(lower{0}).And.BeLessOrEqualTo(upper);")]
        [AssertionDiagnostic("actual.Should().BeGreaterOrEqualTo(lower).And.BeLessOrEqualTo(upper{0});")]
        [Implemented]
        public void NumericShouldBeInRange_BeGreaterOrEqualToAndBeLessOrEqualTo_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.NumericShouldBeInRange_BeGreaterOrEqualToAndBeLessOrEqualTo);

        [DataTestMethod]
        [AssertionDiagnostic("actual.Should().BeLessOrEqualTo(upper{0}).And.BeGreaterOrEqualTo(lower);")]
        [AssertionDiagnostic("actual.Should().BeLessOrEqualTo(upper).And.BeGreaterOrEqualTo(lower{0});")]
        [Implemented]
        public void NumericShouldBeInRange_BeLessOrEqualToAndBeGreaterOrEqualTo_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.NumericShouldBeInRange_BeLessOrEqualToAndBeGreaterOrEqualTo);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().BeGreaterOrEqualTo(lower{0}).And.BeLessOrEqualTo(upper);",
            newAssertion: "actual.Should().BeInRange(lower, upper{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().BeGreaterOrEqualTo(lower).And.BeLessOrEqualTo(upper{0});",
            newAssertion: "actual.Should().BeInRange(lower, upper{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().BeLessOrEqualTo(upper{0}).And.BeGreaterOrEqualTo(lower);",
            newAssertion: "actual.Should().BeInRange(lower, upper{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().BeLessOrEqualTo(upper).And.BeGreaterOrEqualTo(lower{0});",
            newAssertion: "actual.Should().BeInRange(lower, upper{0});")]
        [NotImplemented]
        public void NumericShouldBeInRange_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix(oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Math.Abs(expected - actual).Should().BeLessOrEqualTo(delta{0});")]
        [Implemented]
        public void NumericShouldBeApproximately_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion, DiagnosticMetadata.NumericShouldBeApproximately_MathAbsShouldBeLessOrEqualTo);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Math.Abs(expected - actual).Should().BeLessOrEqualTo(delta{0});",
            newAssertion: "actual.Should().BeApproximately(expected, delta{0});")]
        [Implemented]
        public void NumericShouldBeApproximately_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix(oldAssertion, newAssertion);

        private void VerifyCSharpDiagnostic(string sourceAssertion, DiagnosticMetadata metadata)
        {
            VerifyCSharpDiagnostic(sourceAssertion, metadata, "double");
            VerifyCSharpDiagnostic(sourceAssertion, metadata, "float");
            VerifyCSharpDiagnostic(sourceAssertion, metadata, "decimal");
        }

        private void VerifyCSharpDiagnostic(string sourceAssertion, DiagnosticMetadata metadata, string numericType)
        {
            var source = GenerateCode.NumericAssertion(sourceAssertion, numericType);

            DiagnosticVerifier.VerifyDiagnostic(new DiagnosticVerifierArguments()
                .WithSources(source)
                .WithAllAnalyzers()
                .WithPackageReferences(PackageReference.FluentAssertions_6_12_0)
                .WithExpectedDiagnostics(new DiagnosticResult
                {
                    Id = FluentAssertionsOperationAnalyzer.DiagnosticId,
                    Message = metadata.Message,
                    VisitorName = metadata.Name,
                    Locations = new DiagnosticResultLocation[]
                    {
                        new DiagnosticResultLocation("Test0.cs", 10, 13)
                    },
                    Severity = DiagnosticSeverity.Info
                })
            );
        }

        private void VerifyCSharpFix(string oldSourceAssertion, string newSourceAssertion)
        {
            VerifyCSharpFix(oldSourceAssertion, newSourceAssertion, "double");
            VerifyCSharpFix(oldSourceAssertion, newSourceAssertion, "float");
            VerifyCSharpFix(oldSourceAssertion, newSourceAssertion, "decimal");
        }

        private void VerifyCSharpFix(string oldSourceAssertion, string newSourceAssertion, string numericType)
        {
            var oldSource = GenerateCode.NumericAssertion(oldSourceAssertion, numericType);
            var newSource = GenerateCode.NumericAssertion(newSourceAssertion, numericType);

            DiagnosticVerifier.VerifyFix(new CodeFixVerifierArguments()
                .WithCodeFixProvider<FluentAssertionsCodeFix>()
                .WithDiagnosticAnalyzer<FluentAssertionsOperationAnalyzer>()
                .WithSources(oldSource)
                .WithFixedSources(newSource)
                .WithPackageReferences(PackageReference.FluentAssertions_6_12_0)
            );
        }
    }
}
