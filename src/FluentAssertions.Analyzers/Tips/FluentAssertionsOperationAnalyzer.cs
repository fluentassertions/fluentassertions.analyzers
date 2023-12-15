using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace FluentAssertions.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public partial class FluentAssertionsOperationAnalyzer : DiagnosticAnalyzer
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

        var subject = invocation.Arguments[0].Value;

        switch (assertion.TargetMethod.Name)
        {
            case "NotBeEmpty" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (assertion.TryGetChainedInvocationAfterAndConstraint("NotBeNull", out var chainedInvocation))
                    {
                        if (!assertion.HasEmptyBecauseAndReasonArgs() && !chainedInvocation.HasEmptyBecauseAndReasonArgs()) return;

                        if (chainedInvocation.IsContainedInType(metadata.ReferenceTypeAssertionsOfT2))
                        {
                            context.ReportDiagnostic(CreateDiagnostic(chainedInvocation, DiagnosticMetadata.CollectionShouldNotBeNullOrEmpty_ShouldNotBeEmptyAndNotBeNull));
                        }
                    }
                    else if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Where) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldContainProperty_WhereShouldNotBeEmpty));
                                break;
                            case nameof(Enumerable.Intersect) when invocationBeforeShould.Arguments.Length is 2:
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldIntersectWith_IntersectShouldNotBeEmpty));
                                break;
                        }
                    }
                    break;
                }
            case "BeEmpty" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Intersect) when invocationBeforeShould.Arguments.Length is 2:
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotIntersectWith_IntersectShouldBeEmpty));
                                break;
                            case nameof(Enumerable.Where) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotContainProperty_WhereShouldBeEmpty));
                                break;
                        }
                    }
                    break;
                }
            case "NotBeNull" when assertion.IsContainedInType(metadata.ReferenceTypeAssertionsOfT2):
                {
                    if (!assertion.TryGetChainedInvocationAfterAndConstraint("NotBeEmpty", out var chainedInvocation)) return;
                    if (!assertion.HasEmptyBecauseAndReasonArgs() && !chainedInvocation.HasEmptyBecauseAndReasonArgs()) return;

                    if (chainedInvocation.IsContainedInType(metadata.GenericCollectionAssertionsOfT3))
                    {
                        context.ReportDiagnostic(CreateDiagnostic(chainedInvocation, DiagnosticMetadata.CollectionShouldNotBeNullOrEmpty_ShouldNotBeNullAndNotBeEmpty));
                    }
                }
                break;
            case "NotContainNulls" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.Select) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotContainNulls_SelectShouldNotContainNulls));
                            break;
                    }
                }
                break;
            case "Equal" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.OrderBy) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata) && invocationBeforeShould.Arguments[0].IsSameArgumentReference(assertion.Arguments[0]):
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldBeInAscendingOrder_OrderByShouldEqual));
                            break;
                        case nameof(Enumerable.OrderByDescending) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata) && invocationBeforeShould.Arguments[0].IsSameArgumentReference(assertion.Arguments[0]):
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldBeInDescendingOrder_OrderByDescendingShouldEqual));
                            break;
                        case nameof(Enumerable.Select) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldEqualOtherCollectionByComparer_SelectShouldEqualOtherCollectionSelect));
                            break;
                    }
                }
                break;
            case "BeTrue" when assertion.IsContainedInType(metadata.BooleanAssertionsOfT1):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.Any) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotBeEmpty_AnyShouldBeTrue));
                            break;
                        case nameof(Enumerable.Any) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldContainProperty_AnyWithLambdaShouldBeTrue));
                            break;
                        case nameof(Enumerable.All) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldOnlyContainProperty_AllShouldBeTrue));
                            break;
                        case nameof(Enumerable.Contains) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 2:
                        case nameof(ICollection<object>.Contains) when invocationBeforeShould.ImplementsOrIsInterface(SpecialType.System_Collections_Generic_ICollection_T) && invocationBeforeShould.Arguments.Length is 1:
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldContainItem_ContainsShouldBeTrue));
                            break;
                    }
                }
                break;
            case "BeFalse" when assertion.IsContainedInType(metadata.BooleanAssertionsOfT1):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Any) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldBeEmpty_AnyShouldBeFalse));
                                break;
                            case nameof(Enumerable.Any) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotContainProperty_AnyLambdaShouldBeFalse));
                                break;
                            case nameof(Enumerable.Contains) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 2:
                            case nameof(ICollection<object>.Contains) when invocationBeforeShould.ImplementsOrIsInterface(SpecialType.System_Collections_Generic_ICollection_T) && invocationBeforeShould.Arguments.Length == 1:
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldNotContainItem_ContainsShouldBeFalse));
                                break;
                        }
                    }
                }
                break;
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
                break;
            case "HaveCount" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3) && assertion.Arguments[0].IsLiteralValue(0):
                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldBeEmpty_ShouldHaveCount0));
                break;
            case "HaveCount" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3) && assertion.Arguments[0].HasFirstDescendentInvocation(nameof(Enumerable.Count)):
                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveSameCount_ShouldHaveCountOtherCollectionCount));
                break;
            case "HaveSameCount" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3) && assertion.Arguments[0].HasFirstDescendentInvocation(nameof(Enumerable.Distinct)):
                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldOnlyHaveUniqueItems_ShouldHaveSameCountThisCollectionDistinct));
                break;
            case "OnlyHaveUniqueItems" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.Select) when IsEnumerableMethodWithPredicate(invocationBeforeShould, metadata):
                            context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldOnlyHaveUniqueItemsByComparer_SelectShouldOnlyHaveUniqueItems));
                            break;
                    }
                }
                break;
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
                                    context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCount_CountShouldBe1));
                                }
                                else if (assertion.Arguments[0].IsLiteralValue(0))
                                {
                                    context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCount_CountShouldBe0));
                                }
                                else
                                {
                                    context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCount_CountShouldBe));
                                }
                                break;

                        }
                    }
                    if (invocation.TryGetFirstDescendent<IPropertyReferenceOperation>(out var propertyBeforeShould))
                    {
                        switch (propertyBeforeShould.Property.Name)
                        {
                            case nameof(Array.Length) when propertyBeforeShould.IsContainedInType(SpecialType.System_Array):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCount_LengthShouldBe));
                                break;
                        }
                    }
                    if (subject is IPropertyReferenceOperation propertyReference && propertyReference.Property.Name == WellKnownMemberNames.Indexer
                    && !(subject.Type.AllInterfaces.Contains(metadata.IDictionaryOfT2) || subject.Type.AllInterfaces.Contains(metadata.IReadonlyDictionaryOfT2)))
                    {
                        context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveElementAt_IndexerShouldBe));
                    }
                    break;
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
                                break;
                            case nameof(Enumerable.First) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                {
                                    if (invocationBeforeShould.TryGetFirstDescendent<IInvocationOperation>(out var skipInvocation) && skipInvocation.TargetMethod.Name is nameof(Enumerable.Skip))
                                    {
                                        context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveElementAt_SkipFirstShouldBe));
                                    }
                                }
                                break;
                        }
                    }
                    if (subject.TryGetFirstDescendent<IArrayElementReferenceOperation>(out var arrayElementReference))
                    {
                        context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveElementAt_IndexerShouldBe));
                    }
                    else if (subject.TryGetFirstDescendent<IPropertyReferenceOperation>(out var propertyReference) && propertyReference.Property.IsIndexer)
                    {
                        if (propertyReference.Instance.Type.ImplementsOrIsInterface(metadata.IDictionaryOfT2) || propertyReference.Instance.Type.ImplementsOrIsInterface(metadata.IReadonlyDictionaryOfT2)) break;

                        context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveElementAt_IndexerShouldBe));
                    }
                }
                break;
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
                                break;
                        }
                    }
                }
                break;
            case "BeGreaterOrEqualTo" when assertion.IsContainedInType(metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: add support for Enumerable.LongCount
                            case nameof(Enumerable.Count) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCountGreaterOrEqualTo_CountShouldBeGreaterOrEqualTo));
                                break;
                        }
                    }
                }
                break;
            case "BeGreaterThan" when assertion.IsContainedInType(metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: add support for Enumerable.LongCount
                            case nameof(Enumerable.Count) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCountGreaterThan_CountShouldBeGreaterThan));
                                break;
                        }
                    }
                }
                break;
            case "BeLessOrEqualTo" when assertion.IsContainedInType(metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: add support for Enumerable.LongCount
                            case nameof(Enumerable.Count) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCountLessOrEqualTo_CountShouldBeLessOrEqualTo));
                                break;
                        }
                    }
                }
                break;
            case "BeLessThan" when assertion.IsContainedInType(metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: add support for Enumerable.LongCount
                            case nameof(Enumerable.Count) when IsEnumerableMethodWithoutArguments(invocationBeforeShould, metadata):
                                context.ReportDiagnostic(CreateDiagnostic(assertion, DiagnosticMetadata.CollectionShouldHaveCountLessThan_CountShouldBeLessThan));
                                break;
                        }
                    }
                }
                break;
        }
    }

    static Diagnostic CreateDiagnostic(IOperation operation, DiagnosticMetadata metadata)
    {
        var properties = ImmutableDictionary<string, string>.Empty
            .Add(Constants.DiagnosticProperties.Title, Title)
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