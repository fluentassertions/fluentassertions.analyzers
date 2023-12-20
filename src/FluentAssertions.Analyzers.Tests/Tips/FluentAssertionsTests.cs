using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.Tests
{
    [TestClass]
    public class FluentAssertionsTests
    {
        [TestMethod]
        [Implemented]
        public void ShouldNotReturnEarly_WhenFluentAssertionsIsNotLoaded()
        {
            const string source = @"
namespace TestProject
{
    public class TestClass
    {
    }
}";

            DiagnosticVerifier.VerifyDiagnostic(new DiagnosticVerifierArguments()
                .WithDiagnosticAnalyzer<FluentAssertionsOperationAnalyzer>()
                .WithSources(source)
            );
        }

        [TestMethod]
        [Implemented]
        public void ShouldNotReturnEarly_WhenShouldInvocationIsNotFromFluentAssertions()
        {
            const string source = @"
namespace TestProject
{
    public class TestClass
    {
        public void TestMethod()
        {
            var test = new TestClassA();
            test.Length.Should().BeTrue();
        }
    }
    public class TestClassA
    {
        public TestClassA Length => this;
        public TestClassB Should() => new TestClassB();
    }
    public class TestClassB
    {
        public void BeTrue() { }
    }
}";

            DiagnosticVerifier.VerifyDiagnostic(new DiagnosticVerifierArguments()
                .WithDiagnosticAnalyzer<FluentAssertionsOperationAnalyzer>()
                .WithPackageReferences(PackageReference.FluentAssertions_6_12_0)
                .WithSources(source)
            );
        }
    }
}