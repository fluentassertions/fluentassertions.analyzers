using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public static class EditAction
{
    public static Action<DocumentEditor, InvocationExpressionSyntax> RemoveNode(SyntaxNode node)
        => (editor, invocationExpression) => editor.RemoveNode(node);

    public static Action<DocumentEditor, InvocationExpressionSyntax> SubjectShouldAssertion(int argumentIndex, string assertion)
        => (editor, invocationExpression) => new SubjectShouldAssertionAction(argumentIndex, assertion).Apply(editor, invocationExpression);

    public static Action<DocumentEditor, InvocationExpressionSyntax> SubjectShouldGenericAssertion(int argumentIndex, string assertion, ImmutableArray<ITypeSymbol> genericTypes)
        => (editor, invocationExpression) => new SubjectShouldGenericAssertionAction(argumentIndex, assertion, genericTypes).Apply(editor, invocationExpression);

    public static Action<DocumentEditor, InvocationExpressionSyntax> CreateEquivalencyAssertionOptionsLambda(int optionsIndex)
        => (editor, invocationExpression) => new CreateEquivalencyAssertionOptionsLambdaAction(optionsIndex).Apply(editor, invocationExpression);
}