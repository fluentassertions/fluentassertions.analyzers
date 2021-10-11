using System;
using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers
{
    public abstract class ExceptionAnalyzer : FluentAssertionsAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(ITypeSymbol type, SemanticModel semanticModel) => type.Name == nameof(Action);
    }
}
