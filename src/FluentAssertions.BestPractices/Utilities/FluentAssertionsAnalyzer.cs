using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace FluentAssertions.BestPractices
{
    public abstract class FluentAssertionsAnalyzer<TCSharpSyntaxVisitor> : DiagnosticAnalyzer where TCSharpSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public const string Title = "Simplify Assertion";
        protected abstract DiagnosticDescriptor Rule { get; }

        protected abstract IEnumerable<(TCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors { get; }

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
            foreach (var (visitor, becauseArguments) in Visitors)
            {
                statement.Accept(visitor);

                if (visitor.IsValid)
                {
                    statement.Accept(becauseArguments);
                    return CreateDiagnostic(visitor, statement, becauseArguments.BecauseArgumentsString);
                }
            }
            return null;
        }

        protected virtual Diagnostic CreateDiagnostic(TCSharpSyntaxVisitor visitor, ExpressionStatementSyntax statement, string becauseArguments)
        {
            var properties = visitor.ToDiagnosticProperties()
                .Add(Constants.DiagnosticProperties.Title, Title)
                .Add(Constants.DiagnosticProperties.BecauseArgumentsString, becauseArguments);
            return Diagnostic.Create(
                descriptor: Rule,
                location: statement.GetLocation(),
                properties: properties,
                messageArgs: visitor.VariableName);
        }
    }

    public abstract class FluentAssertionsAnalyzer : FluentAssertionsAnalyzer<FluentAssertionsCSharpSyntaxVisitor>
    {
        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors => Enumerable.Empty<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)>();
    }
}
