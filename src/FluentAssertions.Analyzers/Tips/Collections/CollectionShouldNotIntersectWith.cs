namespace FluentAssertions.Analyzers;

public static class CollectionShouldNotIntersectWith
{
    public class IntersectShouldBeEmptySyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public IntersectShouldBeEmptySyntaxVisitor() : base(MemberValidator.HasArguments("Intersect"), MemberValidator.Should, new MemberValidator("BeEmpty"))
        {
        }
    }
}