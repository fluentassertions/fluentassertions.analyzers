using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace FluentAssertions.BestPractices
{
    public abstract class FluentAssertionsAnalyzer : FluentAssertionsAnalyzer<FluentAssertionsCSharpSyntaxVisitor>
    {
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => Enumerable.Empty<FluentAssertionsCSharpSyntaxVisitor>();
    }

    public abstract class FluentAssertionsAnalyzer<TCSharpSyntaxVisitor> : DiagnosticAnalyzer where TCSharpSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public const string Title = "Assertion can be simplified.";
        protected abstract DiagnosticDescriptor Rule { get; }

        protected abstract IEnumerable<TCSharpSyntaxVisitor> Visitors { get; }

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

        protected virtual Diagnostic AnalyzeExpressionStatement(ExpressionStatementSyntax statement)
        {
            foreach (var visitor in Visitors)
            {
                statement.Accept(visitor);

                if (visitor.IsValid)
                {
                    return CreateDiagnostic(visitor, statement);
                }
            }
            return null;
        }

        protected virtual Diagnostic CreateDiagnostic(TCSharpSyntaxVisitor visitor, ExpressionStatementSyntax statement)
        {
            var properties = new Dictionary<string, string>
            {
                [Constants.DiagnosticProperties.VariableName] = visitor.VariableName,
                [Constants.DiagnosticProperties.Title] = Title
            }.ToImmutableDictionary();

            return Diagnostic.Create(
                descriptor: Rule,
                location: statement.GetLocation(),
                properties: properties,
                messageArgs: visitor.VariableName);
        }
    }
}
