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
