using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.IsFalse(actual{0});")]
        [AssertionDiagnostic("Assert.IsFalse(bool.Parse(\"true\"){0});")]
        [Implemented]
        public void AssertIsFalse_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertIsFalseAnalyzer>("bool actual", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsFalse(actual{0});",
            newAssertion: "actual.Should().BeFalse({0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsFalse(bool.Parse(\"true\"){0});",
            newAssertion: "bool.Parse(\"true\").Should().BeFalse({0});")]
        [Implemented]
        public void AssertIsFalse_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertIsFalseCodeFix, AssertIsFalseAnalyzer>("bool actual", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.IsNull(actual{0});")]
        [Implemented]
        public void AssertIsNull_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertIsNullAnalyzer>("object actual", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsNull(actual{0});",
            newAssertion: "actual.Should().BeNull({0});")]
        [Implemented]
        public void AssertIsNull_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertIsNullCodeFix, AssertIsNullAnalyzer>("object actual", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.IsNotNull(actual{0});")]
        [Implemented]
        public void AssertIsNotNull_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertIsNotNullAnalyzer>("object actual", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsNotNull(actual{0});",
            newAssertion: "actual.Should().NotBeNull({0});")]
        [Implemented]
        public void AssertIsNotNull_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertIsNotNullCodeFix, AssertIsNotNullAnalyzer>("object actual", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.IsInstanceOfType(actual, type{0});")]
        [AssertionDiagnostic("Assert.IsInstanceOfType(actual, typeof(string){0});")]
        [Implemented]
        public void AssertIsInstanceOfType_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertIsInstanceOfTypeAnalyzer>("object actual, Type type", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsInstanceOfType(actual, type{0});",
            newAssertion: "actual.Should().BeOfType(type{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsInstanceOfType(actual, typeof(string){0});",
            newAssertion: "actual.Should().BeOfType<string>({0});")]
        [Implemented]
        public void AssertIsInstanceOfType_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertIsInstanceOfTypeCodeFix, AssertIsInstanceOfTypeAnalyzer>("object actual, Type type", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.IsNotInstanceOfType(actual, type{0});")]
        [AssertionDiagnostic("Assert.IsNotInstanceOfType(actual, typeof(string){0});")]
        [Implemented]
        public void AssertIsNotInstanceOfType_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertIsNotInstanceOfTypeAnalyzer>("object actual, Type type", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsNotInstanceOfType(actual, type{0});",
            newAssertion: "actual.Should().NotBeOfType(type{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsNotInstanceOfType(actual, typeof(string){0});",
            newAssertion: "actual.Should().NotBeOfType<string>({0});")]
        [Implemented]
        public void AssertIsNotInstanceOfType_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertIsNotInstanceOfTypeCodeFix, AssertIsNotInstanceOfTypeAnalyzer>("object actual, Type type", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual{0});")]
        [NotImplemented]
        public void AssertObjectAreEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAreEqualAnalyzer>("object actual, object expected", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual{0});",
            newAssertion: "actual.Should().Be(expected{0});")]
        [NotImplemented]
        public void AssertObjectAreEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertAreEqualCodeFix, AssertAreEqualAnalyzer>("object actual, object expected", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, delta{0});")]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, 0.6{0});")]
        [NotImplemented]
        public void AssertDoubleAreEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAreEqualAnalyzer>("double actual, double expected, double delta", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, delta{0});",
            newAssertion: "actual.Should().BeApproximately(expected, delta{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, 0.6{0});",
            newAssertion: "actual.Should().BeApproximately(expected, 0.6{0});")]
        [NotImplemented]
        public void AssertDoubleAreEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertAreEqualCodeFix, AssertAreEqualAnalyzer>("double actual, double expected, double delta", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, delta{0});")]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, 0.6{0});")]
        [NotImplemented]
        public void AssertFloatAreEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAreEqualAnalyzer>("float actual, float expected, float delta", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, delta{0});",
            newAssertion: "actual.Should().BeApproximately(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, 0.6{0});",
            newAssertion: "actual.Should().BeApproximately(expected, 0.6{0});")]
        [NotImplemented]
        public void AssertFloatAreEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertAreEqualCodeFix, AssertAreEqualAnalyzer>("float actual, float expected, float delta", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual{0});")]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, false{0});")]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, true{0});")]
        [NotImplemented]
        public void AssertStringAreEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAreEqualAnalyzer>("string actual, string expected", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual{0});",
            newAssertion: "actual.Should().Be(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, false{0});",
            newAssertion: "actual.Should().Be(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, true{0});",
            newAssertion: "actual.Should().BeEquivalentTo(expected{0});")]
        [NotImplemented]
        public void AssertStringAreEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertAreEqualCodeFix, AssertAreEqualAnalyzer>("string actual, string expected", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual{0});")]
        [NotImplemented]
        public void AssertObjectAreNotEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAreNotEqualAnalyzer>("object actual, object expected", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual{0});",
            newAssertion: "actual.Should().NotBe(expected{0});")]
        [NotImplemented]
        public void AssertObjectAreNotEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertAreNotEqualCodeFix, AssertAreNotEqualAnalyzer>("object actual, object expected", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, delta{0});")]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, 0.6{0});")]
        [NotImplemented]
        public void AssertDoubleAreNotEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAreNotEqualAnalyzer>("double actual, double expected, double delta", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, delta{0});",
            newAssertion: "actual.Should().NotBeApproximately(expected, delta{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, 0.6{0});",
            newAssertion: "actual.Should().NotBeApproximately(expected, 0.6{0});")]
        [NotImplemented]
        public void AssertDoubleAreNotEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertAreNotEqualCodeFix, AssertAreNotEqualAnalyzer>("double actual, double expected, double delta", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, delta{0});")]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, 0.6{0});")]
        [NotImplemented]
        public void AssertFloatAreNotEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAreNotEqualAnalyzer>("float actual, float expected, float delta", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, delta{0});",
            newAssertion: "actual.Should().NotBeApproximately(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, 0.6{0});",
            newAssertion: "actual.Should().NotBeApproximately(expected, 0.6{0});")]
        [NotImplemented]
        public void AssertFloatAreNotEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertAreNotEqualCodeFix, AssertAreNotEqualAnalyzer>("float actual, float expected, float delta", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual{0});")]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, false{0});")]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, true{0});")]
        [NotImplemented]
        public void AssertStringAreNotEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAreNotEqualAnalyzer>("string actual, string expected", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual{0});",
            newAssertion: "actual.Should().NotBe(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, false{0});",
            newAssertion: "actual.Should().NotBe(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, true{0});",
            newAssertion: "actual.Should().NotBeEquivalentTo(expected{0});")]
        [NotImplemented]
        public void AssertStringAreNotEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertAreNotEqualCodeFix, AssertAreNotEqualAnalyzer>("string actual, string expected", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.AreSame(expected, actual{0});")]
        [Implemented]
        public void AssertAreSame_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAreSameAnalyzer>("object actual, object expected", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreSame(expected, actual{0});",
            newAssertion: "actual.Should().BeSameAs(expected{0});")]
        [Implemented]
        public void AssertAreSame_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertAreSameCodeFix, AssertAreSameAnalyzer>("object actual, object expected", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.AreNotSame(expected, actual{0});")]
        [Implemented]
        public void AssertAreNotSame_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAreNotSameAnalyzer>("object actual, object expected", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotSame(expected, actual{0});",
            newAssertion: "actual.Should().NotBeSameAs(expected{0});")]
        [Implemented]
        public void AssertAreNotSame_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertAreNotSameCodeFix, AssertAreNotSameAnalyzer>("object actual, object expected", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.ThrowsException<ArgumentException>(action{0});")]
        [NotImplemented]
        public void AssertThrowsException_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertThrowsExceptionAnalyzer>("Action action", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.ThrowsException<ArgumentException>(action{0});",
            newAssertion: "actual.Should().ThrowExactly<ArgumentException>({0});")]
        [NotImplemented]
        public void AssertThrowsException_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertThrowsExceptionCodeFix, AssertThrowsExceptionAnalyzer>("Action action", oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("Assert.ThrowsExceptionAsync<ArgumentException>(action{0});")]
        [NotImplemented]
        public void AssertThrowsExceptionAsync_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertThrowsExceptionAsyncAnalyzer>("Func<Task> action", assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.ThrowsExceptionAsync<ArgumentException>(action{0});",
            newAssertion: "actual.Should().ThrowExactly<ArgumentException>({0});")]
        [NotImplemented]
        public void AssertThrowsExceptionAsync_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertThrowsExceptionAsyncCodeFix, AssertThrowsExceptionAsyncAnalyzer>("Func<Task> action", oldAssertion, newAssertion);

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
