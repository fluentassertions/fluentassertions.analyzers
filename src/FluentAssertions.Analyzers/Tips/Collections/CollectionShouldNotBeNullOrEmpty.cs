using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers;

public static class CollectionShouldNotBeNullOrEmpty
{
    public class ShouldNotBeNullAndNotBeEmptySyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public ShouldNotBeNullAndNotBeEmptySyntaxVisitor() : base(MemberValidator.Should, new MemberValidator("NotBeNull"), MemberValidator.And, new MemberValidator("NotBeEmpty"))
        {
        }
    }
    public class ShouldNotBeEmptyAndNotBeNullSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public ShouldNotBeEmptyAndNotBeNullSyntaxVisitor() : base(MemberValidator.Should, new MemberValidator("NotBeEmpty"), MemberValidator.And, new MemberValidator("NotBeNull"))
        {
        }
    }
}

public partial class CollectionCodeFix
{
    private ExpressionSyntax GetCombinedAssertions(ExpressionSyntax expression, string removeMethod, string renameMethod)
    {
        var remove = NodeReplacement.RemoveAndExtractArguments(removeMethod);
        var newExpression = GetNewExpression(expression, NodeReplacement.RemoveMethodBefore(removeMethod), remove);

        return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments(renameMethod, "NotBeNullOrEmpty", remove.Arguments));
    }
}