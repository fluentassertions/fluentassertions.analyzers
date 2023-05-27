using Microsoft.CodeAnalysis;
using System.Linq;

namespace FluentAssertions.Analyzers.Utilities
{
    internal static class TypesExtensions
    {
        public static bool IsTypeOrConstructedFromTypeOrImplementsType(this INamedTypeSymbol type, SpecialType specialType)
        {
            var abstractType = type.OriginalDefinition;
            return abstractType.SpecialType == specialType 
                || abstractType.AllInterfaces.Any(@interface => @interface.OriginalDefinition.SpecialType == specialType);
        }

        public static bool IsTypeOrConstructedFromTypeOrImplementsType(this INamedTypeSymbol type, INamedTypeSymbol other)
        {
            var abstractType = type.OriginalDefinition;
            return abstractType.Equals(other, SymbolEqualityComparer.Default)
                || abstractType.AllInterfaces.Any(@interface => @interface.OriginalDefinition.Equals(other, SymbolEqualityComparer.Default));
        }
    }
}
