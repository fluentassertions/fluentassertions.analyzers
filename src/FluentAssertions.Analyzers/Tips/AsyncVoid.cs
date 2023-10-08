using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAssertions.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AsyncVoidAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = Constants.CodeSmell.AsyncVoid;
    public const string Title = "Code Smell";
    public const string Message = "The assertions might not be executed when assigning an async void lambda to a Action";

    public static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, Message, Constants.CodeSmell.Category, DiagnosticSeverity.Warning, true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    public sealed override void Initialize(AnalysisContext context)
    {
        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.RegisterCodeBlockAction(AnalyzeCodeBlock);
    }

    private void AnalyzeCodeBlock(CodeBlockAnalysisContext context)
    {
        var method = context.CodeBlock as MethodDeclarationSyntax;
        if (method == null) return;

        if (method.Body != null)
        {
            foreach (var statement in method.Body.Statements.OfType<LocalDeclarationStatementSyntax>())
            {

                var diagnostic = AnalyzeStatement(context.SemanticModel, statement);
                if (diagnostic != null)
                {
                    context.ReportDiagnostic(diagnostic);
                }
            }
            return;
        }
    }

    protected virtual Diagnostic AnalyzeStatement(SemanticModel semanticModel, LocalDeclarationStatementSyntax statement)
    {
        var symbolInfo = semanticModel.GetSymbolInfo(statement.Declaration.Type);
        if (symbolInfo.Symbol?.Name != nameof(Action)) return null;

        foreach (var variable in statement.Declaration.Variables)
        {
            if (variable.Initializer == null) continue;

            if (!(variable.Initializer.Value is ParenthesizedLambdaExpressionSyntax lambda)) continue;

            if (lambda.AsyncKeyword.IsKind(SyntaxKind.AsyncKeyword))
            {
                return Diagnostic.Create(descriptor: Rule, location: statement.GetLocation());
            }
        }

        return null;
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AsyncVoidCodeFix)), Shared]
public class AsyncVoidCodeFix : CodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AsyncVoidAnalyzer.DiagnosticId);
    public override Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        return Task.CompletedTask;
    }
}
