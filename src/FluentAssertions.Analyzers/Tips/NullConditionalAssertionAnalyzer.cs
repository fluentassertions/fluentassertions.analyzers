using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace FluentAssertions.Analyzers.Tips
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
            public bool CodeSmells { get; private set; }
            public Location ConditionalAccess { get; private set; }

            public override void VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
            {
                if (CodeSmells) return;

                CodeSmells = node.WhenNotNull is InvocationExpressionSyntax invocation
                    && invocation.Expression is MemberAccessExpressionSyntax memberAccess && memberAccess.IsKind(SyntaxKind.SimpleMemberAccessExpression)
                    && memberAccess.Expression is InvocationExpressionSyntax shouldInvocation
                    && shouldInvocation.Expression is MemberBindingExpressionSyntax memberBinding
                    && memberBinding.Name.Identifier.ValueText == "Should";
                if (CodeSmells)
                {
                    ConditionalAccess = node.GetLocation();
                }
            }
        }
    }
}
