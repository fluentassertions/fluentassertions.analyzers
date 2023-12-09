namespace FluentAssertions.Analyzers;

public static class CollectionShouldHaveCount
{
    public class CountShouldBe0SyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public CountShouldBe0SyntaxVisitor() : base(MemberValidator.MethodNotContainingLambda("Count"), MemberValidator.Should, MemberValidator.ArgumentIsLiteral("Be", 0))
        {
        }
    }

    public class CountShouldBe1SyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public CountShouldBe1SyntaxVisitor() : base(MemberValidator.MethodNotContainingLambda("Count"), MemberValidator.Should, MemberValidator.ArgumentIsLiteral("Be", 1))
        {
        }
    }

    public class CountShouldBeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public CountShouldBeSyntaxVisitor() : base(MemberValidator.MethodNotContainingLambda("Count"), MemberValidator.Should, new MemberValidator("Be"))
        {
        }
    }

    public class LengthShouldBeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public LengthShouldBeSyntaxVisitor() : base(new MemberValidator("Length"), MemberValidator.Should, new MemberValidator("Be"))
        {
        }
    }
}