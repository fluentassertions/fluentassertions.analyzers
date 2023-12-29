using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public class PrependArgumentsToInvocationEditAction(ArgumentListSyntax argumentList) : IEditAction
{
    public void Apply(DocumentEditor editor, InvocationExpressionSyntax invocationExpression)
    {
        var combinedArguments = SyntaxFactory.ArgumentList(argumentList.Arguments.AddRange(invocationExpression.ArgumentList.Arguments));
        editor.ReplaceNode(invocationExpression.ArgumentList, combinedArguments);
    }
}
