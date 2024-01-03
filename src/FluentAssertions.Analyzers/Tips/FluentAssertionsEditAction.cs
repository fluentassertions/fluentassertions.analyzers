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

public interface IFluentAssertionEditAction
{
    void Apply(DocumentEditor editor, FluentAssertionEditActionContext context);
}

public static class FluentAssertionsEditAction
{
    public static IFluentAssertionEditAction RenameAssertion(string newName) => new RenameAssertionEditAction(newName);
    public static IFluentAssertionEditAction SkipInvocationBeforeShould() => new SkipInvocationBeforeShouldEditAction();
    public static IFluentAssertionEditAction SkipExpressionBeforeShould() => new SkipExpressionBeforeShouldEditAction();
    public static IFluentAssertionEditAction RemoveAssertionArgument(int index) => new RemoveAssertionArgumentEditAction(index);
    public static IFluentAssertionEditAction PrependArgumentsFromInvocationBeforeShouldToAssertion(int skipAssertionArguments = 0) => new PrependArgumentsFromInvocationBeforeShouldToAssertionEditAction(skipAssertionArguments);
    public static IFluentAssertionEditAction RemoveInvocationOnAssertionArgument(int assertionArgumentIndex, int invocationArgumentIndex) => new RemoveInvocationOnAssertionArgumentEditAction(assertionArgumentIndex, invocationArgumentIndex);
    public static IFluentAssertionEditAction UnwrapInvocationOnSubject(int argumentIndex) => new UnwrapInvocationOnSubjectEditAction(argumentIndex);

    private class RenameAssertionEditAction(string newName) : IFluentAssertionEditAction
    {
        public void Apply(DocumentEditor editor, FluentAssertionEditActionContext context)
        {
            var newNameNode = (IdentifierNameSyntax)editor.Generator.IdentifierName(newName);
            var memberAccess = (MemberAccessExpressionSyntax)context.AssertionExpression.Expression;
            editor.ReplaceNode(memberAccess.Name, newNameNode);
        }
    }

    private class UnwrapInvocationOnSubjectEditAction(int argumentIndex) : IFluentAssertionEditAction
    {
        public void Apply(DocumentEditor editor, FluentAssertionEditActionContext context)
        {
            var subjectReference = ((IInvocationOperation)context.Subject).Arguments[argumentIndex].Value;

            editor.ReplaceNode(context.Subject.Syntax, subjectReference.Syntax.WithTriviaFrom(context.Subject.Syntax));
        }
    }

    private class SkipInvocationBeforeShouldEditAction : IFluentAssertionEditAction
    {
        public void Apply(DocumentEditor editor, FluentAssertionEditActionContext context)
        {
            var invocationExpressionBeforeShould = (InvocationExpressionSyntax)context.InvocationBeforeShould.Syntax;
            var methodMemberAccess = (MemberAccessExpressionSyntax)invocationExpressionBeforeShould.Expression;

            editor.ReplaceNode(invocationExpressionBeforeShould, methodMemberAccess.Expression);
        }
    }

    private class SkipExpressionBeforeShouldEditAction : IFluentAssertionEditAction
    {
        public void Apply(DocumentEditor editor, FluentAssertionEditActionContext context)
        {
            IEditAction skipExpressionNodeAction = context.Subject switch
            {
                IInvocationOperation invocationBeforeShould => new SkipInvocationNodeAction((InvocationExpressionSyntax)invocationBeforeShould.Syntax),
                IPropertyReferenceOperation propertyReferenceBeforeShould => new SkipMemberAccessNodeAction((MemberAccessExpressionSyntax)propertyReferenceBeforeShould.Syntax),
                _ => throw new NotSupportedException("[SkipExpressionBeforeShouldEditAction] Invalid expression before should invocation")
            };

            skipExpressionNodeAction.Apply(editor, context.AssertionExpression);
        }
    }

    private class RemoveAssertionArgumentEditAction(int index) : IFluentAssertionEditAction
    {
        public void Apply(DocumentEditor editor, FluentAssertionEditActionContext context)
        {
            editor.RemoveNode(context.AssertionExpression.ArgumentList.Arguments[index]);
        }
    }

    private class PrependArgumentsFromInvocationBeforeShouldToAssertionEditAction(int skipAssertionArguments) : IFluentAssertionEditAction
    {
        public void Apply(DocumentEditor editor, FluentAssertionEditActionContext context)
        {
            var invocationExpressionBeforeShould = (InvocationExpressionSyntax)context.InvocationBeforeShould.Syntax;
            var argumentList = invocationExpressionBeforeShould.ArgumentList;

            var combinedArguments = SyntaxFactory.ArgumentList(argumentList.Arguments.AddRange(context.AssertionExpression.ArgumentList.Arguments.Skip(skipAssertionArguments)));
            editor.ReplaceNode(context.AssertionExpression.ArgumentList, combinedArguments);
        }
    }

    private class RemoveInvocationOnAssertionArgumentEditAction(int assertionArgumentIndex, int invocationArgumentIndex) : IFluentAssertionEditAction
    {
        public void Apply(DocumentEditor editor, FluentAssertionEditActionContext context)
        {
            var invocationArgument = (IInvocationOperation)context.Assertion.Arguments[assertionArgumentIndex].Value;
            var expected = invocationArgument.Arguments[invocationArgumentIndex].Value.UnwrapConversion();

            editor.ReplaceNode(invocationArgument.Syntax, expected.Syntax);
        }
    }
}