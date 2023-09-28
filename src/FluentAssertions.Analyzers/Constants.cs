namespace FluentAssertions.Analyzers
{
    public static class Constants
    {
        public static class DiagnosticProperties
        {
            public const string Title = nameof(Title);
            public const string VisitorName = nameof(VisitorName);
            public const string HelpLink = nameof(HelpLink);
            public const string IdPrefix = "FluentAssertions";
        }

        public static class Tips
        {
            public const string Category = "FluentAssertionTips";
            public static class Collections
            {
                public const string CollectionsShouldBeEmpty = $"{DiagnosticProperties.IdPrefix}0000";
                public const string CollectionsShouldNotBeEmpty = $"{DiagnosticProperties.IdPrefix}0001";
                public const string CollectionShouldContainProperty = $"{DiagnosticProperties.IdPrefix}0002";
                public const string CollectionShouldNotContainProperty = $"{DiagnosticProperties.IdPrefix}0003";
                public const string CollectionShouldContainItem = $"{DiagnosticProperties.IdPrefix}0004";
                public const string CollectionShouldNotContainItem = $"{DiagnosticProperties.IdPrefix}0005";
                public const string CollectionShouldHaveCount = $"{DiagnosticProperties.IdPrefix}0006";
                public const string CollectionShouldHaveCountGreaterThan = $"{DiagnosticProperties.IdPrefix}0007";
                public const string CollectionShouldHaveCountGreaterOrEqualTo = $"{DiagnosticProperties.IdPrefix}0008";
                public const string CollectionShouldHaveCountLessThan = $"{DiagnosticProperties.IdPrefix}0009";
                public const string CollectionShouldHaveCountLessOrEqualTo = $"{DiagnosticProperties.IdPrefix}0010";
                public const string CollectionShouldNotHaveCount = $"{DiagnosticProperties.IdPrefix}0011";
                public const string CollectionShouldContainSingle = $"{DiagnosticProperties.IdPrefix}0012";
                public const string CollectionShouldOnlyContainProperty = $"{DiagnosticProperties.IdPrefix}0013";
                public const string CollectionShouldHaveSameCount = $"{DiagnosticProperties.IdPrefix}0014";
                public const string CollectionShouldNotHaveSameCount = $"{DiagnosticProperties.IdPrefix}0015";
                public const string CollectionShouldContainSingleProperty = $"{DiagnosticProperties.IdPrefix}0016";
                public const string CollectionShouldNotBeNullOrEmpty = $"{DiagnosticProperties.IdPrefix}0017";
                public const string CollectionShouldHaveElementAt = $"{DiagnosticProperties.IdPrefix}0018";
                public const string CollectionShouldBeInAscendingOrder = $"{DiagnosticProperties.IdPrefix}0019";
                public const string CollectionShouldBeInDescendingOrder = $"{DiagnosticProperties.IdPrefix}0020";
                public const string CollectionShouldEqualOtherCollectionByComparer = $"{DiagnosticProperties.IdPrefix}0021";
                public const string CollectionShouldNotIntersectWith = $"{DiagnosticProperties.IdPrefix}0022";
                public const string CollectionShouldIntersectWith = $"{DiagnosticProperties.IdPrefix}0023";
                public const string CollectionShouldNotContainNulls = $"{DiagnosticProperties.IdPrefix}0024";
                public const string CollectionShouldOnlyHaveUniqueItems = $"{DiagnosticProperties.IdPrefix}0025";
                public const string CollectionShouldOnlyHaveUniqueItemsByComparer = $"{DiagnosticProperties.IdPrefix}0026";
                public const string CollectionShouldHaveElementAt0Null = $"{DiagnosticProperties.IdPrefix}0027";
            }

            public static class Dictionaries
            {
                public const string DictionaryShouldContainKey = $"{DiagnosticProperties.IdPrefix}0100";
                public const string DictionaryShouldContainValue = $"{DiagnosticProperties.IdPrefix}0101";
                public const string DictionaryShouldContainKeyAndValue = $"{DiagnosticProperties.IdPrefix}0102";
                public const string DictionaryShouldContainPair = $"{DiagnosticProperties.IdPrefix}0103";
                public const string DictionaryShouldNotContainKey = $"{DiagnosticProperties.IdPrefix}0104";
                public const string DictionaryShouldNotContainValue = $"{DiagnosticProperties.IdPrefix}0105";
            }

            public static class Strings
            {
                public const string StringShouldStartWith = $"{DiagnosticProperties.IdPrefix}0200";
                public const string StringShouldEndWith = $"{DiagnosticProperties.IdPrefix}0201";
                public const string StringShouldNotBeNullOrEmpty = $"{DiagnosticProperties.IdPrefix}0202";
                public const string StringShouldBeNullOrEmpty = $"{DiagnosticProperties.IdPrefix}0203";
                public const string StringShouldBeNullOrWhiteSpace = $"{DiagnosticProperties.IdPrefix}0204";
                public const string StringShouldNotBeNullOrWhiteSpace = $"{DiagnosticProperties.IdPrefix}0205";
                public const string StringShouldHaveLength = $"{DiagnosticProperties.IdPrefix}0206";
            }

            public static class Comparable
            {
                public const string ComparableShouldBePositive = $"{DiagnosticProperties.IdPrefix}0300";
            }

            public static class Numeric
            {
                public const string NumericShouldBePositive = $"{DiagnosticProperties.IdPrefix}0400";
                public const string NumericShouldBeNegative = $"{DiagnosticProperties.IdPrefix}0401";
                public const string NumericShouldBeInRange = $"{DiagnosticProperties.IdPrefix}0402";
                public const string NumericShouldBeApproximately = $"{DiagnosticProperties.IdPrefix}0403";
            }

            public static class Exceptions
            {
                public const string ExceptionShouldThrowWithMessage = $"{DiagnosticProperties.IdPrefix}0500";
                public const string ExceptionShouldThrowWithInnerException = $"{DiagnosticProperties.IdPrefix}0501";
            }

            public static class MsTest
            {
                public const string AssertIsTrue = $"{DiagnosticProperties.IdPrefix}0600";
                public const string AssertIsFalse = $"{DiagnosticProperties.IdPrefix}0601";
                public const string AssertIsNotNull = $"{DiagnosticProperties.IdPrefix}0602";
                public const string AssertIsNull = $"{DiagnosticProperties.IdPrefix}0603";
                public const string AssertIsInstanceOfType = $"{DiagnosticProperties.IdPrefix}0604";
                public const string AssertIsNotInstanceOfType = $"{DiagnosticProperties.IdPrefix}0605";
                public const string AssertAreEqual = $"{DiagnosticProperties.IdPrefix}0606";
                public const string AssertAreNotEqual = $"{DiagnosticProperties.IdPrefix}0607";
                public const string AssertAreSame = $"{DiagnosticProperties.IdPrefix}0608";
                public const string AssertAreNotSame = $"{DiagnosticProperties.IdPrefix}0609";
                public const string AssertThrowsException = $"{DiagnosticProperties.IdPrefix}0610";
                public const string AssertThrowsExceptionAsync = $"{DiagnosticProperties.IdPrefix}0611";
                public const string StringAssertContains = $"{DiagnosticProperties.IdPrefix}0612";
                public const string StringAssertStartsWith = $"{DiagnosticProperties.IdPrefix}0613";
                public const string StringAssertEndsWith = $"{DiagnosticProperties.IdPrefix}0614";
                public const string StringAssertMatches = $"{DiagnosticProperties.IdPrefix}0615";
                public const string StringAssertDoesNotMatch = $"{DiagnosticProperties.IdPrefix}0616";
                public const string CollectionAssertAllItemsAreInstancesOfType = $"{DiagnosticProperties.IdPrefix}0617";
                public const string CollectionAssertAreEqual = $"{DiagnosticProperties.IdPrefix}0618";
                public const string CollectionAssertAreNotEqual = $"{DiagnosticProperties.IdPrefix}0619";
                public const string CollectionAssertAreEquivalent = $"{DiagnosticProperties.IdPrefix}0620";
                public const string CollectionAssertAreNotEquivalent = $"{DiagnosticProperties.IdPrefix}0621";
                public const string CollectionAssertAllItemsAreNotNull = $"{DiagnosticProperties.IdPrefix}0622";
                public const string CollectionAssertAllItemsAreUnique = $"{DiagnosticProperties.IdPrefix}0623";
                public const string CollectionAssertContains = $"{DiagnosticProperties.IdPrefix}0624";
                public const string CollectionAssertDoesNotContain = $"{DiagnosticProperties.IdPrefix}0625";
                public const string CollectionAssertIsSubsetOf = $"{DiagnosticProperties.IdPrefix}0626";
                public const string CollectionAssertIsNotSubsetOf = $"{DiagnosticProperties.IdPrefix}0627";
            }

            public static class Xunit
            {
                public const string AssertTrue = $"{DiagnosticProperties.IdPrefix}0700";
                public const string AssertFalse = $"{DiagnosticProperties.IdPrefix}0701";
                public const string AssertSame = $"{DiagnosticProperties.IdPrefix}0702";
                public const string AssertNotSame = $"{DiagnosticProperties.IdPrefix}0703";
                public const string AssertEqual = $"{DiagnosticProperties.IdPrefix}0704";
                public const string AssertStrictEqual = $"{DiagnosticProperties.IdPrefix}0705";
                public const string AssertNotEqual = $"{DiagnosticProperties.IdPrefix}0706";
                public const string AssertNotStrictEqual = $"{DiagnosticProperties.IdPrefix}0707";
                public const string AssertNull = $"{DiagnosticProperties.IdPrefix}0708";
                public const string AssertNotNull = $"{DiagnosticProperties.IdPrefix}0709";
                public const string AssertContains = $"{DiagnosticProperties.IdPrefix}0710";
                public const string AssertDoesNotContain = $"{DiagnosticProperties.IdPrefix}0711";
                public const string AssertMatches = $"{DiagnosticProperties.IdPrefix}0712";
                public const string AssertDoesNotMatch = $"{DiagnosticProperties.IdPrefix}0713";
                public const string AssertEmpty = $"{DiagnosticProperties.IdPrefix}0714";
            }
        }

        public static class CodeSmell
        {
            public const string Category = "FluentAssertionCodeSmell";

            public const string NullConditionalAssertion = $"{DiagnosticProperties.IdPrefix}0800";
            public const string AsyncVoid = $"{DiagnosticProperties.IdPrefix}0801";
            public const string ShouldEquals = $"{DiagnosticProperties.IdPrefix}0802";
        }
    }
}
