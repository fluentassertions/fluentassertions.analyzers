using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public static class EditAction
{
    public static Action<EditActionContext> RemoveNode(SyntaxNode node)
        => context => context.Editor.RemoveNode(node);

    public static Action<EditActionContext> RemoveInvocationArgument(int argumentIndex)
        => context => context.Editor.RemoveNode(context.InvocationExpression.ArgumentList.Arguments[argumentIndex]);

    public static Action<EditActionContext> SubjectShouldAssertion(int argumentIndex, string assertion)
        => context => new SubjectShouldAssertionAction(argumentIndex, assertion).Apply(context);

    public static Action<EditActionContext> SubjectShouldGenericAssertion(int argumentIndex, string assertion, ImmutableArray<ITypeSymbol> genericTypes)
        => context => new SubjectShouldGenericAssertionAction(argumentIndex, assertion, genericTypes).Apply(context);

    public static Action<EditActionContext> CreateEquivalencyAssertionOptionsLambda(int optionsIndex)
        => context => new CreateEquivalencyAssertionOptionsLambdaAction(optionsIndex).Apply(context.Editor, context.InvocationExpression);
}