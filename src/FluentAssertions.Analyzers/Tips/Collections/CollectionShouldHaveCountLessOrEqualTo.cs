namespace FluentAssertions.Analyzers;

public static class CollectionShouldHaveCountLessOrEqualTo
{
    public class CountShouldBeLessOrEqualToSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public CountShouldBeLessOrEqualToSyntaxVisitor() : base(new MemberValidator("Count"), MemberValidator.Should, new MemberValidator("BeLessOrEqualTo"))
        {
        }
    }
}