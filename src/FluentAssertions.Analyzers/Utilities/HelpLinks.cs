using System;
using System.Collections.Generic;

namespace FluentAssertions.Analyzers;

public static class HelpLinks
{
    private static readonly Dictionary<Type, string> TypesHelpLinks;
    private static string GetHelpLink(string id) => $"https://fluentassertions.com/tips/#{id}";

    static HelpLinks()
    {
        TypesHelpLinks = new Dictionary<Type, string>
        {
            [typeof(CollectionShouldNotBeEmpty.AnyShouldBeTrueSyntaxVisitor)] = GetHelpLink("Collections-1"),
            [typeof(CollectionShouldBeEmpty.AnyShouldBeFalseSyntaxVisitor)] = GetHelpLink("Collections-2"),
            [typeof(CollectionShouldContainProperty.AnyWithLambdaShouldBeTrueSyntaxVisitor)] = GetHelpLink("Collections-3"),
            [typeof(CollectionShouldNotContainProperty.AnyLambdaShouldBeFalseSyntaxVisitor)] = GetHelpLink("Collections-4"),
            [typeof(CollectionShouldOnlyContainProperty.AllShouldBeTrueSyntaxVisitor)] = GetHelpLink("Collections-5"),
            [typeof(CollectionShouldContainItem.ContainsShouldBeTrueSyntaxVisitor)] = GetHelpLink("Collections-6"),
            [typeof(CollectionShouldNotContainItem.ContainsShouldBeFalseSyntaxVisitor)] = GetHelpLink("Collections-7"),
            // missing Collections-8
            [typeof(CollectionShouldHaveCount.CountShouldBeSyntaxVisitor)] = GetHelpLink("Collections-9"),
            [typeof(CollectionShouldHaveCountGreaterThan.CountShouldBeGreaterThanSyntaxVisitor)] = GetHelpLink("Collections-10"),
            [typeof(CollectionShouldHaveCountGreaterOrEqualTo.CountShouldBeGreaterOrEqualToSyntaxVisitor)] = GetHelpLink("Collections-11"),
            [typeof(CollectionShouldHaveCountLessThan.CountShouldBeLessThanSyntaxVisitor)] = GetHelpLink("Collections-12"),
            [typeof(CollectionShouldHaveCountLessOrEqualTo.CountShouldBeLessOrEqualToSyntaxVisitor)] = GetHelpLink("Collections-13"),
            [typeof(CollectionShouldNotHaveCount.CountShouldNotBeSyntaxVisitor)] = GetHelpLink("Collections-14"),
            [typeof(CollectionShouldContainSingle.ShouldHaveCount1SyntaxVisitor)] = GetHelpLink("Collections-15"),
            [typeof(CollectionShouldHaveCount.CountShouldBe1SyntaxVisitor)] = GetHelpLink("Collections-15"),
            [typeof(CollectionShouldBeEmpty.ShouldHaveCount0SyntaxVisitor)] = GetHelpLink("Collections-16"),
            [typeof(CollectionShouldHaveCount.CountShouldBe0SyntaxVisitor)] = GetHelpLink("Collections-16"), // hmmm
            [typeof(CollectionShouldHaveSameCount.ShouldHaveCountOtherCollectionCountSyntaxVisitor)] = GetHelpLink("Collections-17"),
            [typeof(CollectionShouldNotHaveSameCount.CountShouldNotBeOtherCollectionCountSyntaxVisitor)] = GetHelpLink("Collections-18"),
            [typeof(CollectionShouldContainProperty.WhereShouldNotBeEmptySyntaxVisitor)] = GetHelpLink("Collections-19"),
            [typeof(CollectionShouldNotContainProperty.WhereShouldBeEmptySyntaxVisitor)] = GetHelpLink("Collections-20"),
            [typeof(CollectionShouldContainSingle.WhereShouldHaveCount1SyntaxVisitor)] = GetHelpLink("Collections-21"),
            [typeof(CollectionShouldNotContainProperty.ShouldOnlyContainSyntaxVisitor)] = GetHelpLink("Collections-22"),
            [typeof(CollectionShouldNotBeNullOrEmptyAnalyzer.ShouldNotBeNullAndNotBeEmptySyntaxVisitor)] = GetHelpLink("Collections-23"),
            [typeof(CollectionShouldNotBeNullOrEmptyAnalyzer.ShouldNotBeEmptyAndNotBeNullSyntaxVisitor)] = GetHelpLink("Collections-23"),
            [typeof(CollectionShouldHaveElementAt.ElementAtIndexShouldBeSyntaxVisitor)] = GetHelpLink("Collections-24"),
            [typeof(CollectionShouldHaveElementAt.IndexerShouldBeSyntaxVisitor)] = GetHelpLink("Collections-25"),
            [typeof(CollectionShouldHaveElementAt.SkipFirstShouldBeSyntaxVisitor)] = GetHelpLink("Collections-26"),
            [typeof(CollectionShouldBeInAscendingOrder.OrderByShouldEqualSyntaxVisitor)] = GetHelpLink("Collections-27"),
            [typeof(CollectionShouldBeInDescendingOrder.OrderByDescendingShouldEqualSyntaxVisitor)] = GetHelpLink("Collections-28"),
            [typeof(CollectionShouldEqualOtherCollectionByComparer.SelectShouldEqualOtherCollectionSelectSyntaxVisitor)] = GetHelpLink("Collections-29"),
            [typeof(CollectionShouldNotIntersectWith.IntersectShouldBeEmptySyntaxVisitor)] = GetHelpLink("Collections-30"),
            [typeof(CollectionShouldIntersectWith.IntersectShouldNotBeEmptySyntaxVisitor)] = GetHelpLink("Collections-31"),
            [typeof(CollectionShouldNotContainNulls.SelectShouldNotContainNullsSyntaxVisitor)] = GetHelpLink("Collections-32"),
            [typeof(CollectionShouldOnlyHaveUniqueItems.ShouldHaveSameCountThisCollectionDistinctSyntaxVisitor)] = GetHelpLink("Collections-33"),
            [typeof(CollectionShouldOnlyHaveUniqueItemsByComparer.SelectShouldOnlyHaveUniqueItemsSyntaxVisitor)] = GetHelpLink("Collections-34"),

            [typeof(NumericShouldBePositiveAnalyzer.NumericShouldBeBeGreaterThan0SyntaxVisitor)] = GetHelpLink("Comparable-and-Numerics-1"),
            [typeof(NumericShouldBeNegativeAnalyzer.NumericShouldBeBeLessThan0SyntaxVisitor)] = GetHelpLink("Comparable-and-Numerics-2"),
            [typeof(NumericShouldBeApproximatelyAnalyzer.MathAbsShouldBeLessOrEqualToSyntaxVisitor)] = string.Empty, // TODO: add to docs
            [typeof(NumericShouldBeInRangeAnalyzer.BeGreaterOrEqualToAndBeLessOrEqualToSyntaxVisitor)] = string.Empty, // TODO: add to docs
            [typeof(NumericShouldBeInRangeAnalyzer.BeLessOrEqualToAndBeGreaterOrEqualToSyntaxVisitor)] = string.Empty, // TODO: add to docs

            [typeof(DictionaryShouldContainKeyAnalyzer.ContainsKeyShouldBeTrueSyntaxVisitor)] = GetHelpLink("Dictionaries-1"),
            [typeof(DictionaryShouldNotContainKeyAnalyzer.ContainsKeyShouldBeFalseSyntaxVisitor)] = GetHelpLink("Dictionaries-2"),
            [typeof(DictionaryShouldContainValueAnalyzer.ContainsValueShouldBeTrueSyntaxVisitor)] = GetHelpLink("Dictionaries-3"),
            [typeof(DictionaryShouldNotContainValueAnalyzer.ContainsValueShouldBeFalseSyntaxVisitor)] = GetHelpLink("Dictionaries-4"),
            [typeof(DictionaryShouldContainKeyAndValueAnalyzer.ShouldContainKeyAndContainValueSyntaxVisitor)] = GetHelpLink("Dictionaries-5"),
            [typeof(DictionaryShouldContainKeyAndValueAnalyzer.ShouldContainValueAndContainKeySyntaxVisitor)] = GetHelpLink("Dictionaries-5"),
            [typeof(DictionaryShouldContainPairAnalyzer.ShouldContainKeyAndContainValueSyntaxVisitor)] = GetHelpLink("Dictionaries-6"),
            [typeof(DictionaryShouldContainPairAnalyzer.ShouldContainValueAndContainKeySyntaxVisitor)] = GetHelpLink("Dictionaries-6"),

            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowExactlyWhichMessageShouldContain)] = GetHelpLink("Exceptions-1"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowExactlyAndMessageShouldContain)] = GetHelpLink("Exceptions-1"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowWhichMessageShouldContain)] = GetHelpLink("Exceptions-2"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowAndMessageShouldContain)] = GetHelpLink("Exceptions-2"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowExactlyWhichMessageShouldBe)] = GetHelpLink("Exceptions-1"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowWhichMessageShouldBe)] = GetHelpLink("Exceptions-2"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowExactlyAndMessageShouldBe)] = GetHelpLink("Exceptions-1"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowAndMessageShouldBe)] = GetHelpLink("Exceptions-2"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowExactlyWhichMessageShouldStartWith)] = GetHelpLink("Exceptions-1"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowWhichMessageShouldStartWith)] = GetHelpLink("Exceptions-2"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowExactlyAndMessageShouldStartWith)] = GetHelpLink("Exceptions-1"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowAndMessageShouldEndWith)] = GetHelpLink("Exceptions-2"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowExactlyWhichMessageShouldEndWith)] = GetHelpLink("Exceptions-1"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowWhichMessageShouldEndWith)] = GetHelpLink("Exceptions-2"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowExactlyAndMessageShouldEndWith)] = GetHelpLink("Exceptions-1"),
            [typeof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowAndMessageShouldStartWith)] = GetHelpLink("Exceptions-2"),

            [typeof(StringShouldStartWithAnalyzer.StartWithShouldBeTrueSyntaxVisitor)] = GetHelpLink("Strings-1"),
            [typeof(StringShouldEndWithAnalyzer.EndWithShouldBeTrueSyntaxVisitor)] = GetHelpLink("Strings-2"),
            [typeof(StringShouldNotBeNullOrEmptyAnalyzer.StringShouldNotBeNullAndNotBeEmptySyntaxVisitor)] = GetHelpLink("Strings-3"),
            [typeof(StringShouldNotBeNullOrEmptyAnalyzer.StringShouldNotBeEmptyAndNotBeNullSyntaxVisitor)] = GetHelpLink("Strings-3"),
            [typeof(StringShouldBeNullOrEmptyAnalyzer.StringIsNullOrEmptyShouldBeTrueSyntaxVisitor)] = GetHelpLink("Strings-4"),
            [typeof(StringShouldNotBeNullOrEmptyAnalyzer.StringIsNullOrEmptyShouldBeFalseSyntaxVisitor)] = GetHelpLink("Strings-5"),
            [typeof(StringShouldBeNullOrWhiteSpaceAnalyzer.StringShouldBeNullOrWhiteSpaceSyntaxVisitor)] = GetHelpLink("Strings-6"),
            [typeof(StringShouldNotBeNullOrWhiteSpaceAnalyzer.StringShouldNotBeNullOrWhiteSpaceSyntaxVisitor)] = GetHelpLink("Strings-7"),
            [typeof(StringShouldHaveLengthAnalyzer.LengthShouldBeSyntaxVisitor)] = GetHelpLink("Strings-8")
        };
    }

    public static string Get(Type type)
        => TypesHelpLinks.TryGetValue(type, out var value) ? value : string.Empty; 
}
