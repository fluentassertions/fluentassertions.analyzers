using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            var methodsMap = methods.ToDictionary(m => m.Identifier.Text);

            foreach (var method in methods.Where(m => m.AttributeLists.Any(list => list.Attributes.Count is 1 && list.Attributes[0].Name.ToString() is "TestMethod")))
            {
                Console.WriteLine($"### scenario: {method.Identifier}");

                var oldAssertionComment = method.DescendantTrivia().First(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) && x.ToString().Equals("// old assertion:"));
                var newAssertionComment = method.DescendantTrivia().First(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) && x.ToString().Equals("// new assertion:"));

                var statements = method.Body.Statements.OfType<ExpressionStatementSyntax>();

                var oldAssertions = statements.Where(x => x.Span.CompareTo(oldAssertionComment.Span) > 0 && x.Span.CompareTo(newAssertionComment.Span) < 0);
                var newAssertion = statements.Single(x => x.Span.CompareTo(newAssertionComment.Span) > 0);

                foreach (var oldAssertion in oldAssertions)
                {
                    if (!oldAssertion.WithoutTrivia().IsEquivalentTo(newAssertion.WithoutTrivia()))
                    {
                        issues.AppendLine($"[{tree.FilePath.Split('\\')[^1]}:{oldAssertion.GetLocation().GetLineSpan().Span.Start}] {method.Identifier} - actual: {oldAssertion.ToFullString()} expected: {newAssertion.ToFullString()}");
                    }
                }

                if (methodsMap.TryGetValue($"{method.Identifier.Text}_Failure", out var methodFailure))
                {
                    var oldAssertionFailureComment = methodFailure.DescendantTrivia().First(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) && x.ToString().Equals("// old assertion:"));
                    var newAssertionFailureComment = methodFailure.DescendantTrivia().First(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) && x.ToString().Equals("// new assertion:"));

                    var statementsFailure = methodFailure.Body.Statements.OfType<ExpressionStatementSyntax>();

                    var oldAssertionsFailure = statementsFailure.Where(x => x.Span.CompareTo(oldAssertionFailureComment.Span) > 0 && x.Span.CompareTo(newAssertionFailureComment.Span) < 0);
                    var newAssertionFailure = statementsFailure.Single(x => x.Span.CompareTo(newAssertionFailureComment.Span) > 0);

                    foreach (var oldAssertionFailure in oldAssertionsFailure)
                    {
                        if (!oldAssertionFailure.WithoutTrivia().IsEquivalentTo(newAssertionFailure.WithoutTrivia()))
                        {
                            issues.AppendLine($"[{tree.FilePath.Split('\\')[^1]}:{oldAssertionFailure.GetLocation().GetLineSpan().Span.Start}] {methodFailure.Identifier} - actual: {oldAssertionFailure.ToFullString()} expected: {newAssertionFailure.ToFullString()}");
                        }
                    }
                }

                if (methodsMap.TryGetValue($"{method.Identifier.Text}_Failure_OldAssertion", out var testWithFailureOldAssertion)
                && methodsMap.TryGetValue($"{method.Identifier.Text}_Failure_NewAssertion", out var testWithFailureNewAssertion))
                {
                    var oldAssertionFailureComment = testWithFailureOldAssertion.DescendantTrivia().First(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) && x.ToString().Equals("// old assertion:"));
                    var newAssertionFailureComment = testWithFailureNewAssertion.DescendantTrivia().First(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) && x.ToString().Equals("// new assertion:"));

                    var statementsFailureOldAssertion = testWithFailureOldAssertion.Body.Statements.OfType<ExpressionStatementSyntax>();
                    var statementsFailureNewAssertion = testWithFailureNewAssertion.Body.Statements.OfType<ExpressionStatementSyntax>();

                    var oldAssertionsFailure = statementsFailureOldAssertion.Where(x => x.Span.CompareTo(oldAssertionFailureComment.Span) > 0 && x.Span.CompareTo(newAssertionFailureComment.Span) < 0);
                    var newAssertionFailure = statementsFailureNewAssertion.Single(x => x.Span.CompareTo(newAssertionFailureComment.Span) > 0);

                    foreach (var oldAssertionFailure in oldAssertionsFailure)
                    {
                        if (!oldAssertionFailure.WithoutTrivia().IsEquivalentTo(newAssertionFailure.WithoutTrivia()))
                        {
                            issues.AppendLine($"[{tree.FilePath.Split('\\')[^1]}:{oldAssertionFailure.GetLocation().GetLineSpan().Span.Start}] {testWithFailureOldAssertion.Identifier} - actual: {oldAssertionFailure.ToFullString()} expected: {newAssertionFailure.ToFullString()}");
                        }
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
