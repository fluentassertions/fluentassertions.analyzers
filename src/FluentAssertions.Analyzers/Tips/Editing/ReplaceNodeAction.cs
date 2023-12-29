using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public class ReplaceNodeAction(SyntaxNode node, SyntaxNode newNode) : IEditAction
{
    public void Apply(DocumentEditor editor, InvocationExpressionSyntax invocationExpression)
    {
        editor.ReplaceNode(node, newNode);
    }
}