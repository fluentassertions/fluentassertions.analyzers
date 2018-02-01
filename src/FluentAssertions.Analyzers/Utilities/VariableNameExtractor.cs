using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers
{
    public class VariableNameExtractor : CSharpSyntaxWalker
    {
        public string VariableName { get; private set; }
        public IdentifierNameSyntax VariableIdentifierName { get; private set; }

        public override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            VariableName = node.Identifier.Text;
            VariableIdentifierName = node;
        }

        public override void Visit(SyntaxNode node)
        {
            // the first identifier encountered will be the one at the bottom of the syntax tree
            if (VariableName == null)
            {
                base.Visit(node);
            }
        }

        public static string ExtractVariabeName(ArgumentSyntax argument)
        {
            if (argument.Parent is ArgumentListSyntax argumentList && argumentList.Parent is InvocationExpressionSyntax invocation)
            {
                return ExtractVariabeName(invocation);
            }
            return null;
        }

        public static string ExtractVariabeName(ExpressionSyntax invocation)
        {
            var variableExtractor = new VariableNameExtractor();
            invocation.Accept(variableExtractor);

            return variableExtractor.VariableName;
        }

        public static string ExtractVariabeName(InvocationExpressionSyntax invocation)
        {
            var variableExtractor = new VariableNameExtractor();
            invocation.Accept(variableExtractor);

            return variableExtractor.VariableName;
        }
    }
}
