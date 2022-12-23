using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentAssertions.Analyzers
{
    public static class Expressions
    {
        public static ArgumentSyntax OptionsUsing(ArgumentSyntax comparer)
        {
            var mae = SF.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SF.IdentifierName("options"),
                SF.IdentifierName("Using"));

            var separatedSyntaxList = new SeparatedSyntaxList<ArgumentSyntax>().Add(comparer);
            var arg = SF.ArgumentList(separatedSyntaxList);

            var parameter = SF.Parameter(SF.Identifier("options"));
            var body = SF.InvocationExpression(mae, arg);
            var simpleLambdaExpression = SF.SimpleLambdaExpression(parameter, body);

            return SF.Argument(simpleLambdaExpression);
        }
        
        public static InvocationExpressionSyntax SubjectShould(ExpressionSyntax subject)
        {
            return SF.InvocationExpression(
                SF.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, subject, SF.IdentifierName("Should")),
                SF.ArgumentList()
            );
        }
    }
}
