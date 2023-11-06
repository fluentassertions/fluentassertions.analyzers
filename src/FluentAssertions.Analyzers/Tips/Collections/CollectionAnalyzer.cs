using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers;

public abstract class CollectionAnalyzer : FluentAssertionsAnalyzer
{
    protected override bool ShouldAnalyzeVariableNamedType(INamedTypeSymbol type, SemanticModel semanticModel)
    {
        return type.SpecialType != SpecialType.System_String
            && type.IsTypeOrConstructedFromTypeOrImplementsType(SpecialType.System_Collections_Generic_IEnumerable_T);
    }

    override protected bool ShouldAnalyzeVariableType(ITypeSymbol type, SemanticModel semanticModel)
    {
        return type.SpecialType != SpecialType.System_String
            && type.IsTypeOrConstructedFromTypeOrImplementsType(SpecialType.System_Collections_Generic_IEnumerable_T);
    }

}
