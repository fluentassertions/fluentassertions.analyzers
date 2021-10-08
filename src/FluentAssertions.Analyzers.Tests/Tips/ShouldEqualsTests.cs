using FluentAssertions.Analyzers.Tips;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

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

            DiagnosticVerifier.VerifyCSharpFix<ShouldEqualsCodeFix, ShouldEqualsAnalyzer>(oldSource, newSource);
        }

        [TestMethod]
        [Implemented]
        public void ShouldEquals_ShouldBe_NumberType_TestCodeFix()
        {
            var oldSource = GenerateCode.NumericAssertion("actual.Should().Equals(expected);");
            var newSource = GenerateCode.NumericAssertion("actual.Should().Be(expected);");

            DiagnosticVerifier.VerifyCSharpFix<ShouldEqualsCodeFix, ShouldEqualsAnalyzer>(oldSource, newSource);
        }

        [TestMethod]
        [Implemented]
        public void ShouldEquals_ShouldBe_StringType_TestCodeFix()
        {
            var oldSource = GenerateCode.StringAssertion("actual.Should().Equals(expected);");
            var newSource = GenerateCode.StringAssertion("actual.Should().Be(expected);");

            DiagnosticVerifier.VerifyCSharpFix<ShouldEqualsCodeFix, ShouldEqualsAnalyzer>(oldSource, newSource);
        }

        [TestMethod]
        [Implemented]
        public void ShouldEquals_ShouldEqual_EnumerableType_TestCodeFix()
        {
            var oldSource = GenerateCode.EnumerableCodeBlockAssertion("actual.Should().Equals(expected);");
            var newSource = GenerateCode.EnumerableCodeBlockAssertion("actual.Should().Equal(expected);");

            DiagnosticVerifier.VerifyCSharpFix<ShouldEqualsCodeFix, ShouldEqualsAnalyzer>(oldSource, newSource);

            Stream s = new MemoryStream(); s.Should();
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
