using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentAssertions.Analyzers.Utilities;

public abstract class TestingLibraryCodeFixBase : FluentAssertionsCodeFixProvider
{
    protected abstract string AssertClassName { get; }

    protected ExpressionSyntax RenameMethodAndReplaceWithSubjectShould(ExpressionSyntax expression, string oldName, string newName)
    {
        var rename = NodeReplacement.RenameAndRemoveFirstArgument(oldName, newName);
        var newExpression = GetNewExpression(expression, rename);

        return ReplaceIdentifier(newExpression, AssertClassName, Expressions.SubjectShould(rename.Argument.Expression));
    }

    protected ExpressionSyntax RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(ExpressionSyntax expression, string oldName, string newName, int argumentIndex = 1)
    {
        var rename = NodeReplacement.RenameAndExtractArguments(oldName, newName);
        var newExpression = GetNewExpression(expression, rename);

        var actual = rename.Arguments[argumentIndex];

        newExpression = ReplaceIdentifier(newExpression, AssertClassName, Expressions.SubjectShould(actual.Expression));

        return GetNewExpression(newExpression, NodeReplacement.WithArguments(newName, rename.Arguments.RemoveAt(argumentIndex)));
    }

    protected ExpressionSyntax ReplaceTypeOfArgumentWithGenericTypeIfExists(ExpressionSyntax expression, string method)
    {
        var methodExpression = expression.DescendantNodes()
            .OfType<MemberAccessExpressionSyntax>()
            .First(node => node.Name.Identifier.Text == method);

        if (methodExpression.Parent is InvocationExpressionSyntax invocation)
        {
            var arguments = invocation.ArgumentList.Arguments;
            if (arguments.Any() && arguments[0].Expression is TypeOfExpressionSyntax typeOfExpression)
            {
                var genericBeOfType = methodExpression.WithName(SF.GenericName(methodExpression.Name.Identifier.Text)
                    .AddTypeArgumentListArguments(typeOfExpression.Type)
                );
                var newExpression = expression.ReplaceNode(methodExpression, genericBeOfType);
                return GetNewExpression(newExpression, NodeReplacement.RemoveFirstArgument(method));
            }
        }

        return expression;
    }
}
