using FluentAssertions.Analyzers.Tips;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FluentAssertions.Analyzers.Tests.Tips
{
    [TestClass]
    public class ShouldEqualsTests
    {
        [TestMethod]
        [Implemented]
        public void ShouldEquals_TestAnalyzer()
            => VerifyCSharpDiagnosticExpressionBody("actual.Should().Equals(expected);");

        [TestMethod]
        [Implemented]
        public void ShouldEquals_ShouldBe_ObjectType_TestCodeFix()
        {
            var oldSource = GenerateCode.ObjectStatement("actual.Should().Equals(expected);");
            var newSource = GenerateCode.ObjectStatement("actual.Should().Be(expected);");

            DiagnosticVerifier.VerifyCSharpFix<ShouldEqualsBeCodeFix, ShouldEqualsAnalyzer>(oldSource, newSource);
        }

        [TestMethod]
        [Implemented]
        public void ShouldEquals_ShouldBe_NumberType_TestCodeFix()
        {
            var oldSource = GenerateCode.NumericAssertion("actual.Should().Equals(expected);");
            var newSource = GenerateCode.NumericAssertion("actual.Should().Be(expected);");

            DiagnosticVerifier.VerifyCSharpFix<ShouldEqualsBeCodeFix, ShouldEqualsAnalyzer>(oldSource, newSource);
        }

        [TestMethod]
        [Implemented]
        public void ShouldEquals_ShouldBe_StringType_TestCodeFix()
        {
            var oldSource = GenerateCode.StringAssertion("actual.Should().Equals(expected);");
            var newSource = GenerateCode.StringAssertion("actual.Should().Be(expected);");

            DiagnosticVerifier.VerifyCSharpFix<ShouldEqualsBeCodeFix, ShouldEqualsAnalyzer>(oldSource, newSource);
        }

        [TestMethod]
        [Implemented]
        public void ShouldEquals_ShouldBe_EnumerableType_TestCodeFix()
        {
            var source = GenerateCode.EnumerableCodeBlockAssertion("actual.Should().Equals(expected);");

            DiagnosticVerifier.VerifyCSharpFix<ShouldEqualsBeCodeFix, ShouldEqualsAnalyzer>(source, source);
        }

        [TestMethod]
        [Implemented]
        public void ShouldEquals_ShouldEqual_EnumerableType_TestCodeFix()
        {
            var oldSource = GenerateCode.EnumerableCodeBlockAssertion("actual.Should().Equals(expected);");
            var newSource = GenerateCode.EnumerableCodeBlockAssertion("actual.Should().Equal(expected);");

            DiagnosticVerifier.VerifyCSharpFix<ShouldEqualsEqualCodeFix, ShouldEqualsAnalyzer>(oldSource, newSource);
        }

        [TestMethod]
        [Implemented]
        public void ShouldEquals_ShouldEqual_ObjectType_TestCodeFix()
        {
            var source = GenerateCode.ObjectStatement("actual.Should().Equals(expected);");

            DiagnosticVerifier.VerifyCSharpFix<ShouldEqualsEqualCodeFix, ShouldEqualsAnalyzer>(source, source);
        }

        [TestMethod]
        [Implemented]
        public void ShouldEquals_ShouldEqual_NumberType_TestCodeFix()
        {
            var source = GenerateCode.NumericAssertion("actual.Should().Equals(expected);");

            DiagnosticVerifier.VerifyCSharpFix<ShouldEqualsEqualCodeFix, ShouldEqualsAnalyzer>(source, source);
        }

        [TestMethod]
        [Implemented]
        public void ShouldEquals_ShouldEqual_StringType_TestCodeFix()
        {
            var source = GenerateCode.StringAssertion("actual.Should().Equals(expected);");

            DiagnosticVerifier.VerifyCSharpFix<ShouldEqualsEqualCodeFix, ShouldEqualsAnalyzer>(source, source);
        }

        private void VerifyCSharpDiagnosticExpressionBody(string sourceAssertion)
        {
            var source = GenerateCode.ObjectStatement(sourceAssertion);
            DiagnosticVerifier.VerifyCSharpDiagnosticUsingAllAnalyzers(source, new DiagnosticResult
            {
                Id = ShouldEqualsAnalyzer.DiagnosticId,
                Message = ShouldEqualsAnalyzer.Message,
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 10,13)
                },
                Severity = DiagnosticSeverity.Info
            });
        }
    }
}
