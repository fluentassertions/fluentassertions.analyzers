using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.Tests.Tips
{
    [TestClass]
    public class SanityTests
    {
        [TestMethod]
        [NotImplemented(Reason = "https://github.com/fluentassertions/fluentassertions.analyzers/issues/10")]
        public void AssertionCallMultipleMethodWithTheSameNameAndArguments()
        {
            const string assertion = "actual.Should().Contain(d => d.Message.Contains(\"a\")).And.Contain(d => d.Message.Contains(\"c\"));";
            var source = GenerateCode.EnumerableAssertion(assertion);

            DiagnosticVerifier.VerifyCSharpDiagnosticUsingAllAnalyzers(source);
        }
    }
}
