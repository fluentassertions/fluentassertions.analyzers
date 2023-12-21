using System;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.Operations;
using CreateChangedDocument = System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<Microsoft.CodeAnalysis.Document>>;

namespace FluentAssertions.Analyzers;

public class DocumentEditorUtils
{
    public static CreateChangedDocument RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(IInvocationOperation invocation, CodeFixContext context, string newName, int argumentIndex, int[] argumentsToRemove)
        => ctx => RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShouldImp(invocation, context, newName, argumentIndex, argumentsToRemove, ctx);

    public static CreateChangedDocument RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould_AndAddGenericType(IInvocationOperation invocation, ITypeOfOperation typeOf, CodeFixContext context, string newName, int argumentIndex, int[] argumentsToRemove)
        => ctx => RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould_AndAddGenericTypeImp(invocation, typeOf, context, newName, argumentIndex, argumentsToRemove, ctx);

    private static async Task<Document> RewriteExpression(InvocationExpressionSyntax invocationExpression, IEditAction[] actions, CodeFixContext context, CancellationToken cancellationToken)
    {
        var editor = await DocumentEditor.CreateAsync(context.Document, cancellationToken);

        foreach (var action in actions)
        {
            action.Apply(editor, invocationExpression);
        }

        return editor.GetChangedDocument();
    }

    private static async Task<Document> RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShouldImp(IInvocationOperation invocation, CodeFixContext context, string newName, int argumentIndex, int[] argumentsToRemove, CancellationToken cancellationToken)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;

        return await RewriteExpression(invocationExpression, [
            ..Array.ConvertAll(argumentsToRemove, arg => new RemoveNodeAction(invocationExpression.ArgumentList.Arguments[arg])),
            new SubjectShouldAssertionAction(argumentIndex, newName)
        ], context, cancellationToken);
    }

    private static async Task<Document> RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould_AndAddGenericTypeImp(IInvocationOperation invocation, ITypeOfOperation typeOf, CodeFixContext context, string newName, int argumentIndex, int[] argumentsToRemove, CancellationToken cancellationToken)
    {
        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;

        return await RewriteExpression(invocationExpression, [
            ..Array.ConvertAll(argumentsToRemove, arg => new RemoveNodeAction(invocationExpression.ArgumentList.Arguments[arg])),
            new SubjectShouldGenericAssertionAction(argumentIndex, newName, typeOf.TypeOperand)
        ], context, cancellationToken);
    }
}