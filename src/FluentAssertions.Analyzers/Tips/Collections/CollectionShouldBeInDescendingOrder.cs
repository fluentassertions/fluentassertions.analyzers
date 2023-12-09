namespace FluentAssertions.Analyzers;

public static class CollectionShouldBeInDescendingOrder
{
    public class OrderByDescendingShouldEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public OrderByDescendingShouldEqualSyntaxVisitor() : base(MemberValidator.MethodContainingLambda("OrderByDescending"), MemberValidator.Should, MemberValidator.ArgumentIsVariable("Equal"))
        {
        }
    }
}