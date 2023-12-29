using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public class SkipInvocationNodeAction(InvocationExpressionSyntax skipInvocation) : IEditAction
{
    public void Apply(DocumentEditor editor, InvocationExpressionSyntax invocationExpression)
    {
        var methodMemberAccess = (MemberAccessExpressionSyntax)skipInvocation.Expression;
        editor.ReplaceNode(skipInvocation, methodMemberAccess.Expression);
    }
}
