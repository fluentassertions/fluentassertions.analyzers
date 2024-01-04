using System;
using System.Linq;
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
    private CreateChangedDocument ReplaceShouldThrowWithInnerException(IInvocationOperation assertion, CodeFixContext context, string newName)
    {
        return RewriteFluentAssertion(assertion, context, [
            (editor, context) => 
            {
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

    // oldAssertion: <subject>.Should().Throw<TException>().<andOrWhich>.Message.Should().<assertion>([arg1, arg2, arg3...])
    // newAssertion: <subject>.Should().Throw<TException>().WithMessage([newArg1, arg2, arg3...])
    private CreateChangedDocument ReplaceShouldThrowWithMessage(IInvocationOperation assertion, CodeFixContext context, string prefix = "", string postfix = "")
    {
        return RewriteFluentAssertion(assertion, context, [
            (editor, context) => 
            {
                var generator = editor.Generator;

                var firstAssertion = context.InvocationBeforeShould;
                var andOrWhich = firstAssertion.GetFirstAncestor<IPropertyReferenceOperation>();
                var andOrWhichExpression = (MemberAccessExpressionSyntax)andOrWhich.Syntax;
                
                var newArgument = context.AssertionExpression.ArgumentList.Arguments[0].Expression switch
                {
                    IdentifierNameSyntax identifier => (prefix is "" && postfix is "") ? identifier : SF.ParseExpression($"$\"{prefix}{{{identifier.Identifier.Text}}}{postfix}\""),
                    LiteralExpressionSyntax literal => generator.LiteralExpression(prefix + literal.Token.ValueText + postfix),
                    _ => throw new NotSupportedException()
                };

                var newAssertion = generator.InvocationExpression(andOrWhichExpression.WithName((SimpleNameSyntax)generator.IdentifierName("WithMessage")), [
                    generator.Argument(newArgument),
                    ..context.AssertionExpression.ArgumentList.Arguments.Skip(1)
                ]);

                editor.ReplaceNode(context.AssertionExpression, newAssertion);
            }
        ]);
    }
}