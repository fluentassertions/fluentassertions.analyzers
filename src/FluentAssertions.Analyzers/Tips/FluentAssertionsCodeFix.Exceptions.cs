using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentAssertions.Analyzers;

public partial class FluentAssertionsCodeFix
{


    private ExpressionSyntax ReplaceBeOfTypeInnerException(ExpressionSyntax expression, string whichOrAnd)
        => ReplaceWithInnerException(expression, whichOrAnd, renameFrom: "BeOfType", renameTo: "WithInnerExceptionExactly");

    private ExpressionSyntax ReplaceBeAssignableToInnerException(ExpressionSyntax expression, string whichOrAnd)
        => ReplaceWithInnerException(expression, whichOrAnd, renameFrom: "BeAssignableTo", renameTo: "WithInnerException");

    private ExpressionSyntax ReplaceWithInnerException(ExpressionSyntax expression, string whichOrAnd, string renameFrom, string renameTo)
    {
        var replacements = new[]
        {
            NodeReplacement.Remove(whichOrAnd),
            NodeReplacement.Remove("InnerException"),
            NodeReplacement.RemoveOccurrence("Should", occurrence: 2)
        };
        var newExpression = GetNewExpression(expression, replacements);
        var rename = NodeReplacement.RenameAndExtractArguments(renameFrom, renameTo);
        return GetNewExpression(newExpression, rename);
    }



    private ExpressionSyntax ReplaceContainMessage(ExpressionSyntax expression, string whichOrAnd)
        => ReplaceWithMessage(expression, whichOrAnd, renameMethod: "Contain", prefix: "*", postfix: "*");

    private ExpressionSyntax ReplaceBeMessage(ExpressionSyntax expression, string whichOrAnd)
    {
        var replacements = new[]
        {
            NodeReplacement.Remove(whichOrAnd),
            NodeReplacement.Remove("Message"),
            NodeReplacement.RemoveOccurrence("Should", occurrence: 2),
            NodeReplacement.Rename("Be", "WithMessage")
        };
        return GetNewExpression(expression, replacements);
    }

    private ExpressionSyntax ReplaceStartWithMessage(ExpressionSyntax expression, string whichOrAnd)
        => ReplaceWithMessage(expression, whichOrAnd, renameMethod: "StartWith", postfix: "*");

    private ExpressionSyntax ReplaceEndWithMessage(ExpressionSyntax expression, string whichOrAnd)
        => ReplaceWithMessage(expression, whichOrAnd, renameMethod: "EndWith", prefix: "*");

    private ExpressionSyntax ReplaceWithMessage(ExpressionSyntax expression, string whichOrAnd, string renameMethod, string prefix = "", string postfix = "")
    {
        var replacements = new[]
        {
            NodeReplacement.Remove(whichOrAnd),
            NodeReplacement.Remove("Message"),
            NodeReplacement.RemoveOccurrence("Should", occurrence: 2)
        };
        var newExpression = GetNewExpression(expression, replacements);
        var rename = NodeReplacement.RenameAndExtractArguments(renameMethod, "WithMessage");
        newExpression = GetNewExpression(newExpression, rename);

        ArgumentSyntax newArgument = null;
        switch (rename.Arguments[0].Expression)
        {
            case IdentifierNameSyntax identifier:
                newArgument = SF.Argument(SF.ParseExpression($"$\"{prefix}{{{identifier.Identifier.Text}}}{postfix}\""));
                break;
            case LiteralExpressionSyntax literal:
                newArgument = SF.Argument(SF.ParseExpression($"\"{prefix}{literal.Token.ValueText}{postfix}\""));
                break;
        }

        var replacement = NodeReplacement.WithArguments("WithMessage", rename.Arguments.Replace(rename.Arguments[0], newArgument));
        return GetNewExpression(newExpression, replacement);
    }
}