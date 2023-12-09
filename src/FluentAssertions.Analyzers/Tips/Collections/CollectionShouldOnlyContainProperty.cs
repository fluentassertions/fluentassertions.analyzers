namespace FluentAssertions.Analyzers;

public static class CollectionShouldOnlyContainProperty
{
    public class AllShouldBeTrueSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AllShouldBeTrueSyntaxVisitor() : base(MemberValidator.MethodContainingLambda("All"), MemberValidator.Should, new MemberValidator("BeTrue"))
        {
        }
    }
}