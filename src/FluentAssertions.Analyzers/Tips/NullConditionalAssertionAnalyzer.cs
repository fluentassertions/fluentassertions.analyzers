using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace FluentAssertions.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class NullConditionalAssertionAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = Constants.CodeSmell.NullConditionalAssertion;
        public const string Title = "Code Smell";
        public const string Message = "The assertions might not be executed when using ?.Should()";

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
                foreach (var statement in method.Body.Statements.OfType<ExpressionStatementSyntax>())
                {
                    var diagnostic = AnalyzeExpression(statement.Expression);
                    if (diagnostic != null)
                    {
                        context.ReportDiagnostic(diagnostic);
                    }
                }
                return;
            }
            if (method.ExpressionBody != null)
            {
                var diagnostic = AnalyzeExpression(method.ExpressionBody.Expression);
                if (diagnostic != null)
                {
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }

        protected virtual Diagnostic AnalyzeExpression(ExpressionSyntax expression)
        {
            var visitor = new ConditionalAccessExpressionVisitor();
            expression.Accept(visitor);

            return visitor.CodeSmells ? Diagnostic.Create(descriptor: Rule, location: expression.GetLocation()) : null;
        }

        private class ConditionalAccessExpressionVisitor : CSharpSyntaxWalker
        {
            private bool _foundConditionalAccessInCurrentScope;
            private bool _foundShouldMethodAfterConditionalAccess;

            public bool CodeSmells => _foundShouldMethodAfterConditionalAccess;

            public override void VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
            {
                Visit(node.Expression);
                _foundConditionalAccessInCurrentScope = true;
                Visit(node.WhenNotNull);
            }

            public override void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
            {
                base.DefaultVisit(node);
                _foundConditionalAccessInCurrentScope = false;
            }

            public override void VisitIdentifierName(IdentifierNameSyntax node)
            {
                if (_foundConditionalAccessInCurrentScope && node.Identifier.ValueText == "Should")
                {
                    _foundShouldMethodAfterConditionalAccess = true;
                }
            }
        }
    }
}
