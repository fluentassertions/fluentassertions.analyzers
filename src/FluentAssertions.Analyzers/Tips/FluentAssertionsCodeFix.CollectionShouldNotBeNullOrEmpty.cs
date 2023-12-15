using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers;

public partial class FluentAssertionsCodeFix
{
    private ExpressionSyntax GetCombinedAssertions(ExpressionSyntax expression, string removeMethod, string renameMethod)
        => GetCombinedAssertions(expression, removeMethod, renameMethod, "NotBeNullOrEmpty");

    private ExpressionSyntax GetCombinedAssertions(ExpressionSyntax expression, string removeMethod, string renameMethod, string newMethod)
    {
        var remove = NodeReplacement.RemoveAndExtractArguments(removeMethod);
        var newExpression = GetNewExpression(expression, NodeReplacement.RemoveMethodBefore(removeMethod), remove);

        return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments(renameMethod, newMethod, remove.Arguments));
    }
}