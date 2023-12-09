namespace FluentAssertions.Analyzers;

public static class CollectionShouldHaveCountGreaterOrEqualTo
{
    public class CountShouldBeGreaterOrEqualToSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public CountShouldBeGreaterOrEqualToSyntaxVisitor() : base(new MemberValidator("Count"), MemberValidator.Should, new MemberValidator("BeGreaterOrEqualTo"))
        {
        }
    }
}