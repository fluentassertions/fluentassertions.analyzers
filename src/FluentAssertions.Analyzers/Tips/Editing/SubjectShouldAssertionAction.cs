using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public class SubjectShouldAssertionAction
{
    private readonly int _argumentIndex;
    protected readonly string _assertion;

    public SubjectShouldAssertionAction(int argumentIndex, string assertion)
    {
        _argumentIndex = argumentIndex;
        _assertion = assertion;
    }

    public void Apply(EditActionContext context)
    {
        var generator = context.Editor.Generator;
        var arguments = context.InvocationExpression.ArgumentList.Arguments;

        var subject = arguments[_argumentIndex];
        var should = generator.InvocationExpression(generator.MemberAccessExpression(subject.Expression, "Should"));
        context.Editor.RemoveNode(subject);

        var memberAccess = (MemberAccessExpressionSyntax) generator.MemberAccessExpression(should, GenerateAssertion(generator)).WithTriviaFrom(context.InvocationExpression.Expression);

        context.Editor.ReplaceNode(context.InvocationExpression.Expression, memberAccess);
        context.FluentAssertion = context.InvocationExpression
            .WithExpression(memberAccess)
            .WithArgumentList(SyntaxFactory.ArgumentList(arguments.RemoveAt(_argumentIndex)));
    }

    protected virtual SyntaxNode GenerateAssertion(SyntaxGenerator generator) => generator.IdentifierName(_assertion);
}