using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers;

public partial class FluentAssertionsCodeFix
{
    private SeparatedSyntaxList<ArgumentSyntax> GetArgumentsWithFirstAsPairIdentifierArgument(SeparatedSyntaxList<ArgumentSyntax> arguments)
    {
        var argument = arguments[0];
        var memberAccess = (MemberAccessExpressionSyntax)argument.Expression;
        var identifier = (IdentifierNameSyntax)memberAccess.Expression;

        return arguments.Replace(argument, argument.WithExpression(identifier));
    }
}