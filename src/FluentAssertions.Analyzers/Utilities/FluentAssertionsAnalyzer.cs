using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace FluentAssertions.Analyzers
{
    public abstract class FluentAssertionsAnalyzer<TCSharpSyntaxVisitor> : DiagnosticAnalyzer where TCSharpSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public const string Title = "Simplify Assertion";
        protected abstract DiagnosticDescriptor Rule { get; }

        protected abstract IEnumerable<TCSharpSyntaxVisitor> Visitors { get; }

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
                foreach (var statement in method.Body.Statements.OfType<ExpressionStatementSyntax>())
                {
                    var diagnostic = AnalyzeExpression(statement.Expression, context.SemanticModel);
                    if (diagnostic != null)
                    {
                        context.ReportDiagnostic(diagnostic);
                    }
                }
                return;
            }
            if (method.ExpressionBody != null)
            {
                var diagnostic = AnalyzeExpression(method.ExpressionBody.Expression, context.SemanticModel);
                if (diagnostic != null)
                {
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }

        protected virtual bool ShouldAnalyzeVariableType(ITypeSymbol type) => true;

        protected virtual Diagnostic AnalyzeExpression(ExpressionSyntax expression, SemanticModel semanticModel)
        {
            var variableNameExtractor = new VariableNameExtractor(semanticModel);
            expression.Accept(variableNameExtractor);

            var typeInfo = semanticModel.GetTypeInfo(variableNameExtractor.VariableIdentifierName);
            if (typeInfo.ConvertedType == null) return null;
            if (!ShouldAnalyzeVariableType(typeInfo.ConvertedType)) return null;

            foreach (var visitor in Visitors)
            {
                expression.Accept(visitor);

                if (visitor.IsValid(expression))
                {
                    return CreateDiagnostic(visitor, expression);
                }
            }
            return null;
        }

        protected virtual Diagnostic CreateDiagnostic(TCSharpSyntaxVisitor visitor, ExpressionSyntax expression)
        {
            var properties = visitor.ToDiagnosticProperties()
                .Add(Constants.DiagnosticProperties.Title, Title);
            return Diagnostic.Create(
                descriptor: Rule,
                location: expression.GetLocation(),
                properties: properties);
        }
    }

    public abstract class FluentAssertionsAnalyzer : FluentAssertionsAnalyzer<FluentAssertionsCSharpSyntaxVisitor>
    {
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => Enumerable.Empty<FluentAssertionsCSharpSyntaxVisitor>();
    }
}
