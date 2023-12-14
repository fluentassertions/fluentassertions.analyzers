using System.Runtime.CompilerServices;

namespace FluentAssertions.Analyzers;

public class DiagnosticMetadata
{
    public string Name { get; }
    public string Message { get; }
    public string HelpLink { get; }

    private DiagnosticMetadata(string message, string helpLink, [CallerMemberName] string name = "")
    {
        Name = name;
        Message = message;
        HelpLink = helpLink;
    }

    public static DiagnosticMetadata CollectionShouldNotBeEmpty_AnyShouldBeTrue { get; } = new("Use .Should().NotBeEmpty()", GetHelpLink("Collections-1"));
    public static DiagnosticMetadata CollectionShouldBeEmpty_AnyShouldBeFalse { get; } = new("Use .Should().BeEmpty()", GetHelpLink("Collections-2"));
    public static DiagnosticMetadata CollectionShouldContainProperty_AnyWithLambdaShouldBeTrue { get; } = new("Use .Should().Contain()", GetHelpLink("Collections-3"));
    public static DiagnosticMetadata CollectionShouldNotContainProperty_AnyLambdaShouldBeFalse { get; } = new("Use .Should().NotContain()", GetHelpLink("Collections-4"));
    public static DiagnosticMetadata CollectionShouldOnlyContainProperty_AllShouldBeTrue { get; } = new("Use .Should().OnlyContain()", GetHelpLink("Collections-5"));
    public static DiagnosticMetadata CollectionShouldContainItem_ContainsShouldBeTrue { get; } = new("Use .Should().Contain()", GetHelpLink("Collections-6"));
    public static DiagnosticMetadata CollectionShouldNotContainItem_ContainsShouldBeFalse { get; } = new("Use .Should().NotContain()", GetHelpLink("Collections-7"));
    public static DiagnosticMetadata CollectionShouldNotContainItem_AnyShouldBeFalse { get; } = new("Use .Should().NotContain()", GetHelpLink("Collections-7"));
    // missing Collections-8
    public static DiagnosticMetadata CollectionShouldHaveCount_CountShouldBe { get; } = new("Use .Should().HaveCount()", GetHelpLink("Collections-9"));
    public static DiagnosticMetadata CollectionShouldHaveCount_LengthShouldBe { get; } = new("Use .Should().HaveCount()", GetHelpLink("Collections-9"));
    public static DiagnosticMetadata CollectionShouldHaveCountGreaterThan_CountShouldBeGreaterThan { get; } = new("Use .Should().HaveCountGreaterThan()", GetHelpLink("Collections-10"));
    public static DiagnosticMetadata CollectionShouldHaveCountGreaterOrEqualTo_CountShouldBeGreaterOrEqualTo { get; } = new("Use .Should().HaveCountGreaterOrEqualTo()", GetHelpLink("Collections-11"));
    public static DiagnosticMetadata CollectionShouldHaveCountLessThan_CountShouldBeLessThan { get; } = new("Use .Should().HaveCountLessThan()", GetHelpLink("Collections-12"));
    public static DiagnosticMetadata CollectionShouldHaveCountLessOrEqualTo_CountShouldBeLessOrEqualTo { get; } = new("Use .Should().HaveCountLessOrEqualTo()", GetHelpLink("Collections-13"));
    public static DiagnosticMetadata CollectionShouldNotHaveCount_CountShouldNotBe { get; } = new("Use .Should().NotHaveCount()", GetHelpLink("Collections-14"));
    public static DiagnosticMetadata CollectionShouldContainSingle_ShouldHaveCount1 { get; } = new("Use .Should().HaveCount()", GetHelpLink("Collections-15"));
    public static DiagnosticMetadata CollectionShouldHaveCount_CountShouldBe1 { get; } = new("Use .Should().HaveCount()", GetHelpLink("Collections-15"));
    public static DiagnosticMetadata CollectionShouldBeEmpty_ShouldHaveCount0 { get; } = new("Use .Should().BeEmpty()", GetHelpLink("Collections-16"));
    public static DiagnosticMetadata CollectionShouldHaveCount_CountShouldBe0 { get; } = new("Use .Should().HaveCount()", GetHelpLink("Collections-16"));
    public static DiagnosticMetadata CollectionShouldHaveSameCount_ShouldHaveCountOtherCollectionCount { get; } = new("Use .Should().HaveSameCount()", GetHelpLink("Collections-17"));
    public static DiagnosticMetadata CollectionShouldNotHaveSameCount_CountShouldNotBeOtherCollectionCount { get; } = new("Use .Should().NotHaveSameCount()", GetHelpLink("Collections-18"));
    public static DiagnosticMetadata CollectionShouldContainProperty_WhereShouldNotBeEmpty { get; } = new("Use .Should().NotBeEmpty()", GetHelpLink("Collections-19"));
    public static DiagnosticMetadata CollectionShouldNotContainProperty_WhereShouldBeEmpty { get; } = new("Use .Should().BeEmpty()", GetHelpLink("Collections-20"));
    public static DiagnosticMetadata CollectionShouldContainSingle_WhereShouldHaveCount1 { get; } = new("Use .Should().HaveCount()", GetHelpLink("Collections-21"));
    public static DiagnosticMetadata CollectionShouldNotContainProperty_ShouldOnlyContainNot { get; } = new("Use .Should().NotContain()", GetHelpLink("Collections-22"));
    public static DiagnosticMetadata CollectionShouldNotBeNullOrEmpty_ShouldNotBeNullAndNotBeEmpty { get; } = new("Use .Should().NotBeNullOrEmpty()", GetHelpLink("Collections-23"));
    public static DiagnosticMetadata CollectionShouldNotBeNullOrEmpty_ShouldNotBeEmptyAndNotBeNull { get; } = new("Use .Should().NotBeNullOrEmpty()", GetHelpLink("Collections-23"));
    public static DiagnosticMetadata CollectionShouldHaveElementAt_ElementAtIndexShouldBe { get; } = new("Use .Should().HaveElementAt()", GetHelpLink("Collections-24"));
    public static DiagnosticMetadata CollectionShouldHaveElementAt_IndexerShouldBe { get; } = new("Use .Should().HaveElementAt()", GetHelpLink("Collections-25"));
    public static DiagnosticMetadata CollectionShouldHaveElementAt_SkipFirstShouldBe { get; } = new("Use .Should().HaveElementAt()", GetHelpLink("Collections-26"));
    public static DiagnosticMetadata CollectionShouldBeInAscendingOrder_OrderByShouldEqual { get; } = new("Use .Should().BeInAscendingOrder()", GetHelpLink("Collections-27"));
    public static DiagnosticMetadata CollectionShouldBeInDescendingOrder_OrderByDescendingShouldEqual { get; } = new("Use .Should().BeInDescendingOrder()", GetHelpLink("Collections-28"));
    public static DiagnosticMetadata CollectionShouldEqualOtherCollectionByComparer_SelectShouldEqualOtherCollectionSelect { get; } = new("Use .Should().BeEquivalentTo()", GetHelpLink("Collections-29"));
    public static DiagnosticMetadata CollectionShouldNotIntersectWith_IntersectShouldBeEmpty { get; } = new("Use .Should().NotIntersectWith()", GetHelpLink("Collections-30"));
    public static DiagnosticMetadata CollectionShouldIntersectWith_IntersectShouldNotBeEmpty { get; } = new("Use .Should().IntersectWith()", GetHelpLink("Collections-31"));
    public static DiagnosticMetadata CollectionShouldNotContainNulls_SelectShouldNotContainNulls { get; } = new("Use .Should().NotContainNulls()", GetHelpLink("Collections-32"));
    public static DiagnosticMetadata CollectionShouldOnlyHaveUniqueItems_ShouldHaveSameCountThisCollectionDistinct { get; } = new("Use .Should().OnlyHaveUniqueItems()", GetHelpLink("Collections-33"));
    public static DiagnosticMetadata CollectionShouldOnlyHaveUniqueItemsByComparer_SelectShouldOnlyHaveUniqueItems { get; } = new("Use .Should().OnlyHaveUniqueItems()", GetHelpLink("Collections-34"));

    private static string GetHelpLink(string id) => $"https://fluentassertions.com/tips/#{id}";
}