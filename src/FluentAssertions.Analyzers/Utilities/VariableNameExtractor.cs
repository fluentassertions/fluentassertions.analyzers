using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace FluentAssertions.Analyzers
{
    public class VariableNameExtractor : CSharpSyntaxWalker
    {
        private readonly SemanticModel _semanticModel;

        public string VariableName => VariableIdentifierName?.Identifier.Text;
        public IdentifierNameSyntax VariableIdentifierName => PropertiesAccessed.Count > 0 ? PropertiesAccessed[0] : null;

        public List<IdentifierNameSyntax> PropertiesAccessed { get; } = new List<IdentifierNameSyntax>();

        public VariableNameExtractor(SemanticModel semanticModel = null)
        {
            _semanticModel = semanticModel;
        }

        public override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (IsVariable(node))
            {
                PropertiesAccessed.Add(node);
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

        public static string ExtractVariabeName(InvocationExpressionSyntax invocation)
        {
            var variableExtractor = new VariableNameExtractor();
            invocation.Accept(variableExtractor);

            return variableExtractor.VariableName;
        }

        private bool IsVariable(IdentifierNameSyntax node)
        {
            if (_semanticModel != null)
            {
                SymbolInfo info = _semanticModel.GetSymbolInfo(node);
                if (info.Symbol == null ||
                    info.Symbol.Kind == SymbolKind.Method ||
                    info.Symbol.IsStatic)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
