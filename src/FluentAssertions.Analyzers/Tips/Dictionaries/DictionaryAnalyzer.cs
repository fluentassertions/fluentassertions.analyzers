using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers
{
    public abstract class DictionaryAnalyzer : FluentAssertionsAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(INamedTypeSymbol type, SemanticModel semanticModel)
        {
            var iDictionaryType = semanticModel.GetGenericIDictionaryType();
            return type.IsTypeOrConstructedFromTypeOrImplementsType(iDictionaryType);
        }
    }
}