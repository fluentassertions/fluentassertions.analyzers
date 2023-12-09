namespace FluentAssertions.Analyzers;

public static class CollectionShouldNotBeEmpty
{
    public class AnyShouldBeTrueSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AnyShouldBeTrueSyntaxVisitor() : base(MemberValidator.MethodNotContainingLambda("Any"), MemberValidator.Should, new MemberValidator("BeTrue"))
        {
        }
    }
}