using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAssertions.Analyzers.Utilities
{
    internal static class TypesExtensions
    {
        public static bool IsTypeOrConstructedFromTypeOrImplementsType(this ITypeSymbol type, SpecialType specialType)
        {
            return type.SpecialType == specialType
                || type.OriginalDefinition?.SpecialType == specialType
                || type.AllInterfaces.Any(@interface => @interface.SpecialType == specialType);
        }
    }
}
