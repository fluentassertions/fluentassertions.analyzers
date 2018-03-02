using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers
{
    public abstract class ComparableAnalyzer : FluentAssertionsAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(TypeInfo typeInfo)
        {
            return true;
        }
    }
}
