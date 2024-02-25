using System;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

[Generator]
public class DocsGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        foreach (var tree in context.Compilation.SyntaxTrees)
        {
        var root = tree.GetRoot();
            var methods = root.DescendantNodes().OfType<MethodDeclarationSyntax>();
            foreach (var method in methods)
            {
                var methodSymbol = context.Compilation.GetSemanticModel(method.SyntaxTree).GetDeclaredSymbol(method);
                var methodString = methodSymbol?.ToDisplayString();
                if (methodString != null)
                {
                    // TODO: generate markdown file
                }
            }
        }
    }

    public void Initialize(GeneratorInitializationContext context)
    {
    }
}