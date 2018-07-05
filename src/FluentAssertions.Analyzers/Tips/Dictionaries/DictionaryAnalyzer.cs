using System.Linq;
using Microsoft.CodeAnalysis;

namespace FluentAssertions.Analyzers
{
    public abstract class DictionaryAnalyzer : FluentAssertionsAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(ITypeSymbol type)
        {
            var res = type.AllInterfaces.Any(@interface => @interface.Name == "IDictionary");
            return res;
        }
    }
}
