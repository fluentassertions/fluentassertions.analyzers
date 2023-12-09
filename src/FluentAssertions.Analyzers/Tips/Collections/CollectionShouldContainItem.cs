namespace FluentAssertions.Analyzers;

public static class CollectionShouldContainItem
{
    public class ContainsShouldBeTrueSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public ContainsShouldBeTrueSyntaxVisitor() : base(new MemberValidator("Contains"), MemberValidator.Should, new MemberValidator("BeTrue"))
        {
        }
    }
}