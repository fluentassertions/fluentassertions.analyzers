using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FluentAssertions.BestPractices
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

                context.RegisterCodeFix(CodeAction.Create(
                    title: diagnostic.Properties[Constants.DiagnosticProperties.Title],
                    createChangedDocument: c => RewriteAssertion(context.Document, statement, diagnostic.Properties, c)
                    ), diagnostic);
            }
        }

        protected async Task<Document> RewriteAssertion(Document document, ExpressionStatementSyntax statement, ImmutableDictionary<string, string> properties, CancellationToken cancellationToken)
        {
            var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);

            var newStatement = GetNewStatement(properties).WithTriviaFrom(statement);

            root = root.ReplaceNode(statement, newStatement);

            return document.WithSyntaxRoot(root);
        }

        protected abstract StatementSyntax GetNewStatement(ImmutableDictionary<string, string> properties);
    }
}
