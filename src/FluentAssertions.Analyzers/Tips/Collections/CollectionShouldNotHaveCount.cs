namespace FluentAssertions.Analyzers;

public static class CollectionShouldNotHaveCount
{
    public class CountShouldNotBeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public CountShouldNotBeSyntaxVisitor() : base(MemberValidator.HasNoArguments("Count"), MemberValidator.Should, MemberValidator.ArgumentIsIdentifierOrLiteral("NotBe"))
        {
        }
    }
}