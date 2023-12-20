namespace FluentAssertions.Analyzers;

public static class Constants
{
    public static class DiagnosticProperties
    {
        public const string RuleId = nameof(RuleId);
        public const string Title = nameof(Title);
        public const string VisitorName = nameof(VisitorName);
        public const string HelpLink = nameof(HelpLink);
        public const string IdPrefix = "FluentAssertions";
    }

    public static class Tips
    {
        public const string Category = "FluentAssertionTips";

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
            public const string AssertEndsWith = $"{DiagnosticProperties.IdPrefix}0715";
            public const string AssertStartsWith = $"{DiagnosticProperties.IdPrefix}0716";
            public const string AssertSubset = $"{DiagnosticProperties.IdPrefix}0717";
            public const string AssertIsAssignableFrom = $"{DiagnosticProperties.IdPrefix}0718";
            public const string AssertIsNotAssignableFrom = $"{DiagnosticProperties.IdPrefix}0719";
            public const string AssertIsType = $"{DiagnosticProperties.IdPrefix}0720";
            public const string AssertIsNotType = $"{DiagnosticProperties.IdPrefix}0721";
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
