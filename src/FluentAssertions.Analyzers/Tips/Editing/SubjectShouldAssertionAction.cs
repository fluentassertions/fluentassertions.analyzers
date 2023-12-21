using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public class SubjectShouldAssertionAction(int argumentIndex, string assertion) : IEditAction
{
    public void Apply(DocumentEditor editor, InvocationExpressionSyntax invocationExpression)
    {
        var generator = editor.Generator;
        var subject = invocationExpression.ArgumentList.Arguments[argumentIndex];
        var should = generator.InvocationExpression(generator.MemberAccessExpression(subject.Expression, "Should"));
        editor.RemoveNode(subject);
        editor.ReplaceNode(invocationExpression.Expression, generator.MemberAccessExpression(should, GenerateAssertion(generator)).WithTriviaFrom(invocationExpression.Expression));
    }

    protected virtual SyntaxNode GenerateAssertion(SyntaxGenerator generator) => generator.IdentifierName(assertion);
}
