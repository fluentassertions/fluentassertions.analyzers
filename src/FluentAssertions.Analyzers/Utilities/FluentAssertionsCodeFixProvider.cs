using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FluentAssertions.Analyzers
{

    public abstract class FluentAssertionsCodeFixProvider : CodeFixProvider
    {
        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
            foreach (var diagnostic in context.Diagnostics)
            {
                var statement = root.FindToken(diagnostic.Location.SourceSpan.Start)
                   .Parent.AncestorsAndSelf().OfType<ExpressionStatementSyntax>().First();

                if (CanRewriteAssertion(statement))
                {
                    context.RegisterCodeFix(CodeAction.Create(
                        title: diagnostic.Properties[Constants.DiagnosticProperties.Title],
                        createChangedDocument: c => RewriteAssertion(context.Document, statement, diagnostic.Properties, c)
                        ), diagnostic);
                }
            }
        }

        protected virtual bool CanRewriteAssertion(ExpressionStatementSyntax statement) => true;

        protected async Task<Document> RewriteAssertion(Document document, ExpressionStatementSyntax statement, ImmutableDictionary<string, string> properties, CancellationToken cancellationToken)
        {
            var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);

            var newStatement = GetNewStatement(statement, new FluentAssertionsDiagnosticProperties(properties));

            root = root.ReplaceNode(statement, newStatement);

            return document.WithSyntaxRoot(root);
        }

        protected abstract StatementSyntax GetNewStatement(ExpressionStatementSyntax statement, FluentAssertionsDiagnosticProperties properties);

        protected ExpressionStatementSyntax GetNewStatement(ExpressionStatementSyntax statement, params NodeReplacement[] replacements)
        {
            var newStatement = statement;
            foreach (var replacement in replacements)
            {
                newStatement = GetNewStatement(newStatement, replacement);
                var code = newStatement.ToFullString();
            }
            return newStatement;
        }

        protected ExpressionStatementSyntax GetNewStatement(ExpressionStatementSyntax statement, NodeReplacement replacement)
        {
            var visitor = new MemberAccessExpressionsCSharpSyntaxVisitor();
            statement.Accept(visitor);
            var members =  new LinkedList<MemberAccessExpressionSyntax>(visitor.Members);

            var current = members.Last;
            while (current != null)
            {
                if (replacement.IsValidNode(current.Value))
                {
                    // extract custom data into the replacement object
                    replacement.ExtractValues(current.Value);

                    return statement.ReplaceNode(replacement.ComputeOld(current), replacement.ComputeNew(current));
                }
                current = current.Previous;
            }

            throw new System.InvalidOperationException("should not get here");
        }

        protected class MemberAccessExpressionsCSharpSyntaxVisitor : CSharpSyntaxVisitor
        {
            public List<MemberAccessExpressionSyntax> Members { get; } = new List<MemberAccessExpressionSyntax>();

            public override void VisitInvocationExpression(InvocationExpressionSyntax node) => Visit(node.Expression);

            public sealed override void VisitExpressionStatement(ExpressionStatementSyntax node) => Visit(node.Expression);


            public sealed override void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
            {
                if (node.Name.Identifier.Text != "And")
                {
                    Members.Add(node);
                }
                Visit(node.Expression);
            }
        }
    }
}
