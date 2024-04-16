using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

public class DocsGenerator
{
    public async Task Execute()
    {
        DiagnosticAnalyzer analyzer = new FluentAssertionsAnalyzer();

        var compilation = await FluentAssertionAnalyzerDocsUtils.GetFluentAssertionAnalyzerDocsCompilation();
        var compilationWithAnalyzers = compilation.WithAnalyzers(ImmutableArray.Create(analyzer));

        var testAssembly = typeof(FluentAssertionAnalyzerDocs.FluentAssertionsAnalyzerTests).Assembly;

        foreach (var tree in compilationWithAnalyzers.Compilation.SyntaxTrees.Where(t => t.FilePath.EndsWith("Tests.cs")))
        {
            Console.WriteLine($"File: {Path.GetFileName(tree.FilePath)}");

            var docsName = Path.GetFileNameWithoutExtension(tree.FilePath).Replace("Tests", ".md");

            var docs = new StringBuilder();
            var toc = new StringBuilder();
            var scenarios = new StringBuilder();
    
            docs.AppendLine("<!--");
            docs.AppendLine("This is a generated file, please edit src\\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator\\DocsGenerator.cs to change the contents");
            docs.AppendLine("-->");
            docs.AppendLine();

            var subject = Path.GetFileNameWithoutExtension(tree.FilePath).Replace("AnalyzerTests", string.Empty);
            docs.AppendLine($"# {subject} Analyzer Docs");
            docs.AppendLine();
    
            scenarios.AppendLine("## Scenarios");
            scenarios.AppendLine();

            var root = await tree.GetRootAsync();
            var classDef = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
            var methods = root.DescendantNodes().OfType<MethodDeclarationSyntax>();

            var classType = testAssembly.GetType($"FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs.{classDef.Identifier.Text}");
            var classInstance = Activator.CreateInstance(classType);

            foreach (var method in methods.Where(m => m.AttributeLists.Any(list => list.Attributes.Count is 1 && list.Attributes[0].Name.ToString() is "TestMethod")))
            {
                {
                    scenarios.AppendLine($"### scenario: {method.Identifier}");
                    scenarios.AppendLine();
                    var bodyLines = method.Body.ToFullString().Split(Environment.NewLine)[1..^2];
                    var paddingToRemove = bodyLines[0].IndexOf(bodyLines[0].TrimStart());
                    var normalizedBody = bodyLines.Select(l => l.Length > paddingToRemove ? l.Substring(paddingToRemove) : l).Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
                    var methodBody = $"```cs{Environment.NewLine}{normalizedBody}{Environment.NewLine}```";
                    scenarios.AppendLine(methodBody);
                    scenarios.AppendLine();

                    var newAssertion = bodyLines[^1].Trim();

                    toc.AppendLine($"- [{method.Identifier}](#scenario-{method.Identifier.Text.ToLower()}) - `{newAssertion}`");
                }
                {
                    var testWithFailure = methods.FirstOrDefault(m => m.Identifier.Text == $"{method.Identifier.Text}_Failure");
                    var testMethodWithFailure = classType.GetMethod(testWithFailure.Identifier.Text);

                    var exceptionMessageLines = GetMethodExceptionMessageLines(classInstance, testMethodWithFailure);

                    var bodyLines = testWithFailure.Body.ToFullString().Split(Environment.NewLine)[2..^2];
                    var paddingToRemove = bodyLines[0].IndexOf(bodyLines[0].TrimStart());

                    var oldAssertionComment = testWithFailure.DescendantTrivia().First(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) && x.ToString().Equals("// old assertion:"));
                    var newAssertionComment = testWithFailure.DescendantTrivia().First(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) && x.ToString().Equals("// new assertion:"));

                    var statements = testWithFailure.Body.Statements.OfType<ExpressionStatementSyntax>();

                    var oldAssertions = statements.Where(x => x.Span.CompareTo(oldAssertionComment.Span) > 0 && x.Span.CompareTo(newAssertionComment.Span) < 0)
                        .Select((x, i) => x.ToString().TrimStart() + " \t// fail message: " + exceptionMessageLines[i]);
                    var newAssertion = statements.Single(x => x.Span.CompareTo(newAssertionComment.Span) > 0).ToString().TrimStart() + " \t// fail message: " + exceptionMessageLines[^1];

                    var arrange = bodyLines.TakeWhile(x => !string.IsNullOrEmpty(x))
                        .Select(l => l.Length > paddingToRemove ? l.Substring(paddingToRemove) : l).Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");

                    var methodBody = $"```cs{Environment.NewLine}{arrange}{Environment.NewLine}```";

                    scenarios.AppendLine($"#### Failure messages");
                    scenarios.AppendLine();
                    scenarios.AppendLine("```cs");
                    scenarios.AppendLine(arrange);
                    scenarios.AppendLine();
                    scenarios.AppendLine($"// old assertion:");
                    foreach (var oldAssertion in oldAssertions)
                    {
                        scenarios.AppendLine(oldAssertion);
                    }
                    scenarios.AppendLine();
                    scenarios.AppendLine($"// new assertion:");
                    scenarios.AppendLine(newAssertion);
                    scenarios.AppendLine("```");
                    scenarios.AppendLine();
                }
            }

            var diagnostics = await compilationWithAnalyzers.GetAllDiagnosticsAsync();
            foreach (var diagnostic in diagnostics.Where(diagnostic => analyzer.SupportedDiagnostics.Any(d => d.Id == diagnostic.Id)))
            {
                Console.WriteLine($"source: {root.FindNode(diagnostic.Location.SourceSpan)}");
                Console.WriteLine($"  diagnostic: {diagnostic}");
            }

            docs.AppendLine(toc.ToString());
            docs.AppendLine();
            docs.AppendLine(scenarios.ToString());

            var docsPath = Path.Combine(Environment.CurrentDirectory, "..", "..", "docs", docsName);
            Directory.CreateDirectory(Path.GetDirectoryName(docsPath));
            await File.WriteAllTextAsync(docsPath, docs.ToString());
        }
    }

    private string[] GetMethodExceptionMessageLines(object instance, MethodInfo method)
    {
        try
        {
            method.Invoke(instance, null);
        }
        catch (Exception ex) when (ex.InnerException is AssertFailedException exception)
        {
            return exception.Message.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }

        throw new InvalidOperationException("Method did not throw an exception");
    }
}
