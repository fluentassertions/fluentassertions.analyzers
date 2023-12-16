using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;

namespace FluentAssertions.Analyzers;

public partial class FluentAssertionsOperationAnalyzer
{
    private static bool IsEnumerableMethodWithoutArguments(IInvocationOperation invocation, FluentAssertionsMetadata metadata)
        => invocation.IsContainedInType(metadata.Enumerable) && invocation.Arguments.Length == 1;

    private static bool IsEnumerableMethodWithPredicate(IInvocationOperation invocation, FluentAssertionsMetadata metadata)
        => invocation.IsContainedInType(metadata.Enumerable) && invocation.Arguments.Length == 2 && invocation.Arguments[1].IsLambda(); // invocation.Arguments[0] is `this` argument

    private class FluentAssertionsMetadata
    {
        public FluentAssertionsMetadata(Compilation compilation)
        {
            AssertionExtensions = compilation.GetTypeByMetadataName("FluentAssertions.AssertionExtensions");
            ReferenceTypeAssertionsOfT2 = compilation.GetTypeByMetadataName("FluentAssertions.Primitives.ReferenceTypeAssertions`2");
            ObjectAssertionsOfT2 = compilation.GetTypeByMetadataName("FluentAssertions.Primitives.ObjectAssertions`2");
            NumericAssertionsOfT2 = compilation.GetTypeByMetadataName("FluentAssertions.Numeric.NumericAssertions`2");
            BooleanAssertionsOfT1 = compilation.GetTypeByMetadataName("FluentAssertions.Primitives.BooleanAssertions`1");
            GenericCollectionAssertionsOfT3 = compilation.GetTypeByMetadataName("FluentAssertions.Collections.GenericCollectionAssertions`3");
            StringAssertionsOfT1 = compilation.GetTypeByMetadataName("FluentAssertions.Primitives.StringAssertions`1");
            IDictionaryOfT2 = compilation.GetTypeByMetadataName(typeof(IDictionary<,>).FullName);
            IReadonlyDictionaryOfT2 = compilation.GetTypeByMetadataName(typeof(IReadOnlyDictionary<,>).FullName);

            Enumerable = compilation.GetTypeByMetadataName(typeof(Enumerable).FullName);
            Math = compilation.GetTypeByMetadataName(typeof(Math).FullName);
        }
        public INamedTypeSymbol AssertionExtensions { get; }
        public INamedTypeSymbol ReferenceTypeAssertionsOfT2 { get; }
        public INamedTypeSymbol ObjectAssertionsOfT2 { get; }
        public INamedTypeSymbol GenericCollectionAssertionsOfT3 { get; }
        public INamedTypeSymbol StringAssertionsOfT1 { get; }
        public INamedTypeSymbol IDictionaryOfT2 { get; }
        public INamedTypeSymbol IReadonlyDictionaryOfT2 { get; }
        public INamedTypeSymbol BooleanAssertionsOfT1 { get; }
        public INamedTypeSymbol NumericAssertionsOfT2 { get; }
        public INamedTypeSymbol Enumerable { get; }
        public INamedTypeSymbol Math { get; }
    }
}