using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers;

public abstract class StringAnalyzer : FluentAssertionsAnalyzer
{
    protected override bool ShouldAnalyzeVariableNamedType(INamedTypeSymbol type, SemanticModel semanticModel) => type.SpecialType == SpecialType.System_String;

    protected override bool ShouldAnalyzeVariableType(ITypeSymbol type, SemanticModel semanticModel)
    {
        return false;
    }
}
