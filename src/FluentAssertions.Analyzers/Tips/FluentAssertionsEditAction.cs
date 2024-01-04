using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.Operations;

namespace FluentAssertions.Analyzers;


public record struct FluentAssertionEditActionContext(
    IInvocationOperation Assertion,
    InvocationExpressionSyntax AssertionExpression,
    IInvocationOperation Should,
    IOperation Subject,
    IInvocationOperation InvocationBeforeShould
);

public static class FluentAssertionsEditAction
{
    public static Action<DocumentEditor, FluentAssertionEditActionContext> RenameAssertion(string newName)
    {
        return (DocumentEditor editor, FluentAssertionEditActionContext context) =>
        {
            var newNameNode = (IdentifierNameSyntax)editor.Generator.IdentifierName(newName);
            var memberAccess = (MemberAccessExpressionSyntax)context.AssertionExpression.Expression;
            editor.ReplaceNode(memberAccess.Name, newNameNode);
        };
    }

    public static Action<DocumentEditor, FluentAssertionEditActionContext> SkipInvocationBeforeShould()
    {
        return (DocumentEditor editor, FluentAssertionEditActionContext context) =>
        {
            var invocationExpressionBeforeShould = (InvocationExpressionSyntax)context.InvocationBeforeShould.Syntax;
            var methodMemberAccess = (MemberAccessExpressionSyntax)invocationExpressionBeforeShould.Expression;

            editor.ReplaceNode(invocationExpressionBeforeShould, methodMemberAccess.Expression);
        };
    }

    public static Action<DocumentEditor, FluentAssertionEditActionContext> SkipExpressionBeforeShould()
    {
        return (DocumentEditor editor, FluentAssertionEditActionContext context) =>
        {
            IEditAction skipExpressionNodeAction = context.Subject switch
            {
                IInvocationOperation invocationBeforeShould => new SkipInvocationNodeAction((InvocationExpressionSyntax)invocationBeforeShould.Syntax),
                IPropertyReferenceOperation propertyReferenceBeforeShould => new SkipMemberAccessNodeAction((MemberAccessExpressionSyntax)propertyReferenceBeforeShould.Syntax),
                _ => throw new NotSupportedException("[SkipExpressionBeforeShouldEditAction] Invalid expression before should invocation")
            };

            skipExpressionNodeAction.Apply(editor, context.AssertionExpression);
        };
    }

    public static Action<DocumentEditor, FluentAssertionEditActionContext> RemoveAssertionArgument(int index)
    {
        return (DocumentEditor editor, FluentAssertionEditActionContext context) =>
        {
            editor.RemoveNode(context.AssertionExpression.ArgumentList.Arguments[index]);
        };
    }

    public static Action<DocumentEditor, FluentAssertionEditActionContext> PrependArgumentsFromInvocationBeforeShouldToAssertion(int skipAssertionArguments = 0)
    {
        return (DocumentEditor editor, FluentAssertionEditActionContext context) =>
        {
            var invocationExpressionBeforeShould = (InvocationExpressionSyntax)context.InvocationBeforeShould.Syntax;
            var argumentList = invocationExpressionBeforeShould.ArgumentList;

            var combinedArguments = SyntaxFactory.ArgumentList(argumentList.Arguments.AddRange(context.AssertionExpression.ArgumentList.Arguments.Skip(skipAssertionArguments)));
            editor.ReplaceNode(context.AssertionExpression.ArgumentList, combinedArguments);
        };
    }
    public static Action<DocumentEditor, FluentAssertionEditActionContext> RemoveInvocationOnAssertionArgument(int assertionArgumentIndex, int invocationArgumentIndex)
    {
        return (DocumentEditor editor, FluentAssertionEditActionContext context) =>
        {
            var invocationArgument = (IInvocationOperation)context.Assertion.Arguments[assertionArgumentIndex].Value;
            var expected = invocationArgument.Arguments[invocationArgumentIndex].Value.UnwrapConversion();

            editor.ReplaceNode(invocationArgument.Syntax, expected.Syntax);
        };
    }

    public static Action<DocumentEditor, FluentAssertionEditActionContext> UnwrapInvocationOnSubject(int argumentIndex)
    {
        return (DocumentEditor editor, FluentAssertionEditActionContext context) =>
        {
            var subjectReference = ((IInvocationOperation)context.Subject).Arguments[argumentIndex].Value;

            editor.ReplaceNode(context.Subject.Syntax, subjectReference.Syntax.WithTriviaFrom(context.Subject.Syntax));
        };
    }
}