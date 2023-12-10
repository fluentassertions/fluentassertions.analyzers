namespace FluentAssertions.Analyzers;

public static class CollectionShouldNotContainProperty
{
    public class AnyLambdaShouldBeFalseSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AnyLambdaShouldBeFalseSyntaxVisitor() : base(MemberValidator.MethodContainingLambda("Any"), MemberValidator.Should, new MemberValidator("BeFalse"))
        {
        }
    }

    public class WhereShouldBeEmptySyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public WhereShouldBeEmptySyntaxVisitor() : base(MemberValidator.MethodContainingLambda("Where"), MemberValidator.Should, new MemberValidator("BeEmpty"))
        {
        }
    }

    public class ShouldOnlyContainSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public ShouldOnlyContainSyntaxVisitor() : base(MemberValidator.Should, MemberValidator.MethodContainingLambda("OnlyContain"))
        {
        }
    }
}