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
        var current = type;
        while (!current.Equals(current.ConstructedFrom, SymbolEqualityComparer.Default))
        {
            current = current.ConstructedFrom;
        }
        return current.Equals(interfaceType, SymbolEqualityComparer.Default);
    }

    public static bool ConstructedFromType(this INamedTypeSymbol type, SpecialType specialType)
    {
        var current = type;
        while (!current.Equals(current.ConstructedFrom, SymbolEqualityComparer.Default))
        {
            current = current.ConstructedFrom;
        }
        return current.SpecialType == specialType;
    }

    public static bool ImplementsOrIsInterface(this ITypeSymbol type, INamedTypeSymbol interfaceType)
    {
        var current = type;
        while (!current.Equals(current.OriginalDefinition, SymbolEqualityComparer.Default))
        {
            current = current.OriginalDefinition;
        }
        return current.Equals(interfaceType, SymbolEqualityComparer.Default) 
            || current.AllInterfaces.Any(@interface => @interface.OriginalDefinition.Equals(interfaceType, SymbolEqualityComparer.Default));
    }
    public static bool ImplementsOrIsInterface(this ITypeSymbol type, SpecialType specialType)
    {
        var current = type;
        while (!current.Equals(current.OriginalDefinition, SymbolEqualityComparer.Default))
        {
            current = current.OriginalDefinition;
        }
        return current.SpecialType == specialType || current.AllInterfaces.Any(@interface => @interface.OriginalDefinition.SpecialType.Equals(specialType));
    }
}
