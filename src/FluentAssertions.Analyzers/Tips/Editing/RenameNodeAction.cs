using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public class RenameNodeAction(MemberAccessExpressionSyntax node, string newName) : IEditAction
{
    public void Apply(DocumentEditor editor, InvocationExpressionSyntax invocationExpression)
    {
        var newNameNode = (IdentifierNameSyntax)editor.Generator.IdentifierName(newName);
        editor.ReplaceNode(node.Name, newNameNode);
    }
}
