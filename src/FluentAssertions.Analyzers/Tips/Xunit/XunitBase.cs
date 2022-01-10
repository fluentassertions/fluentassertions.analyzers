using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace FluentAssertions.Analyzers.Xunit
{
    public abstract class XunitAnalyzer : FluentAssertionsAnalyzer
    {
        private static readonly NameSyntax XunitNamespace = SyntaxFactory.ParseName("Xunit");

        protected override bool ShouldAnalyzeMethod(MethodDeclarationSyntax method)
        {
            var compilation = method.FirstAncestorOrSelf<CompilationUnitSyntax>();

            if (compilation == null) return false;

            return compilation.Usings.Any(usingDirective => usingDirective.Name.IsEquivalentTo(XunitNamespace));
        }

        protected override bool ShouldAnalyzeVariableType(INamedTypeSymbol type, SemanticModel semanticModel) => type.Name == "Assert";
    }

    public abstract class XunitCodeFixProvider : TestingLibraryCodeFixBase
    {
        protected override string AssertClassName => "Assert";
    }
}