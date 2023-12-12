namespace FluentAssertions.Analyzers;

public static class CollectionShouldContainProperty
{
    public class AnyWithLambdaShouldBeTrueSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AnyWithLambdaShouldBeTrueSyntaxVisitor() : base(MemberValidator.MethodContainingLambda("Any"), MemberValidator.Should, new MemberValidator("BeTrue"))
        {
        }
    }

    public class WhereShouldNotBeEmptySyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public WhereShouldNotBeEmptySyntaxVisitor() : base(MemberValidator.MethodContainingLambda("Where"), MemberValidator.Should, new MemberValidator("NotBeEmpty"))
        {
        }
    }
}