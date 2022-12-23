using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers.Xunit
{
    public abstract class XunitAnalyzer : TestingLibraryAnalyzerBase
    {
        private static readonly string XunitNamespace = "Xunit";
        protected override string TestingLibraryNamespace => XunitNamespace;

        protected override bool ShouldAnalyzeVariableType(INamedTypeSymbol type, SemanticModel semanticModel) => type.Name == "Assert";
    }

    public abstract class XunitCodeFixProvider : TestingLibraryCodeFixBase
    {
        protected override string AssertClassName => "Assert";
        
        protected ExpressionSyntax GetNewExpressionForEqualityWithComparer(
            ExpressionSyntax expression,
            string oldName,
            string newName)
        {
            var rename = NodeReplacement.RenameAndExtractArguments(oldName, newName);
            var newExpression = GetNewExpression(expression, rename);

            var actual = rename.Arguments[1];
            var optionsLambda = Expressions.OptionsUsing(rename.Arguments[2]);

            newExpression = ReplaceIdentifier(newExpression, AssertClassName, Expressions.SubjectShould(actual.Expression));

            return GetNewExpression(newExpression, NodeReplacement.WithArguments(newName, rename.Arguments.RemoveAt(2).Add(optionsLambda).RemoveAt(1)));
        }
    }
}