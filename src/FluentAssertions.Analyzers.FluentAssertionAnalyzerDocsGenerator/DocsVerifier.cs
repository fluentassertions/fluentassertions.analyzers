using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

public class DocsVerifier
{
    public async Task Execute()
    {
        var compilation = await FluentAssertionAnalyzerDocsUtils.GetFluentAssertionAnalyzerDocsCompilation();
        var issues = new StringBuilder();
        foreach (var tree in compilation.SyntaxTrees.Where(t => t.FilePath.EndsWith("Tests.cs")))
        {
            Console.WriteLine($"File: {Path.GetFileName(tree.FilePath)}");

            var root = await tree.GetRootAsync();
            var methods = root.DescendantNodes().OfType<MethodDeclarationSyntax>();

            foreach (var method in methods)
            {
                Console.WriteLine($"### scenario: {method.Identifier}");

                var oldAssertionComment = method.DescendantTrivia().First(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) && x.ToString().Equals("// old assertion:"));
                var newAssertionComment = method.DescendantTrivia().First(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) && x.ToString().Equals("// new assertion:"));
                
                var statements = method.Body.Statements.OfType<ExpressionStatementSyntax>();

                var oldAssertions = statements.Where(x => x.Span.CompareTo(oldAssertionComment.Span) > 0 && x.Span.CompareTo(newAssertionComment.Span) < 0);
                var newAssertion = statements.Single(x => x.Span.CompareTo(newAssertionComment.Span) > 0);

                foreach (var oldAssertion in oldAssertions)
                {
                    if (!oldAssertion.IsEquivalentTo(newAssertion))
                    {
                        issues.AppendLine($"[{tree.FilePath}:{oldAssertion.GetLocation().GetLineSpan().Span.Start}] {method.Identifier} - actual: {oldAssertion} expected: {newAssertion}");
                    }
                }
            }
        }

        if (issues.Length > 0)
        {
            throw new Exception(issues.ToString());
        }
    }
}
