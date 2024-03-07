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
    // missing Collections-8
    public static DiagnosticMetadata CollectionShouldHaveCount_CountShouldBe { get; } = new("Use .Should().HaveCount()", GetHelpLink("Collections-9"));
    public static DiagnosticMetadata CollectionShouldHaveCount_LengthShouldBe { get; } = new("Use .Should().HaveCount()", GetHelpLink("Collections-9"));
    public static DiagnosticMetadata CollectionShouldHaveCountGreaterThan_CountShouldBeGreaterThan { get; } = new("Use .Should().HaveCountGreaterThan()", GetHelpLink("Collections-10"));
    public static DiagnosticMetadata CollectionShouldHaveCountGreaterOrEqualTo_CountShouldBeGreaterOrEqualTo { get; } = new("Use .Should().HaveCountGreaterOrEqualTo()", GetHelpLink("Collections-11"));
    public static DiagnosticMetadata CollectionShouldHaveCountLessThan_CountShouldBeLessThan { get; } = new("Use .Should().HaveCountLessThan()", GetHelpLink("Collections-12"));
    public static DiagnosticMetadata CollectionShouldHaveCountLessOrEqualTo_CountShouldBeLessOrEqualTo { get; } = new("Use .Should().HaveCountLessOrEqualTo()", GetHelpLink("Collections-13"));
    public static DiagnosticMetadata CollectionShouldNotHaveCount_CountShouldNotBe { get; } = new("Use .Should().NotHaveCount()", GetHelpLink("Collections-14"));
    public static DiagnosticMetadata CollectionShouldContainSingle_ShouldHaveCount1 { get; } = new("Use .Should().ContainSingle()", GetHelpLink("Collections-15"));
    public static DiagnosticMetadata CollectionShouldContainSingle_CountShouldBe1 { get; } = new("Use .Should().ContainSingle()", GetHelpLink("Collections-15"));
    public static DiagnosticMetadata CollectionShouldContainSingle_CountPropertyShouldBe1 { get; } = new("Use .Should().ContainSingle()", GetHelpLink("Collections-15"));
    public static DiagnosticMetadata CollectionShouldBeEmpty_ShouldHaveCount0 { get; } = new("Use .Should().BeEmpty()", GetHelpLink("Collections-16"));
    public static DiagnosticMetadata CollectionShouldBeEmpty_CountShouldBe0 { get; } = new("Use .Should().BeEmpty()", GetHelpLink("Collections-16"));
    public static DiagnosticMetadata CollectionShouldBeEmpty_CountPropertyShouldBe0 { get; } = new("Use .Should().BeEmpty()", GetHelpLink("Collections-16"));
    public static DiagnosticMetadata CollectionShouldHaveSameCount_ShouldHaveCountOtherCollectionCount { get; } = new("Use .Should().HaveSameCount()", GetHelpLink("Collections-17"));
    public static DiagnosticMetadata CollectionShouldNotHaveSameCount_CountShouldNotBeOtherCollectionCount { get; } = new("Use .Should().NotHaveSameCount()", GetHelpLink("Collections-18"));
    public static DiagnosticMetadata CollectionShouldContainProperty_WhereShouldNotBeEmpty { get; } = new("Use .Should().Contain()", GetHelpLink("Collections-19"));
    public static DiagnosticMetadata CollectionShouldNotContainProperty_WhereShouldBeEmpty { get; } = new("Use .Should().NotContain()", GetHelpLink("Collections-20"));
    public static DiagnosticMetadata CollectionShouldContainSingle_WhereShouldHaveCount1 { get; } = new("Use .Should().HaveCount()", GetHelpLink("Collections-21"));
    public static DiagnosticMetadata CollectionShouldNotContainProperty_ShouldOnlyContainNot { get; } = new("Use .Should().NotContain()", GetHelpLink("Collections-22"));
    public static DiagnosticMetadata CollectionShouldNotBeNullOrEmpty_ShouldNotBeNullAndNotBeEmpty { get; } = new("Use .Should().NotBeNullOrEmpty()", GetHelpLink("Collections-23"));
    public static DiagnosticMetadata CollectionShouldNotBeNullOrEmpty_ShouldNotBeEmptyAndNotBeNull { get; } = new("Use .Should().NotBeNullOrEmpty()", GetHelpLink("Collections-23"));
    public static DiagnosticMetadata CollectionShouldHaveElementAt_ElementAtIndexShouldBe { get; } = new("Use .Should().HaveElementAt()", GetHelpLink("Collections-24"));
    public static DiagnosticMetadata CollectionShouldHaveElementAt_IndexerShouldBe { get; } = new("Use .Should().HaveElementAt()", GetHelpLink("Collections-25"));
    public static DiagnosticMetadata CollectionShouldHaveElementAt_SkipFirstShouldBe { get; } = new("Use .Should().HaveElementAt()", GetHelpLink("Collections-26"));
    public static DiagnosticMetadata CollectionShouldBeInAscendingOrder_OrderByShouldEqual { get; } = new("Use .Should().BeInAscendingOrder()", GetHelpLink("Collections-27"));
    public static DiagnosticMetadata CollectionShouldBeInDescendingOrder_OrderByDescendingShouldEqual { get; } = new("Use .Should().BeInDescendingOrder()", GetHelpLink("Collections-28"));
    public static DiagnosticMetadata CollectionShouldEqualOtherCollectionByComparer_SelectShouldEqualOtherCollectionSelect { get; } = new("Use .Should().Equal()", GetHelpLink("Collections-29"));
    public static DiagnosticMetadata CollectionShouldNotIntersectWith_IntersectShouldBeEmpty { get; } = new("Use .Should().NotIntersectWith()", GetHelpLink("Collections-30"));
    public static DiagnosticMetadata CollectionShouldIntersectWith_IntersectShouldNotBeEmpty { get; } = new("Use .Should().IntersectWith()", GetHelpLink("Collections-31"));
    public static DiagnosticMetadata CollectionShouldNotContainNulls_SelectShouldNotContainNulls { get; } = new("Use .Should().NotContainNulls()", GetHelpLink("Collections-32"));
    public static DiagnosticMetadata CollectionShouldOnlyHaveUniqueItems_ShouldHaveSameCountThisCollectionDistinct { get; } = new("Use .Should().OnlyHaveUniqueItems()", GetHelpLink("Collections-33"));
    public static DiagnosticMetadata CollectionShouldOnlyHaveUniqueItemsByComparer_SelectShouldOnlyHaveUniqueItems { get; } = new("Use .Should().OnlyHaveUniqueItems()", GetHelpLink("Collections-34"));

    public static DiagnosticMetadata NumericShouldBePositive_ShouldBeGreaterThan { get; } = new("Use .Should().BePositive()", GetHelpLink("Numeric-1"));
    public static DiagnosticMetadata NumericShouldBeNegative_ShouldBeLessThan { get; } = new("Use .Should().BeNegative()", GetHelpLink("Numeric-2"));
    public static DiagnosticMetadata NumericShouldBeInRange_BeGreaterOrEqualToAndBeLessOrEqualTo { get; } = new("Use .Should().BeInRange()", string.Empty);
    public static DiagnosticMetadata NumericShouldBeInRange_BeLessOrEqualToAndBeGreaterOrEqualTo { get; } = new("Use .Should().BeInRange()", string.Empty);
    public static DiagnosticMetadata NumericShouldBeApproximately_MathAbsShouldBeLessOrEqualTo { get; } = new("Use .Should().BeApproximately()", string.Empty);

    public static DiagnosticMetadata StringShouldStartWith_StartsWithShouldBeTrue { get; } = new("Use .Should().StartWith()", GetHelpLink("Strings-1"));
    public static DiagnosticMetadata StringShouldEndWith_EndsWithShouldBeTrue { get; } = new("Use .Should().EndWith()", GetHelpLink("Strings-2"));
    public static DiagnosticMetadata StringShouldNotBeNullOrEmpty_StringShouldNotBeNullAndNotBeEmpty { get; } = new("Use .Should().NotBeNullOrEmpty()", GetHelpLink("Strings-3"));
    public static DiagnosticMetadata StringShouldNotBeNullOrEmpty_StringShouldNotBeEmptyAndNotBeNull { get; } = new("Use .Should().NotBeNullOrEmpty()", GetHelpLink("Strings-3"));
    public static DiagnosticMetadata StringShouldBeNullOrEmpty_StringIsNullOrEmptyShouldBeTrue { get; } = new("Use .Should().BeNullOrEmpty()", GetHelpLink("Strings-4"));
    public static DiagnosticMetadata StringShouldNotBeNullOrEmpty_StringIsNullOrEmptyShouldBeFalse { get; } = new("Use .Should().NotBeNullOrEmpty()", GetHelpLink("Strings-5"));
    public static DiagnosticMetadata StringShouldBeNullOrWhiteSpace_StringIsNullOrWhiteSpaceShouldBeTrue { get; } = new("Use .Should().BeNullOrWhiteSpace()", GetHelpLink("Strings-6"));
    public static DiagnosticMetadata StringShouldNotBeNullOrWhiteSpace_StringShouldNotBeNullOrWhiteSpace { get; } = new("Use .Should().NotBeNullOrWhiteSpace()", GetHelpLink("Strings-7"));
    public static DiagnosticMetadata StringShouldHaveLength_LengthShouldBe { get; } = new("Use .Should().HaveLength()", GetHelpLink("Strings-8"));

    public static DiagnosticMetadata DictionaryShouldContainKey_ContainsKeyShouldBeTrue = new("Use .Should().ContainKey()", GetHelpLink("Dictionaries-1"));
    public static DiagnosticMetadata DictionaryShouldNotContainKey_ContainsKeyShouldBeFalse = new("Use .Should().NotContainKey() ", GetHelpLink("Dictionaries-2"));
    public static DiagnosticMetadata DictionaryShouldContainValue_ContainsValueShouldBeTrue = new("Use .Should().ContainValue() ", GetHelpLink("Dictionaries-3"));
    public static DiagnosticMetadata DictionaryShouldNotContainValue_ContainsValueShouldBeFalse = new("Use .Should().NotContainValue() ", GetHelpLink("Dictionaries-4"));
    public static DiagnosticMetadata DictionaryShouldContainKeyAndValue_ShouldContainKeyAndContainValue = new("Use .Should().Contain() ", GetHelpLink("Dictionaries-5"));
    public static DiagnosticMetadata DictionaryShouldContainKeyAndValue_ShouldContainValueAndContainKey = new("Use .Should().Contain() ", GetHelpLink("Dictionaries-5"));
    public static DiagnosticMetadata DictionaryShouldContainPair_ShouldContainKeyAndContainValue = new("Use .Should().Contain() ", GetHelpLink("Dictionaries-6"));
    public static DiagnosticMetadata DictionaryShouldContainPair_ShouldContainValueAndContainKey = new("Use .Should().Contain() ", GetHelpLink("Dictionaries-6"));

    public static DiagnosticMetadata ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldBe = new("Use .Should().ThrowExactly<TException>().WithMessage()", GetHelpLink("Exceptions-1"));
    public static DiagnosticMetadata ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldBe = new("Use .Should().ThrowExactly<TException>().WithMessage()", GetHelpLink("Exceptions-1"));
    public static DiagnosticMetadata ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldContain = new("Use .Should().ThrowExactly<TException>().WithMessage()", GetHelpLink("Exceptions-1"));
    public static DiagnosticMetadata ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldContain = new("Use .Should().ThrowExactly<TException>().WithMessage()", GetHelpLink("Exceptions-1"));
    public static DiagnosticMetadata ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldEndWith = new("Use .Should().ThrowExactly<TException>().WithMessage()", GetHelpLink("Exceptions-1"));
    public static DiagnosticMetadata ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldEndWith = new("Use .Should().ThrowExactly<TException>().WithMessage()", GetHelpLink("Exceptions-1"));
    public static DiagnosticMetadata ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldStartWith = new("Use .Should().ThrowExactly<TException>().WithMessage()", GetHelpLink("Exceptions-1"));
    public static DiagnosticMetadata ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldStartWith = new("Use .Should().ThrowExactly<TException>().WithMessage()", GetHelpLink("Exceptions-1"));
    public static DiagnosticMetadata ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldBe = new("Use .Should().Throw<TException>().WithMessage()", GetHelpLink("Exceptions-2"));
    public static DiagnosticMetadata ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldBe = new("Use .Should().Throw<TException>().WithMessage()", GetHelpLink("Exceptions-2"));
    public static DiagnosticMetadata ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldContain = new("Use .Should().Throw<TException>().WithMessage()", GetHelpLink("Exceptions-2"));
    public static DiagnosticMetadata ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldContain = new("Use .Should().Throw<TException>().WithMessage()", GetHelpLink("Exceptions-2"));
    public static DiagnosticMetadata ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldEndWith = new("Use .Should().Throw<TException>().WithMessage()", GetHelpLink("Exceptions-2"));
    public static DiagnosticMetadata ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldEndWith = new("Use .Should().Throw<TException>().WithMessage()", GetHelpLink("Exceptions-2"));
    public static DiagnosticMetadata ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldStartWith = new("Use .Should().Throw<TException>().WithMessage()", GetHelpLink("Exceptions-2"));
    public static DiagnosticMetadata ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldStartWith = new("Use .Should().Throw<TException>().WithMessage()", GetHelpLink("Exceptions-2"));
    public static DiagnosticMetadata ExceptionShouldThrowWithInnerException_ShouldThrowAndInnerExceptionShouldBeOfType = new("Use .Should().Throw<TException>().WithInnerException<TInnerException>()", string.Empty);
    public static DiagnosticMetadata ExceptionShouldThrowWithInnerException_ShouldThrowWhichInnerExceptionShouldBeOfType = new("Use .Should().Throw<TException>().WithInnerException<TInnerException>()", string.Empty);
    public static DiagnosticMetadata ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyAndInnerExceptionShouldBeOfType = new("Use .Should().ThrowExactly<TException>().WithInnerException<TInnerException>()", string.Empty);
    public static DiagnosticMetadata ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyWhichInnerExceptionShouldBeOfType = new("Use .Should().ThrowExactly<TException>().WithInnerException<TInnerException>()", string.Empty);
    public static DiagnosticMetadata ExceptionShouldThrowWithInnerException_ShouldThrowAndInnerExceptionShouldBeAssignableTo = new("Use .Should().Throw<TException>().WithInnerException<TInnerException>()", string.Empty);
    public static DiagnosticMetadata ExceptionShouldThrowWithInnerException_ShouldThrowWhichInnerExceptionShouldBeAssignableTo = new("Use .Should().Throw<TException>().WithInnerException<TInnerException>()", string.Empty);
    public static DiagnosticMetadata ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyAndInnerExceptionShouldBeAssignableTo = new("Use .Should().ThrowExactly<TException>().WithInnerException<TInnerException>()", string.Empty);
    public static DiagnosticMetadata ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyWhichInnerExceptionShouldBeAssignableTo = new("Use .Should().ThrowExactly<TException>().WithInnerException<TInnerException>()", string.Empty);

    public static DiagnosticMetadata StringShouldBe_StringShouldEquals = new("Use .Should().Be()", string.Empty);
    public static DiagnosticMetadata CollectionShouldEqual_CollectionShouldEquals = new("Use .Should().Equal()", string.Empty);
    public static DiagnosticMetadata ShouldEquals = new("Use .Should().Be() or .Should().BeEquivalentTo or .Should().Equal() or other equivalency assertion", string.Empty);
    public static DiagnosticMetadata ShouldBe_ShouldEquals = new("Use .Should().Be()", string.Empty);
    public static DiagnosticMetadata NullConditionalMayNotExecute = new("Use .Should() instead of ?.Should()", string.Empty);

    private static string GetHelpLink(string id) => $"https://fluentassertions.com/tips/#{id}";
}