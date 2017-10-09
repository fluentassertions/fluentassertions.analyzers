using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace FluentAssertions.BestPractices.Tests
{
    [TestClass]
    public class CollectionTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [Assertion("actual.Any().Should().BeTrue();")]
        [Implemented]
        public void CollectionsShouldNotBeEmpty_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldNotBeEmptyAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Any().Should().BeTrue();",
            newAssertion: "actual.Should().NotBeEmpty();")]
        [Implemented]
        public void CollectionsShouldNotBeEmpty_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotBeEmptyCodeFix, CollectionShouldNotBeEmptyAnalyzer>();

        [TestMethod]
        [Assertion("actual.Any().Should().BeFalse();")]
        [Implemented]
        public void CollectionsShouldBeEmpty_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldBeEmptyAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Any().Should().BeFalse();",
            newAssertion: "actual.Should().BeEmpty();")]
        [Implemented]
        public void CollectionsShouldBeEmpty_TestCodeFix() => VerifyCSharpFix<CollectionShouldBeEmptyCodeFix, CollectionShouldBeEmptyAnalyzer>();

        [TestMethod]
        [Assertion("actual.Any(x => x.BooleanProperty).Should().BeTrue();")]
        [Implemented]
        public void CollectionShouldContainProperty_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldContainPropertyAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Any(x => x.BooleanProperty).Should().BeTrue();",
            newAssertion: "actual.Should().Contain(x => x.BooleanProperty);")]
        [Implemented]
        public void CollectionShouldContainProperty_TestCodeFix() => VerifyCSharpFix<CollectionShouldContainPropertyCodeFix, CollectionShouldContainPropertyAnalyzer>();

        [TestMethod]
        [Assertion("actual.Any(x => x.BooleanProperty).Should().BeFalse();")]
        [Implemented]
        public void CollectionShouldNotContainProperty_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldNotContainPropertyAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Any(x => x.BooleanProperty).Should().BeFalse();",
            newAssertion: "actual.Should().NotContain(x => x.BooleanProperty);")]
        [Implemented]
        public void CollectionShouldNotContainProperty_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotContainPropertyCodeFix, CollectionShouldNotContainPropertyAnalyzer>();

        [TestMethod]
        [Assertion("actual.All(x => x.BooleanProperty).Should().BeTrue();")]
        [Implemented]
        public void CollectionShouldOnlyContainProperty_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldOnlyContainPropertyAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.All(x => x.BooleanProperty).Should().BeTrue();",
            newAssertion: "actual.Should().OnlyContain(x => x.BooleanProperty);")]
        [Implemented]
        public void CollectionShouldOnlyContainProperty_TestCodeFix() => VerifyCSharpFix<CollectionShouldOnlyContainPropertyCodeFix, CollectionShouldOnlyContainPropertyAnalyzer>();

        [TestMethod]
        [Assertion("actual.Contains(expected).Should().BeTrue();")]
        [NotImplemented]
        public void CollectionShouldContainItem_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldContainItemAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Contains(expected).Should().BeTrue();",
            newAssertion: "actual.Should().Contain(expected);")]
        [NotImplemented]
        public void CollectionShouldContainItem_TestCodeFix() => VerifyCSharpFix<CollectionShouldContainItemCodeFix, CollectionShouldContainItemAnalyzer>();

        [TestMethod]
        [Assertion("actual.Contains(unexpected).Should().BeFalse();")]
        [NotImplemented]
        public void CollectionShouldNotContainItem_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldNotContainItemAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Contains(unexpected).Should().BeFalse();",
            newAssertion: "actual.Should().NotContain(unexpected);")]
        [NotImplemented]
        public void CollectionShouldNotContainItem_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotContainItemCodeFix, CollectionShouldNotContainItemAnalyzer>();

        [TestMethod]
        [Assertion("actual.Count().Should().Be(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCount_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveCountAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Count().Should().Be(k);",
            newAssertion: "actual.Should().HaveCount(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCount_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveCountCodeFix, CollectionShouldHaveCountAnalyzer>();

        [TestMethod]
        [Assertion("actual.Count().Should().BeGreaterThan(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterThan_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveCountGreaterThanAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Count().Should().BeGreaterThan(k);",
            newAssertion: "actual.Should().HaveCountGreaterThan(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterThan_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveCountGreaterThanCodeFix, CollectionShouldHaveCountGreaterThanAnalyzer>();

        [TestMethod]
        [Assertion("actual.Count().Should().BeGreaterOrEqualTo(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterOrEqualTo_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveCountGreaterOrEqualToAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Count().Should().BeGreaterOrEqualTo(k);",
            newAssertion: "actual.Should().HaveCountGreaterOrEqualTo(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterOrEqualTo_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveCountGreaterOrEqualToCodeFix, CollectionShouldHaveCountGreaterOrEqualToAnalyzer>();

        [TestMethod]
        [Assertion("actual.Count().Should().BeLessThan(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessThan_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveCountLessThanAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Count().Should().BeLessThan(k);",
            newAssertion: "actual.Should().HaveCountLessThan(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessThan_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveCountLessThanCodeFix, CollectionShouldHaveCountLessThanAnalyzer>();

        [TestMethod]
        [Assertion("actual.Count().Should().BeLessOrEqualTo(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessOrEqualTo_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveCountLessOrEqualToAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Count().Should().BeLessOrEqualTo(k);",
            newAssertion: "actual.Should().HaveCountLessOrEqualTo(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessOrEqualTo_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveCountLessOrEqualToCodeFix, CollectionShouldHaveCountLessOrEqualToAnalyzer>();

        [TestMethod]
        [Assertion("actual.Count().Should().NotBe(k);")]
        [NotImplemented]
        public void CollectionShouldNotHaveCount_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldNotHaveCountAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Count().Should().NotBe(k);",
            newAssertion: "actual.Should().NotHaveCount(k);")]
        [NotImplemented]
        public void CollectionShouldNotHaveCount_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotHaveCountCodeFix, CollectionShouldNotHaveCountAnalyzer>();

        [TestMethod]
        [Assertion("actual.Should().HaveCount(1);")]
        [NotImplemented]
        public void CollectionShouldContainSingle_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldContainSingleAnalyzer>();

        [TestMethod]
        [Assertion(oldAssertion: "actual.Should().HaveCount(1);",
            newAssertion: "actual.Should().ContainSingle();")]
        [NotImplemented]
        public void CollectionShouldContainSingle_TestCodeFix() => VerifyCSharpFix<CollectionShouldContainSingleCodeFix, CollectionShouldContainSingleAnalyzer>();

        [TestMethod]
        [Assertion("actual.Should().HaveCount(0);")]
        [NotImplemented]
        public void CollectionShouldBeEmpty_TestAnalyzer02() => VerifyCSharpDiagnostic<CollectionShouldBeEmptyAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Should().HaveCount(0);",
            newAssertion: "actual.Should().BeEmpty();")]
        [NotImplemented]
        public void CollectionShouldBeEmpty_TestCodeFix02() => VerifyCSharpFix<CollectionShouldBeEmptyCodeFix, CollectionShouldBeEmptyAnalyzer>();

        [TestMethod]
        [Assertion("actual.Should().HaveCount(expected.Count());")]
        [NotImplemented]
        public void CollectionShouldHaveSameCount_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveSameCountAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Should().HaveCount(expected.Count());",
            newAssertion: "actual.Should().HaveSameCount(expected);")]
        [NotImplemented]
        public void CollectionShouldHaveSameCount_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveSameCountCodeFix, CollectionShouldHaveSameCountAnalyzer>();


        [TestMethod]
        [Assertion("actual.Count().Should().NotBe(unexpected.Count());")]
        [NotImplemented]
        public void CollectionShouldNotHaveSameCount_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldNotHaveSameCountAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Count().Should().NotBe(unexpected.Count());",
            newAssertion: "actual.Should().NotHaveSameCount(unexpected);")]
        [NotImplemented]
        public void CollectionShouldNotHaveSameCount_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotHaveSameCountCodeFix, CollectionShouldNotHaveSameCountAnalyzer>();

        [TestMethod]
        [Assertion("actual.Where(x => x.BooleanProperty).Should().NotBeEmpty();")]
        [NotImplemented]
        public void CollectionShouldContainProperty_TestAnalyzer02() => VerifyCSharpDiagnostic<CollectionShouldContainPropertyAnalyzer>();

        [TestMethod]
        [Assertion(
            oldAssertion: "actual.Where(x => x.SomeProperty).Should().NotBeEmpty();",
            newAssertion: "actual.Should().Contain(x => x.BooleanProperty);")]
        [NotImplemented]
        public void CollectionShouldContainProperty_TestCodeFix02() => VerifyCSharpFix<CollectionShouldContainPropertyCodeFix, CollectionShouldContainPropertyAnalyzer>();

        private void VerifyCSharpDiagnostic<TDiagnosticAnalyzer>() where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var method = GetType().GetMethod(TestContext.TestName);
            var attribute = method.GetCustomAttribute<AssertionAttribute>();

            VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(attribute.Assertion);
        }

        private void VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(string sourceAssersion) where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var source = GenerateCode.EnumerableAssertion(sourceAssersion);

            var type = typeof(TDiagnosticAnalyzer);
            var diagnosticId = (string)type.GetField("DiagnosticId").GetValue(null);
            var message = (string)type.GetField("Message").GetValue(null);

            DiagnosticVerifier.VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(source, new DiagnosticResult
            {
                Id = diagnosticId,
                Message = string.Format(message, GenerateCode.ActualVariableName),
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 7,13)
                },
                Severity = DiagnosticSeverity.Info
            });
        }

        private void VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>()
            where TCodeFixProvider : Microsoft.CodeAnalysis.CodeFixes.CodeFixProvider, new()
            where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var method = GetType().GetMethod(TestContext.TestName);
            var attribute = method.GetCustomAttribute<AssertionAttribute>();

            VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>(attribute.OldAssertion, attribute.NewAssertion);
        }

        private void VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>(string oldSourceAssertion, string newSourceAssertion)
            where TCodeFixProvider : Microsoft.CodeAnalysis.CodeFixes.CodeFixProvider, new()
            where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var oldSource = GenerateCode.EnumerableAssertion(oldSourceAssertion);
            var newSource = GenerateCode.EnumerableAssertion(newSourceAssertion);

            DiagnosticVerifier.VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>(oldSource, newSource);
        }
    }
}
