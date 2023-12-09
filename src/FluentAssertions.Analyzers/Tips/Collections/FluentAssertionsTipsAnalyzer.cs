using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace FluentAssertions.Analyzers;

// [DiagnosticAnalyzer(LanguageNames.CSharp)]
public class FluentAssertionsTipsAnalyzer : DiagnosticAnalyzer
{
    private static readonly DiagnosticDescriptor TipsRule = new(
        "FA001",
        title: "Simplify Fluent Assertions usage",
        messageFormat: "Simplify Fluent Assertions usage",
        description: "",
        category: "Design",
        defaultSeverity: DiagnosticSeverity.Info,
        isEnabledByDefault: true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(TipsRule);

    public override void Initialize(AnalysisContext context)
    {
        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.RegisterCompilationStartAction(compilationStartContext =>
        {
            var fluentassertions = compilationStartContext.Compilation.GetTypeByMetadataName("FluentAssertions.AssertionExtensions");
            if (fluentassertions is null)
            {
                return;
            }

            compilationStartContext.RegisterOperationAction(operationContext => AnalyzeInvocation(operationContext), OperationKind.Invocation);
        });
    }

    private static void AnalyzeInvocation(OperationAnalysisContext context)
    {
        var op = (IInvocationOperation)context.Operation;
        if (op.TargetMethod.Name != "BeTrue")
        {
            return;
        }

        var invocations = op.Descendants().OfType<IInvocationOperation>();
    }

    private class AnalyzerMetadata
    {
        
    }
}
