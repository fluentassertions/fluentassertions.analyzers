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
    public static CreateChangedDocument RenameMethodToSubjectShouldAssertion(IInvocationOperation invocation, CodeFixContext context, string newName, int argumentIndex, int[] argumentsToRemove)
        => async ctx =>
        {
            var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;

            return await RewriteExpression(invocationExpression, [
                ..Array.ConvertAll(argumentsToRemove, arg => new RemoveNodeAction(invocationExpression.ArgumentList.Arguments[arg])),
            new SubjectShouldAssertionAction(argumentIndex, newName)
            ], context, ctx);
        };

    public static CreateChangedDocument RenameGenericMethodToSubjectShouldGenericAssertion(IInvocationOperation invocation, CodeFixContext context, string newName, int argumentIndex, int[] argumentsToRemove)
        => RenameMethodToSubjectShouldGenericAssertion(invocation, invocation.TargetMethod.TypeArguments, context, newName, argumentIndex, argumentsToRemove);
    public static CreateChangedDocument RenameMethodToSubjectShouldGenericAssertion(IInvocationOperation invocation, ImmutableArray<ITypeSymbol> genericTypes, CodeFixContext context, string newName, int argumentIndex, int[] argumentsToRemove)
        => async ctx =>
        {
            var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;

            return await RewriteExpression(invocationExpression, [
                ..Array.ConvertAll(argumentsToRemove, arg => new RemoveNodeAction(invocationExpression.ArgumentList.Arguments[arg])),
            new SubjectShouldGenericAssertionAction(argumentIndex, newName, genericTypes)
            ], context, ctx);
        };


    private static async Task<Document> RewriteExpression(InvocationExpressionSyntax invocationExpression, IEditAction[] actions, CodeFixContext context, CancellationToken cancellationToken)
    {
        var editor = await DocumentEditor.CreateAsync(context.Document, cancellationToken);

        foreach (var action in actions)
        {
            action.Apply(editor, invocationExpression);
        }

        return editor.GetChangedDocument();
    }
}