using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers
{
    public abstract class CollectionAnalyzer : FluentAssertionsAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(INamedTypeSymbol type, SemanticModel semanticModel)
        {
            return type.SpecialType != SpecialType.System_String
                && type.IsTypeOrConstructedFromTypeOrImplementsType(SpecialType.System_Collections_Generic_IEnumerable_T);
        }
    }
}
