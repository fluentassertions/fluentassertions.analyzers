using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers;

public static class CollectionShouldEqualOtherCollectionByComparer
{
    public sealed class SelectShouldEqualOtherCollectionSelectSyntaxVisitor {}
}

public partial class CollectionCodeFix
{
    private ExpressionSyntax GetNewExpressionForSelectShouldEqualOtherCollectionSelectSyntaxVisitor(ExpressionSyntax expression)
    {
        var removeMethodContainingFirstLambda = NodeReplacement.RemoveAndExtractArguments("Select");
        var newExpression = GetNewExpression(expression, removeMethodContainingFirstLambda);

        var removeArgument = NodeReplacement.RemoveFirstArgument("Equal");
        newExpression = GetNewExpression(newExpression, removeArgument);

        var argumentInvocation = (InvocationExpressionSyntax)removeArgument.Argument.Expression;
        var identifier = ((MemberAccessExpressionSyntax)argumentInvocation.Expression).Expression;

        var firstLambda = (SimpleLambdaExpressionSyntax)removeMethodContainingFirstLambda.Arguments[0].Expression;
        var secondLambda = (SimpleLambdaExpressionSyntax)argumentInvocation.ArgumentList.Arguments[0].Expression;

        var newArguments = SyntaxFactory.SeparatedList<ArgumentSyntax>()
            .Add(removeArgument.Argument.WithExpression(identifier))
            .Add(removeArgument.Argument.WithExpression(CombineLambdas(firstLambda, secondLambda).NormalizeWhitespace()
        ));

        return GetNewExpression(newExpression, NodeReplacement.PrependArguments("Equal", newArguments));
    }

    private ParenthesizedLambdaExpressionSyntax CombineLambdas(SimpleLambdaExpressionSyntax left, SimpleLambdaExpressionSyntax right) => SyntaxFactory.ParenthesizedLambdaExpression(
        parameterList: SyntaxFactory.ParameterList().AddParameters(left.Parameter, right.Parameter),
        body: SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression,
            left: (ExpressionSyntax)left.Body,
            right: (ExpressionSyntax)right.Body)
    );
}
