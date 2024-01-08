using Microsoft.CodeAnalysis.CodeFixes;
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

        [TestMethod]
        [Implemented]
        public void ShouldAddFluentAssertionsUsing_WhenFluentAssertionIsNotInScope_ForXunit()
            => ShouldAddFluentAssertionsUsing_WhenFluentAssertionIsNotInScope<XunitCodeFixProvider>("True", "using Xunit;", PackageReference.XunitAssert_2_5_1);

        [TestMethod]
        [Implemented]
        public void ShouldNotAddFluentAssertionsUsing_WhenFluentAssertionIsInGlobalScope_ForXunit()
            => ShouldNotAddFluentAssertionsUsing_WhenFluentAssertionIsInGlobalScope<XunitCodeFixProvider>("True", "using Xunit;", PackageReference.XunitAssert_2_5_1);

        [TestMethod]
        [Implemented]
        public void ShouldNotAddFluentAssertionsUsing_WhenFluentAssertionIsInAnyScope_ForXunit()
            => ShouldNotAddFluentAssertionsUsing_WhenFluentAssertionIsInAnyScope<XunitCodeFixProvider>("True", "using Xunit;", PackageReference.XunitAssert_2_5_1);

        [TestMethod]
        [Implemented]
        public void ShouldAddFluentAssertionsUsing_WhenFluentAssertionIsNotInScope_ForMsTest()
            => ShouldAddFluentAssertionsUsing_WhenFluentAssertionIsNotInScope<MsTestCodeFixProvider>("IsTrue", "using Microsoft.VisualStudio.TestTools.UnitTesting;", PackageReference.MSTestTestFramework_3_1_1);

        [TestMethod]
        [Implemented]
        public void ShouldNotAddFluentAssertionsUsing_WhenFluentAssertionIsInGlobalScope_ForMsTest()
            => ShouldNotAddFluentAssertionsUsing_WhenFluentAssertionIsInGlobalScope<MsTestCodeFixProvider>("IsTrue", "using Microsoft.VisualStudio.TestTools.UnitTesting;", PackageReference.MSTestTestFramework_3_1_1);

        [TestMethod]
        [Implemented]
        public void ShouldNotAddFluentAssertionsUsing_WhenFluentAssertionIsInAnyScope_ForMsTest()
            => ShouldNotAddFluentAssertionsUsing_WhenFluentAssertionIsInAnyScope<MsTestCodeFixProvider>("IsTrue", "using Microsoft.VisualStudio.TestTools.UnitTesting;", PackageReference.MSTestTestFramework_3_1_1);

        private void ShouldAddFluentAssertionsUsing_WhenFluentAssertionIsNotInScope<TCodeFixProvider>(string assertTrue, string usingDirective, PackageReference testingLibraryReference) where TCodeFixProvider : CodeFixProvider, new()
        {
            string source = $@"
{usingDirective}
namespace TestProject
{{
    public class TestClass
    {{
        public void TestMethod(bool subject)
        {{
            Assert.{assertTrue}(subject);
        }}
    }}
}}";
            string newSource = @$"
using FluentAssertions;
{usingDirective}
namespace TestProject
{{
    public class TestClass
    {{
        public void TestMethod(bool subject)
        {{
            subject.Should().BeTrue();
        }}
    }}
}}";
            DiagnosticVerifier.VerifyFix(new CodeFixVerifierArguments()
                .WithDiagnosticAnalyzer<AssertAnalyzer>()
                .WithCodeFixProvider<TCodeFixProvider>()
                .WithPackageReferences(PackageReference.FluentAssertions_6_12_0, testingLibraryReference)
                .WithSources(source)
                .WithFixedSources(newSource)
            );
        }

        private void ShouldNotAddFluentAssertionsUsing_WhenFluentAssertionIsInGlobalScope<TCodeFixProvider>(string assertTrue, string usingDirective, PackageReference testingLibraryReference) where TCodeFixProvider : CodeFixProvider, new()
        {
            string source = $@"
{usingDirective}
namespace TestProject
{{
    public class TestClass
    {{
        public void TestMethod(bool subject)
        {{
            Assert.{assertTrue}(subject);
        }}
    }}
}}";
            const string globalUsings = "global using FluentAssertions;";
            string newSource = @$"
{usingDirective}
namespace TestProject
{{
    public class TestClass
    {{
        public void TestMethod(bool subject)
        {{
            subject.Should().BeTrue();
        }}
    }}
}}";

            DiagnosticVerifier.VerifyFix(new CodeFixVerifierArguments()
                .WithDiagnosticAnalyzer<AssertAnalyzer>()
                .WithCodeFixProvider<TCodeFixProvider>()
                .WithPackageReferences(PackageReference.FluentAssertions_6_12_0, testingLibraryReference)
                .WithSources(source, globalUsings)
                .WithFixedSources(newSource)
            );
        }

        private void ShouldNotAddFluentAssertionsUsing_WhenFluentAssertionIsInAnyScope<TCodeFixProvider>(string assertTrue, string usingDirective, PackageReference testingLibraryReference) where TCodeFixProvider : CodeFixProvider, new()
        {
            string source = $@"
{usingDirective}
namespace TestProject
{{
    using FluentAssertions;
    public class TestClass
    {{
        public void TestMethod(bool subject)
        {{
            Assert.{assertTrue}(subject);
        }}
    }}
}}";
            string newSource = @$"
{usingDirective}
namespace TestProject
{{
    using FluentAssertions;
    public class TestClass
    {{
        public void TestMethod(bool subject)
        {{
            subject.Should().BeTrue();
        }}
    }}
}}";

            DiagnosticVerifier.VerifyFix(new CodeFixVerifierArguments()
                .WithDiagnosticAnalyzer<AssertAnalyzer>()
                .WithCodeFixProvider<TCodeFixProvider>()
                .WithPackageReferences(PackageReference.FluentAssertions_6_12_0, testingLibraryReference)
                .WithSources(source)
                .WithFixedSources(newSource)
            );
        }
    }
}