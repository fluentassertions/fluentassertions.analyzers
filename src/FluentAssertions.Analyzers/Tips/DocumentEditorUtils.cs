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

    private static async Task<Document> RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShouldImp(IInvocationOperation invocation, CodeFixContext context, string newName, int argumentIndex, int[] argumentsToRemove, CancellationToken cancellationToken)
    {
        var editor = await DocumentEditor.CreateAsync(context.Document, cancellationToken);
        var generator = editor.Generator;

        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;
        var assertionInvocation = (MemberAccessExpressionSyntax)invocationExpression.Expression;

        var actual = invocationExpression.ArgumentList.Arguments[argumentIndex];

        var should = generator.InvocationExpression(generator.MemberAccessExpression(actual.Expression, "Should"));

        for (int i = 0; i < argumentsToRemove.Length; i++)
        {
            editor.RemoveNode(invocationExpression.ArgumentList.Arguments[argumentsToRemove[i]]);
        }

        editor.RemoveNode(actual);
        editor.ReplaceNode(assertionInvocation.Expression, should.WithTriviaFrom(assertionInvocation.Expression));
        editor.ReplaceNode(assertionInvocation.Name, assertionInvocation.Name.WithIdentifier(SyntaxFactory.Identifier(newName)));

        return editor.GetChangedDocument();
    }

    private static async Task<Document> RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould_AndAddGenericTypeImp(IInvocationOperation invocation, ITypeOfOperation typeOf, CodeFixContext context, string newName, int argumentIndex, int[] argumentsToRemove, CancellationToken cancellationToken)
    {
        var editor = await DocumentEditor.CreateAsync(context.Document, cancellationToken);
        var generator = editor.Generator;

        var invocationExpression = (InvocationExpressionSyntax)invocation.Syntax;
        var assertionInvocation = (MemberAccessExpressionSyntax)invocationExpression.Expression;

        var actual = invocationExpression.ArgumentList.Arguments[argumentIndex];

        var should = generator.InvocationExpression(generator.MemberAccessExpression(actual.Expression, "Should"));

        for (int i = 0; i < argumentsToRemove.Length; i++)
        {
            editor.RemoveNode(invocationExpression.ArgumentList.Arguments[argumentsToRemove[i]]);
        }

        editor.RemoveNode(typeOf.Syntax.Parent); // remove the argument of the typeof expression

        editor.RemoveNode(actual);
        editor.ReplaceNode(assertionInvocation.Expression, should.WithTriviaFrom(assertionInvocation.Expression));
        editor.ReplaceNode(assertionInvocation.Name, generator.GenericName(newName, typeOf.TypeOperand));

        return editor.GetChangedDocument();
    }
}