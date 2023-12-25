using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public class CreateEquivalencyAssertionOptionsLambda : IEditAction
{
    private readonly int _argumentIndex;

    public CreateEquivalencyAssertionOptionsLambda(int argumentIndex)
    {
        _argumentIndex = argumentIndex;
    }

    public void Apply(DocumentEditor editor, InvocationExpressionSyntax invocationExpression)
    {
        const string lambdaParameter = "options";
        const string equivalencyAssertionOptionsMethod = "Using";

        var generator = editor.Generator;
        var optionsParameter = invocationExpression.ArgumentList.Arguments[_argumentIndex];

        var equivalencyAssertionLambda = generator.ValueReturningLambdaExpression(lambdaParameter, generator.InvocationExpression(generator.MemberAccessExpression(generator.IdentifierName(lambdaParameter), equivalencyAssertionOptionsMethod), optionsParameter));
        editor.ReplaceNode(optionsParameter.Expression, equivalencyAssertionLambda);
    }
}