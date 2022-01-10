using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace FluentAssertions.Analyzers
{
    public abstract class MsTestAnalyzer : FluentAssertionsAnalyzer
    {
        private static readonly NameSyntax MsTestNamespace = SyntaxFactory.ParseName("Microsoft.VisualStudio.TestTools.UnitTesting");

        protected override bool ShouldAnalyzeMethod(MethodDeclarationSyntax method)
        {
            var compilation = method.FirstAncestorOrSelf<CompilationUnitSyntax>();

            if (compilation == null) return false;

            return compilation.Usings.Any(usingDirective => usingDirective.Name.IsEquivalentTo(MsTestNamespace));
        }
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

    public abstract class MsTestCodeFixProvider : FluentAssertionsCodeFixProvider
    {
        protected ExpressionSyntax RenameMethodAndReplaceWithSubjectShould(ExpressionSyntax expression, string oldName, string newName, string assert)
        {
            var rename = NodeReplacement.RenameAndRemoveFirstArgument(oldName, newName);
            var newExpression = GetNewExpression(expression, rename);

            return ReplaceIdentifier(newExpression, assert, Expressions.SubjectShould(rename.Argument.Expression));
        }

        protected ExpressionSyntax RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(ExpressionSyntax expression, string oldName, string newName, string assert)
        {
            var rename = NodeReplacement.RenameAndExtractArguments(oldName, newName);
            var newExpression = GetNewExpression(expression, rename);

            var actual = rename.Arguments[1];

            newExpression = ReplaceIdentifier(newExpression, assert, Expressions.SubjectShould(actual.Expression));

            return GetNewExpression(newExpression, NodeReplacement.WithArguments(newName, rename.Arguments.RemoveAt(1)));
        }

        protected ExpressionSyntax GetNewExpressionForAreNotEqualOrAreEqualStrings(ExpressionSyntax expression, SemanticModel semanticModel, string oldName, string newName, string newNameIgnoreCase, string assert)
        {
            var rename = NodeReplacement.RenameAndExtractArguments(oldName, newName);
            var newExpression = GetNewExpression(expression, rename);

            var actual = rename.Arguments[1];

            newExpression = ReplaceIdentifier(newExpression, assert, Expressions.SubjectShould(actual.Expression));

            var newArguments = rename.Arguments.Remove(actual);

            var ignoreCase = false;
            if (newArguments.Count >= 2 && newArguments[1].Expression is LiteralExpressionSyntax possibleIgnoreCaseArg)
            {
                newArguments = newArguments.Remove(newArguments[1]);
                ignoreCase = possibleIgnoreCaseArg.Token.IsKind(SyntaxKind.TrueKeyword);
            }

            if (newArguments.Count >= 2 && semanticModel.GetCultureInfoType().Equals(semanticModel.GetTypeInfo(rename.Arguments[3].Expression).Type))
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
}