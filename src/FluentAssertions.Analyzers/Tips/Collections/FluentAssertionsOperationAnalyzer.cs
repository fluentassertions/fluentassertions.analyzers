using System;
using System.Collections.Immutable;
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

        // CollectionShouldNotBeNullOrEmptyAnalyzer
        switch (assertion.TargetMethod.Name)
        {
            case "NotBeEmpty" when assertion.TargetMethod.ContainingType.ConstructedFrom.Equals(metadata.GenericCollectionAssertionsOfT3, SymbolEqualityComparer.Default):
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
            case "NotBeNull" when assertion.TargetMethod.ContainingType.ConstructedFrom.Equals(metadata.ReferenceTypeAssertionsOfT2, SymbolEqualityComparer.Default):
                {
                    if (TryGetChainedInvocationAfterAndConstraint(assertion, "NotBeEmpty", out var chainedInvocation))
                    {
                        if (HasEmptyBecauseAndReasonArgs(assertion) || HasEmptyBecauseAndReasonArgs(chainedInvocation))
                        {
                            context.ReportDiagnostic(Diagnostic.Create(Rule, chainedInvocation.Syntax.GetLocation()));
                            return;
                        }
                    }
                }
                break;
        }

        var fluentAssertionsOperationVisitor = new FluentAssertionsOperationVisitor();
        fluentAssertionsOperationVisitor.Visit(invocation);

        var subject = fluentAssertionsOperationVisitor.Subject;
    }

    static bool HasEmptyBecauseAndReasonArgs(IInvocationOperation invocation, int startingIndex = 0)
    {
        if (invocation.Arguments.Length != startingIndex + 2)
        {
            return false;
        }

        return invocation.Arguments[startingIndex].Value is ILiteralOperation literal && literal.ConstantValue.HasValue && literal.ConstantValue.Value is ""
        && invocation.Arguments[startingIndex + 1].Value is IArrayCreationOperation arrayCreation && arrayCreation.Initializer.ElementValues.IsEmpty;
    }

    static bool TryGetChainedInvocationAfterAndConstraint(IInvocationOperation invocation, string chainedMethod, out IInvocationOperation chainedInvocation)
    {
        if (invocation.Parent is IPropertyReferenceOperation { Property.Name: "And" } andConstraint)
        {
            chainedInvocation = andConstraint.Parent as IInvocationOperation;
            return chainedInvocation.TargetMethod.Name == chainedMethod;
        }

        chainedInvocation = null;
        return false;
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


    private class FluentAssertionsOperationVisitor : OperationVisitor
    {
        public IOperation Subject { get; private set; }

        public override void VisitInvocation(IInvocationOperation operation)
        {
            base.VisitInvocation(operation);
        }
    }
}