using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace FluentAssertions.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public partial class FluentAssertionsAnalyzer : DiagnosticAnalyzer
{
    public const string Title = "Simplify Assertion";
    public const string DiagnosticId = "FAA0001";
    public const string Message = "Clean up FluentAssertion usage";

    protected static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, Message, Constants.Tips.Category, DiagnosticSeverity.Info, true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.RegisterCompilationStartAction(compilationStartContext =>
        {
            var metadata = new FluentAssertionsMetadata(compilationStartContext.Compilation);
            if (metadata.AssertionExtensions is null)
            {
                return;
            }

            compilationStartContext.RegisterOperationAction(operationContext => AnalyzeInvocation(operationContext, metadata), OperationKind.Invocation);
        });
    }

    private static void AnalyzeInvocation(OperationAnalysisContext context, FluentAssertionsMetadata metadata)
    {
        var invocation = (IInvocationOperation)context.Operation;
        if (invocation.TargetMethod.Name is not "Should" || invocation.Arguments.Length is not 1)
        {
            return;
        }

        if (invocation.Parent is not IInvocationOperation assertion)
        {
            return;
        }

        if (HasConditionalAccessAncestor(invocation))
        {
            var expressionStatement = invocation.GetFirstAncestor<IExpressionStatementOperation>();
            context.ReportDiagnostic(CreateDiagnostic(expressionStatement, DiagnosticMetadata.NullConditionalMayNotExecute));
            return;
        }

        var subjectArgument = invocation.Arguments[0];
        var subject = subjectArgument.Value;

        switch (assertion.TargetMethod.Name)
        {
            case nameof(object.Equals):

                if (subject.Type.SpecialType is SpecialType.System_String)
                {
                    context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.StringShouldBe_StringShouldEquals));
                    return;
                }

                if (subject.Type.EqualsSymbol(metadata.TaskCompletionSourceOfT1)
                || subject.Type.AllInterfaces.Contains(metadata.Stream))
                {
                    context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.ShouldEquals));
                    return;
                }

                if (subject.Type.ImplementsOrIsInterface(metadata.IEnumerable))
                {
                    context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldEqual_CollectionShouldEquals));
                    return;
                }

                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.ShouldBe_ShouldEquals));
                return;
            case "NotBeEmpty" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (assertion.TryGetChainedInvocationAfterAndConstraint("NotBeNull", out var chainedInvocation))
                    {
                        if (!assertion.HasEmptyBecauseAndReasonArgs() && !chainedInvocation.HasEmptyBecauseAndReasonArgs()) return;

                        if (chainedInvocation.IsContainedInType(metadata.ReferenceTypeAssertionsOfT2))
                        {
                            context.ReportDiagnostic(CreateDiagnostic(chainedInvocation, DiagnosticMetadata.CollectionShouldNotBeNullOrEmpty_ShouldNotBeEmptyAndNotBeNull));
                            return;
                        }
                    }
                    else if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Where) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldContainProperty_WhereShouldNotBeEmpty));
                                return;
                            case nameof(Enumerable.Intersect) when invocationBeforeShould.Arguments.Length is 2:
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldIntersectWith_IntersectShouldNotBeEmpty));
                                return;
                        }
                    }
                    return;
                }
            case "NotBeEmpty" when assertion.IsContainedInType(metadata.StringAssertionsOfT1):
                {
                    if (assertion.TryGetChainedInvocationAfterAndConstraint("NotBeNull", out var chainedInvocation))
                    {
                        if (!assertion.HasEmptyBecauseAndReasonArgs() && !chainedInvocation.HasEmptyBecauseAndReasonArgs()) return;

                        if (chainedInvocation.IsContainedInType(metadata.ReferenceTypeAssertionsOfT2))
                        {
                            context.ReportDiagnostic(CreateDiagnostic(chainedInvocation, DiagnosticMetadata.StringShouldNotBeNullOrEmpty_StringShouldNotBeEmptyAndNotBeNull));
                            return;
                        }
                    }
                }
                return;
            case "BeEmpty" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Intersect) when invocationBeforeShould.Arguments.Length is 2:
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotIntersectWith_IntersectShouldBeEmpty));
                                return;
                            case nameof(Enumerable.Where) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotContainProperty_WhereShouldBeEmpty));
                                return;
                        }
                    }
                    return;
                }
            case "NotBeNull" when assertion.IsContainedInType(metadata.ReferenceTypeAssertionsOfT2):
                {
                    if (!assertion.TryGetChainedInvocationAfterAndConstraint("NotBeEmpty", out var chainedInvocation)) return;
                    if (!assertion.HasEmptyBecauseAndReasonArgs() && !chainedInvocation.HasEmptyBecauseAndReasonArgs()) return;

                    if (chainedInvocation.IsContainedInType(metadata.GenericCollectionAssertionsOfT3))
                    {
                        context.ReportDiagnostic(CreateDiagnostic(chainedInvocation, DiagnosticMetadata.CollectionShouldNotBeNullOrEmpty_ShouldNotBeNullAndNotBeEmpty));
                        return;
                    }
                    if (chainedInvocation.IsContainedInType(metadata.StringAssertionsOfT1))
                    {
                        context.ReportDiagnostic(CreateDiagnostic(chainedInvocation, DiagnosticMetadata.StringShouldNotBeNullOrEmpty_StringShouldNotBeNullAndNotBeEmpty));
                        return;
                    }
                }
                return;
            case "NotContainNulls" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.Select) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotContainNulls_SelectShouldNotContainNulls));
                            return;
                    }
                }
                return;
            case "Equal" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.OrderBy) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata) && invocationBeforeShould.Arguments[0].IsSameArgumentReference(assertion.Arguments[0]):
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldBeInAscendingOrder_OrderByShouldEqual));
                            return;
                        case nameof(Enumerable.OrderByDescending) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata) && invocationBeforeShould.Arguments[0].IsSameArgumentReference(assertion.Arguments[0]):
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldBeInDescendingOrder_OrderByDescendingShouldEqual));
                            return;
                        case nameof(Enumerable.Select) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata) 
                            && assertion.Arguments[0].Value is IInvocationOperation { TargetMethod.Name: nameof(Enumerable.Select), Arguments.Length: 2 } expectedInvocation && expectedInvocation.Arguments[1].IsLambda():
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldEqualOtherCollectionByComparer_SelectShouldEqualOtherCollectionSelect));
                            return;
                    }
                }
                return;
            case "BeTrue" when assertion.IsContainedInType(metadata.BooleanAssertionsOfT1):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Any) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotBeEmpty_AnyShouldBeTrue));
                                return;
                            case nameof(Enumerable.Any) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldContainProperty_AnyWithLambdaShouldBeTrue));
                                return;
                            case nameof(Enumerable.All) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldOnlyContainProperty_AllShouldBeTrue));
                                return;
                            case nameof(Enumerable.Contains) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 2:
                            case nameof(ICollection<object>.Contains) when invocationBeforeShould.ImplementsOrIsInterface(SpecialType.System_Collections_Generic_ICollection_T) && invocationBeforeShould.Arguments.Length is 1:
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldContainItem_ContainsShouldBeTrue));
                                return;
                            case nameof(string.EndsWith) when invocationBeforeShould.IsContainedInType(SpecialType.System_String):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.StringShouldEndWith_EndsWithShouldBeTrue));
                                return;
                            case nameof(string.StartsWith) when invocationBeforeShould.IsContainedInType(SpecialType.System_String):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.StringShouldStartWith_StartsWithShouldBeTrue));
                                return;
                            case nameof(IDictionary<string, object>.ContainsKey) when invocationBeforeShould.ImplementsOrIsInterface(metadata.IDictionaryOfT2) || invocationBeforeShould.ImplementsOrIsInterface(metadata.IReadonlyDictionaryOfT2):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.DictionaryShouldContainKey_ContainsKeyShouldBeTrue));
                                return;
                            case nameof(Dictionary<string, object>.ContainsValue) when invocationBeforeShould.IsContainedInType(metadata.DictionaryOfT2):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.DictionaryShouldContainValue_ContainsValueShouldBeTrue));
                                return;
                        }
                    }
                    if (subject is IInvocationOperation shouldArgumentInvocation)
                    {
                        switch (shouldArgumentInvocation.TargetMethod.Name)
                        {
                            case nameof(string.IsNullOrEmpty) when shouldArgumentInvocation.IsContainedInType(SpecialType.System_String):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.StringShouldBeNullOrEmpty_StringIsNullOrEmptyShouldBeTrue));
                                return;
                            case nameof(string.IsNullOrWhiteSpace) when shouldArgumentInvocation.IsContainedInType(SpecialType.System_String):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.StringShouldBeNullOrWhiteSpace_StringIsNullOrWhiteSpaceShouldBeTrue));
                                return;
                        }
                    }
                }
                return;
            case "BeFalse" when assertion.IsContainedInType(metadata.BooleanAssertionsOfT1):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Any) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldBeEmpty_AnyShouldBeFalse));
                                return;
                            case nameof(Enumerable.Any) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotContainProperty_AnyLambdaShouldBeFalse));
                                return;
                            case nameof(Enumerable.Contains) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 2:
                            case nameof(ICollection<object>.Contains) when invocationBeforeShould.ImplementsOrIsInterface(SpecialType.System_Collections_Generic_ICollection_T) && invocationBeforeShould.Arguments.Length is 1:
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotContainItem_ContainsShouldBeFalse));
                                return;
                            case nameof(IDictionary<string, object>.ContainsKey) when invocationBeforeShould.ImplementsOrIsInterface(metadata.IDictionaryOfT2) || invocationBeforeShould.ImplementsOrIsInterface(metadata.IReadonlyDictionaryOfT2):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.DictionaryShouldNotContainKey_ContainsKeyShouldBeFalse));
                                return;
                            case nameof(Dictionary<string, object>.ContainsValue) when invocationBeforeShould.IsContainedInType(metadata.DictionaryOfT2):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.DictionaryShouldNotContainValue_ContainsValueShouldBeFalse));
                                return;
                        }
                    }
                    if (subject is IInvocationOperation shouldArgumentInvocation)
                    {
                        switch (shouldArgumentInvocation.TargetMethod.Name)
                        {
                            case nameof(string.IsNullOrEmpty) when shouldArgumentInvocation.IsContainedInType(SpecialType.System_String):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.StringShouldNotBeNullOrEmpty_StringIsNullOrEmptyShouldBeFalse));
                                return;
                            case nameof(string.IsNullOrWhiteSpace) when shouldArgumentInvocation.IsContainedInType(SpecialType.System_String):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.StringShouldNotBeNullOrWhiteSpace_StringShouldNotBeNullOrWhiteSpace));
                                return;
                        }
                    }
                }
                return;
            case "HaveCount" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3) && assertion.Arguments[0].IsLiteralValue(1):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Where):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldContainSingle_WhereShouldHaveCount1));
                                return;
                        }
                    }

                    context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldContainSingle_ShouldHaveCount1));
                }
                return;
            case "HaveCount" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3) && assertion.Arguments[0].IsLiteralValue(0):
                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldBeEmpty_ShouldHaveCount0));
                return;
            case "HaveCount" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3) && assertion.Arguments[0].Value is IInvocationOperation { TargetMethod.Name: nameof(Enumerable.Count) }:
                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveSameCount_ShouldHaveCountOtherCollectionCount));
                return;
            case "HaveSameCount" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3) && assertion.Arguments[0].Value is IInvocationOperation { TargetMethod.Name: nameof(Enumerable.Distinct) } assertionArgumentInvocation
                && assertionArgumentInvocation.Arguments[0].IsSameArgumentReference(subjectArgument):
                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldOnlyHaveUniqueItems_ShouldHaveSameCountThisCollectionDistinct));
                return;
            case "OnlyHaveUniqueItems" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.Select) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldOnlyHaveUniqueItemsByComparer_SelectShouldOnlyHaveUniqueItems));
                            return;
                    }
                }
                return;
            case "Be" when assertion.IsContainedInType(metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: add support for Enumerable.LongCount
                            case nameof(Enumerable.Count) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                if (assertion.Arguments[0].IsLiteralValue(1))
                                {
                                    context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldContainSingle_CountShouldBe1));
                                }
                                else if (assertion.Arguments[0].IsLiteralValue(0))
                                {
                                    context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldBeEmpty_CountShouldBe0));
                                }
                                else
                                {
                                    context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCount_CountShouldBe));
                                }
                                return;

                        }
                    }
                    if (invocation.TryGetFirstDescendent<IPropertyReferenceOperation>(out var propertyBeforeShould))
                    {
                        switch (propertyBeforeShould.Property.Name)
                        {
                            case nameof(Array.Length) when propertyBeforeShould.IsContainedInType(SpecialType.System_Array):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCount_LengthShouldBe));
                                return;
                            case nameof(string.Length) when propertyBeforeShould.IsContainedInType(SpecialType.System_String):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.StringShouldHaveLength_LengthShouldBe));
                                return;
                        }
                    }
                    if (subject is IPropertyReferenceOperation propertyReference && propertyReference.Property.Name is WellKnownMemberNames.Indexer
                    && !(subject.Type.AllInterfaces.Contains(metadata.IDictionaryOfT2) || subject.Type.AllInterfaces.Contains(metadata.IReadonlyDictionaryOfT2)))
                    {
                        context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveElementAt_IndexerShouldBe));
                    }
                    return;
                }
            case "Be" when assertion.IsContainedInType(metadata.ObjectAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: add support when element type is Numeric
                            case nameof(Enumerable.ElementAt) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 2:
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveElementAt_ElementAtIndexShouldBe));
                                return;
                            case nameof(Enumerable.First) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                {
                                    if (invocationBeforeShould.TryGetFirstDescendent<IInvocationOperation>(out var skipInvocation) && skipInvocation.TargetMethod.Name is nameof(Enumerable.Skip))
                                    {
                                        context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveElementAt_SkipFirstShouldBe));
                                    }
                                }
                                return;
                        }
                    }
                    if (subject.TryGetFirstDescendent<IArrayElementReferenceOperation>(out var arrayElementReference))
                    {
                        context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveElementAt_IndexerShouldBe));
                    }
                    else if (subject.TryGetFirstDescendent<IPropertyReferenceOperation>(out var propertyReference) && propertyReference.Property.IsIndexer)
                    {
                        if (propertyReference.Instance.Type.ImplementsOrIsInterface(metadata.IDictionaryOfT2) || propertyReference.Instance.Type.ImplementsOrIsInterface(metadata.IReadonlyDictionaryOfT2)) return;

                        context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveElementAt_IndexerShouldBe));
                    }
                }
                return;
            case "NotBe" when assertion.IsContainedInType(metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: add support for Enumerable.LongCount
                            case nameof(Enumerable.Count) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                if (assertion.Arguments[0].HasFirstDescendentInvocation(nameof(Enumerable.Count)))
                                {
                                    context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotHaveSameCount_CountShouldNotBeOtherCollectionCount));
                                }
                                else if (assertion.Arguments[0].IsReference() || assertion.Arguments[0].IsLiteralValue<int>())
                                {
                                    context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotHaveCount_CountShouldNotBe));
                                }
                                return;
                        }
                    }
                }
                return;
            case "BeGreaterOrEqualTo" when assertion.IsContainedInType(metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: add support for Enumerable.LongCount
                            case nameof(Enumerable.Count) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCountGreaterOrEqualTo_CountShouldBeGreaterOrEqualTo));
                                return;
                        }
                    }

                    if (assertion.TryGetChainedInvocationAfterAndConstraint("BeLessOrEqualTo", out var chainedInvocation))
                    {
                        if (!assertion.HasEmptyBecauseAndReasonArgs(startingIndex: 1) && !chainedInvocation.HasEmptyBecauseAndReasonArgs(startingIndex: 1)) return;

                        context.ReportDiagnostic(CreateDiagnostic(chainedInvocation, DiagnosticMetadata.NumericShouldBeInRange_BeGreaterOrEqualToAndBeLessOrEqualTo));
                        return;
                    }
                }
                return;
            case "BeGreaterThan" when assertion.IsContainedInType(metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: add support for Enumerable.LongCount
                            case nameof(Enumerable.Count) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCountGreaterThan_CountShouldBeGreaterThan));
                                return;
                        }
                    }
                    if (assertion.Arguments[0].IsLiteralValue(0))
                    {
                        context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.NumericShouldBePositive_ShouldBeGreaterThan));
                        return;
                    }
                }
                return;
            case "BeLessOrEqualTo" when assertion.IsContainedInType(metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: add support for Enumerable.LongCount
                            case nameof(Enumerable.Count) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCountLessOrEqualTo_CountShouldBeLessOrEqualTo));
                                return;
                            case nameof(Math.Abs) when invocationBeforeShould.IsContainedInType(metadata.Math) && (
                                    assertion.Arguments[0].IsReferenceOfType(SpecialType.System_Double) 
                                    || assertion.Arguments[0].IsReferenceOfType(SpecialType.System_Single)
                                    || assertion.Arguments[0].IsReferenceOfType(SpecialType.System_Decimal)
                                ):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.NumericShouldBeApproximately_MathAbsShouldBeLessOrEqualTo));
                                return;
                        }
                    }

                    if (assertion.TryGetChainedInvocationAfterAndConstraint("BeGreaterOrEqualTo", out var chainedInvocation))
                    {
                        if (!assertion.HasEmptyBecauseAndReasonArgs(startingIndex: 1) && !chainedInvocation.HasEmptyBecauseAndReasonArgs(startingIndex: 1)) return;

                        context.ReportDiagnostic(CreateDiagnostic(chainedInvocation, DiagnosticMetadata.NumericShouldBeInRange_BeLessOrEqualToAndBeGreaterOrEqualTo));
                        return;
                    }
                }
                return;
            case "BeLessThan" when assertion.IsContainedInType(metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: add support for Enumerable.LongCount
                            case nameof(Enumerable.Count) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCountLessThan_CountShouldBeLessThan));
                                return;
                        }
                    }

                    if (assertion.Arguments[0].IsLiteralValue(0))
                    {
                        context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.NumericShouldBeNegative_ShouldBeLessThan));
                        return;
                    }
                }
                return;
            case "ContainKey" when assertion.IsContainedInType(metadata.GenericDictionaryAssertionsOfT4):
                {
                    if (assertion.TryGetChainedInvocationAfterAndConstraint("ContainValue", out var chainedInvocation))
                    {
                        if (!assertion.HasEmptyBecauseAndReasonArgs(startingIndex: 1) && !chainedInvocation.HasEmptyBecauseAndReasonArgs(startingIndex: 1)) return;

                        if (assertion.Arguments[0].Value is IPropertyReferenceOperation { Property.Name: nameof(KeyValuePair<string, object>.Key) } firstPropertyReference
                        && chainedInvocation.Arguments[0].Value is IPropertyReferenceOperation { Property.Name: nameof(KeyValuePair<string, object>.Value) } secondPropertyReference)
                        {
                            if (firstPropertyReference.IsSamePropertyReference(secondPropertyReference))
                            {
                                context.ReportDiagnostic(CreateDiagnostic(chainedInvocation, DiagnosticMetadata.DictionaryShouldContainPair_ShouldContainKeyAndContainValue));
                                return;
                            }
                            // TODO: report here
                        }
                        else
                        {
                            context.ReportDiagnostic(CreateDiagnostic(chainedInvocation, DiagnosticMetadata.DictionaryShouldContainKeyAndValue_ShouldContainKeyAndContainValue));
                            return;
                        }
                        return;
                    }
                }
                return;
            case "ContainValue" when assertion.IsContainedInType(metadata.GenericDictionaryAssertionsOfT4):
                {
                    if (assertion.TryGetChainedInvocationAfterAndConstraint("ContainKey", out var chainedInvocation))
                    {
                        if (!assertion.HasEmptyBecauseAndReasonArgs(startingIndex: 1) && !chainedInvocation.HasEmptyBecauseAndReasonArgs(startingIndex: 1)) return;

                        if (assertion.Arguments[0].Value is IPropertyReferenceOperation { Property.Name: nameof(KeyValuePair<string, object>.Value) } firstPropertyReference
                        && chainedInvocation.Arguments[0].Value is IPropertyReferenceOperation { Property.Name: nameof(KeyValuePair<string, object>.Key) } secondPropertyReference)
                        {
                            if (firstPropertyReference.IsSamePropertyReference(secondPropertyReference))
                            {
                                context.ReportDiagnostic(CreateDiagnostic(chainedInvocation, DiagnosticMetadata.DictionaryShouldContainPair_ShouldContainValueAndContainKey));
                                return;
                            }
                            // TODO: report here
                        }
                        else
                        {
                            context.ReportDiagnostic(CreateDiagnostic(chainedInvocation, DiagnosticMetadata.DictionaryShouldContainKeyAndValue_ShouldContainValueAndContainKey));
                            return;
                        }
                        return;
                    }
                }
                return;
            case "Throw" when assertion.IsContainedInType(metadata.DelegateAssertionsOfT2):
                {
                    if (!TryGetExceptionPropertyAssertion(assertion, out var fluentAssertionProperty, out var exceptionProperty, out var nextAssertion)) return;
                    switch ((fluentAssertionProperty, exceptionProperty, nextAssertion.TargetMethod.Name))
                    {
                        case ("And", nameof(Exception.Message), "Contain"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldContain));
                            return;
                        case ("And", nameof(Exception.Message), "Be"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldBe));
                            return;
                        case ("And", nameof(Exception.Message), "StartWith"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldStartWith));
                            return;
                        case ("And", nameof(Exception.Message), "EndWith"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldEndWith));
                            return;
                        case ("Which", nameof(Exception.Message), "Contain"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldContain));
                            return;
                        case ("Which", nameof(Exception.Message), "Be"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldBe));
                            return;
                        case ("Which", nameof(Exception.Message), "StartWith"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldStartWith));
                            return;
                        case ("Which", nameof(Exception.Message), "EndWith"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldEndWith));
                            return;
                        case ("And", nameof(Exception.InnerException), "BeOfType"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowWithInnerException_ShouldThrowAndInnerExceptionShouldBeOfType));
                            return;
                        case ("And", nameof(Exception.InnerException), "BeAssignableTo"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowWithInnerException_ShouldThrowAndInnerExceptionShouldBeAssignableTo));
                            return;
                        case ("Which", nameof(Exception.InnerException), "BeOfType"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowWithInnerException_ShouldThrowWhichInnerExceptionShouldBeOfType));
                            return;
                        case ("Which", nameof(Exception.InnerException), "BeAssignableTo"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowWithInnerException_ShouldThrowWhichInnerExceptionShouldBeAssignableTo));
                            return;
                    }
                }
                return;
            case "ThrowExactly" when assertion.IsContainedInType(metadata.DelegateAssertionsOfT2):
                {
                    if (!TryGetExceptionPropertyAssertion(assertion, out var fluentAssertionProperty, out var exceptionProperty, out var nextAssertion)) return;
                    switch ((fluentAssertionProperty, exceptionProperty, nextAssertion.TargetMethod.Name))
                    {
                        case ("And", nameof(Exception.Message), "Contain"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldContain));
                            return;
                        case ("And", nameof(Exception.Message), "Be"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldBe));
                            return;
                        case ("And", nameof(Exception.Message), "StartWith"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldStartWith));
                            return;
                        case ("And", nameof(Exception.Message), "EndWith"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldEndWith));
                            return;
                        case ("Which", nameof(Exception.Message), "Contain"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldContain));
                            return;
                        case ("Which", nameof(Exception.Message), "Be"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldBe));
                            return;
                        case ("Which", nameof(Exception.Message), "StartWith"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldStartWith));
                            return;
                        case ("Which", nameof(Exception.Message), "EndWith"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldEndWith));
                            return;
                        case ("And", nameof(Exception.InnerException), "BeOfType"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyAndInnerExceptionShouldBeOfType));
                            return;
                        case ("And", nameof(Exception.InnerException), "BeAssignableTo"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyAndInnerExceptionShouldBeAssignableTo));
                            return;
                        case ("Which", nameof(Exception.InnerException), "BeOfType"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyWhichInnerExceptionShouldBeOfType));
                            return;
                        case ("Which", nameof(Exception.InnerException), "BeAssignableTo"):
                            context.ReportDiagnostic(CreateDiagnostic(nextAssertion, DiagnosticMetadata.ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyWhichInnerExceptionShouldBeAssignableTo));
                            return;
                    }
                }
                return;
        }
    }

    static Diagnostic CreateDiagnostic(IOperation operation, DiagnosticMetadata metadata)
    {
        var properties = ImmutableDictionary<string, string>.Empty
            .Add(Constants.DiagnosticProperties.VisitorName, metadata.Name)
            .Add(Constants.DiagnosticProperties.HelpLink, metadata.HelpLink);
        var newRule = new DiagnosticDescriptor(Rule.Id, Rule.Title, metadata.Message, Rule.Category, Rule.DefaultSeverity, true,
            helpLinkUri: metadata.HelpLink);
        return Diagnostic.Create(
            descriptor: newRule,
            location: operation.Syntax.GetLocation(),
            properties: properties);
    }
}