namespace FluentAssertions.Analyzers;

public class CollectionShouldHaveElementAt
{

    public class ElementAtIndexShouldBeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public ElementAtIndexShouldBeSyntaxVisitor() : base(new MemberValidator("ElementAt"), MemberValidator.Should, new MemberValidator("Be"))
        {
        }
    }

    public class IndexerShouldBeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public IndexerShouldBeSyntaxVisitor() : base(new MemberValidator("[]"), MemberValidator.Should, new MemberValidator("Be"))
        {
        }
    }

    public class SkipFirstShouldBeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public SkipFirstShouldBeSyntaxVisitor() : base(new MemberValidator("Skip"), MemberValidator.MethodNotContainingLambda("First"), MemberValidator.Should, new MemberValidator("Be"))
        {
        }
    }
}