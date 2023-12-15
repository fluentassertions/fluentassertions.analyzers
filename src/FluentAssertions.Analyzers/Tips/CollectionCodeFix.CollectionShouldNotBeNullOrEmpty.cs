using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers;

public partial class CollectionCodeFix
{
    private ExpressionSyntax GetCombinedAssertions(ExpressionSyntax expression, string removeMethod, string renameMethod)
    {
        var remove = NodeReplacement.RemoveAndExtractArguments(removeMethod);
        var newExpression = GetNewExpression(expression, NodeReplacement.RemoveMethodBefore(removeMethod), remove);

        return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments(renameMethod, "NotBeNullOrEmpty", remove.Arguments));
    }
}