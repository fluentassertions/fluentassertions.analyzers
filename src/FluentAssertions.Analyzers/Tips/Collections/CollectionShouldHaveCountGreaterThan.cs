namespace FluentAssertions.Analyzers;

public static class CollectionShouldHaveCountGreaterThan
{
    public class CountShouldBeGreaterThanSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public CountShouldBeGreaterThanSyntaxVisitor() : base(new MemberValidator("Count"), MemberValidator.Should, new MemberValidator("BeGreaterThan"))
        {
        }
    }
}