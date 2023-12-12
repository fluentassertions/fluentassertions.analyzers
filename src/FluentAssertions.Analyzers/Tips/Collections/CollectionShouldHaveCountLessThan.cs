namespace FluentAssertions.Analyzers;

public static class CollectionShouldHaveCountLessThan
{
    public class CountShouldBeLessThanSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public CountShouldBeLessThanSyntaxVisitor() : base(new MemberValidator("Count"), MemberValidator.Should, new MemberValidator("BeLessThan"))
        {
        }
    }
}