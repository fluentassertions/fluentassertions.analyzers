using Microsoft.CodeAnalysis;
using System.Linq;

namespace FluentAssertions.Analyzers
{
    public abstract class CollectionAnalyzer : FluentAssertionsAnalyzer
    {
        protected override bool ShouldAnalyzeVariableType(TypeInfo typeInfo)
        {
            return typeInfo.ConvertedType.Name != "String"
                && typeInfo.ConvertedType.AllInterfaces.Any(@interface => @interface.Name == "IEnumerable");
        }
    }
}
