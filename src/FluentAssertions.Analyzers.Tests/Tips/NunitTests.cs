using FluentAssertions.Analyzers.TestUtils;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.Tests.Tips;

[TestClass]
public class NunitTests
{

    [DataTestMethod]
    [AssertionDiagnostic("Assert.True(actual{0});")]
    [AssertionDiagnostic("Assert.True(bool.Parse(\"true\"){0});")]
    [AssertionDiagnostic("Assert.IsTrue(actual{0});")]
    [AssertionDiagnostic("Assert.IsTrue(bool.Parse(\"true\"){0});")]
    [Implemented]
    public void AssertTrue_TestAnalyzer(string assertion) => VerifyDiagnostic("bool actual", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.True(actual{0});",
        newAssertion: "actual.Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.True(bool.Parse(\"true\"){0});",
        newAssertion: "bool.Parse(\"true\").Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.True(!actual{0});",
        newAssertion: "(!actual).Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.True(actual == false{0});",
        newAssertion: "(actual == false).Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsTrue(actual{0});",
        newAssertion: "actual.Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsTrue(bool.Parse(\"true\"){0});",
        newAssertion: "bool.Parse(\"true\").Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsTrue(!actual{0});",
        newAssertion: "(!actual).Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsTrue(actual == false{0});",
        newAssertion: "(actual == false).Should().BeTrue({0});")]
    [Implemented]
    public void AssertTrue_TestCodeFix(string oldAssertion, string newAssertion)
        => VerifyFix("bool actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.False(actual{0});")]
    [AssertionDiagnostic("Assert.False(bool.Parse(\"false\"){0});")]
    [AssertionDiagnostic("Assert.IsFalse(actual{0});")]
    [AssertionDiagnostic("Assert.IsFalse(bool.Parse(\"false\"){0});")]
    [Implemented]
    public void AssertFalse_TestAnalyzer(string assertion) => VerifyDiagnostic("bool actual", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.False(actual{0});",
        newAssertion: "actual.Should().BeFalse({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.False(bool.Parse(\"false\"){0});",
        newAssertion: "bool.Parse(\"false\").Should().BeFalse({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsFalse(actual{0});",
        newAssertion: "actual.Should().BeFalse({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsFalse(bool.Parse(\"false\"){0});",
        newAssertion: "bool.Parse(\"false\").Should().BeFalse({0});")]
    [Implemented]
    public void AssertFalse_TestCodeFix(string oldAssertion, string newAssertion)
        => VerifyFix("bool actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.Null(actual{0});")]
    [AssertionDiagnostic("Assert.IsNull(actual{0});")]
    [Implemented]
    public void AssertNull_TestAnalyzer(string assertion) => VerifyDiagnostic("object actual", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.Null(actual{0});",
        newAssertion: "actual.Should().BeNull({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsNull(actual{0});",
        newAssertion: "actual.Should().BeNull({0});")]
    [Implemented]
    public void AssertNull_TestCodeFix(string oldAssertion, string newAssertion)
        => VerifyFix("object actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.NotNull(actual{0});")]
    [AssertionDiagnostic("Assert.IsNotNull(actual{0});")]
    [Implemented]
    public void AssertNotNull_TestAnalyzer(string assertion) => VerifyDiagnostic("object actual", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.NotNull(actual{0});",
        newAssertion: "actual.Should().NotBeNull({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsNotNull(actual{0});",
        newAssertion: "actual.Should().NotBeNull({0});")]
    [Implemented]
    public void AssertNotNull_TestCodeFix(string oldAssertion, string newAssertion)
        => VerifyFix("object actual", oldAssertion, newAssertion);

    private void VerifyDiagnostic(string methodArguments, string assertion)
    {
        var source = GenerateCode.Nunit3Assertion(methodArguments, assertion);
        DiagnosticVerifier.VerifyDiagnostic(new DiagnosticVerifierArguments()
            .WithAllAnalyzers()
            .WithSources(source)
            .WithPackageReferences(PackageReference.FluentAssertions_6_12_0, PackageReference.Nunit_3_14_0)
            .WithExpectedDiagnostics(new DiagnosticResult
            {
                Id = AssertAnalyzer.NUnitRule.Id,
                Message = AssertAnalyzer.Message,
                Locations = new DiagnosticResultLocation[]
                {
                        new("Test0.cs", 15, 13)
                },
                Severity = DiagnosticSeverity.Info
            })
        );
    }

    private void VerifyFix(string methodArguments, string oldAssertion, string newAssertion)
    {
        var oldSource = GenerateCode.Nunit3Assertion(methodArguments, oldAssertion);
        var newSource = GenerateCode.Nunit3Assertion(methodArguments, newAssertion);

        DiagnosticVerifier.VerifyFix(new CodeFixVerifierArguments()
            .WithDiagnosticAnalyzer<AssertAnalyzer>()
            .WithCodeFixProvider<NunitCodeFixProvider>()
            .WithSources(oldSource)
            .WithFixedSources(newSource)
            .WithPackageReferences(PackageReference.FluentAssertions_6_12_0, PackageReference.Nunit_3_14_0)
        );
    }
}