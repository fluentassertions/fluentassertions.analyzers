using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;

using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentAssertions.Analyzers
{
    [DebuggerDisplay("AddTypeArgument(name: \"{_name}\", type: \"_type\")")]
    public class AddTypeArgumentNodeReplacement : EditNodeReplacement
    {
        private readonly TypeSyntax _type;

        public AddTypeArgumentNodeReplacement(string name, TypeSyntax type) : base(name) => _type = type;

        public override InvocationExpressionSyntax ComputeNew(InvocationExpressionSyntax node)
        {
            var memberAccessExpression = node.Expression as MemberAccessExpressionSyntax;
            var newExpression = memberAccessExpression.WithName(SF.GenericName(
                memberAccessExpression.Name.Identifier, SF.TypeArgumentList(
                    new SeparatedSyntaxList<TypeSyntax>().Add(_type))
                ));
            return node.WithExpression(newExpression);
        }
    }
}