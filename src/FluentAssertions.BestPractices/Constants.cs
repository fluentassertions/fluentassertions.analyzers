namespace FluentAssertions.BestPractices
{
    public static class Constants
    {
        public static class DiagnosticProperties
        {
            public const string Title = nameof(Title);
            public const string VariableName = nameof(VariableName);
            public const string PredicateString = nameof(PredicateString);
        }

        public static class Tips
        {
            public const string Category = "FluentAssertionTips";
            public static class Collections
            {
                public const string CollectionsShouldBeEmpty = nameof(CollectionsShouldBeEmpty);
                public const string CollectionsShouldNotBeEmpty = nameof(CollectionsShouldNotBeEmpty);

                public const string CollectionShouldContainProperty = nameof(CollectionShouldContainProperty);
                public const string CollectionShouldNotContainProperty = nameof(CollectionShouldNotContainProperty);
            }
        }
    }
}
