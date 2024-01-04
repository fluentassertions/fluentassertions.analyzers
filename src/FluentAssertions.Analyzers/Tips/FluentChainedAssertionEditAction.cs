using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.Operations;

namespace FluentAssertions.Analyzers;

public record struct FluentChainedAssertionEditActionContext(
    IInvocationOperation AssertionA,
    InvocationExpressionSyntax AssertionAExpression,
    IPropertyReferenceOperation AndOrWhich,
    IInvocationOperation AssertionB,
    InvocationExpressionSyntax AssertionBExpression,
    IInvocationOperation Should,
    IOperation Subject
);

public static class FluentChainedAssertionEditAction
{
    public static Action<DocumentEditor, FluentChainedAssertionEditActionContext> CombineAssertionsWithNameAndArguments(string newName, CombineAssertionArgumentsStrategy strategy)
    {
        return CombineAssertionsWithName(newName, (editor, context) =>
        {
            var arguments = strategy switch
            {
                CombineAssertionArgumentsStrategy.FirstAssertionFirst => context.AssertionAExpression.ArgumentList.Arguments.AddRange(context.AssertionBExpression.ArgumentList.Arguments),
                CombineAssertionArgumentsStrategy.InsertFirstAssertionIntoIndex1OfSecondAssertion => context.AssertionBExpression.ArgumentList.Arguments.InsertRange(1, context.AssertionAExpression.ArgumentList.Arguments),
                CombineAssertionArgumentsStrategy.InsertSecondAssertionIntoIndex1OfFirstAssertion => context.AssertionAExpression.ArgumentList.Arguments.InsertRange(1, context.AssertionBExpression.ArgumentList.Arguments),
                _ => throw new NotImplementedException(),
            };
            return SyntaxFactory.ArgumentList(arguments);
        });
    }

    public static Action<DocumentEditor, FluentChainedAssertionEditActionContext> CombineAssertionsWithName(string newName, Func<DocumentEditor, FluentChainedAssertionEditActionContext, ArgumentListSyntax> argumentsGenerator)
    {
        return (DocumentEditor editor, FluentChainedAssertionEditActionContext context) =>
        {
            var newNameNode = (IdentifierNameSyntax)editor.Generator.IdentifierName(newName);

            var assertionMemberAccess = (MemberAccessExpressionSyntax)context.AssertionAExpression.Expression;

            var allArguments = argumentsGenerator(editor, context);
            var newAssertion = context.AssertionAExpression
                .WithExpression(assertionMemberAccess.WithName(newNameNode))
                .WithArgumentList(allArguments);

            editor.ReplaceNode(context.AssertionBExpression, newAssertion);
        };
    }
}

public enum CombineAssertionArgumentsStrategy
{
    FirstAssertionFirst,
    InsertFirstAssertionIntoIndex1OfSecondAssertion,
    InsertSecondAssertionIntoIndex1OfFirstAssertion,
}