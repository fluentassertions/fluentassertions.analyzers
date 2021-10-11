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
            var abstractType = type.OriginalDefinition;
            return abstractType.SpecialType == specialType 
                || abstractType.AllInterfaces.Any(@interface => @interface.OriginalDefinition.SpecialType == specialType);
        }
    }
}
