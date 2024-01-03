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

