using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers;

public abstract class CollectionBaseAnalyzer : FluentAssertionsAnalyzer
{
    protected override bool ShouldAnalyzeVariableNamedType(INamedTypeSymbol type, SemanticModel semanticModel)
    {
        return type.SpecialType != SpecialType.System_String
            && type.IsTypeOrConstructedFromTypeOrImplementsType(SpecialType.System_Collections_Generic_IEnumerable_T);
    }

    protected override bool ShouldAnalyzeVariableType(ITypeSymbol type, SemanticModel semanticModel)
    {
        return type.SpecialType != SpecialType.System_String
            && type.IsTypeOrConstructedFromTypeOrImplementsType(SpecialType.System_Collections_Generic_IEnumerable_T);
    }
}
