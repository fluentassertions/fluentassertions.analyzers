using Microsoft.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Analyzers.Utilities
{
    internal static class SemanticModelTypeExtensions
    {
        public static INamedTypeSymbol GetActionType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, typeof(Action));

        public static INamedTypeSymbol GetGenericIEnumerableType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, SpecialType.System_Collections_Generic_IEnumerable_T);

        public static INamedTypeSymbol GetIEnumerableType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, SpecialType.System_Collections_IEnumerable);

        public static INamedTypeSymbol GetIDictionaryType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, typeof(IDictionary));

        public static INamedTypeSymbol GetGenericIDictionaryType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, typeof(IDictionary<,>));

        public static INamedTypeSymbol GetIReadOnlyDictionaryType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, typeof(IReadOnlyDictionary<,>));

        private static INamedTypeSymbol GetTypeFrom(SemanticModel semanticModel, Type type)
            => semanticModel.Compilation.GetTypeByMetadataName(type.FullName);

        private static INamedTypeSymbol GetTypeFrom(SemanticModel semanticModel, SpecialType type)
            => semanticModel.Compilation.GetSpecialType(type);
    }
}
