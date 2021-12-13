using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers
{
    public abstract class StringAnalyzer : FluentAssertionsAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(INamedTypeSymbol type, SemanticModel semanticModel) => type.SpecialType == SpecialType.System_String;
    }
}
