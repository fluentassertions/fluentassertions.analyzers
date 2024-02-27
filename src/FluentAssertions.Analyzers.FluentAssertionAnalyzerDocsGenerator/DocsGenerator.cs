using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

public class DocsGenerator
{
    public async Task Execute()
    {
        MSBuildLocator.RegisterDefaults();

        using var workspace = MSBuildWorkspace.Create();

        var project = await workspace.OpenProjectAsync(@"..\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs.csproj");

        var compilation = await project.GetCompilationAsync();

        foreach (var tree in compilation.SyntaxTrees.Where(t => t.FilePath.EndsWith("Tests.cs")))
        {
            Console.WriteLine($"File: {Path.GetFileName(tree.FilePath)}");

            var root = await tree.GetRootAsync();
            var methods = root.DescendantNodes().OfType<MethodDeclarationSyntax>();

            foreach (var method in methods)
            {
                Console.WriteLine($"  method: {method.Identifier}");
                Console.WriteLine();
                var bodyLines = method.Body.ToFullString().Split(Environment.NewLine)[1..^2];
                var paddingToRemove = bodyLines[0].IndexOf(bodyLines[0].TrimStart());
                var normalizedBody = bodyLines.Select(l => l.Length > paddingToRemove ? l.Substring(paddingToRemove) : l).Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
                var methodBody = $"```cs{Environment.NewLine}{normalizedBody}{Environment.NewLine}```";
                Console.WriteLine(methodBody);
            }
        }
    }
}
