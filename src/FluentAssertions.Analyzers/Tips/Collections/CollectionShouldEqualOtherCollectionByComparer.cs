using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers;

public static class CollectionShouldEqualOtherCollectionByComparer
{
    public class SelectShouldEqualOtherCollectionSelectSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public SelectShouldEqualOtherCollectionSelectSyntaxVisitor()
            : base(MemberValidator.MethodContainingLambda("Select"), MemberValidator.Should, new MemberValidator("Equal", MathodContainingArgumentInvokingLambda))
        {
        }

        private static bool MathodContainingArgumentInvokingLambda(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel)
        {
            if (!arguments.Any()) return false;

            return arguments[0].Expression is InvocationExpressionSyntax invocation
                && MemberValidator.MethodContainingLambdaPredicate(invocation.ArgumentList.Arguments, semanticModel);
        }
    }
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
