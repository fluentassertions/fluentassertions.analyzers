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
            case "NotBeEmpty" when IsMethodContainedInType(assertion, metadata.GenericCollectionAssertionsOfT3):
                {
                    if (TryGetChainedInvocationAfterAndConstraint(assertion, "NotBeNull", out var chainedInvocation))
                    {
                        if (!HasEmptyBecauseAndReasonArgs(assertion) && !HasEmptyBecauseAndReasonArgs(chainedInvocation)) return;
                        context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotBeNullOrEmpty.ShouldNotBeEmptyAndNotBeNullSyntaxVisitor>(assertion));
                    }
                    else if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Where) when invocationBeforeShould.Arguments.Length == 2 && IsLambda(invocationBeforeShould.Arguments[1]):
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldContainProperty.WhereShouldNotBeEmptySyntaxVisitor>(assertion));
                                break;
                        }
                    }
                    break;
                }
            case "NotBeNull" when IsMethodContainedInType(assertion, metadata.ReferenceTypeAssertionsOfT2):
                {
                    if (!TryGetChainedInvocationAfterAndConstraint(assertion, "NotBeEmpty", out var chainedInvocation)) return;
                    if (!HasEmptyBecauseAndReasonArgs(assertion) && !HasEmptyBecauseAndReasonArgs(chainedInvocation)) return;

                    context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotBeNullOrEmpty.ShouldNotBeNullAndNotBeEmptySyntaxVisitor>(assertion));
                }
                break;
            case "Equal" when IsMethodContainedInType(assertion, metadata.GenericCollectionAssertionsOfT3):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.OrderBy):
                            if (invocationBeforeShould.Arguments.Length == 2
                            && IsLambda(invocationBeforeShould.Arguments[1])
                            && IsSameArgumentReference(invocationBeforeShould.Arguments[0], assertion.Arguments[0]))
                            {
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldBeInAscendingOrder.OrderByShouldEqualSyntaxVisitor>(assertion));
                            }
                            break;
                        case nameof(Enumerable.OrderByDescending):
                            if (invocationBeforeShould.Arguments.Length == 2
                            && IsLambda(invocationBeforeShould.Arguments[1])
                            && IsSameArgumentReference(invocationBeforeShould.Arguments[0], assertion.Arguments[0]))
                            {
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldBeInDescendingOrder.OrderByDescendingShouldEqualSyntaxVisitor>(assertion));
                            }
                            break;
                        case nameof(Enumerable.Select): // TODO:
                            if (invocationBeforeShould.Arguments.Length == 2
                            && IsLambda(invocationBeforeShould.Arguments[1]))
                            {
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldEqualOtherCollectionByComparer.SelectShouldEqualOtherCollectionSelectSyntaxVisitor>(assertion));
                            }
                            break;
                    }
                }
                break;
            case "BeTrue" when IsMethodContainedInType(assertion, metadata.BooleanAssertionsOfT1):
                {
                    if (!invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould)) return;
                    switch (invocationBeforeShould.TargetMethod.Name)
                    {
                        case nameof(Enumerable.Any) when invocationBeforeShould.Arguments.Length == 1:
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotBeEmpty.AnyShouldBeTrueSyntaxVisitor>(assertion));
                            break;
                        case nameof(Enumerable.Any) when invocationBeforeShould.Arguments.Length == 2 && IsLambda(invocationBeforeShould.Arguments[1]):
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldContainProperty.AnyWithLambdaShouldBeTrueSyntaxVisitor>(assertion));
                            break;
                        case nameof(Enumerable.All) when invocationBeforeShould.Arguments.Length == 2 && IsLambda(invocationBeforeShould.Arguments[1]):
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldOnlyContainProperty.AllShouldBeTrueSyntaxVisitor>(assertion));
                            break;
                        case nameof(Enumerable.Contains):
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldContainItem.ContainsShouldBeTrueSyntaxVisitor>(assertion));
                            break;
                    }
                }
                break;
            case "BeFalse" when IsMethodContainedInType(assertion, metadata.BooleanAssertionsOfT1):
                break;
            case "HaveCount" when IsMethodContainedInType(assertion, metadata.GenericCollectionAssertionsOfT3) && IsArgumentLiteral(assertion.Arguments[0], 1):
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
            case "Be" when IsMethodContainedInType(assertion, metadata.NumericAssertionsOfT2):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var invocationBeforeShould))
                    {
                        switch (invocationBeforeShould.TargetMethod.Name)
                        {
                            case nameof(Enumerable.Count) when IsMethodContainedInType(invocationBeforeShould, metadata.Enumerable):
                                // TODO: add support for Enumerable.LongCount
                                // case nameof(Enumerable.LongCount) when IsMethodContainedInType(invocationBeforeShould, metadata.Enumerable):
                                if (IsArgumentLiteral(assertion.Arguments[0], 1))
                                {
                                    context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveCount.CountShouldBe1SyntaxVisitor>(assertion));
                                }
                                else if (IsArgumentLiteral(assertion.Arguments[0], 0))
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
                            case nameof(Array.Length) when IsPropertyContainedInType(propertyBeforeShould, SpecialType.System_Array):
                                context.ReportDiagnostic(CreateDiagnostic<CollectionShouldHaveCount.LengthShouldBeSyntaxVisitor>(assertion));
                                break;
                        }
                    }
                    break;
                }
        }
    }

    private static bool HasEmptyBecauseAndReasonArgs(IInvocationOperation invocation, int startingIndex = 0)
    {
        if (invocation.Arguments.Length != startingIndex + 2)
        {
            return false;
        }

        return invocation.Arguments[startingIndex].Value is ILiteralOperation literal && literal.ConstantValue.HasValue && literal.ConstantValue.Value is ""
        && invocation.Arguments[startingIndex + 1].Value is IArrayCreationOperation arrayCreation && arrayCreation.Initializer.ElementValues.IsEmpty;
    }

    private static bool TryGetChainedInvocationAfterAndConstraint(IInvocationOperation invocation, string chainedMethod, out IInvocationOperation chainedInvocation)
    {
        if (invocation.Parent is IPropertyReferenceOperation { Property.Name: "And" } andConstraint)
        {
            chainedInvocation = andConstraint.Parent as IInvocationOperation;
            return chainedInvocation.TargetMethod.Name == chainedMethod;
        }

        chainedInvocation = null;
        return false;
    }

    private static bool IsPropertyContainedInType(IPropertyReferenceOperation property, SpecialType type)
        => property.Property.ContainingType.SpecialType == type;
    private static bool IsPropertyContainedInType(IPropertyReferenceOperation property, INamedTypeSymbol type)
        => property.Property.ContainingType.ConstructedFrom.Equals(type, SymbolEqualityComparer.Default);
    private static bool IsMethodContainedInType(IInvocationOperation invocation, SpecialType type)
        => invocation.TargetMethod.ContainingType.SpecialType == type;
    private static bool IsMethodContainedInType(IInvocationOperation invocation, INamedTypeSymbol type)
        => invocation.TargetMethod.ContainingType.ConstructedFrom.Equals(type, SymbolEqualityComparer.Default);

    private static bool IsSameArgumentReference(IArgumentOperation argument1, IArgumentOperation argument2)
    {
        return argument1.TryGetFirstDescendent<IParameterReferenceOperation>(out var argument1Reference)
        && argument2.TryGetFirstDescendent<IParameterReferenceOperation>(out var argument2Reference)
        && argument1Reference.Parameter.Equals(argument2Reference.Parameter, SymbolEqualityComparer.Default);
    }

    private static bool IsArgumentLiteral<T>(IArgumentOperation argument, T value)
        => argument.Value is ILiteralOperation literal && literal.ConstantValue.HasValue && literal.ConstantValue.Value.Equals(value);

    private static bool IsLambda(IArgumentOperation argument)
        => argument.Value is IDelegateCreationOperation delegateCreation && delegateCreation.Target.Kind == OperationKind.AnonymousFunction;

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

internal static class OperartionExtensions
{
    public static bool TryGetFirstDescendent<TOperation>(this IOperation parent, out TOperation operation) where TOperation : IOperation
    {
        IOperation current = parent;
        while (current.ChildOperations.Count == 1)
        {
            current = current.ChildOperations.First();
            if (current is TOperation op)
            {
                operation = op;
                return true;
            }
        }

        operation = default;
        return false;
    }
}