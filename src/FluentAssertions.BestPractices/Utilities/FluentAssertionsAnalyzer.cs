using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace FluentAssertions.BestPractices
{
    public abstract class FluentAssertionsAnalyzer : DiagnosticAnalyzer
    {
        public const string Title = "Assertion can be simplified.";
        protected abstract DiagnosticDescriptor Rule { get; }
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public sealed override void Initialize(AnalysisContext context)
        {
            context.RegisterCodeBlockAction(AnalyzeCodeBlock);
        }

        private void AnalyzeCodeBlock(CodeBlockAnalysisContext context)
        {
            var method = context.CodeBlock as MethodDeclarationSyntax;
            if (method == null) return;

            foreach (var statement in method.Body.Statements.OfType<ExpressionStatementSyntax>())
            {
                var diagnostic = AnalyzeExpressionStatement(statement);
                if (diagnostic != null)
                {
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }

        protected abstract Diagnostic AnalyzeExpressionStatement(ExpressionStatementSyntax statement);
    }
}
