namespace FluentAssertions.Analyzers;

public static class CollectionShouldNotContainNulls
{
    public class SelectShouldNotContainNullsSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public SelectShouldNotContainNullsSyntaxVisitor() : base(MemberValidator.MethodContainingLambda("Select"), MemberValidator.Should, new MemberValidator("NotContainNulls"))
        {
        }
    }
}