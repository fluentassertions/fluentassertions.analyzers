using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public class PrependArgumentToInvocation(ArgumentSyntax argument) : IEditAction
{
    public void Apply(DocumentEditor editor, InvocationExpressionSyntax invocationExpression)
    {
        var combinedArguments = SyntaxFactory.ArgumentList()
            .AddArguments(argument)
            .AddArguments([.. invocationExpression.ArgumentList.Arguments]);
        editor.ReplaceNode(invocationExpression.ArgumentList, combinedArguments);
    }
}