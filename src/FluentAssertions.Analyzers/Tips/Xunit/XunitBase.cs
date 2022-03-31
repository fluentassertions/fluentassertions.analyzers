using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers.Xunit
{
    public abstract class XunitAnalyzer : TestingLibraryAnalyzerBase
    {
        private static readonly NameSyntax XunitNamespace = SyntaxFactory.ParseName("Xunit");
        protected override NameSyntax TestingLibraryNamespace => XunitNamespace;

        protected override bool ShouldAnalyzeVariableType(INamedTypeSymbol type, SemanticModel semanticModel) => type.Name == "Assert";
    }

    public abstract class XunitCodeFixProvider : TestingLibraryCodeFixBase
    {
        protected override string AssertClassName => "Assert";
    }
}