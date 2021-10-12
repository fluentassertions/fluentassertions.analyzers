using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers
{
    public abstract class ExceptionAnalyzer : FluentAssertionsAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(INamedTypeSymbol type, SemanticModel semanticModel)
        {
            var actionType = semanticModel.GetActionType();
            return type.IsTypeOrConstructedFromTypeOrImplementsType(actionType);
        }
    }
}
