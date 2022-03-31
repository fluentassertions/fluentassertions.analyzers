using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;

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
    }
}