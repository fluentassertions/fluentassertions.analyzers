using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers
{
    public abstract class MsTestAnalyzer : TestingLibraryAnalyzerBase
    {
        private static readonly string MsTestNamespace = "Microsoft.VisualStudio.TestTools.UnitTesting";
        protected override string TestingLibraryNamespace => MsTestNamespace;
    }

    public abstract class MsTestAssertAnalyzer : MsTestAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(INamedTypeSymbol type, SemanticModel semanticModel) => type.Name == "Assert";
    }

    public abstract class MsTestStringAssertAnalyzer : MsTestAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(INamedTypeSymbol type, SemanticModel semanticModel) => type.Name == "StringAssert";
    }

    public abstract class MsTestCollectionAssertAnalyzer : MsTestAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(INamedTypeSymbol type, SemanticModel semanticModel) => type.Name == "CollectionAssert";
    }

    public abstract class MsTestAssertCodeFixProvider : TestingLibraryCodeFixBase
    {
        protected override string AssertClassName => "Assert";

        protected ExpressionSyntax GetNewExpressionForAreNotEqualOrAreEqualStrings(ExpressionSyntax expression, SemanticModel semanticModel, string oldName, string newName, string newNameIgnoreCase)
        {
            var rename = NodeReplacement.RenameAndExtractArguments(oldName, newName);
            var newExpression = GetNewExpression(expression, rename);

            var actual = rename.Arguments[1];

            newExpression = ReplaceIdentifier(newExpression, AssertClassName, Expressions.SubjectShould(actual.Expression));

            var newArguments = rename.Arguments.Remove(actual);

            var ignoreCase = false;
            if (newArguments.Count >= 2 && newArguments[1].Expression is LiteralExpressionSyntax possibleIgnoreCaseArg)
            {
                newArguments = newArguments.Remove(newArguments[1]);
                ignoreCase = possibleIgnoreCaseArg.Token.IsKind(SyntaxKind.TrueKeyword);
            }

            if (newArguments.Count >= 2 && semanticModel.GetCultureInfoType().Equals(semanticModel.GetTypeInfo(rename.Arguments[3].Expression).Type, SymbolEqualityComparer.Default))
            {
                newArguments = newArguments.Remove(newArguments[1]);
            }

            newExpression = GetNewExpression(newExpression, NodeReplacement.WithArguments(newName, newArguments));

            if (ignoreCase)
            {
                return GetNewExpression(newExpression, NodeReplacement.Rename(newName, newNameIgnoreCase));
            }

            return newExpression;
        }
    }

    public abstract class MsTestCollectionAssertCodeFixProvider : TestingLibraryCodeFixBase
    {
        protected override string AssertClassName => "CollectionAssert";
    }

    public abstract class MsTestStringAssertCodeFixProvider : TestingLibraryCodeFixBase
    {
        protected override string AssertClassName => "StringAssert";
    }
}