using System;
using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers.Tips.Exceptions
{
    public abstract class ExceptionAnalyzer : FluentAssertionsAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(ITypeSymbol type) => type.Name == nameof(Action);
    }
}
