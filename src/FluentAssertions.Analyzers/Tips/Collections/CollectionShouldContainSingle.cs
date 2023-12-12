namespace FluentAssertions.Analyzers;

public static class CollectionShouldContainSingle
{
    public class WhereShouldHaveCount1SyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public WhereShouldHaveCount1SyntaxVisitor() : base(MemberValidator.MethodContainingLambda("Where"), MemberValidator.Should, MemberValidator.ArgumentIsLiteral("HaveCount", 1))
        {
        }
    }

    public class ShouldHaveCount1SyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public ShouldHaveCount1SyntaxVisitor() : base(MemberValidator.Should, MemberValidator.ArgumentIsLiteral("HaveCount", 1))
        {
        }
    }
}