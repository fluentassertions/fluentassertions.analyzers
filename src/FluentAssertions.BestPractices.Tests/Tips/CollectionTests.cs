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
        [AssertionDiagnostic("actual.Any().Should().BeTrue({0});")]
        [Implemented]
        public void CollectionsShouldNotBeEmpty_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldNotBeEmptyAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Any().Should().BeTrue({0});",
            newAssertion: "actual.Should().NotBeEmpty({0});")]
        [Implemented]
        public void CollectionsShouldNotBeEmpty_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldNotBeEmptyCodeFix, CollectionShouldNotBeEmptyAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Any().Should().BeFalse({0});")]
        [AssertionDiagnostic("actual.Should().HaveCount(0{0});")]
        [Implemented]
        public void CollectionsShouldBeEmpty_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldBeEmptyAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Any().Should().BeFalse({0});",
            newAssertion: "actual.Should().BeEmpty({0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().HaveCount(0{0});",
            newAssertion: "actual.Should().BeEmpty({0});")]
        [Implemented]
        public void CollectionsShouldBeEmpty_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldBeEmptyCodeFix, CollectionShouldBeEmptyAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Any(x => x.BooleanProperty).Should().BeTrue({0});")]
        [AssertionDiagnostic("actual.Where(x => x.BooleanProperty).Should().NotBeEmpty({0});")]
        [Implemented]
        public void CollectionShouldContainProperty_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldContainPropertyAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Any(x => x.BooleanProperty).Should().BeTrue({0});",
            newAssertion: "actual.Should().Contain(x => x.BooleanProperty{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.Where(x => x.BooleanProperty).Should().NotBeEmpty({0});",
            newAssertion: "actual.Should().Contain(x => x.BooleanProperty{0});")]
        [Implemented]
        public void CollectionShouldContainProperty_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldContainPropertyCodeFix, CollectionShouldContainPropertyAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Any(x => x.BooleanProperty).Should().BeFalse({0});")]
        [Implemented]
        public void CollectionShouldNotContainProperty_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldNotContainPropertyAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Any(x => x.BooleanProperty).Should().BeFalse({0});",
            newAssertion: "actual.Should().NotContain(x => x.BooleanProperty{0});")]
        [Implemented]
        public void CollectionShouldNotContainProperty_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldNotContainPropertyCodeFix, CollectionShouldNotContainPropertyAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.All(x => x.BooleanProperty).Should().BeTrue({0});")]
        [Implemented]
        public void CollectionShouldOnlyContainProperty_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldOnlyContainPropertyAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.All(x => x.BooleanProperty).Should().BeTrue({0});",
            newAssertion: "actual.Should().OnlyContain(x => x.BooleanProperty{0});")]
        [Implemented]
        public void CollectionShouldOnlyContainProperty_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldOnlyContainPropertyCodeFix, CollectionShouldOnlyContainPropertyAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Contains(expectedItem).Should().BeTrue({0});")]
        [Implemented]
        public void CollectionShouldContainItem_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldContainItemAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Contains(expectedItem).Should().BeTrue({0});",
            newAssertion: "actual.Should().Contain(expectedItem{0});")]
        [Implemented]
        public void CollectionShouldContainItem_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldContainItemCodeFix, CollectionShouldContainItemAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Contains(unexpectedItem).Should().BeFalse({0});")]
        [Implemented]
        public void CollectionShouldNotContainItem_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldNotContainItemAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Contains(unexpectedItem).Should().BeFalse({0});",
            newAssertion: "actual.Should().NotContain(unexpectedItem{0});")]
        [Implemented]
        public void CollectionShouldNotContainItem_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldNotContainItemCodeFix, CollectionShouldNotContainItemAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Count().Should().Be(k{0});")]
        [AssertionDiagnostic("actual.Count().Should().Be(6{0});")]
        [Implemented]
        public void CollectionShouldHaveCount_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldHaveCountAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().Be(k{0});",
            newAssertion: "actual.Should().HaveCount(k{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().Be(6{0});",
            newAssertion: "actual.Should().HaveCount(6{0});")]
        [Implemented]
        public void CollectionShouldHaveCount_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldHaveCountCodeFix, CollectionShouldHaveCountAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Count().Should().BeGreaterThan(k{0});")]
        [AssertionDiagnostic("actual.Count().Should().BeGreaterThan(6{0});")]
        [Implemented]
        public void CollectionShouldHaveCountGreaterThan_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldHaveCountGreaterThanAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().BeGreaterThan(k{0});",
            newAssertion: "actual.Should().HaveCountGreaterThan(k{0});")]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().BeGreaterThan(6{0});",
            newAssertion: "actual.Should().HaveCountGreaterThan(6{0});")]
        [Implemented]
        [Ignore("Waiting for official FluentAssertions 5.0")]
        public void CollectionShouldHaveCountGreaterThan_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldHaveCountGreaterThanCodeFix, CollectionShouldHaveCountGreaterThanAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Count().Should().BeGreaterOrEqualTo(k{0});")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterOrEqualTo_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldHaveCountGreaterOrEqualToAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().BeGreaterOrEqualTo(k{0});",
            newAssertion: "actual.Should().HaveCountGreaterOrEqualTo(k{0});")]
        [NotImplemented]
        [Ignore("Waiting for official FluentAssertions 5.0")]
        public void CollectionShouldHaveCountGreaterOrEqualTo_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldHaveCountGreaterOrEqualToCodeFix, CollectionShouldHaveCountGreaterOrEqualToAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Count().Should().BeLessThan(k{0});")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessThan_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldHaveCountLessThanAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().BeLessThan(k{0});",
            newAssertion: "actual.Should().HaveCountLessThan(k{0});")]
        [NotImplemented]
        [Ignore("Waiting for official FluentAssertions 5.0")]
        public void CollectionShouldHaveCountLessThan_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldHaveCountLessThanCodeFix, CollectionShouldHaveCountLessThanAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Count().Should().BeLessOrEqualTo(k{0});")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessOrEqualTo_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldHaveCountLessOrEqualToAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().BeLessOrEqualTo(k{0});",
            newAssertion: "actual.Should().HaveCountLessOrEqualTo(k{0});")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessOrEqualTo_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldHaveCountLessOrEqualToCodeFix, CollectionShouldHaveCountLessOrEqualToAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Count().Should().NotBe(k{0});")]
        [NotImplemented]
        public void CollectionShouldNotHaveCount_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldNotHaveCountAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().NotBe(k{0});",
            newAssertion: "actual.Should().NotHaveCount(k{0});")]
        [NotImplemented]
        public void CollectionShouldNotHaveCount_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldNotHaveCountCodeFix, CollectionShouldNotHaveCountAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Should().HaveCount(1{0});")]
        [NotImplemented]
        public void CollectionShouldContainSingle_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldContainSingleAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(oldAssertion: "actual.Should().HaveCount(1{0});",
            newAssertion: "actual.Should().ContainSingle({0});")]
        [NotImplemented]
        public void CollectionShouldContainSingle_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldContainSingleCodeFix, CollectionShouldContainSingleAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Should().HaveCount(expected.Count(){0});")]
        [NotImplemented]
        public void CollectionShouldHaveSameCount_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldHaveSameCountAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Should().HaveCount(expected.Count(){0});",
            newAssertion: "actual.Should().HaveSameCount(expected{0});")]
        [NotImplemented]
        public void CollectionShouldHaveSameCount_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldHaveSameCountCodeFix, CollectionShouldHaveSameCountAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Count().Should().NotBe(unexpected.Count(){0});")]
        [NotImplemented]
        public void CollectionShouldNotHaveSameCount_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldNotHaveSameCountAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "actual.Count().Should().NotBe(unexpected.Count(){0});",
            newAssertion: "actual.Should().NotHaveSameCount(unexpected{0});")]
        [NotImplemented]
        public void CollectionShouldNotHaveSameCount_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldNotHaveSameCountCodeFix, CollectionShouldNotHaveSameCountAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Where(x => x.BooleanProperty).Should().BeEmpty({0});")]
        [NotImplemented]
        public void CollectionShouldNotContainProperty_TestAnalyzer02(string assertion) => VerifyCSharpDiagnostic<CollectionShouldNotContainPropertyAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Where(x => x.BooleanProperty).Should().BeEmpty({0});",
        newAssertion: "actual.Should().NotContain(x => x.BooleanProperty{0});")]
        [NotImplemented]
        public void CollectionShouldNotContainProperty_TestCodeFix02(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldNotContainPropertyCodeFix, CollectionShouldNotContainPropertyAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Where(x => x.BooleanProperty).Should().HaveCount(1{0});")]
        [NotImplemented]
        public void CollectionShouldContainSingleProperty_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldContainSinglePropertyAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Where(x => x.BooleanProperty).Should().HaveCount(1{0});",
        newAssertion: "actual.Should().ContainSingle(x => x.BooleanProperty{0});")]
        [NotImplemented]
        public void CollectionShouldContainSingleProperty_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldContainSinglePropertyCodeFix, CollectionShouldContainSinglePropertyAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Should().OnlyContain(e => !e.BooleanProperty{0});")]
        [NotImplemented]
        public void CollectionShouldNotContainProperty_TestAnalyzer03(string assertion) => VerifyCSharpDiagnostic<CollectionShouldNotContainPropertyAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Should().OnlyContain(e => !e.BooleanProperty{0});",
        newAssertion: "actual.Should().NotContain(x => x.BooleanProperty{0});")]
        [NotImplemented]
        public void CollectionShouldNotContainProperty_TestCodeFix03(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldNotContainPropertyCodeFix, CollectionShouldNotContainPropertyAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Should().NotBeNull().And.NotBeEmpty({0});")]
        [NotImplemented]
        public void CollectionShouldNotBeNullOrEmpty_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldNotBeNullOrEmptyAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Should().NotBeNull({0}).And.NotBeEmpty({0});",
        newAssertion: "actual.Should().NotBeNullOrEmpty({0});")]
        [NotImplemented]
        public void CollectionShouldNotBeNullOrEmpty_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldNotBeNullOrEmptyCodeFix, CollectionShouldNotBeNullOrEmptyAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.ElementAt(k).Should().Be(expectedItem{0});")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldHaveElementAtAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.ElementAt(k).Should().Be(expectedItem{0});",
        newAssertion: "actual.Should().HaveElementAt(k, expectedItem{0});")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldHaveElementAtCodeFix, CollectionShouldHaveElementAtAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual[k].Should().Be(expectedItem{0});")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt_TestAnalyzer02(string assertion) => VerifyCSharpDiagnostic<CollectionShouldHaveElementAtAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual[k].Should().Be(expectedItem{0});",
        newAssertion: "actual.Should().HaveElementAt(k, expectedItem{0});")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt_TestCodeFix02(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldHaveElementAtCodeFix, CollectionShouldHaveElementAtAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Skip(k).First().Should().Be(expectedItem{0});")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt_TestAnalyzer03(string assertion) => VerifyCSharpDiagnostic<CollectionShouldHaveElementAtAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Skip(k).First().Should().Be(expectedItem{0});",
        newAssertion: "actual.Should().HaveElementAt(k, expectedItem{0});")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt_TestCodeFix03(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldHaveElementAtCodeFix, CollectionShouldHaveElementAtAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.OrderBy(x => x.BooleanProperty).Should().Equal(actual{0});")]
        [NotImplemented]
        public void CollectionShouldBeInAscendingOrder_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldBeInAscendingOrderAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.OrderBy(x => x.BooleanProperty).Should().Equal(actual{0});",
        newAssertion: "actual.Should().BeInAscendingOrder(x => x.BooleanProperty{0});")]
        [NotImplemented]
        public void CollectionShouldBeInAscendingOrder_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldBeInAscendingOrderCodeFix, CollectionShouldBeInAscendingOrderAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.OrderByDescending(x => x.BooleanProperty).Should().Equal(actual{0});")]
        [NotImplemented]
        public void CollectionShouldBeInDescendingOrder_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldBeInDescendingOrderAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.OrderByDescending(x => x.BooleanProperty).Should().Equal(actual{0});",
        newAssertion: "actual.Should().BeInDescendingOrder(x => x.BooleanProperty{0});")]
        [NotImplemented]
        public void CollectionShouldBeInDescendingOrder_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldBeInDescendingOrderCodeFix, CollectionShouldBeInDescendingOrderAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Select(e1 => e1.SomeProperty).Should().Equal(expected.Select(e2 => e2.SomeProperty){0});")]
        [NotImplemented]
        public void CollectionShouldEqualOtherCollectionByComparer_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldEqualOtherCollectionByComparerAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Select(e1 => e1.SomeProperty).Should().Equal(expected.Select(e2 => e2.SomeProperty){0});",
        newAssertion: "actual.Should().Equal(expected, (e1, e2) => e1.SomeProperty == e2.SomeProperty{0});")]
        [NotImplemented]
        public void CollectionShouldEqualOtherCollectionByComparer_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldEqualOtherCollectionByComparerCodeFix, CollectionShouldEqualOtherCollectionByComparerAnalyzer>(oldAssertion, newAssertion);

        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Intersect(expected).Should().BeEmpty({0});")]
        [NotImplemented]
        public void CollectionShouldNotIntersectWith_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldNotIntersectWithAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Intersect(expected).Should().BeEmpty({0});",
        newAssertion: "actual.Should().NotIntersectWith(expected{0});")]
        [NotImplemented]
        public void CollectionShouldNotIntersectWith_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldNotIntersectWithCodeFix, CollectionShouldNotIntersectWithAnalyzer>(oldAssertion, newAssertion);
        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Intersect(expected).Should().NotBeEmpty({0});")]
        [NotImplemented]
        public void CollectionShouldIntersectWith_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldIntersectWithAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Intersect(expected).Should().NotBeEmpty({0});",
        newAssertion: "actual.Should().IntersectWith(expected{0});")]
        [NotImplemented]
        public void CollectionShouldIntersectWith_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldIntersectWithCodeFix, CollectionShouldIntersectWithAnalyzer>(oldAssertion, newAssertion);
        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Select(x => x.BooleanProperty).Should().NotContainNulls({0});")]
        [NotImplemented]
        public void CollectionShouldNotContainNulls_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldNotContainNullsAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Select(x => x.BooleanProperty).Should().NotContainNulls({0});",
        newAssertion: "actual.Should().NotContainNulls(e => e.OtherProperty{0});")]
        [NotImplemented]
        public void CollectionShouldNotContainNulls_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldNotContainNullsCodeFix, CollectionShouldNotContainNullsAnalyzer>(oldAssertion, newAssertion);
        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Should().HaveSameCount(actual.Distinct(){0});")]
        [NotImplemented]
        public void CollectionShouldOnlyHaveUniqueItems_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldOnlyHaveUniqueItemsAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Should().HaveSameCount(actual.Distinct(){0});",
        newAssertion: "actual.Should().OnlyHaveUniqueItems({0});")]
        [NotImplemented]
        public void CollectionShouldOnlyHaveUniqueItems_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldOnlyHaveUniqueItemsCodeFix, CollectionShouldOnlyHaveUniqueItemsAnalyzer>(oldAssertion, newAssertion);
        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.Select(x => x.BooleanProperty).Should().OnlyHaveUniqueItems({0});")]
        [NotImplemented]
        public void CollectionShouldOnlyHaveUniqueItemsByComparer_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldOnlyHaveUniqueItemsByComparerAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.Select(x => x.BooleanProperty).Should().OnlyHaveUniqueItems({0});",
        newAssertion: "actual.Should().OnlyHaveUniqueItems(x => x.BooleanProperty{0});")]
        [NotImplemented]
        public void CollectionShouldOnlyHaveUniqueItemsByComparer_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldOnlyHaveUniqueItemsByComparerCodeFix, CollectionShouldOnlyHaveUniqueItemsByComparerAnalyzer>(oldAssertion, newAssertion);
        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual.FirstOrDefault().Should().BeNull({0});")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt0Null_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionShouldHaveElementAt0NullAnalyzer>(assertion);

        [AssertionDataTestMethod]
        [AssertionCodeFix(
        oldAssertion: "actual.FirstOrDefault().Should().BeNull({0});",
        newAssertion: "actual.Should().HaveElementAt(0, null{0});")]
        [NotImplemented]
        public void CollectionShouldHaveElementAt0Null_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionShouldHaveElementAt0NullCodeFix, CollectionShouldHaveElementAt0NullAnalyzer>(oldAssertion, newAssertion);

        private void VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(string sourceAssersion) where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var source = GenerateCode.EnumerableAssertion(sourceAssersion);

            var type = typeof(TDiagnosticAnalyzer);
            var diagnosticId = (string)type.GetField("DiagnosticId").GetValue(null);
            var message = (string)type.GetField("Message").GetValue(null);

            DiagnosticVerifier.VerifyCSharpDiagnosticUsingAllAnalyzers(source, new DiagnosticResult
            {
                Id = diagnosticId,
                Message = string.Format(message, GenerateCode.ActualVariableName),
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 11,13)
                },
                Severity = DiagnosticSeverity.Info
            });
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
