namespace FluentAssertions.Analyzers;

public static class CollectionShouldBeInAscendingOrder
{
    public class OrderByShouldEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public OrderByShouldEqualSyntaxVisitor() : base(MemberValidator.MethodContainingLambda("OrderBy"), MemberValidator.Should, MemberValidator.ArgumentIsVariable("Equal"))
        {
        }
    }
}