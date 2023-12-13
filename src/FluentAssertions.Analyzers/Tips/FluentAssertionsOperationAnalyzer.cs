using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
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
        if (invocation.TargetMethod.Name != "Should")
        {
            return;
        }

        if (!(invocation.Parent is IInvocationOperation assertion))
        {
            return;
        }

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
            case "NotBeEmpty" when assertion.IsMethodContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (assertion.TryGetChainedInvocationAfterAndConstraint("NotBeNull", out var chainedInvocation))
                    {
                        if (!assertion.HasEmptyBecauseAndReasonArgs() && !chainedInvocation.HasEmptyBecauseAndReasonArgs()) return;
                        context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotBeNullOrEmpty.ShouldNotBeEmptyAndNotBeNullSyntaxVisitor>(assertion));
                    }
                    else if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Where) when invocationBeforeShould.Arguments.Length == 2 && invocationBeforeShould.Arguments[1].IsLambda():
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldContainProperty.WhereShouldNotBeEmptySyntaxVisitor>(assertion));
                                break;
                        }
                    }
                    break;
                }
            case "NotBeNull" when assertion.IsMethodContainedInType(metadata.ReferenceTypeAssertionsOfT2):
                {
                    if (!assertion.TryGetChainedInvocationAfterAndConstraint("NotBeEmpty", out var chainedInvocation)) return;
                    if (!assertion.HasEmptyBecauseAndReasonArgs() && !chainedInvocation.HasEmptyBecauseAndReasonArgs()) return;

                    context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotBeNullOrEmpty.ShouldNotBeNullAndNotBeEmptySyntaxVisitor>(assertion));
                }
                break;
            case "Equal" when assertion.IsMethodContainedInType(metadata.GenericCollectionAssertionsOfT3):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.OrderBy):
                            if (invocationBeforeShould.Arguments.Length == 2
                            && invocationBeforeShould.Arguments[1].IsLambda()
                            && invocationBeforeShould.Arguments[0].IsSameArgumentReference(assertion.Arguments[0]))
                            {
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldBeInAscendingOrder.OrderByShouldEqualSyntaxVisitor>(assertion));
                            }
                            break;
                        case nameof(Enumerable.OrderByDescending):
                            if (invocationBeforeShould.Arguments.Length == 2
                            && invocationBeforeShould.Arguments[1].IsLambda()
                            && invocationBeforeShould.Arguments[0].IsSameArgumentReference(assertion.Arguments[0]))
                            {
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldBeInDescendingOrder.OrderByDescendingShouldEqualSyntaxVisitor>(assertion));
                            }
                            break;
                        case nameof(Enumerable.Select): // TODO:
                            if (invocationBeforeShould.Arguments.Length == 2
                            && invocationBeforeShould.Arguments[1].IsLambda())
                            {
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldEqualOtherCollectionByComparer.SelectShouldEqualOtherCollectionSelectSyntaxVisitor>(assertion));
                            }
                            break;
                    }
                }
                break;
            case "BeTrue" when assertion.IsMethodContainedInType(metadata.BooleanAssertionsOfT1):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.Any) when invocationBeforeShould.Arguments.Length == 1:
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotBeEmpty.AnyShouldBeTrueSyntaxVisitor>(assertion));
                            break;
                        case nameof(Enumerable.Any) when invocationBeforeShould.Arguments.Length == 2 && invocationBeforeShould.Arguments[1].IsLambda():
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldContainProperty.AnyWithLambdaShouldBeTrueSyntaxVisitor>(assertion));
                            break;
                        case nameof(Enumerable.All) when invocationBeforeShould.Arguments.Length == 2 && invocationBeforeShould.Arguments[1].IsLambda():
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldOnlyContainProperty.AllShouldBeTrueSyntaxVisitor>(assertion));
                            break;
                        case nameof(Enumerable.Contains):
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldContainItem.ContainsShouldBeTrueSyntaxVisitor>(assertion));
                            break;
                    }
                }
                break;
            case "BeFalse" when assertion.IsMethodContainedInType(metadata.BooleanAssertionsOfT1):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Any) when invocationBeforeShould.Arguments.Length == 1:
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldBeEmpty.AnyShouldBeFalseSyntaxVisitor>(assertion));
                                break;
                        }
                    }
                }
                break;
            case "HaveCount" when assertion.IsMethodContainedInType(metadata.GenericCollectionAssertionsOfT3) && assertion.Arguments[0].IsArgumentLiteral(1):
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
            case "HaveCount" when assertion.IsMethodContainedInType(metadata.GenericCollectionAssertionsOfT3) && assertion.Arguments[0].IsArgumentLiteral(0):
                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldBeEmpty.HaveCountNodeReplacement>(assertion));
                break;
            case "Be" when assertion.IsMethodContainedInType(metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: validate that count is not used with a lambda
                            case nameof(Enumerable.Count) when invocationBeforeShould.IsMethodContainedInType(metadata.Enumerable):
                                // TODO: add support for Enumerable.LongCount
                                // case nameof(Enumerable.LongCount) when IsMethodContainedInType(invocationBeforeShould, metadata.Enumerable):
                                if (assertion.Arguments[0].IsArgumentLiteral(1))
                                {
                                    context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveCount.CountShouldBe1SyntaxVisitor>(assertion));
                                }
                                else if (assertion.Arguments[0].IsArgumentLiteral(0))
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
                            case nameof(Array.Length) when propertyBeforeShould.IsPropertyContainedInType(SpecialType.System_Array):
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveCount.LengthShouldBeSyntaxVisitor>(assertion));
                                break;
                        }
                    }
                    break;
                }
            case "BeGreaterOrEqualTo" when assertion.IsMethodContainedInType(metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            // TODO: validate that count is not used with a lambda
                            case nameof(Enumerable.Count) when invocationBeforeShould.IsMethodContainedInType(metadata.Enumerable):

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
            GenericCollectionAssertionsOfT1 = compilation.GetTypeByMetadataName("FluentAssertions.Collections.GenericCollectionAssertions`1");
            BooleanAssertionsOfT1 = compilation.GetTypeByMetadataName("FluentAssertions.Primitives.BooleanAssertions`1");
            GenericCollectionAssertionsOfT3 = compilation.GetTypeByMetadataName("FluentAssertions.Collections.GenericCollectionAssertions`3");
            ReferenceTypeAssertionsOfT2 = compilation.GetTypeByMetadataName("FluentAssertions.Primitives.ReferenceTypeAssertions`2");
            NumericAssertionsOfT2 = compilation.GetTypeByMetadataName("FluentAssertions.Numeric.NumericAssertions`2");
            Enumerable = compilation.GetTypeByMetadataName("System.Linq.Enumerable");

        }
        public INamedTypeSymbol AssertionExtensions { get; }
        public INamedTypeSymbol GenericCollectionAssertionsOfT1 { get; }
        public INamedTypeSymbol GenericCollectionAssertionsOfT3 { get; }
        public INamedTypeSymbol BooleanAssertionsOfT1 { get; }
        public INamedTypeSymbol ReferenceTypeAssertionsOfT2 { get; }
        public INamedTypeSymbol NumericAssertionsOfT2 { get; }
        public INamedTypeSymbol Enumerable { get; }
    }
}