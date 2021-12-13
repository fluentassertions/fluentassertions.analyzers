using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
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
                var expression = (ExpressionSyntax)root.FindNode(diagnostic.Location.SourceSpan);
                if (await CanRewriteAssertion(expression, context).ConfigureAwait(false))
                {
                    context.RegisterCodeFix(CodeAction.Create(
                        title: diagnostic.Properties[Constants.DiagnosticProperties.Title],
                        createChangedDocument: c => RewriteAssertion(context.Document, expression, diagnostic.Properties, c)
                        ), diagnostic);
                }
            }
        }

        protected virtual Task<bool> CanRewriteAssertion(ExpressionSyntax expression, CodeFixContext context) => Task.FromResult(true);

        protected async Task<Document> RewriteAssertion(Document document, ExpressionSyntax expression, ImmutableDictionary<string, string> properties, CancellationToken cancellationToken)
        {
            var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);

            var newExpression = await GetNewExpressionSafelyAsync(expression, document, new FluentAssertionsDiagnosticProperties(properties), cancellationToken);

            root = root.ReplaceNode(expression, newExpression);

            return document.WithSyntaxRoot(root);
        }

        protected virtual Task<ExpressionSyntax> GetNewExpressionAsync(ExpressionSyntax expression, Document document, FluentAssertionsDiagnosticProperties properties, CancellationToken cancellationToken)
            => Task.FromResult(GetNewExpression(expression, properties));

        protected virtual ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties) => expression;

        protected ExpressionSyntax GetNewExpression(ExpressionSyntax expression, params NodeReplacement[] replacements)
        {
            var newStatement = expression;
            foreach (var replacement in replacements)
            {
                newStatement = GetNewExpression(newStatement, replacement);
                var code = newStatement.ToFullString();
            }
            return newStatement;
        }

        protected static ExpressionSyntax GetNewExpression(ExpressionSyntax expression, NodeReplacement replacement)
        {
            var visitor = new MemberAccessExpressionsCSharpSyntaxVisitor();
            expression.Accept(visitor);
            var members = new LinkedList<MemberAccessExpressionSyntax>(visitor.Members);

            var current = members.Last;
            while (current != null)
            {
                if (replacement.IsValidNode(current))
                {
                    // extract custom data into the replacement object
                    replacement.ExtractValues(current.Value);

                    var oldNode = replacement.ComputeOld(current);
                    var newNode = replacement.ComputeNew(current);
                    return expression.ReplaceNode(oldNode, newNode);
                }
                current = current.Previous;
            }

            throw new System.InvalidOperationException("should not get here");
        }

        protected static ExpressionSyntax RenameIdentifier(ExpressionSyntax expression, string oldName, string newName)
        {
            var identifierNode = expression.DescendantNodes()
                .OfType<IdentifierNameSyntax>()
                .First(node => node.Identifier.Text == oldName);
            return expression.ReplaceNode(identifierNode, identifierNode.WithIdentifier(SyntaxFactory.Identifier(newName).WithTriviaFrom(identifierNode.Identifier)));
        }

        private Task<ExpressionSyntax> GetNewExpressionSafelyAsync(ExpressionSyntax expression, Document document, FluentAssertionsDiagnosticProperties properties, CancellationToken cancellationToken)
        {
            try
            {
                return GetNewExpressionAsync(expression, document, properties, cancellationToken);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Failed to get new expression in {GetType().FullName}.\n{e}");
                return Task.FromResult(expression);
            }
        }

        protected static ExpressionSyntax ReplaceIdentifier(ExpressionSyntax expression, string name, ExpressionSyntax identifierReplacement)
        {
            var identifierNode = expression.DescendantNodes()
                .OfType<IdentifierNameSyntax>()
                .First(node => node.Identifier.Text == name);
            return expression.ReplaceNode(identifierNode, identifierReplacement.WithTriviaFrom(identifierNode));
        }
    }
}
