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
public class FluentAssertionsOperationAnalyzer : DiagnosticAnalyzer
{
    public const string Title = "Simplify Assertion";
    public const string DiagnosticId = "FAA0001";
    public const string Message = "Clean up FluentAssertion usage.";

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

        static Diagnostic CreateDiagnostic<TVistor>(IOperation operation)
        {
            var properties = ImmutableDictionary<string, string>.Empty
                .Add(Constants.DiagnosticProperties.Title, Title)
                .Add(Constants.DiagnosticProperties.VisitorName, typeof(TVistor).Name)
                .Add(Constants.DiagnosticProperties.HelpLink, HelpLinks.Get(typeof(TVistor)));
            var newRule = new DiagnosticDescriptor(Rule.Id, Rule.Title, Rule.MessageFormat, Rule.Category, Rule.DefaultSeverity, true,
                helpLinkUri: properties.GetValueOrDefault(Constants.DiagnosticProperties.HelpLink));
            return Diagnostic.Create(
                descriptor: newRule,
                location: operation.Syntax.GetLocation(),
                properties: properties);
        }

        switch (assertion.TargetMethod.Name)
        {
            case "NotBeEmpty" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (assertion.TryGetChainedInvocationAfterAndConstraint("NotBeNull", out var chainedInvocation))
                    {
                        if (!assertion.HasEmptyBecauseAndReasonArgs() && !chainedInvocation.HasEmptyBecauseAndReasonArgs()) return;

                        if (chainedInvocation.IsContainedInType(metadata.ReferenceTypeAssertionsOfT2))
                        {
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotBeNullOrEmpty.ShouldNotBeEmptyAndNotBeNullSyntaxVisitor>(chainedInvocation));
                        }
                    }
                    else if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Where) when invocationBeforeShould.Arguments.Length is 2 && invocationBeforeShould.Arguments[1].IsLambda():
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldContainProperty.WhereShouldNotBeEmptySyntaxVisitor>(assertion));
                                break;
                            case nameof(Enumerable.Intersect) when invocationBeforeShould.Arguments.Length is 2:
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldIntersectWith.IntersectShouldNotBeEmptySyntaxVisitor>(assertion));
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
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotIntersectWith.IntersectShouldBeEmptySyntaxVisitor>(assertion));
                                break;
                            case nameof(Enumerable.Where) when invocationBeforeShould.Arguments.Length is 2 && invocationBeforeShould.Arguments[1].IsLambda():
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotContainProperty.WhereShouldBeEmptySyntaxVisitor>(assertion));
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
                        context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotBeNullOrEmpty.ShouldNotBeNullAndNotBeEmptySyntaxVisitor>(chainedInvocation));
                    }
                }
                break;
            case "NotContainNulls" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.Select) when invocationBeforeShould.Arguments.Length is 2 && invocationBeforeShould.Arguments[1].IsLambda():
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotContainNulls.SelectShouldNotContainNullsSyntaxVisitor>(assertion));
                            break;
                    }
                }
                break;
            case "Equal" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.OrderBy):
                            if (invocationBeforeShould.Arguments.Length is 2
                            && invocationBeforeShould.Arguments[1].IsLambda()
                            && invocationBeforeShould.Arguments[0].IsSameArgumentReference(assertion.Arguments[0]))
                            {
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldBeInAscendingOrder.OrderByShouldEqualSyntaxVisitor>(assertion));
                            }
                            break;
                        case nameof(Enumerable.OrderByDescending):
                            if (invocationBeforeShould.Arguments.Length is 2
                            && invocationBeforeShould.Arguments[1].IsLambda()
                            && invocationBeforeShould.Arguments[0].IsSameArgumentReference(assertion.Arguments[0]))
                            {
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldBeInDescendingOrder.OrderByDescendingShouldEqualSyntaxVisitor>(assertion));
                            }
                            break;
                        case nameof(Enumerable.Select): // TODO:
                            if (invocationBeforeShould.Arguments.Length is 2
                            && invocationBeforeShould.Arguments[1].IsLambda())
                            {
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldEqualOtherCollectionByComparer.SelectShouldEqualOtherCollectionSelectSyntaxVisitor>(assertion));
                            }
                            break;
                    }
                }
                break;
            case "BeTrue" when assertion.IsContainedInType(metadata.BooleanAssertionsOfT1):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.Any) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 1:
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotBeEmpty.AnyShouldBeTrueSyntaxVisitor>(assertion));
                            break;
                        case nameof(Enumerable.Any) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 2 && invocationBeforeShould.Arguments[1].IsLambda():
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldContainProperty.AnyWithLambdaShouldBeTrueSyntaxVisitor>(assertion));
                            break;
                        case nameof(Enumerable.All) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 2 && invocationBeforeShould.Arguments[1].IsLambda():
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldOnlyContainProperty.AllShouldBeTrueSyntaxVisitor>(assertion));
                            break;
                        case nameof(Enumerable.Contains) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length == 2:
                        case nameof(ICollection<object>.Contains) when invocationBeforeShould.IsContainedInType(SpecialType.System_Collections_Generic_ICollection_T) && invocationBeforeShould.Arguments.Length == 1:
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldContainItem.ContainsShouldBeTrueSyntaxVisitor>(assertion));
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
                            case nameof(Enumerable.Any) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length == 1:
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldBeEmpty.AnyShouldBeFalseSyntaxVisitor>(assertion));
                                break;
                            case nameof(Enumerable.Any) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length == 2 && invocationBeforeShould.Arguments[1].IsLambda():
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotContainProperty.AnyLambdaShouldBeFalseSyntaxVisitor>(assertion));
                                break;
                            case nameof(Enumerable.Contains) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length == 2:
                            case nameof(ICollection<object>.Contains) when invocationBeforeShould.IsContainedInType(SpecialType.System_Collections_Generic_ICollection_T) && invocationBeforeShould.Arguments.Length == 1:
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotContainItem.ContainsShouldBeFalseSyntaxVisitor>(assertion));
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
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldContainSingle.WhereShouldHaveCount1SyntaxVisitor>(assertion));
                                return;
                        }
                    }

                    context.ReportDiagnostic(CreateDiagnostic<CollectionShouldContainSingle.ShouldHaveCount1SyntaxVisitor>(assertion));
                }
                break;
            case "HaveCount" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3) && assertion.Arguments[0].IsLiteralValue(0):
                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldBeEmpty.ShouldHaveCount0SyntaxVisitor>(assertion));
                break;
            case "HaveCount" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (assertion.Arguments[0].TryGetFirstDescendent<IInvocationOperation>(out var expectationInvocation) && expectationInvocation.TargetMethod.Name is nameof(Enumerable.Count))
                    {
                        context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveSameCount.ShouldHaveCountOtherCollectionCountSyntaxVisitor>(assertion));
                    }
                }
                break;
            case "HaveSameCount" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (assertion.Arguments[0].TryGetFirstDescendent<IInvocationOperation>(out var expectationInvocation) && expectationInvocation.TargetMethod.Name is nameof(Enumerable.Distinct))
                    {
                        context.ReportDiagnostic(CreateDiagnostic<CollectionShouldOnlyHaveUniqueItems.ShouldHaveSameCountThisCollectionDistinctSyntaxVisitor>(assertion));
                    }
                }
                break;
            case "OnlyHaveUniqueItems" when assertion.IsContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.Select) when invocationBeforeShould.Arguments.Length is 2 && invocationBeforeShould.Arguments[1].IsLambda():
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldOnlyHaveUniqueItemsByComparer.SelectShouldOnlyHaveUniqueItemsSyntaxVisitor>(assertion));
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
                            case nameof(Enumerable.Count) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 1:
                                if (assertion.Arguments[0].IsLiteralValue(1))
                                {
                                    context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveCount.CountShouldBe1SyntaxVisitor>(assertion));
                                }
                                else if (assertion.Arguments[0].IsLiteralValue(0))
                                {
                                    context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveCount.CountShouldBe0SyntaxVisitor>(assertion));
                                }
                                else
                                {
                                    context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveCount.CountShouldBeSyntaxVisitor>(assertion));
                                }
                                break;

                        }
                    }
                    if (invocation.TryGetFirstDescendent<IPropertyReferenceOperation>(out var propertyBeforeShould))
                    {
                        switch (propertyBeforeShould.Property.Name)
                        {
                            case nameof(Array.Length) when propertyBeforeShould.IsContainedInType(SpecialType.System_Array):
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveCount.LengthShouldBeSyntaxVisitor>(assertion));
                                break;
                        }
                    }
                    if (subject is IPropertyReferenceOperation propertyReference && propertyReference.Property.Name == WellKnownMemberNames.Indexer
                    && !(subject.Type.AllInterfaces.Contains(metadata.IDictionaryOfT2) || subject.Type.AllInterfaces.Contains(metadata.IReadonlyDictionaryOfT2)))
                    {
                        context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveElementAt.IndexerShouldBeSyntaxVisitor>(assertion));
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
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveElementAt.ElementAtIndexShouldBeSyntaxVisitor>(assertion));
                                break;
                            case nameof(Enumerable.First) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 1:
                                {
                                    if (invocationBeforeShould.TryGetFirstDescendent<IInvocationOperation>(out var skipInvocation) && skipInvocation.TargetMethod.Name is nameof(Enumerable.Skip))
                                    {
                                        context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveElementAt.SkipFirstShouldBeSyntaxVisitor>(assertion));
                                    }
                                }
                                break;
                        }
                    }

                    if (subject.TryGetFirstDescendent<IArrayElementReferenceOperation>(out var arrayElementReference))
                    {
                        context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveElementAt.IndexerShouldBeSyntaxVisitor>(assertion));
                    }

                    if (subject.TryGetFirstDescendent<IPropertyReferenceOperation>(out var propertyReference) && propertyReference.Property.IsIndexer)
                    {
                        if (propertyReference.Instance.Type.ImplementsOrIsInterface(metadata.IDictionaryOfT2) || propertyReference.Instance.Type.ImplementsOrIsInterface(metadata.IReadonlyDictionaryOfT2)) break;

                        context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveElementAt.IndexerShouldBeSyntaxVisitor>(assertion));
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
                            // TODO: is identifier or literal
                            case nameof(Enumerable.Count) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 1:
                                if (assertion.Arguments[0].TryGetFirstDescendent<IInvocationOperation>(out var expectationInvocation) && expectationInvocation.TargetMethod.Name is nameof(Enumerable.Count))
                                {
                                    context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotHaveSameCount.CountShouldNotBeOtherCollectionCountSyntaxVisitor>(assertion));
                                }
                                else if (assertion.Arguments[0].IsReference() || assertion.Arguments[0].IsLiteralValue<int>())
                                {
                                    context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotHaveCount.CountShouldNotBeSyntaxVisitor>(assertion));
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
                            case nameof(Enumerable.Count) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 1:
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveCountGreaterOrEqualTo.CountShouldBeGreaterOrEqualToSyntaxVisitor>(assertion));
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
                            case nameof(Enumerable.Count) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 1:
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveCountGreaterThan.CountShouldBeGreaterThanSyntaxVisitor>(assertion));
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
                            case nameof(Enumerable.Count) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 1:
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveCountLessOrEqualTo.CountShouldBeLessOrEqualToSyntaxVisitor>(assertion));
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
                            case nameof(Enumerable.Count) when invocationBeforeShould.IsContainedInType(metadata.Enumerable) && invocationBeforeShould.Arguments.Length is 1:
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveCountLessThan.CountShouldBeLessThanSyntaxVisitor>(assertion));
                                break;
                        }
                    }
                }
                break;
        }
    }
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
            IDictionaryOfT2 = compilation.GetTypeByMetadataName(typeof(IDictionary<,>).FullName);
            IReadonlyDictionaryOfT2 = compilation.GetTypeByMetadataName(typeof(IReadOnlyDictionary<,>).FullName);

            Enumerable = compilation.GetTypeByMetadataName(typeof(Enumerable).FullName);

        }
        public INamedTypeSymbol AssertionExtensions { get; }
        public INamedTypeSymbol ReferenceTypeAssertionsOfT2 { get; }
        public INamedTypeSymbol ObjectAssertionsOfT2 { get; }
        public INamedTypeSymbol GenericCollectionAssertionsOfT3 { get; }
        public INamedTypeSymbol IDictionaryOfT2 { get; }
        public INamedTypeSymbol IReadonlyDictionaryOfT2 { get; }
        public INamedTypeSymbol BooleanAssertionsOfT1 { get; }
        public INamedTypeSymbol NumericAssertionsOfT2 { get; }
        public INamedTypeSymbol Enumerable { get; }
    }
}