using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.Operations;
using CreateChangedDocument = System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<Microsoft.CodeAnalysis.Document>>;

namespace FluentAssertions.Analyzers;

public sealed partial class FluentAssertionsCodeFixProvider
{
    // <subject>.<invocationBeforeShould>().Should().<assertion>(<arguments>)
    private static CreateChangedDocument RewriteFluentAssertion(IInvocationOperation assertion, CodeFixContext context, params IFluentAssertionEditAction[] actions)
    {
        var assertionExpression = (InvocationExpressionSyntax)assertion.Syntax;

        assertion.TryGetFirstDescendent<IInvocationOperation>(out var should);
        var subject = should?.Arguments[0].Value;

        IInvocationOperation invocationBeforeShould = default;
        should?.TryGetFirstDescendent(out invocationBeforeShould);

        var actionContext = new FluentAssertionEditActionContext(assertion, assertionExpression, should, subject, invocationBeforeShould);

        return async ctx =>
        {
            var editor = await DocumentEditor.CreateAsync(context.Document, ctx);
            foreach (var action in actions)
            {
                action.Apply(editor, actionContext);
            }

            return editor.GetChangedDocument();
        };
    }

    // <subject>.Should().<assertionA>(argumentsA).<andOrWhich>.<assertionB>(<argumentsB>)
    private static CreateChangedDocument RewriteFluentChainedAssertion(IInvocationOperation assertionB, CodeFixContext context, params IFluentChainedAssertionEditAction[] actions)
    {
        var assertionExpressionB = (InvocationExpressionSyntax)assertionB.Syntax;

        assertionB.TryGetFirstDescendent<IPropertyReferenceOperation>(out var andOrWhich);

        andOrWhich.TryGetFirstDescendent<IInvocationOperation>(out var assertionA);

        var assertionExpressionA = (InvocationExpressionSyntax)assertionA.Syntax;

        assertionA.TryGetFirstDescendent<IInvocationOperation>(out var should);
        
        var subject = should?.Arguments[0].Value;

        var actionContext = new FluentChainedAssertionEditActionContext(assertionA, assertionExpressionA, andOrWhich, assertionB, assertionExpressionB, should, subject);

        return async ctx =>
        {
            var editor = await DocumentEditor.CreateAsync(context.Document, ctx);
            foreach (var action in actions)
            {
                action.Apply(editor, actionContext);
            }

            return editor.GetChangedDocument();
        };
    }
}