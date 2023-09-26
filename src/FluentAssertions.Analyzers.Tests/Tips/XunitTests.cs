using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions.Analyzers.Xunit;

using XunitAssert = Xunit.Assert;

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


        [DataTestMethod]
        [DataRow("Assert.Same(expected, actual);")]
        [Implemented]
        public void AssertSame_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertSameAnalyzer>("object actual, object expected", assertion);

        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.Same(expected, actual);",
            /* newAssertion: */ "actual.Should().BeSameAs(expected);")]
        [Implemented]
        public void AssertSame_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertSameCodeFix, AssertSameAnalyzer>("object actual, object expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [DataRow("Assert.NotSame(expected, actual);")]
        [Implemented]
        public void AssertNotSame_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertNotSameAnalyzer>("object actual, object expected", assertion);

        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.NotSame(expected, actual);",
            /* newAssertion: */ "actual.Should().NotBeSameAs(expected);")]
        [Implemented]
        public void AssertNotSame_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertNotSameCodeFix, AssertNotSameAnalyzer>("object actual, object expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [DataRow("Assert.Equal(expected, actual, tolerance);")]
        [DataRow("Assert.Equal(expected, actual, 0.6f);")]
        [Implemented]
        public void AssertFloatEqualWithTolerance_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertEqualAnalyzer>("float actual, float expected, float tolerance", assertion);
        
        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, tolerance);",
            /* newAssertion: */ "actual.Should().BeApproximately(expected, tolerance);")]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, 0.6f);",
            /* newAssertion: */ "actual.Should().BeApproximately(expected, 0.6f);")]
        [Implemented]
        public void AssertFloatEqualWithTolerance_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertEqualCodeFix, AssertEqualAnalyzer>("float actual, float expected, float tolerance", oldAssertion, newAssertion);
        
        [DataTestMethod]
        [DataRow("Assert.Equal(expected, actual, tolerance);")]
        [DataRow("Assert.Equal(expected, actual, 0.6);")]
        [Implemented]
        public void AssertDoubleEqualWithTolerance_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertEqualAnalyzer>("double actual, double expected, double tolerance", assertion);
        
        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, tolerance);",
            /* newAssertion: */ "actual.Should().BeApproximately(expected, tolerance);")]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, 0.6);",
            /* newAssertion: */ "actual.Should().BeApproximately(expected, 0.6);")]
        [Implemented]
        public void AssertDoubleEqualWithTolerance_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertEqualCodeFix, AssertEqualAnalyzer>("double actual, double expected, double tolerance", oldAssertion, newAssertion);

        [DataTestMethod]
        [DataRow("Assert.Equal(expected, actual, precision);")]
        [DataRow("Assert.Equal(expected, actual, 5);")]
        [Implemented]
        public void AssertDoubleEqualWithPrecision_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertEqualAnalyzer>("double actual, double expected, int precision", assertion);

        // There is no corresponding API in FluentAssertions
        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, precision);",
            /* newAssertion: */ "Assert.Equal(expected, actual, precision);")]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, 5);",
            /* newAssertion: */ "Assert.Equal(expected, actual, 5);")]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, precision, rounding);",
            /* newAssertion: */ "Assert.Equal(expected, actual, precision, rounding);")]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, 5, MidpointRounding.ToEven);",
            /* newAssertion: */ "Assert.Equal(expected, actual, 5, MidpointRounding.ToEven);")]
        [Implemented]
        public void AssertDoubleEqualWithPrecision_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertEqualCodeFix, AssertEqualAnalyzer>("double actual, double expected, int precision, MidpointRounding rounding", oldAssertion, newAssertion);

        [DataTestMethod]
        [DataRow("Assert.Equal(expected, actual, precision);")]
        [DataRow("Assert.Equal(expected, actual, 5);")]
        [Implemented]
        public void AssertDecimalEqualWithPrecision_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertEqualAnalyzer>("decimal actual, decimal expected, int precision", assertion);
        
        // There is no corresponding API in FluentAssertions
        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, precision);",
            /* newAssertion: */ "Assert.Equal(expected, actual, precision);")]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, 5);",
            /* newAssertion: */ "Assert.Equal(expected, actual, 5);")]
        [Implemented]
        public void AssertDecimalEqualWithPrecision_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertEqualCodeFix, AssertEqualAnalyzer>("decimal actual, decimal expected, int precision", oldAssertion, newAssertion);
        
        [DataTestMethod]
        [DataRow("Assert.Equal(expected, actual, precision);")]
        [DataRow("Assert.Equal(expected, actual, TimeSpan.FromSeconds(1));")]
        [Implemented]
        public void AssertDateTimeEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertEqualAnalyzer>("DateTime actual, DateTime expected, TimeSpan precision", assertion);
        
        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, precision);",
            /* newAssertion: */ "actual.Should().BeCloseTo(expected, precision);")]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, TimeSpan.FromSeconds(1));",
            /* newAssertion: */ "actual.Should().BeCloseTo(expected, TimeSpan.FromSeconds(1));")]
        [Implemented]
        public void AssertDateTimeEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertEqualCodeFix, AssertEqualAnalyzer>("DateTime actual, DateTime expected, TimeSpan precision", oldAssertion, newAssertion);
        
        [DataTestMethod]
        [DataRow("Assert.Equal(expected, actual, comparer);")]
        [DataRow("Assert.Equal(expected, actual, ReferenceEqualityComparer.Instance);")]
        [Implemented]
        public void AssertObjectEqualWithComparer_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertEqualAnalyzer>("object actual, object expected, IEqualityComparer<object> comparer", assertion);

        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, comparer);",
            /* newAssertion: */ "actual.Should().BeEquivalentTo(expected, options => options.Using(comparer));")]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual, ReferenceEqualityComparer.Instance);",
            /* newAssertion: */ "actual.Should().BeEquivalentTo(expected, options => options.Using(ReferenceEqualityComparer.Instance));")]
        [Implemented]
        public void AssertObjectEqualWithComparer_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertEqualCodeFix, AssertEqualAnalyzer>("object actual, object expected, IEqualityComparer<object> comparer", oldAssertion, newAssertion);

        [DataTestMethod]
        [DataRow("Assert.Equal(expected, actual);")]
        [Implemented]
        public void AssertObjectEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertEqualAnalyzer>("object actual, object expected", assertion);
        
        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.Equal(expected, actual);",
            /* newAssertion: */ "actual.Should().Be(expected);")]
        [Implemented]
        public void AssertObjectEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertEqualCodeFix, AssertEqualAnalyzer>("object actual, object expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [DataRow("Assert.StrictEqual(expected, actual);")]
        [Implemented]
        public void AssertStrictEqual_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertStrictEqualAnalyzer>("object actual, object expected", assertion);

        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.StrictEqual(expected, actual);",
            /* newAssertion: */ "actual.Should().Be(expected);")]
        [Implemented]
        public void AssertStrictEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertStrictEqualCodeFix, AssertStrictEqualAnalyzer>("object actual, object expected", oldAssertion, newAssertion);
        
                [DataTestMethod]
        [DataRow("Assert.NotEqual(expected, actual, precision);")]
        [DataRow("Assert.NotEqual(expected, actual, 5);")]
        [Implemented]
        public void AssertDoubleNotEqualWithPrecision_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertNotEqualAnalyzer>("double actual, double expected, int precision", assertion);

        // There is no corresponding API in FluentAssertions
        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.NotEqual(expected, actual, precision);",
            /* newAssertion: */ "Assert.NotEqual(expected, actual, precision);")]
        [DataRow(
            /* oldAssertion: */ "Assert.NotEqual(expected, actual, 5);",
            /* newAssertion: */ "Assert.NotEqual(expected, actual, 5);")]
        [Implemented]
        public void AssertDoubleNotEqualWithPrecision_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertNotEqualCodeFix, AssertNotEqualAnalyzer>("double actual, double expected, int precision", oldAssertion, newAssertion);

        [DataTestMethod]
        [DataRow("Assert.NotEqual(expected, actual, precision);")]
        [DataRow("Assert.NotEqual(expected, actual, 5);")]
        [Implemented]
        public void AssertDecimalNotEqualWithPrecision_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertNotEqualAnalyzer>("decimal actual, decimal expected, int precision", assertion);
        
        // There is no corresponding API in FluentAssertions
        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.NotEqual(expected, actual, precision);",
            /* newAssertion: */ "Assert.NotEqual(expected, actual, precision);")]
        [DataRow(
            /* oldAssertion: */ "Assert.NotEqual(expected, actual, 5);",
            /* newAssertion: */ "Assert.NotEqual(expected, actual, 5);")]
        [Implemented]
        public void AssertDecimalNotEqualWithPrecision_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertNotEqualCodeFix, AssertNotEqualAnalyzer>("decimal actual, decimal expected, int precision", oldAssertion, newAssertion);
        
        [DataTestMethod]
        [DataRow("Assert.NotEqual(expected, actual, comparer);")]
        [DataRow("Assert.NotEqual(expected, actual, ReferenceEqualityComparer.Instance);")]
        [Implemented]
        public void AssertObjectNotEqualWithComparer_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertNotEqualAnalyzer>("object actual, object expected, IEqualityComparer<object> comparer", assertion);

        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.NotEqual(expected, actual, comparer);",
            /* newAssertion: */ "actual.Should().NotBeEquivalentTo(expected, options => options.Using(comparer));")]
        [DataRow(
            /* oldAssertion: */ "Assert.NotEqual(expected, actual, ReferenceEqualityComparer.Instance);",
            /* newAssertion: */ "actual.Should().NotBeEquivalentTo(expected, options => options.Using(ReferenceEqualityComparer.Instance));")]
        [Implemented]
        public void AssertObjectNotEqualWithComparer_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertNotEqualCodeFix, AssertNotEqualAnalyzer>("object actual, object expected, IEqualityComparer<object> comparer", oldAssertion, newAssertion);
        
        [DataTestMethod]
        [DataRow("Assert.NotEqual(expected, actual);")]
        [Implemented]
        public void AssertObjectNotEqual_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertNotEqualAnalyzer>("object actual, object expected", assertion);
        
        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.NotEqual(expected, actual);",
            /* newAssertion: */ "actual.Should().NotBe(expected);")]
        [Implemented]
        public void AssertObjectNotEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertNotEqualCodeFix, AssertNotEqualAnalyzer>("object actual, object expected", oldAssertion, newAssertion);
        
        [DataTestMethod]
        [DataRow("Assert.NotStrictEqual(expected, actual);")]
        [Implemented]
        public void AssertObjectNotStrictEqual_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertNotStrictEqualAnalyzer>("object actual, object expected", assertion);
        
        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.NotStrictEqual(expected, actual);",
            /* newAssertion: */ "actual.Should().NotBe(expected);")]
        [Implemented]
        public void AssertObjectNotStrictEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertNotStrictEqualCodeFix, AssertNotStrictEqualAnalyzer>("object actual, object expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [DataRow("Assert.Null(actual);")]
        [Implemented]
        public void AssertNull_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertNullAnalyzer>("object actual", assertion);

        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.Null(actual);",
            /* newAssertion: */ "actual.Should().BeNull();")]
        [Implemented]
        public void AssertNull_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertNullCodeFix, AssertNullAnalyzer>("object actual", oldAssertion, newAssertion);

        [DataTestMethod]
        [DataRow("Assert.NotNull(actual);")]
        [Implemented]
        public void AssertNotNull_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertNotNullAnalyzer>("object actual", assertion);

        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.NotNull(actual);",
            /* newAssertion: */ "actual.Should().NotBeNull();")]
        [Implemented]
        public void AssertNotNull_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertNotNullCodeFix, AssertNotNullAnalyzer>("object actual", oldAssertion, newAssertion);

        [DataTestMethod]
        [DataRow("Assert.Contains(expected, actual);")]
        [Implemented]
        public void AssertStringContains_TestAnalyzer(string assertion) =>
            VerifyCSharpDiagnostic<AssertContainsAnalyzer>("string actual, string expected", assertion);

        [DataTestMethod]
        [DataRow(
            /* oldAssertion: */ "Assert.Contains(expected, actual);",
            /* newAssertion: */ "actual.Should().Contain(expected);")]
        [Implemented]
        public void AssertStringContains_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<AssertContainsCodeFix, AssertContainsAnalyzer>("string actual, string expected", oldAssertion, newAssertion);

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
                    new("Test0.cs", 13, 13)
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
