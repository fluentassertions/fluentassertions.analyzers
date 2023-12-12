namespace FluentAssertions.Analyzers;

public static class CollectionShouldOnlyHaveUniqueItemsByComparer
{
    public class SelectShouldOnlyHaveUniqueItemsSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public SelectShouldOnlyHaveUniqueItemsSyntaxVisitor() : base(MemberValidator.MethodContainingLambda("Select"), MemberValidator.Should, new MemberValidator("OnlyHaveUniqueItems"))
        {
        }
    }
}