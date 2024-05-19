﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

public abstract class DocsVerifier
{
    protected abstract string TestAttribute { get; }
    protected abstract string TestFile { get; }

    public async Task Execute()
    {
        var compilation = SyntaxFactory.ParseCompilationUnit(await File.ReadAllTextAsync(TestFile));
        var tree = compilation.SyntaxTree;

        var issues = new StringBuilder();

        void ValidateAssertions(IEnumerable<ExpressionStatementSyntax> oldAssertions, ExpressionStatementSyntax newAssertion, MethodDeclarationSyntax method, string className)
        {
            foreach (var oldAssertion in oldAssertions)
            {
                if (!oldAssertion.WithoutTrivia().IsEquivalentTo(newAssertion.WithoutTrivia()))
                {
                    issues.AppendLine($"[{className}] {method.Identifier} - actual: {oldAssertion.ToFullString()} expected: {newAssertion.ToFullString()}");
                }
            }
        }

        Console.WriteLine($"File: {Path.GetFileName(tree.FilePath)}");

        var root = await tree.GetRootAsync();
        var methods = root.DescendantNodes().OfType<MethodDeclarationSyntax>();
        var methodsMap = methods.ToDictionary(m => m.Identifier.Text);

        foreach (var method in methods.Where(m => m.AttributeLists.Any(list => list.Attributes.Count is 1 && list.Attributes[0].Name.ToString() == TestAttribute)))
        {
            Console.WriteLine($"### scenario: {method.Identifier}");

            var (oldAssertions, newAssertion) = GetAssertionsFromMethod(method);

            ValidateAssertions(oldAssertions, newAssertion, method, tree.FilePath.Split('\\')[^1]);

            if (methodsMap.TryGetValue($"{method.Identifier.Text}_Failure", out var methodFailure))
            {
                var (oldAssertionsFailure, newAssertionFailure) = GetAssertionsFromMethod(methodFailure);

                ValidateAssertions(oldAssertionsFailure, newAssertionFailure, methodFailure, tree.FilePath.Split('\\')[^1]);
            }

            if (methodsMap.TryGetValue($"{method.Identifier.Text}_Failure_OldAssertion", out var testWithFailureOldAssertion)
            && methodsMap.TryGetValue($"{method.Identifier.Text}_Failure_NewAssertion", out var testWithFailureNewAssertion))
            {
                var (oldAssertionsFailure, _) = GetAssertionsFromMethod(testWithFailureOldAssertion);
                var (_, newAssertionFailure) = GetAssertionsFromMethod(testWithFailureNewAssertion);

                ValidateAssertions(oldAssertionsFailure, newAssertionFailure, testWithFailureOldAssertion, tree.FilePath.Split('\\')[^1]);
            }
        }

        if (issues.Length > 0)
        {
            throw new Exception(issues.ToString());
        }
    }

    (IEnumerable<ExpressionStatementSyntax> oldAssertions, ExpressionStatementSyntax newAssertion) GetAssertionsFromMethod(MethodDeclarationSyntax method)
    {
        var oldAssertionComment = method.DescendantTrivia().FirstOrDefault(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) && x.ToString().Equals("// old assertion:"));
        var newAssertionComment = method.DescendantTrivia().FirstOrDefault(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) && x.ToString().Equals("// new assertion:"));

        var statements = method.Body.Statements.OfType<ExpressionStatementSyntax>();

        var oldAssertions = statements.Where(x => x.Span.CompareTo(oldAssertionComment.Span) > 0 && x.Span.CompareTo(newAssertionComment.Span) < 0);
        var newAssertion = statements.SingleOrDefault(x => x.Span.CompareTo(newAssertionComment.Span) > 0);

        return (oldAssertions, newAssertion);
    }
}
