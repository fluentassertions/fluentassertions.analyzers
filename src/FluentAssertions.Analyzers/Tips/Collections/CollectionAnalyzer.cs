using Microsoft.CodeAnalysis;
using System.Linq;

namespace FluentAssertions.Analyzers
{
    public abstract class CollectionAnalyzer : FluentAssertionsAnalyzer
    {
        protected override bool ShouldAnalyzerVariableType(TypeInfo typeInfo)
        {
            return typeInfo.ConvertedType.Name != "String"
                && typeInfo.ConvertedType.AllInterfaces.Any(@interface => @interface.Name == "IEnumerable");
        }
    }
}
