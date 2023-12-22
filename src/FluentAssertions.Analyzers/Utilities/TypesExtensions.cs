using Microsoft.CodeAnalysis;
using System.Linq;

namespace FluentAssertions.Analyzers.Utilities;

internal static class TypesExtensions
{
    public static bool IsTypeOrConstructedFromTypeOrImplementsType(this INamedTypeSymbol type, INamedTypeSymbol other)
    {
        var abstractType = type.OriginalDefinition;
        return abstractType.EqualsSymbol(other)
            || abstractType.AllInterfaces.Any(@interface => @interface.OriginalDefinition.EqualsSymbol(other));
    }

    public static bool IsTypeOrConstructedFromTypeOrImplementsType(this ITypeSymbol type, SpecialType specialType)
    {
        return type.SpecialType == specialType
            || type.AllInterfaces.Any(@interface => @interface.OriginalDefinition.SpecialType == specialType);
    }


    public static bool ConstructedFromType(this INamedTypeSymbol type, INamedTypeSymbol interfaceType)
    {
        var current = type;
        while (!current.EqualsSymbol(current.ConstructedFrom))
        {
            current = current.ConstructedFrom;
        }
        return current.EqualsSymbol(interfaceType);
    }

    public static bool ConstructedFromType(this INamedTypeSymbol type, SpecialType specialType)
    {
        var current = type;
        while (!current.EqualsSymbol(current.ConstructedFrom))
        {
            current = current.ConstructedFrom;
        }
        return current.SpecialType == specialType;
    }

    public static bool ImplementsOrIsInterface(this ITypeSymbol type, INamedTypeSymbol interfaceType)
    {
        var current = type;
        while (!current.EqualsSymbol(current.OriginalDefinition))
        {
            current = current.OriginalDefinition;
        }
        return current.EqualsSymbol(interfaceType) 
            || current.AllInterfaces.Any(@interface => @interface.OriginalDefinition.EqualsSymbol(interfaceType));
    }
    public static bool ImplementsOrIsInterface(this ITypeSymbol type, SpecialType specialType)
    {
        var current = type;
        while (!current.EqualsSymbol(current.OriginalDefinition))
        {
            current = current.OriginalDefinition;
        }
        return current.SpecialType == specialType || current.AllInterfaces.Any(@interface => @interface.OriginalDefinition.SpecialType.Equals(specialType));
    }

    public static bool IsOrInheritsFrom(this ITypeSymbol symbol, INamedTypeSymbol baseSymbol)
    {
        if (symbol is null || baseSymbol is null)
            return false;

        do
        {
            if (symbol.EqualsSymbol(baseSymbol))
                return true;

            symbol = symbol.BaseType;
        } while (symbol is not null);

        return false;
    }

    public static bool EqualsSymbol(this ISymbol type, ISymbol other) => type.Equals(other, SymbolEqualityComparer.Default);
}
