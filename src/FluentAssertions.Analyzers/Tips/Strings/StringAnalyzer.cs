using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers
{
    public abstract class StringAnalyzer : FluentAssertionsAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(TypeInfo typeInfo)
        {
            return typeInfo.ConvertedType.Name == "String";
        }
    }
}
