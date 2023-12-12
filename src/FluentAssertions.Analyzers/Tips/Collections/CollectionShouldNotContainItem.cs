namespace FluentAssertions.Analyzers;

public static class CollectionShouldNotContainItem
{
    public class ContainsShouldBeFalseSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public ContainsShouldBeFalseSyntaxVisitor() : base(new MemberValidator("Contains"), MemberValidator.Should, new MemberValidator("BeFalse"))
        {
        }
    }
}