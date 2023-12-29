using System;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.Operations;
using CreateChangedDocument = System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<Microsoft.CodeAnalysis.Document>>;

namespace FluentAssertions.Analyzers;

public class DocumentEditorUtils
{
    public static CreateChangedDocument RenameMethodToSubjectShouldAssertion(IInvocationOperation invocation, CodeFixContext context, string newName, int subjectIndex, int[] argumentsToRemove)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;

        return async ctx => await RewriteExpression(invocationExpression, [
            ..Array.ConvertAll(argumentsToRemove, arg => new RemoveNodeAction(invocationExpression.ArgumentList.Arguments[arg])),
            new SubjectShouldAssertionAction(subjectIndex, newName)
        ], context, ctx);
    }

    public static CreateChangedDocument RenameGenericMethodToSubjectShouldGenericAssertion(IInvocationOperation invocation, CodeFixContext context, string newName, int subjectIndex, int[] argumentsToRemove)
        => RenameMethodToSubjectShouldGenericAssertion(invocation, invocation.TargetMethod.TypeArguments, context, newName, subjectIndex, argumentsToRemove);
    public static CreateChangedDocument RenameMethodToSubjectShouldGenericAssertion(IInvocationOperation invocation, ImmutableArray<ITypeSymbol> genericTypes, CodeFixContext context, string newName, int subjectIndex, int[] argumentsToRemove)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;

        return async ctx => await RewriteExpression(invocationExpression, [
             ..Array.ConvertAll(argumentsToRemove, arg => new RemoveNodeAction(invocationExpression.ArgumentList.Arguments[arg])),
                new SubjectShouldGenericAssertionAction(subjectIndex, newName, genericTypes)
         ], context, ctx);
    }

    public static CreateChangedDocument RenameMethodToSubjectShouldAssertionWithOptionsLambda(IInvocationOperation invocation, CodeFixContext context, string newName, int subjectIndex, int optionsIndex)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;

        return async ctx => await RewriteExpression(invocationExpression, [
            new SubjectShouldAssertionAction(subjectIndex, newName),
                new CreateEquivalencyAssertionOptionsLambda(optionsIndex)
        ], context, ctx);
    }

    public static CreateChangedDocument RemoveExpressionBeforeShouldAndRenameAssertion(IInvocationOperation invocation, CodeFixContext context, string newName)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;
        var memberAccessExpression = (MemberAccessExpressionSyntax)invocationExpression.Expression;

        if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var should)) return null;

        var subject = should.Arguments[0].Value;
        IEditAction skipExpressionNodeAction = subject switch {
            IInvocationOperation invocationBeforeShould => new SkipInvocationNodeAction((InvocationExpressionSyntax)invocationBeforeShould.Syntax),
            IPropertyReferenceOperation propertyReferenceBeforeShould => new SkipMemberAccessNodeAction((MemberAccessExpressionSyntax)propertyReferenceBeforeShould.Syntax),
            _ => null
        };
        if (skipExpressionNodeAction is null) return null;
        
        return async ctx => await RewriteExpression(invocationExpression, [
            new RenameNodeAction(memberAccessExpression, newName),
            skipExpressionNodeAction
        ], context, ctx);
    }

    public static CreateChangedDocument RenameAssertion(IInvocationOperation invocation, CodeFixContext context, string newName)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;
        var memberAccessExpression = (MemberAccessExpressionSyntax)invocationExpression.Expression;

        return async ctx => await RewriteExpression(invocationExpression, [
            new RenameNodeAction(memberAccessExpression, newName),
        ], context, ctx);
    }

    public static CreateChangedDocument RenameAssertionAndRemoveArguments(IInvocationOperation invocation, CodeFixContext context, string newName, int removeArgumentIndex)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;
        var memberAccessExpression = (MemberAccessExpressionSyntax)invocationExpression.Expression;

        return async ctx => await RewriteExpression(invocationExpression, [
            new RemoveNodeAction(invocationExpression.ArgumentList.Arguments[removeArgumentIndex]),
            new RenameNodeAction(memberAccessExpression, newName),
        ], context, ctx);
    }

    public static CreateChangedDocument RemoveMethodBeforeShouldAndRenameAssertion(IInvocationOperation invocation, CodeFixContext context, string newName, int arguemntIndex)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;
        var memberAccessExpression = (MemberAccessExpressionSyntax)invocationExpression.Expression;

        if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var should)) return null;
        if (!should.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return null;

        var invocationExpressionBeforeShould = (InvocationExpressionSyntax)invocationBeforeShould.Syntax;

        return async ctx => await RewriteExpression(invocationExpression, [
            new RenameNodeAction(memberAccessExpression, newName),
            new SkipInvocationNodeAction(invocationExpressionBeforeShould)
        ], context, ctx);
    }

    public static CreateChangedDocument RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(IInvocationOperation invocation, CodeFixContext context, string newName)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;
        var memberAccessExpression = (MemberAccessExpressionSyntax)invocationExpression.Expression;

        if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var should)) return null;
        if (!should.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return null;

        var invocationExpressionBeforeShould = (InvocationExpressionSyntax)invocationBeforeShould.Syntax;

        return async ctx => await RewriteExpression(invocationExpression, [
            new RenameNodeAction(memberAccessExpression, newName),
            new SkipInvocationNodeAction(invocationExpressionBeforeShould),
            new PrependArgumentsToInvocationEditAction(invocationExpressionBeforeShould.ArgumentList)
        ], context, ctx);
    }

    public static CreateChangedDocument RemoveMethodBeforeShouldAndRenameAssertionWithoutFirstArgumentWithArgumentsFromRemoved(IInvocationOperation invocation, CodeFixContext context, string newName)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;
        var memberAccessExpression = (MemberAccessExpressionSyntax)invocationExpression.Expression;

        if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var should)) return null;
        if (!should.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return null;

        var invocationExpressionBeforeShould = (InvocationExpressionSyntax)invocationBeforeShould.Syntax;

        return async ctx => await RewriteExpression(invocationExpression, [
            new RenameNodeAction(memberAccessExpression, newName),
            new SkipInvocationNodeAction(invocationExpressionBeforeShould),
            new RemoveNodeAction(invocationExpression.ArgumentList.Arguments[0]),
            new PrependArgumentsToInvocationWithoutFirstArgument(invocationExpressionBeforeShould.ArgumentList),
        ], context, ctx);
    }

    public static CreateChangedDocument RenameAssertionAndRemoveInvocationOfMethodOnFirstArgument(IInvocationOperation invocation, CodeFixContext context, string newName)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;
        var memberAccessExpression = (MemberAccessExpressionSyntax)invocationExpression.Expression;

        if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var should)) return null;

        var invocationArgument = (IInvocationOperation)invocation.Arguments[0].Value;
        var expected = invocationArgument.Arguments[0].Value.UnwrapConversion();

        return async ctx => await RewriteExpression(invocationExpression, [
            new RenameNodeAction(memberAccessExpression, newName),
            new ReplaceNodeAction(invocationArgument.Syntax, expected.Syntax)
        ], context, ctx);
    }

    public static CreateChangedDocument RemoveMethodBeforeShouldAndRenameAssertionAndRemoveInvocationOfMethodOnFirstArgument(IInvocationOperation invocation, CodeFixContext context, string newName)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;
        var memberAccessExpression = (MemberAccessExpressionSyntax)invocationExpression.Expression;

        if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var should)) return null;
        if (!should.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return null;

        var invocationExpressionBeforeShould = (InvocationExpressionSyntax)invocationBeforeShould.Syntax;

        var invocationArgument = (IInvocationOperation)invocation.Arguments[0].Value;
        var expected = invocationArgument.Arguments[0].Value.UnwrapConversion();

        return async ctx => await RewriteExpression(invocationExpression, [
            new RenameNodeAction(memberAccessExpression, newName),
            new SkipInvocationNodeAction(invocationExpressionBeforeShould),
            new ReplaceNodeAction(invocationArgument.Syntax, expected.Syntax)
        ], context, ctx);
    }

    private static async Task<Document> RewriteExpression(InvocationExpressionSyntax invocationExpression, IEditAction[] actions, CodeFixContext context, CancellationToken cancellationToken)
    {
        var editor = await DocumentEditor.CreateAsync(context.Document, cancellationToken);

        foreach (var action in actions)
        {
            action.Apply(editor, invocationExpression);

            var code = await editor.GetChangedDocument().GetTextAsync();
        }

        return editor.GetChangedDocument();
    }
}
