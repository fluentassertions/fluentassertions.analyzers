using System;
using FluentAssertions.Analyzers.TestUtils;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.Tests.Tips;

[TestClass]
public class NunitTests
{
    #region Assert.Conditions.cs

    [DataTestMethod]
    [AssertionDiagnostic("Assert.True(actual{0});")]
    [AssertionDiagnostic("Assert.True(bool.Parse(\"true\"){0});")]
    [AssertionDiagnostic("Assert.IsTrue(actual{0});")]
    [AssertionDiagnostic("Assert.IsTrue(bool.Parse(\"true\"){0});")]
    [Implemented]
    public void Nunit3_AssertTrue_TestAnalyzer(string assertion) => Nunit3VerifyDiagnostic("bool actual", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.True(actual{0});")]
    [AssertionDiagnostic("ClassicAssert.True(bool.Parse(\"true\"){0});")]
    [AssertionDiagnostic("ClassicAssert.IsTrue(actual{0});")]
    [AssertionDiagnostic("ClassicAssert.IsTrue(bool.Parse(\"true\"){0});")]
    [Implemented]
    public void Nunit4_AssertTrue_TestAnalyzer(string assertion) => Nunit4VerifyDiagnostic("bool actual", assertion);

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
    public void Nunit3_AssertTrue_TestCodeFix(string oldAssertion, string newAssertion) => Nunit3VerifyFix("bool actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.True(actual{0});",
        newAssertion: "actual.Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.True(bool.Parse(\"true\"){0});",
        newAssertion: "bool.Parse(\"true\").Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.True(!actual{0});",
        newAssertion: "(!actual).Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.True(actual == false{0});",
        newAssertion: "(actual == false).Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsTrue(actual{0});",
        newAssertion: "actual.Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsTrue(bool.Parse(\"true\"){0});",
        newAssertion: "bool.Parse(\"true\").Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsTrue(!actual{0});",
        newAssertion: "(!actual).Should().BeTrue({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsTrue(actual == false{0});",
        newAssertion: "(actual == false).Should().BeTrue({0});")]
    [Implemented]
    public void Nunit4_AssertTrue_TestCodeFix(string oldAssertion, string newAssertion) => Nunit4VerifyFix("bool actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.False(actual{0});")]
    [AssertionDiagnostic("Assert.False(bool.Parse(\"false\"){0});")]
    [AssertionDiagnostic("Assert.IsFalse(actual{0});")]
    [AssertionDiagnostic("Assert.IsFalse(bool.Parse(\"false\"){0});")]
    [Implemented]
    public void Nunit3_AssertFalse_TestAnalyzer(string assertion) => Nunit3VerifyDiagnostic("bool actual", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.False(actual{0});")]
    [AssertionDiagnostic("ClassicAssert.False(bool.Parse(\"false\"){0});")]
    [AssertionDiagnostic("ClassicAssert.IsFalse(actual{0});")]
    [AssertionDiagnostic("ClassicAssert.IsFalse(bool.Parse(\"false\"){0});")]
    [Implemented]
    public void Nunit4_AssertFalse_TestAnalyzer(string assertion) => Nunit4VerifyDiagnostic("bool actual", assertion);

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
    public void Nunit3_AssertFalse_TestCodeFix(string oldAssertion, string newAssertion) => Nunit3VerifyFix("bool actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.False(actual{0});",
        newAssertion: "actual.Should().BeFalse({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.False(bool.Parse(\"false\"){0});",
        newAssertion: "bool.Parse(\"false\").Should().BeFalse({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsFalse(actual{0});",
        newAssertion: "actual.Should().BeFalse({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsFalse(bool.Parse(\"false\"){0});",
        newAssertion: "bool.Parse(\"false\").Should().BeFalse({0});")]
    [Implemented]
    public void Nunit4_AssertFalse_TestCodeFix(string oldAssertion, string newAssertion) => Nunit4VerifyFix("bool actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.Null(actual{0});")]
    [AssertionDiagnostic("Assert.IsNull(actual{0});")]
    [Implemented]
    public void Nunit3_AssertNull_TestAnalyzer(string assertion) => Nunit3VerifyDiagnostic("object actual", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.Null(actual{0});")]
    [AssertionDiagnostic("ClassicAssert.IsNull(actual{0});")]
    [Implemented]
    public void Nunit4_AssertNull_TestAnalyzer(string assertion) => Nunit4VerifyDiagnostic("object actual", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.Null(actual{0});",
        newAssertion: "actual.Should().BeNull({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsNull(actual{0});",
        newAssertion: "actual.Should().BeNull({0});")]
    [Implemented]
    public void Nunit3_AssertNull_TestCodeFix(string oldAssertion, string newAssertion) => Nunit3VerifyFix("object actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.Null(actual{0});",
        newAssertion: "actual.Should().BeNull({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsNull(actual{0});",
        newAssertion: "actual.Should().BeNull({0});")]
    [Implemented]
    public void Nunit4_AssertNull_TestCodeFix(string oldAssertion, string newAssertion) => Nunit4VerifyFix("object actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.NotNull(actual{0});")]
    [AssertionDiagnostic("Assert.IsNotNull(actual{0});")]
    [Implemented]
    public void Nunit3_AssertNotNull_TestAnalyzer(string assertion) => Nunit3VerifyDiagnostic("object actual", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.NotNull(actual{0});")]
    [AssertionDiagnostic("ClassicAssert.IsNotNull(actual{0});")]
    [Implemented]
    public void Nunit4_AssertNotNull_TestAnalyzer(string assertion) => Nunit4VerifyDiagnostic("object actual", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.NotNull(actual{0});",
        newAssertion: "actual.Should().NotBeNull({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsNotNull(actual{0});",
        newAssertion: "actual.Should().NotBeNull({0});")]
    [Implemented]
    public void Nunit3_AssertNotNull_TestCodeFix(string oldAssertion, string newAssertion) => Nunit3VerifyFix("object actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.NotNull(actual{0});",
        newAssertion: "actual.Should().NotBeNull({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsNotNull(actual{0});",
        newAssertion: "actual.Should().NotBeNull({0});")]
    [Implemented]
    public void Nunit4_AssertNotNull_TestCodeFix(string oldAssertion, string newAssertion) => Nunit4VerifyFix("object actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.IsNaN(actual{0});")]
    [Implemented]
    public void Nunit3_AssertIsNaN_TestAnalyzer(string assertion)
    {
        Nunit3VerifyDiagnostic("double actual", assertion);
        Nunit3VerifyNoFix("double actual", assertion);
    }

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.IsNaN(actual{0});")]
    [Implemented]
    public void Nunit4_AssertIsNaN_TestAnalyzer(string assertion)
    {
        Nunit4VerifyDiagnostic("double actual", assertion);
        Nunit4VerifyNoFix("double actual", assertion);
    }

    // IsEmpty
    [DataTestMethod]
    [AssertionDiagnostic("Assert.IsEmpty(actual{0});")]
    [Implemented]
    public void Nunit3_AssertIsEmpty_TestAnalyzer(string assertion)
    {
        Nunit3VerifyDiagnostic("object[] actual", assertion);
        Nunit3VerifyDiagnostic("IEnumerable<int> actual", assertion);
        Nunit3VerifyDiagnostic("IEnumerable actual", assertion);
        Nunit3VerifyDiagnostic("string actual", assertion);
    }

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.IsEmpty(actual{0});")]
    [Implemented]
    public void Nunit4_AssertIsEmpty_TestAnalyzer(string assertion)
    {
        Nunit4VerifyDiagnostic("object[] actual", assertion);
        Nunit4VerifyDiagnostic("IEnumerable<int> actual", assertion);
        Nunit4VerifyDiagnostic("IEnumerable actual", assertion);
        Nunit4VerifyDiagnostic("string actual", assertion);
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsEmpty(actual{0});",
        newAssertion: "actual.Should().BeEmpty({0});")]
    [Implemented]
    public void Nunit3_AssertIsEmpty_TestCodeFix(string oldAssertion, string newAssertion)
    {
        Nunit3VerifyFix("object[] actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("IEnumerable<int> actual", oldAssertion, newAssertion);
        Nunit3VerifyNoFix("IEnumerable actual", oldAssertion);
        Nunit3VerifyFix("string actual", oldAssertion, newAssertion);
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsEmpty(actual{0});",
        newAssertion: "actual.Should().BeEmpty({0});")]
    [Implemented]
    public void Nunit4_AssertIsEmpty_TestCodeFix(string oldAssertion, string newAssertion)
    {
        Nunit4VerifyFix("object[] actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("IEnumerable<int> actual", oldAssertion, newAssertion);
        Nunit4VerifyNoFix("IEnumerable actual", oldAssertion);
        Nunit4VerifyFix("string actual", oldAssertion, newAssertion);
    }

    // IsNotEmpty
    [DataTestMethod]
    [AssertionDiagnostic("Assert.IsNotEmpty(actual{0});")]
    [Implemented]
    public void Nunit3_AssertIsNotEmpty_TestAnalyzer(string assertion)
    {
        Nunit3VerifyDiagnostic("object[] actual", assertion);
        Nunit3VerifyDiagnostic("IEnumerable<int> actual", assertion);
        Nunit3VerifyDiagnostic("IEnumerable actual", assertion);
        Nunit3VerifyDiagnostic("string actual", assertion);
    }

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.IsNotEmpty(actual{0});")]
    [Implemented]
    public void Nunit4_AssertIsNotEmpty_TestAnalyzer(string assertion)
    {
        Nunit4VerifyDiagnostic("object[] actual", assertion);
        Nunit4VerifyDiagnostic("IEnumerable<int> actual", assertion);
        Nunit4VerifyDiagnostic("IEnumerable actual", assertion);
        Nunit4VerifyDiagnostic("string actual", assertion);
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsNotEmpty(actual{0});",
        newAssertion: "actual.Should().NotBeEmpty({0});")]
    [Implemented]
    public void Nunit3_AssertIsNotEmpty_TestCodeFix(string oldAssertion, string newAssertion)
    {
        Nunit3VerifyFix("object[] actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("IEnumerable<int> actual", oldAssertion, newAssertion);
        Nunit3VerifyNoFix("IEnumerable actual", oldAssertion);
        Nunit3VerifyFix("string actual", oldAssertion, newAssertion);
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsNotEmpty(actual{0});",
        newAssertion: "actual.Should().NotBeEmpty({0});")]
    [Implemented]
    public void Nunit4_AssertIsNotEmpty_TestCodeFix(string oldAssertion, string newAssertion)
    {
        Nunit4VerifyFix("object[] actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("IEnumerable<int> actual", oldAssertion, newAssertion);
        Nunit4VerifyNoFix("IEnumerable actual", oldAssertion);
        Nunit4VerifyFix("string actual", oldAssertion, newAssertion);
    }

    [DataTestMethod]
    [AssertionDiagnostic("Assert.Zero(actual{0});")]
    [Implemented]
    public void Nunit3_AssertZero_TestAnalyzer(string assertion)
    {
        Nunit3VerifyDiagnostic("int actual", assertion);
        Nunit3VerifyDiagnostic("uint actual", assertion);
        Nunit3VerifyDiagnostic("long actual", assertion);
        Nunit3VerifyDiagnostic("ulong actual", assertion);
        Nunit3VerifyDiagnostic("float actual", assertion);
        Nunit3VerifyDiagnostic("double actual", assertion);
        Nunit3VerifyDiagnostic("decimal actual", assertion);
    }

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.Zero(actual{0});")]
    [Implemented]
    public void Nunit4_AssertZero_TestAnalyzer(string assertion)
    {
        Nunit4VerifyDiagnostic("int actual", assertion);
        Nunit4VerifyDiagnostic("uint actual", assertion);
        Nunit4VerifyDiagnostic("long actual", assertion);
        Nunit4VerifyDiagnostic("ulong actual", assertion);
        Nunit4VerifyDiagnostic("float actual", assertion);
        Nunit4VerifyDiagnostic("double actual", assertion);
        Nunit4VerifyDiagnostic("decimal actual", assertion);
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.Zero(actual{0});",
        newAssertion: "actual.Should().Be(0{0});")]
    [Implemented]
    public void Nunit3_AssertZero_TestCodeFix(string oldAssertion, string newAssertion)
    {
        Nunit3VerifyFix("int actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("uint actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("long actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("ulong actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("float actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("double actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("decimal actual", oldAssertion, newAssertion);
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.Zero(actual{0});",
        newAssertion: "actual.Should().Be(0{0});")]
    [Implemented]
    public void Nunit4_AssertZero_TestCodeFix(string oldAssertion, string newAssertion)
    {
        Nunit4VerifyFix("int actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("uint actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("long actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("ulong actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("float actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("double actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("decimal actual", oldAssertion, newAssertion);
    }

    [DataTestMethod]
    [AssertionDiagnostic("Assert.NotZero(actual{0});")]
    [Implemented]
    public void Nunit3_AssertNotZero_TestAnalyzer(string assertion)
    {
        Nunit3VerifyDiagnostic("int actual", assertion);
        Nunit3VerifyDiagnostic("uint actual", assertion);
        Nunit3VerifyDiagnostic("long actual", assertion);
        Nunit3VerifyDiagnostic("ulong actual", assertion);
        Nunit3VerifyDiagnostic("float actual", assertion);
        Nunit3VerifyDiagnostic("double actual", assertion);
        Nunit3VerifyDiagnostic("decimal actual", assertion);
    }

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.NotZero(actual{0});")]
    [Implemented]
    public void Nunit4_AssertNotZero_TestAnalyzer(string assertion)
    {
        Nunit4VerifyDiagnostic("int actual", assertion);
        Nunit4VerifyDiagnostic("uint actual", assertion);
        Nunit4VerifyDiagnostic("long actual", assertion);
        Nunit4VerifyDiagnostic("ulong actual", assertion);
        Nunit4VerifyDiagnostic("float actual", assertion);
        Nunit4VerifyDiagnostic("double actual", assertion);
        Nunit4VerifyDiagnostic("decimal actual", assertion);
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.NotZero(actual{0});",
        newAssertion: "actual.Should().NotBe(0{0});")]
    [Implemented]
    public void Nunit3_AssertNotZero_TestCodeFix(string oldAssertion, string newAssertion)
    {
        Nunit3VerifyFix("int actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("uint actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("long actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("ulong actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("float actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("double actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("decimal actual", oldAssertion, newAssertion);
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.NotZero(actual{0});",
        newAssertion: "actual.Should().NotBe(0{0});")]
    [Implemented]
    public void Nunit4_AssertNotZero_TestCodeFix(string oldAssertion, string newAssertion)
    {
        Nunit4VerifyFix("int actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("uint actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("long actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("ulong actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("float actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("double actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("decimal actual", oldAssertion, newAssertion);
    }

    // Positive
    [DataTestMethod]
    [AssertionDiagnostic("Assert.Positive(actual{0});")]
    [Implemented]
    public void Nunit3_AssertPositive_TestAnalyzer(string assertion)
    {
        Nunit3VerifyDiagnostic("int actual", assertion);
        Nunit3VerifyDiagnostic("uint actual", assertion);
        Nunit3VerifyDiagnostic("long actual", assertion);
        Nunit3VerifyDiagnostic("ulong actual", assertion);
        Nunit3VerifyDiagnostic("float actual", assertion);
        Nunit3VerifyDiagnostic("double actual", assertion);
        Nunit3VerifyDiagnostic("decimal actual", assertion);
    }

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.Positive(actual{0});")]
    [Implemented]
    public void Nunit4_AssertPositive_TestAnalyzer(string assertion)
    {
        Nunit4VerifyDiagnostic("int actual", assertion);
        Nunit4VerifyDiagnostic("uint actual", assertion);
        Nunit4VerifyDiagnostic("long actual", assertion);
        Nunit4VerifyDiagnostic("ulong actual", assertion);
        Nunit4VerifyDiagnostic("float actual", assertion);
        Nunit4VerifyDiagnostic("double actual", assertion);
        Nunit4VerifyDiagnostic("decimal actual", assertion);
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.Positive(actual{0});",
        newAssertion: "actual.Should().BePositive({0});")]
    [Implemented]
    public void Nunit3_AssertPositive_TestCodeFix(string oldAssertion, string newAssertion)
    {
        Nunit3VerifyFix("int actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("uint actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("long actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("ulong actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("float actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("double actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("decimal actual", oldAssertion, newAssertion);
    }

    // Negative
    [DataTestMethod]
    [AssertionDiagnostic("Assert.Negative(actual{0});")]
    [Implemented]
    public void Nunit3_AssertNegative_TestAnalyzer(string assertion)
    {
        Nunit3VerifyDiagnostic("int actual", assertion);
        Nunit3VerifyDiagnostic("uint actual", assertion);
        Nunit3VerifyDiagnostic("long actual", assertion);
        Nunit3VerifyDiagnostic("ulong actual", assertion);
        Nunit3VerifyDiagnostic("float actual", assertion);
        Nunit3VerifyDiagnostic("double actual", assertion);
        Nunit3VerifyDiagnostic("decimal actual", assertion);
    }

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.Negative(actual{0});")]
    [Implemented]
    public void Nunit4_AssertNegative_TestAnalyzer(string assertion)
    {
        Nunit4VerifyDiagnostic("int actual", assertion);
        Nunit4VerifyDiagnostic("uint actual", assertion);
        Nunit4VerifyDiagnostic("long actual", assertion);
        Nunit4VerifyDiagnostic("ulong actual", assertion);
        Nunit4VerifyDiagnostic("float actual", assertion);
        Nunit4VerifyDiagnostic("double actual", assertion);
        Nunit4VerifyDiagnostic("decimal actual", assertion);
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.Negative(actual{0});",
        newAssertion: "actual.Should().BeNegative({0});")]
    [Implemented]
    public void Nunit3_AssertNegative_TestCodeFix(string oldAssertion, string newAssertion)
    {
        Nunit3VerifyFix("int actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("uint actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("long actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("ulong actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("float actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("double actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("decimal actual", oldAssertion, newAssertion);
    }

    #endregion

    #region Assert.Comparisons.cs

    [DataTestMethod]
    [AssertionDiagnostic("Assert.Greater(arg1, arg2{0});")]
    [Implemented]
    public void Nunit3_AssertGreater_TestAnalyzer(string assertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit3VerifyDiagnostic(comparableArgument, assertion);
        }
    }

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.Greater(arg1, arg2{0});")]
    [Implemented]
    public void Nunit4_AssertGreater_TestAnalyzer(string assertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit4VerifyDiagnostic(comparableArgument, assertion);
        }
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.Greater(arg1, arg2{0});",
        newAssertion: "arg1.Should().BeGreaterThan(arg2{0});")]
    [Implemented]
    public void Nunit3_AssertGreater_TestCodeFix(string oldAssertion, string newAssertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit3VerifyFix(comparableArgument, oldAssertion, newAssertion);
        }
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.Greater(arg1, arg2{0});",
        newAssertion: "arg1.Should().BeGreaterThan(arg2{0});")]
    [Implemented]
    public void Nunit4_AssertGreater_TestCodeFix(string oldAssertion, string newAssertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit4VerifyFix(comparableArgument, oldAssertion, newAssertion);
        }
    }

    [DataTestMethod]
    [AssertionDiagnostic("Assert.GreaterOrEqual(arg1, arg2{0});")]
    [Implemented]
    public void Nunit3_AssertGreaterOrEqual_TestAnalyzer(string assertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit3VerifyDiagnostic(comparableArgument, assertion);
        }
    }

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.GreaterOrEqual(arg1, arg2{0});")]
    [Implemented]
    public void Nunit4_AssertGreaterOrEqual_TestAnalyzer(string assertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit4VerifyDiagnostic(comparableArgument, assertion);
        }
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.GreaterOrEqual(arg1, arg2{0});",
        newAssertion: "arg1.Should().BeGreaterOrEqualTo(arg2{0});")]
    [Implemented]
    public void Nunit3_AssertGreaterOrEqual_TestCodeFix(string oldAssertion, string newAssertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit3VerifyFix(comparableArgument, oldAssertion, newAssertion);
        }
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.GreaterOrEqual(arg1, arg2{0});",
        newAssertion: "arg1.Should().BeGreaterOrEqualTo(arg2{0});")]
    [Implemented]
    public void Nunit4_AssertGreaterOrEqual_TestCodeFix(string oldAssertion, string newAssertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit4VerifyFix(comparableArgument, oldAssertion, newAssertion);
        }
    }

    [DataTestMethod]
    [AssertionDiagnostic("Assert.Less(arg1, arg2{0});")]
    [Implemented]
    public void Nunit3_AssertLess_TestAnalyzer(string assertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit3VerifyDiagnostic(comparableArgument, assertion);
        }
    }

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.Less(arg1, arg2{0});")]
    [Implemented]
    public void Nunit4_AssertLess_TestAnalyzer(string assertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit4VerifyDiagnostic(comparableArgument, assertion);
        }
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.Less(arg1, arg2{0});",
        newAssertion: "arg1.Should().BeLessThan(arg2{0});")]
    [Implemented]
    public void Nunit3_AssertLess_TestCodeFix(string oldAssertion, string newAssertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit3VerifyFix(comparableArgument, oldAssertion, newAssertion);
        }
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.Less(arg1, arg2{0});",
        newAssertion: "arg1.Should().BeLessThan(arg2{0});")]
    [Implemented]
    public void Nunit4_AssertLess_TestCodeFix(string oldAssertion, string newAssertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit4VerifyFix(comparableArgument, oldAssertion, newAssertion);
        }
    }

    [DataTestMethod]
    [AssertionDiagnostic("Assert.LessOrEqual(arg1, arg2{0});")]
    [Implemented]
    public void Nunit3_AssertLessOrEqual_TestAnalyzer(string assertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit3VerifyDiagnostic(comparableArgument, assertion);
        }
    }

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.LessOrEqual(arg1, arg2{0});")]
    [Implemented]
    public void Nunit4_AssertLessOrEqual_TestAnalyzer(string assertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit4VerifyDiagnostic(comparableArgument, assertion);
        }
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.LessOrEqual(arg1, arg2{0});",
        newAssertion: "arg1.Should().BeLessOrEqualTo(arg2{0});")]
    [Implemented]
    public void Nunit3_AssertLessOrEqual_TestCodeFix(string oldAssertion, string newAssertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit3VerifyFix(comparableArgument, oldAssertion, newAssertion);
        }
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.LessOrEqual(arg1, arg2{0});",
        newAssertion: "arg1.Should().BeLessOrEqualTo(arg2{0});")]
    [Implemented]
    public void Nunit4_AssertLessOrEqual_TestCodeFix(string oldAssertion, string newAssertion)
    {
        foreach (var comparableArgument in ComparableArguments)
        {
            Nunit4VerifyFix(comparableArgument, oldAssertion, newAssertion);
        }
    }

    private static readonly string[] ComparableArguments = Array.ConvertAll(new string[] { "int", "uint", "long", "ulong", "float", "double", "decimal" }, x => $"{x} arg1, {x} arg2");

    #endregion

    #region Assert.Equality.cs

    [DataTestMethod]
    [AssertionDiagnostic("Assert.AreEqual(expected, actual, delta{0});")]
    [Implemented]
    public void Nunit3_AssertEqualDouble_TestAnalyzer(string assertion)
        => Nunit3VerifyDiagnostic("double expected, double actual, double delta", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.AreEqual(expected, actual, delta{0});")]
    [Implemented]
    public void Nunit4_AssertEqualDouble_TestAnalyzer(string assertion)
        => Nunit4VerifyDiagnostic("double expected, double actual, double delta", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.AreEqual(expected, actual, delta{0});",
        newAssertion: "actual.Should().BeApproximately(expected, delta{0});")]
    [Implemented]
    public void Nunit3_AssertEqualDouble_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit3VerifyFix("double expected, double actual, double delta", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.AreEqual(expected, actual, delta{0});",
        newAssertion: "actual.Should().BeApproximately(expected, delta{0});")]
    [Implemented]
    public void Nunit4_AssertEqualDouble_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit4VerifyFix("double expected, double actual, double delta", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.AreEqual(expected, actual{0});")]
    [Implemented]
    public void Nunit3_AssertEqualObject_TestAnalyzer(string assertion)
        => Nunit3VerifyDiagnostic("object expected, object actual", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.AreEqual(expected, actual{0});")]
    [Implemented]
    public void Nunit4_AssertEqualObject_TestAnalyzer(string assertion)
        => Nunit4VerifyDiagnostic("object expected, object actual", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.AreEqual(expected, actual{0});",
        newAssertion: "actual.Should().Be(expected{0});")]
    [Implemented]
    public void Nunit3_AssertEqualObject_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit3VerifyFix("object expected, object actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.AreEqual(expected, actual{0});",
        newAssertion: "actual.Should().Be(expected{0});")]
    [Implemented]
    public void Nunit4_AssertEqualObject_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit4VerifyFix("object expected, object actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.AreNotEqual(expected, actual{0});")]
    [Implemented]
    public void Nunit3_AssertNotEqualObject_TestAnalyzer(string assertion)
        => Nunit3VerifyDiagnostic("object expected, object actual", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.AreNotEqual(expected, actual{0});")]
    [Implemented]
    public void Nunit4_AssertNotEqualObject_TestAnalyzer(string assertion)
        => Nunit4VerifyDiagnostic("object expected, object actual", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.AreNotEqual(expected, actual{0});",
        newAssertion: "actual.Should().NotBe(expected{0});")]
    [Implemented]
    public void Nunit3_AssertNotEqualObject_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit3VerifyFix("object expected, object actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.AreNotEqual(expected, actual{0});",
        newAssertion: "actual.Should().NotBe(expected{0});")]
    [Implemented]
    public void Nunit4_AssertNotEqualObject_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit4VerifyFix("object expected, object actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.AreSame(expected, actual{0});")]
    [Implemented]
    public void Nunit3_AssertSame_TestAnalyzer(string assertion)
        => Nunit3VerifyDiagnostic("object expected, object actual", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.AreSame(expected, actual{0});")]
    [Implemented]
    public void Nunit4_AssertSame_TestAnalyzer(string assertion)
        => Nunit4VerifyDiagnostic("object expected, object actual", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.AreSame(expected, actual{0});",
        newAssertion: "actual.Should().BeSameAs(expected{0});")]
    [Implemented]
    public void Nunit3_AssertSame_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit3VerifyFix("object expected, object actual", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.AreSame(expected, actual{0});",
        newAssertion: "actual.Should().BeSameAs(expected{0});")]
    [Implemented]
    public void Nunit4_AssertSame_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit4VerifyFix("object expected, object actual", oldAssertion, newAssertion);

    #endregion

    #region Assert.Types.cs

    [DataTestMethod]
    [AssertionDiagnostic("Assert.IsAssignableFrom(typeof(string), actual{0});")]
    [AssertionDiagnostic("Assert.IsAssignableFrom(expected, actual{0});")]
    [AssertionDiagnostic("Assert.IsAssignableFrom<string>(actual{0});")]
    [Implemented]
    public void Nunit3_AssertIsAssignableFrom_TestAnalyzer(string assertion)
        => Nunit3VerifyDiagnostic("object actual, Type expected", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.IsAssignableFrom(typeof(string), actual{0});")]
    [AssertionDiagnostic("ClassicAssert.IsAssignableFrom(expected, actual{0});")]
    [AssertionDiagnostic("ClassicAssert.IsAssignableFrom<string>(actual{0});")]
    [Implemented]
    public void Nunit4_AssertIsAssignableFrom_TestAnalyzer(string assertion)
        => Nunit4VerifyDiagnostic("object actual, Type expected", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsAssignableFrom(typeof(string), actual{0});",
        newAssertion: "actual.Should().BeAssignableTo<string>({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsAssignableFrom(expected, actual{0});",
        newAssertion: "actual.Should().BeAssignableTo(expected{0});")]
    [Implemented]
    public void Nunit3_AssertIsAssignableFrom_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit3VerifyFix("object actual, Type expected", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsAssignableFrom(typeof(string), actual{0});",
        newAssertion: "actual.Should().BeAssignableTo<string>({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsAssignableFrom(expected, actual{0});",
        newAssertion: "actual.Should().BeAssignableTo(expected{0});")]
    [Implemented]
    public void Nunit4_AssertIsAssignableFrom_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit4VerifyFix("object actual, Type expected", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.IsNotAssignableFrom(typeof(string), actual{0});")]
    [AssertionDiagnostic("Assert.IsNotAssignableFrom(expected, actual{0});")]
    [AssertionDiagnostic("Assert.IsNotAssignableFrom<string>(actual{0});")]
    [Implemented]
    public void Nunit3_AssertIsNotAssignableFrom_TestAnalyzer(string assertion)
        => Nunit3VerifyDiagnostic("object actual, Type expected", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.IsNotAssignableFrom(typeof(string), actual{0});")]
    [AssertionDiagnostic("ClassicAssert.IsNotAssignableFrom(expected, actual{0});")]
    [AssertionDiagnostic("ClassicAssert.IsNotAssignableFrom<string>(actual{0});")]
    [Implemented]
    public void Nunit4_AssertIsNotAssignableFrom_TestAnalyzer(string assertion)
        => Nunit4VerifyDiagnostic("object actual, Type expected", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsNotAssignableFrom(typeof(string), actual{0});",
        newAssertion: "actual.Should().NotBeAssignableTo<string>({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsNotAssignableFrom(expected, actual{0});",
        newAssertion: "actual.Should().NotBeAssignableTo(expected{0});")]
    [Implemented]
    public void Nunit3_AssertIsNotAssignableFrom_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit3VerifyFix("object actual, Type expected", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsNotAssignableFrom(typeof(string), actual{0});",
        newAssertion: "actual.Should().NotBeAssignableTo<string>({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsNotAssignableFrom(expected, actual{0});",
        newAssertion: "actual.Should().NotBeAssignableTo(expected{0});")]
    [Implemented]
    public void Nunit4_AssertIsNotAssignableFrom_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit4VerifyFix("object actual, Type expected", oldAssertion, newAssertion);

    // void IsInstanceOf(Type expected, object? actual, string message, params object?[]? args)
    [DataTestMethod]
    [AssertionDiagnostic("Assert.IsInstanceOf(typeof(string), actual{0});")]
    [AssertionDiagnostic("Assert.IsInstanceOf(expected, actual{0});")]
    [AssertionDiagnostic("Assert.IsInstanceOf<string>(actual{0});")]
    [Implemented]
    public void Nunit3_AssertIsInstanceOf_TestAnalyzer(string assertion)
        => Nunit3VerifyDiagnostic("object actual, Type expected", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.IsInstanceOf(typeof(string), actual{0});")]
    [AssertionDiagnostic("ClassicAssert.IsInstanceOf(expected, actual{0});")]
    [AssertionDiagnostic("ClassicAssert.IsInstanceOf<string>(actual{0});")]
    [Implemented]
    public void Nunit4_AssertIsInstanceOf_TestAnalyzer(string assertion)
        => Nunit4VerifyDiagnostic("object actual, Type expected", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsInstanceOf(typeof(string), actual{0});",
        newAssertion: "actual.Should().BeOfType<string>({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsInstanceOf(expected, actual{0});",
        newAssertion: "actual.Should().BeOfType(expected{0});")]
    [Implemented]
    public void Nunit3_AssertIsInstanceOf_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit3VerifyFix("object actual, Type expected", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsInstanceOf(typeof(string), actual{0});",
        newAssertion: "actual.Should().BeOfType<string>({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsInstanceOf(expected, actual{0});",
        newAssertion: "actual.Should().BeOfType(expected{0});")]
    [Implemented]
    public void Nunit4_AssertIsInstanceOf_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit4VerifyFix("object actual, Type expected", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.IsNotInstanceOf(typeof(string), actual{0});")]
    [AssertionDiagnostic("Assert.IsNotInstanceOf(expected, actual{0});")]
    [AssertionDiagnostic("Assert.IsNotInstanceOf<string>(actual{0});")]
    [Implemented]
    public void Nunit3_AssertIsNotInstanceOf_TestAnalyzer(string assertion)
        => Nunit3VerifyDiagnostic("object actual, Type expected", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.IsNotInstanceOf(typeof(string), actual{0});")]
    [AssertionDiagnostic("ClassicAssert.IsNotInstanceOf(expected, actual{0});")]
    [AssertionDiagnostic("ClassicAssert.IsNotInstanceOf<string>(actual{0});")]
    [Implemented]
    public void Nunit4_AssertIsNotInstanceOf_TestAnalyzer(string assertion)
        => Nunit4VerifyDiagnostic("object actual, Type expected", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsNotInstanceOf(typeof(string), actual{0});",
        newAssertion: "actual.Should().NotBeOfType<string>({0});")]
    [AssertionCodeFix(
        oldAssertion: "Assert.IsNotInstanceOf(expected, actual{0});",
        newAssertion: "actual.Should().NotBeOfType(expected{0});")]
    [Implemented]
    public void Nunit3_AssertIsNotInstanceOf_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit3VerifyFix("object actual, Type expected", oldAssertion, newAssertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsNotInstanceOf(typeof(string), actual{0});",
        newAssertion: "actual.Should().NotBeOfType<string>({0});")]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.IsNotInstanceOf(expected, actual{0});",
        newAssertion: "actual.Should().NotBeOfType(expected{0});")]
    [Implemented]
    public void Nunit4_AssertIsNotInstanceOf_TestCodeFix(string oldAssertion, string newAssertion)
        => Nunit4VerifyFix("object actual, Type expected", oldAssertion, newAssertion);

    #endregion

    #region Assert.Contains.cs

    [DataTestMethod]
    [AssertionDiagnostic("Assert.Contains(expected, actual{0});")]
    [Implemented]
    public void Nunit3_AssertContains_ICollection_TestCodeNoFix(string assertion)
        => Nunit3VerifyNoFix("object expected, ICollection actual", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.Contains(expected, actual{0});")]
    [Implemented]
    public void Nunit4_AssertContains_ICollection_TestCodeNoFix(string assertion)
        => Nunit4VerifyNoFix("object expected, ICollection actual", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("Assert.Contains(expected, actual{0});")]
    [Implemented]
    public void Nunit3_AssertContains_TestAnalyzer(string assertion)
        => Nunit3VerifyDiagnostic("object expected, string[] actual", assertion);

    [DataTestMethod]
    [AssertionDiagnostic("ClassicAssert.Contains(expected, actual{0});")]
    [Implemented]
    public void Nunit4_AssertContains_TestAnalyzer(string assertion)
        => Nunit4VerifyDiagnostic("object expected, string[] actual", assertion);

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "Assert.Contains(expected, actual{0});",
        newAssertion: "actual.Should().Contain(expected{0});")]
    [Implemented]
    public void Nunit3_AssertContains_TestCodeFix(string oldAssertion, string newAssertion)
    {
        Nunit3VerifyFix("string expected, string[] actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("string expected, List<string> actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("string expected, object[] actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("string expected, List<object> actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("DateTime expected, DateTime[] actual", oldAssertion, newAssertion);
        Nunit3VerifyFix("DateTime expected, List<DateTime> actual", oldAssertion, newAssertion);
    }

    [DataTestMethod]
    [AssertionCodeFix(
        oldAssertion: "ClassicAssert.Contains(expected, actual{0});",
        newAssertion: "actual.Should().Contain(expected{0});")]
    [Implemented]
    public void Nunit4_AssertContains_TestCodeFix(string oldAssertion, string newAssertion)
    {
        Nunit4VerifyFix("string expected, string[] actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("string expected, List<string> actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("string expected, object[] actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("string expected, List<object> actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("DateTime expected, DateTime[] actual", oldAssertion, newAssertion);
        Nunit4VerifyFix("DateTime expected, List<DateTime> actual", oldAssertion, newAssertion);
    }

    [DataTestMethod]
    [DataRow(
        /* methodArguments: */ "object expected, string[] actual",
        /* oldAssertion: */ "Assert.Contains(expected, actual);",
        /* newAssertion: */ "actual.Should().Contain((string)expected);")]
    [DataRow(
        /* methodArguments: */ "object expected, List<string> actual",
        /* oldAssertion: */ "Assert.Contains(expected, actual);",
        /* newAssertion: */ "actual.Should().Contain((string)expected);")]
    [DataRow(
        /* methodArguments: */ "object expected, DateTime[] actual",
        /* oldAssertion: */ "Assert.Contains(expected, actual);",
        /* newAssertion: */ "actual.Should().Contain((DateTime)expected);")]
    [DataRow(
        /* methodArguments: */ "object expected, List<DateTime> actual",
        /* oldAssertion: */ "Assert.Contains(expected, actual);",
        /* newAssertion: */ "actual.Should().Contain((DateTime)expected);")]
    [Implemented]
    public void Nunit3_AssertContains_WithCasting_TestCodeFix(string methodArguments, string oldAssertion, string newAssertion)
        => Nunit3VerifyFix(methodArguments, oldAssertion, newAssertion);

    [DataTestMethod]
    [DataRow(
        /* methodArguments: */ "object expected, string[] actual",
        /* oldAssertion: */ "ClassicAssert.Contains(expected, actual);",
        /* newAssertion: */ "actual.Should().Contain((string)expected);")]
    [DataRow(
        /* methodArguments: */ "object expected, List<string> actual",
        /* oldAssertion: */ "ClassicAssert.Contains(expected, actual);",
        /* newAssertion: */ "actual.Should().Contain((string)expected);")]
    [DataRow(
        /* methodArguments: */ "object expected, DateTime[] actual",
        /* oldAssertion: */ "ClassicAssert.Contains(expected, actual);",
        /* newAssertion: */ "actual.Should().Contain((DateTime)expected);")]
    [DataRow(
        /* methodArguments: */ "object expected, List<DateTime> actual",
        /* oldAssertion: */ "ClassicAssert.Contains(expected, actual);",
        /* newAssertion: */ "actual.Should().Contain((DateTime)expected);")]
    [Implemented]
    public void Nunit4_AssertContains_WithCasting_TestCodeFix(string methodArguments, string oldAssertion, string newAssertion)
        => Nunit4VerifyFix(methodArguments, oldAssertion, newAssertion);

    #endregion

    private void Nunit3VerifyDiagnostic(string methodArguments, string assertion)
        => VerifyDiagnostic(GenerateCode.Nunit3Assertion(methodArguments, assertion), PackageReference.Nunit_3_14_0);
    private void Nunit3VerifyFix(string methodArguments, string oldAssertion, string newAssertion)
        => VerifyFix(GenerateCode.Nunit3Assertion(methodArguments, oldAssertion), GenerateCode.Nunit3Assertion(methodArguments, newAssertion), PackageReference.Nunit_3_14_0);
    private void Nunit3VerifyNoFix(string methodArguments, string assertion)
        => VerifyNoFix(GenerateCode.Nunit3Assertion(methodArguments, assertion), PackageReference.Nunit_3_14_0);

    private void Nunit4VerifyDiagnostic(string methodArguments, string assertion)
        => VerifyDiagnostic(GenerateCode.Nunit4Assertion(methodArguments, assertion), PackageReference.Nunit_4_0_1);
    private void Nunit4VerifyFix(string methodArguments, string oldAssertion, string newAssertion)
        => VerifyFix(GenerateCode.Nunit4Assertion(methodArguments, oldAssertion), GenerateCode.Nunit4Assertion(methodArguments, newAssertion), PackageReference.Nunit_4_0_1);
    private void Nunit4VerifyNoFix(string methodArguments, string assertion)
        => VerifyNoFix(GenerateCode.Nunit4Assertion(methodArguments, assertion), PackageReference.Nunit_4_0_1);
    private void VerifyDiagnostic(string source, PackageReference nunit)
    {
        DiagnosticVerifier.VerifyDiagnostic(new DiagnosticVerifierArguments()
            .WithAllAnalyzers()
            .WithSources(source)
            .WithPackageReferences(PackageReference.FluentAssertions_6_12_0, nunit)
            .WithExpectedDiagnostics(new DiagnosticResult
            {
                Id = AssertAnalyzer.NUnitRule.Id,
                Message = AssertAnalyzer.Message,
                Locations = new DiagnosticResultLocation[]
                {
                        new("Test0.cs", 16, 13)
                },
                Severity = DiagnosticSeverity.Info
            })
        );
    }

    private void VerifyFix(string oldSource, string newSource, PackageReference nunit)
    {
        DiagnosticVerifier.VerifyFix(new CodeFixVerifierArguments()
            .WithDiagnosticAnalyzer<AssertAnalyzer>()
            .WithCodeFixProvider<NunitCodeFixProvider>()
            .WithSources(oldSource)
            .WithFixedSources(newSource)
            .WithPackageReferences(PackageReference.FluentAssertions_6_12_0, nunit)
        );
    }
    private void VerifyNoFix(string source, PackageReference nunit)
    {
        DiagnosticVerifier.VerifyNoFix(new CodeFixVerifierArguments()
            .WithDiagnosticAnalyzer<AssertAnalyzer>()
            .WithCodeFixProvider<NunitCodeFixProvider>()
            .WithSources(source)
            .WithPackageReferences(PackageReference.FluentAssertions_6_12_0, nunit)
        );
    }
}