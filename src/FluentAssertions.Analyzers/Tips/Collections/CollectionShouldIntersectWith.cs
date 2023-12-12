namespace FluentAssertions.Analyzers;

public static class CollectionShouldIntersectWith
{
    public class IntersectShouldNotBeEmptySyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public IntersectShouldNotBeEmptySyntaxVisitor() : base(MemberValidator.HasArguments("Intersect"), MemberValidator.Should, new MemberValidator("NotBeEmpty"))
        {
        }
    }
}