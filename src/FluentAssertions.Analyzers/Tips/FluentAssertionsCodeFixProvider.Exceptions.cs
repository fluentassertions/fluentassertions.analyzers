using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using CreateChangedDocument = System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<Microsoft.CodeAnalysis.Document>>;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentAssertions.Analyzers;

public sealed partial class FluentAssertionsCodeFixProvider
{
    // oldAssertion: <subject>.Should().Throw<TException1>().<andOrWhich>.InnerException.Should().<assertion><TException2>();
    // newAssertion: <subject>.Should().Throw<TException1>().WithInnerExceptionExactly<TException2>();
    private CreateChangedDocument ReplaceWithInnerException(IInvocationOperation assertion, CodeFixContext context, string newName)
    {
        return RewriteFluentAssertion(assertion, context, [
            (editor, context) => {
                var generator = editor.Generator;

                var firstAssertion = context.InvocationBeforeShould;
                var andOrWhich = firstAssertion.GetFirstAncestor<IPropertyReferenceOperation>();
                var andOrWhichExpression = (MemberAccessExpressionSyntax)andOrWhich.Syntax;
                
                var secondAssertionMemberAccess = (MemberAccessExpressionSyntax)context.AssertionExpression.Expression;

                var newAssertion = generator.InvocationExpression(andOrWhichExpression.WithName(secondAssertionMemberAccess.Name.WithIdentifier(SF.Identifier(newName))), context.AssertionExpression.ArgumentList.Arguments);

                editor.ReplaceNode(context.AssertionExpression, newAssertion);
            }
        ]);
    }
}