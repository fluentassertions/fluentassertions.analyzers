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
                        if (HasEmptyBecauseAndReasonArgs(assertion) || HasEmptyBecauseAndReasonArgs(chainedInvocation))
                        {
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotBeNullOrEmpty.ShouldNotBeEmptyAndNotBeNullSyntaxVisitor>(chainedInvocation));
                            return;
                        }
                    }
                }
                break;
            case "NotBeNull" when IsMethodContainedInType(assertion, metadata.ReferenceTypeAssertionsOfT2):
                {
                    if (TryGetChainedInvocationAfterAndConstraint(assertion, "NotBeEmpty", out var chainedInvocation))
                    {
                        if (HasEmptyBecauseAndReasonArgs(assertion) || HasEmptyBecauseAndReasonArgs(chainedInvocation))
                        {
                            context.ReportDiagnostic(CreateDiagnostic<CollectionShouldNotBeNullOrEmpty.ShouldNotBeNullAndNotBeEmptySyntaxVisitor>(chainedInvocation));
                            return;
                        }
                    }
                }
                break;
            case "Equal" when IsMethodContainedInType(assertion, metadata.GenericCollectionAssertionsOfT3):
                {
                    if (invocation.TryGetFirstDescendent<IInvocationOperation>(out var equal))
                    {
                        switch (equal.TargetMethod.Name)
                        {
                            case nameof(Enumerable.OrderBy):
                                if (equal.Arguments.Length == 2 && IsSameArgumentReference(equal.Arguments[0], assertion.Arguments[0]))
                                {
                                    context.ReportDiagnostic(CreateDiagnostic<CollectionShouldBeInAscendingOrder.OrderByShouldEqualSyntaxVisitor>(equal));
                                }
                                break;
                            case nameof(Enumerable.OrderByDescending):
                                if (equal.Arguments.Length == 2 && IsSameArgumentReference(equal.Arguments[0], assertion.Arguments[0]))
                                {
                                    context.ReportDiagnostic(CreateDiagnostic<CollectionShouldBeInDescendingOrder.OrderByDescendingShouldEqualSyntaxVisitor>(equal));
                                }
                                break;
                        }
                    }
                }
                break;
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

    private static bool IsMethodContainedInType(IInvocationOperation invocation, INamedTypeSymbol type)
        => invocation.TargetMethod.ContainingType.ConstructedFrom.Equals(type, SymbolEqualityComparer.Default);

    private static bool IsSameArgumentReference(IArgumentOperation argument1, IArgumentOperation argument2)
    {
        return argument1.TryGetFirstDescendent<IParameterReferenceOperation>(out var argument1Reference)
        && argument2.TryGetFirstDescendent<IParameterReferenceOperation>(out var argument2Reference)
        && argument1Reference.Parameter.Equals(argument2Reference.Parameter, SymbolEqualityComparer.Default);
    }

    private class FluentAssertionsMetadata
    {
        public FluentAssertionsMetadata(Compilation compilation)
        {
            AssertionExtensions = compilation.GetTypeByMetadataName("FluentAssertions.AssertionExtensions");
            GenericCollectionAssertionsOfT1 = compilation.GetTypeByMetadataName("FluentAssertions.Collections.GenericCollectionAssertions`1");
            GenericCollectionAssertionsOfT3 = compilation.GetTypeByMetadataName("FluentAssertions.Collections.GenericCollectionAssertions`3");
            ReferenceTypeAssertionsOfT2 = compilation.GetTypeByMetadataName("FluentAssertions.Primitives.ReferenceTypeAssertions`2");
        }
        public INamedTypeSymbol AssertionExtensions { get; }
        public INamedTypeSymbol GenericCollectionAssertionsOfT1 { get; }
        public INamedTypeSymbol GenericCollectionAssertionsOfT3 { get; }
        public INamedTypeSymbol ReferenceTypeAssertionsOfT2 { get; }
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