using Microsoft.CodeAnalysis;
using System.Linq;

namespace FluentAssertions.Analyzers.Utilities;

internal static class TypesExtensions
{
    public static bool IsTypeOrConstructedFromTypeOrImplementsType(this INamedTypeSymbol type, INamedTypeSymbol other)
    {
        var abstractType = type.OriginalDefinition;
        return abstractType.Equals(other, SymbolEqualityComparer.Default)
            || abstractType.AllInterfaces.Any(@interface => @interface.OriginalDefinition.Equals(other, SymbolEqualityComparer.Default));
    }

    public static bool IsTypeOrConstructedFromTypeOrImplementsType(this ITypeSymbol type, SpecialType specialType)
    {
        return type.SpecialType == specialType 
            || type.AllInterfaces.Any(@interface => @interface.OriginalDefinition.SpecialType == specialType);
    }


    public static bool ConstructedFromType(this INamedTypeSymbol type, INamedTypeSymbol interfaceType)
    {
        var constructedFrom = type;
        while (constructedFrom.Equals(type, SymbolEqualityComparer.Default))
        {
            constructedFrom = type.ConstructedFrom;
        }

        return constructedFrom.Equals(interfaceType, SymbolEqualityComparer.Default);
    }

    public static bool ConstructedFromType(this INamedTypeSymbol type, SpecialType specialType)
    {
        var constructedFrom = type;
        while (constructedFrom.Equals(type, SymbolEqualityComparer.Default))
        {
            constructedFrom = type.ConstructedFrom;
        }

        return constructedFrom.SpecialType == specialType;
    }

    public static bool ImplementsOrIsInterface(this ITypeSymbol type, INamedTypeSymbol interfaceType)
    {
        var originalDefinition = type;
        while (originalDefinition.Equals(type, SymbolEqualityComparer.Default))
        {
            originalDefinition = type.OriginalDefinition;
        }

        return originalDefinition.AllInterfaces.Any(@interface => @interface.OriginalDefinition.Equals(interfaceType, SymbolEqualityComparer.Default));
    }
}
