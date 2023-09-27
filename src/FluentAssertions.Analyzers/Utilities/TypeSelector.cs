using Microsoft.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FluentAssertions.Analyzers.Utilities
{
    internal static class TypeSelector
    {
        public static INamedTypeSymbol GetActionType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, typeof(Action));

        public static INamedTypeSymbol GetIntType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, SpecialType.System_Int32);
        
        public static INamedTypeSymbol GetFloatType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, SpecialType.System_Single);

        public static INamedTypeSymbol GetDoubleType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, SpecialType.System_Double);
        
        public static INamedTypeSymbol GetDecimalType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, SpecialType.System_Decimal);

        public static INamedTypeSymbol GetDateTimeType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, SpecialType.System_DateTime);

        public static INamedTypeSymbol GetTimeSpanType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, typeof(TimeSpan));

        public static INamedTypeSymbol GetStringType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, SpecialType.System_String);

        public static INamedTypeSymbol GetRegexType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, typeof(Regex));

        public static INamedTypeSymbol GetCultureInfoType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, typeof(CultureInfo));

        public static INamedTypeSymbol GetBooleanType(this SemanticModel semanticModel)
            => GetTypeFrom(semanticModel, SpecialType.System_Boolean);

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
