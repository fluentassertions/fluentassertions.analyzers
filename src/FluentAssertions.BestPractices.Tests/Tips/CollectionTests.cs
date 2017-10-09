using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace FluentAssertions.BestPractices.Tests
{
    [TestClass]
    public class CollectionTests
    {
        public TestContext TestContext { get; set; }

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Any().Should().BeTrue();")]
        [Implemented]
        public void CollectionsShouldNotBeEmpty_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldNotBeEmptyAnalyzer>(assertion);

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Any().Should().BeTrue();",
            newAssertion: "actual.Should().NotBeEmpty();")]
        [Implemented]
        public void CollectionsShouldNotBeEmpty_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotBeEmptyCodeFix, CollectionShouldNotBeEmptyAnalyzer>();

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Any().Should().BeFalse();")]
        [AssertionDiagnostic("actual.Should().HaveCount(0);")]
        [Implemented]
        public void CollectionsShouldBeEmpty_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldBeEmptyAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Any().Should().BeFalse();",
            newAssertion: "actual.Should().BeEmpty();")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().HaveCount(0);",
            newAssertion: "actual.Should().BeEmpty();")]
        [Implemented]
        public void CollectionsShouldBeEmpty_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldBeEmptyCodeFix, CollectionShouldBeEmptyAnalyzer>(oldAssertion, newAssertion);

        [TestMethod]
        [AssertionDiagnostic("actual.Any(x => x.BooleanProperty).Should().BeTrue();")]
        [Implemented]
        public void CollectionShouldContainProperty_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Any(x => x.BooleanProperty).Should().BeTrue();",
            newAssertion: "actual.Should().Contain(x => x.BooleanProperty);")]
        [Implemented]
        public void CollectionShouldContainProperty_TestCodeFix() => VerifyCSharpFix<CollectionShouldContainPropertyCodeFix, CollectionShouldContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Any(x => x.BooleanProperty).Should().BeFalse();")]
        [Implemented]
        public void CollectionShouldNotContainProperty_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldNotContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Any(x => x.BooleanProperty).Should().BeFalse();",
            newAssertion: "actual.Should().NotContain(x => x.BooleanProperty);")]
        [Implemented]
        public void CollectionShouldNotContainProperty_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotContainPropertyCodeFix, CollectionShouldNotContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.All(x => x.BooleanProperty).Should().BeTrue();")]
        [Implemented]
        public void CollectionShouldOnlyContainProperty_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldOnlyContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.All(x => x.BooleanProperty).Should().BeTrue();",
            newAssertion: "actual.Should().OnlyContain(x => x.BooleanProperty);")]
        [Implemented]
        public void CollectionShouldOnlyContainProperty_TestCodeFix() => VerifyCSharpFix<CollectionShouldOnlyContainPropertyCodeFix, CollectionShouldOnlyContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Contains(expectedItem).Should().BeTrue();")]
        [NotImplemented]
        public void CollectionShouldContainItem_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldContainItemAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Contains(expectedItem).Should().BeTrue();",
            newAssertion: "actual.Should().Contain(expectedItem);")]
        [NotImplemented]
        public void CollectionShouldContainItem_TestCodeFix() => VerifyCSharpFix<CollectionShouldContainItemCodeFix, CollectionShouldContainItemAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Contains(unexpectedItem).Should().BeFalse();")]
        [NotImplemented]
        public void CollectionShouldNotContainItem_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldNotContainItemAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Contains(unexpectedItem).Should().BeFalse();",
            newAssertion: "actual.Should().NotContain(unexpectedItem);")]
        [NotImplemented]
        public void CollectionShouldNotContainItem_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotContainItemCodeFix, CollectionShouldNotContainItemAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Count().Should().Be(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCount_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveCountAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().Be(k);",
            newAssertion: "actual.Should().HaveCount(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCount_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveCountCodeFix, CollectionShouldHaveCountAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Count().Should().BeGreaterThan(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterThan_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveCountGreaterThanAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().BeGreaterThan(k);",
            newAssertion: "actual.Should().HaveCountGreaterThan(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterThan_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveCountGreaterThanCodeFix, CollectionShouldHaveCountGreaterThanAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Count().Should().BeGreaterOrEqualTo(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterOrEqualTo_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveCountGreaterOrEqualToAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().BeGreaterOrEqualTo(k);",
            newAssertion: "actual.Should().HaveCountGreaterOrEqualTo(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterOrEqualTo_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveCountGreaterOrEqualToCodeFix, CollectionShouldHaveCountGreaterOrEqualToAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Count().Should().BeLessThan(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessThan_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveCountLessThanAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().BeLessThan(k);",
            newAssertion: "actual.Should().HaveCountLessThan(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessThan_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveCountLessThanCodeFix, CollectionShouldHaveCountLessThanAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Count().Should().BeLessOrEqualTo(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessOrEqualTo_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveCountLessOrEqualToAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().BeLessOrEqualTo(k);",
            newAssertion: "actual.Should().HaveCountLessOrEqualTo(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessOrEqualTo_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveCountLessOrEqualToCodeFix, CollectionShouldHaveCountLessOrEqualToAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Count().Should().NotBe(k);")]
        [NotImplemented]
        public void CollectionShouldNotHaveCount_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldNotHaveCountAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().NotBe(k);",
            newAssertion: "actual.Should().NotHaveCount(k);")]
        [NotImplemented]
        public void CollectionShouldNotHaveCount_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotHaveCountCodeFix, CollectionShouldNotHaveCountAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Should().HaveCount(1);")]
        [NotImplemented]
        public void CollectionShouldContainSingle_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldContainSingleAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(oldAssertion: "actual.Should().HaveCount(1);",
            newAssertion: "actual.Should().ContainSingle();")]
        [NotImplemented]
        public void CollectionShouldContainSingle_TestCodeFix() => VerifyCSharpFix<CollectionShouldContainSingleCodeFix, CollectionShouldContainSingleAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Should().HaveCount(expected.Count());")]
        [NotImplemented]
        public void CollectionShouldHaveSameCount_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveSameCountAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().HaveCount(expected.Count());",
            newAssertion: "actual.Should().HaveSameCount(expected);")]
        [NotImplemented]
        public void CollectionShouldHaveSameCount_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveSameCountCodeFix, CollectionShouldHaveSameCountAnalyzer>();


        [TestMethod]
        [AssertionDiagnostic("actual.Count().Should().NotBe(unexpected.Count());")]
        [NotImplemented]
        public void CollectionShouldNotHaveSameCount_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldNotHaveSameCountAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().NotBe(unexpected.Count());",
            newAssertion: "actual.Should().NotHaveSameCount(unexpected);")]
        [NotImplemented]
        public void CollectionShouldNotHaveSameCount_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotHaveSameCountCodeFix, CollectionShouldNotHaveSameCountAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Where(x => x.BooleanProperty).Should().NotBeEmpty();")]
        [NotImplemented]
        public void CollectionShouldContainProperty_TestAnalyzer02() => VerifyCSharpDiagnostic<CollectionShouldContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Where(x => x.BooleanProperty).Should().NotBeEmpty();",
            newAssertion: "actual.Should().Contain(x => x.BooleanProperty);")]
        [NotImplemented]
        public void CollectionShouldContainProperty_TestCodeFix02() => VerifyCSharpFix<CollectionShouldContainPropertyCodeFix, CollectionShouldContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Where(x => x.BooleanProperty).Should().NotBeEmpty();")]
        [NotImplemented]
        public void CollectionShouldContainProperty_TestAnalyzer03() => VerifyCSharpDiagnostic<CollectionShouldContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Where(x => x.BooleanProperty).Should().NotBeEmpty();",
        newAssertion: "actual.Should().Contain(x => x.BooleanProperty);")]
        [NotImplemented]
        public void CollectionShouldContainProperty_TestCodeFix03() => VerifyCSharpFix<CollectionShouldContainPropertyCodeFix, CollectionShouldContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Where(x => x.BooleanProperty).Should().BeEmpty();")]
        [NotImplemented]
        public void CollectionShouldNotContainProperty_TestAnalyzer02() => VerifyCSharpDiagnostic<CollectionShouldNotContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Where(x => x.BooleanProperty).Should().BeEmpty();",
        newAssertion: "actual.Should().NotContain(x => x.BooleanProperty);")]
        [NotImplemented]
        public void CollectionShouldNotContainProperty_TestCodeFix02() => VerifyCSharpFix<CollectionShouldNotContainPropertyCodeFix, CollectionShouldNotContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Where(x => x.BooleanProperty).Should().HaveCount(1);")]
        [NotImplemented]
        public void CollectionShouldContainSingleProperty_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldContainSinglePropertyAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Where(x => x.BooleanProperty).Should().HaveCount(1);",
        newAssertion: "actual.Should().ContainSingle(x => x.BooleanProperty);")]
        [NotImplemented]
        public void CollectionShouldContainSingleProperty_TestCodeFix() => VerifyCSharpFix<CollectionShouldContainSinglePropertyCodeFix, CollectionShouldContainSinglePropertyAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Should().OnlyContain(e => !e.SomeProperty);")]
        [NotImplemented]
        public void CollectionShouldNotContainProperty_TestAnalyzer03() => VerifyCSharpDiagnostic<CollectionShouldNotContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Should().OnlyContain(e => !e.SomeProperty);",
        newAssertion: "actual.Should().NotContain(x => x.BooleanProperty);")]
        [NotImplemented]
        public void CollectionShouldNotContainProperty_TestCodeFix03() => VerifyCSharpFix<CollectionShouldNotContainPropertyCodeFix, CollectionShouldNotContainPropertyAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Should().NotBeNull().And.NotBeEmpty();")]
        [NotImplemented]
        public void CollectionShouldNotBeNullOrEmpty_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldNotBeNullOrEmptyAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Should().NotBeNull().And.NotBeEmpty();",
        newAssertion: "actual.Should().NotBeNullOrEmpty();")]
        [NotImplemented]
        public void CollectionShouldNotBeNullOrEmpty_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotBeNullOrEmptyCodeFix, CollectionShouldNotBeNullOrEmptyAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.ElementAt(k).Should().Be(expected);")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveElementAtAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.ElementAt(k).Should().Be(expected);",
        newAssertion: "actual.Should().HaveElementAt(k, expected);")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveElementAtCodeFix, CollectionShouldHaveElementAtAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual[k].Should().Be(expected);")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt_TestAnalyzer02() => VerifyCSharpDiagnostic<CollectionShouldHaveElementAtAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual[k].Should().Be(expected);",
        newAssertion: "actual.Should().HaveElementAt(k, expected);")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt_TestCodeFix02() => VerifyCSharpFix<CollectionShouldHaveElementAtCodeFix, CollectionShouldHaveElementAtAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Skip(k).First().Should().Be(expected);")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt_TestAnalyzer03() => VerifyCSharpDiagnostic<CollectionShouldHaveElementAtAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Skip(k).First().Should().Be(expected);",
        newAssertion: "actual.Should().HaveElementAt(k, expected);")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt_TestCodeFix03() => VerifyCSharpFix<CollectionShouldHaveElementAtCodeFix, CollectionShouldHaveElementAtAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.OrderBy(x => x.BooleanProperty).Should().Equal(actual);")]
        [NotImplemented]
        public void CollectionShouldBeInAscendingOrder_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldBeInAscendingOrderAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.OrderBy(x => x.BooleanProperty).Should().Equal(actual);",
        newAssertion: "actual.Should().BeInAscendingOrder(x => x.BooleanProperty);")]
        [NotImplemented]
        public void CollectionShouldBeInAscendingOrder_TestCodeFix() => VerifyCSharpFix<CollectionShouldBeInAscendingOrderCodeFix, CollectionShouldBeInAscendingOrderAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.OrderByDescending(x => x.BooleanProperty).Should().Equal(actual);")]
        [NotImplemented]
        public void CollectionShouldBeInDescendingOrder_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldBeInDescendingOrderAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.OrderByDescending(x => x.BooleanProperty).Should().Equal(actual);",
        newAssertion: "actual.Should().BeInDescendingOrder(x => x.BooleanProperty);")]
        [NotImplemented]
        public void CollectionShouldBeInDescendingOrder_TestCodeFix() => VerifyCSharpFix<CollectionShouldBeInDescendingOrderCodeFix, CollectionShouldBeInDescendingOrderAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Select(e1 => e1.SomeProperty).Should().Equal(expected.Select(e2 => e2.SomeProperty));")]
        [NotImplemented]
        public void CollectionShouldEqualOtherCollectionByComparer_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldEqualOtherCollectionByComparerAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Select(e1 => e1.SomeProperty).Should().Equal(expected.Select(e2 => e2.SomeProperty));",
        newAssertion: "actual.Should().Equal(expected, (e1, e2) => e1.SomeProperty == e2.SomeProperty);")]
        [NotImplemented]
        public void CollectionShouldEqualOtherCollectionByComparer_TestCodeFix() => VerifyCSharpFix<CollectionShouldEqualOtherCollectionByComparerCodeFix, CollectionShouldEqualOtherCollectionByComparerAnalyzer>();

        [TestMethod]
        [AssertionDiagnostic("actual.Intersect(expected).Should().BeEmpty();")]
        [NotImplemented]
        public void CollectionShouldNotIntersectWith_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldNotIntersectWithAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Intersect(expected).Should().BeEmpty();",
        newAssertion: "actual.Should().NotIntersectWith(expected);")]
        [NotImplemented]
        public void CollectionShouldNotIntersectWith_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotIntersectWithCodeFix, CollectionShouldNotIntersectWithAnalyzer>();
        [TestMethod]
        [AssertionDiagnostic("actual.Intersect(expected).Should().NotBeEmpty();")]
        [NotImplemented]
        public void CollectionShouldIntersectWith_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldIntersectWithAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Intersect(expected).Should().NotBeEmpty();",
        newAssertion: "actual.Should().IntersectWith(expected);")]
        [NotImplemented]
        public void CollectionShouldIntersectWith_TestCodeFix() => VerifyCSharpFix<CollectionShouldIntersectWithCodeFix, CollectionShouldIntersectWithAnalyzer>();
        [TestMethod]
        [AssertionDiagnostic("actual.Select(x => x.BooleanProperty).Should().NotContainNulls();")]
        [NotImplemented]
        public void CollectionShouldNotContainNulls_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldNotContainNullsAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Select(x => x.BooleanProperty).Should().NotContainNulls();",
        newAssertion: "actual.Should().NotContainNulls(e => e.OtherProperty);")]
        [NotImplemented]
        public void CollectionShouldNotContainNulls_TestCodeFix() => VerifyCSharpFix<CollectionShouldNotContainNullsCodeFix, CollectionShouldNotContainNullsAnalyzer>();
        [TestMethod]
        [AssertionDiagnostic("actual.Should().HaveSameCount(actual.Distinct());")]
        [NotImplemented]
        public void CollectionShouldOnlyHaveUniqueItems_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldOnlyHaveUniqueItemsAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Should().HaveSameCount(actual.Distinct());",
        newAssertion: "actual.Should().OnlyHaveUniqueItems();")]
        [NotImplemented]
        public void CollectionShouldOnlyHaveUniqueItems_TestCodeFix() => VerifyCSharpFix<CollectionShouldOnlyHaveUniqueItemsCodeFix, CollectionShouldOnlyHaveUniqueItemsAnalyzer>();
        [TestMethod]
        [AssertionDiagnostic("actual.Select(x => x.BooleanProperty).Should().OnlyHaveUniqueItems();")]
        [NotImplemented]
        public void CollectionShouldOnlyHaveUniqueItemsByComparer_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldOnlyHaveUniqueItemsByComparerAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Select(x => x.BooleanProperty).Should().OnlyHaveUniqueItems();",
        newAssertion: "actual.Should().OnlyHaveUniqueItems(x => x.BooleanProperty);")]
        [NotImplemented]
        public void CollectionShouldOnlyHaveUniqueItemsByComparer_TestCodeFix() => VerifyCSharpFix<CollectionShouldOnlyHaveUniqueItemsByComparerCodeFix, CollectionShouldOnlyHaveUniqueItemsByComparerAnalyzer>();
        [TestMethod]
        [AssertionDiagnostic("actual.FirstOrDefault().Should().BeNull();")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt0Null_TestAnalyzer() => VerifyCSharpDiagnostic<CollectionShouldHaveElementAt0NullAnalyzer>();

        [TestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.FirstOrDefault().Should().BeNull();",
        newAssertion: "actual.Should().HaveElementAt(0, null);")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt0Null_TestCodeFix() => VerifyCSharpFix<CollectionShouldHaveElementAt0NullCodeFix, CollectionShouldHaveElementAt0NullAnalyzer>();


        private void VerifyCSharpDiagnostic<TDiagnosticAnalyzer>() where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var method = GetType().GetMethod(TestContext.TestName);
            var attribute = method.GetCustomAttribute<AssertionDiagnosticAttribute>();

            VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(attribute.Assertion);
        }

        private void VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(string sourceAssersion) where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var source = GenerateCode.EnumerableAssertion(sourceAssersion);

            var type = typeof(TDiagnosticAnalyzer);
            var diagnosticId = (string)type.GetField("DiagnosticId").GetValue(null);
            var message = (string)type.GetField("Message").GetValue(null);

            DiagnosticVerifier.VerifyCSharpDiagnosticUsingAllAnalyzers(
            /*DiagnosticVerifier.VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(*/source, new DiagnosticResult
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
            var attribute = method.GetCustomAttribute<AssertionCodeFixAttribute>();

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
