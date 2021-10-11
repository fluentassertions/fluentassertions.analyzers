using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers
{
    public abstract class StringAnalyzer : FluentAssertionsAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(ITypeSymbol type, SemanticModel semanticModel) => type.Name == "String";
    }
}
