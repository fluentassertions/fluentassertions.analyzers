using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FluentAssertions.Analyzers.Xunit;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertStartsWithAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertStartsWith;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().StartWith()";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertStartsWithStringSyntaxVisitor()
    };

    //public static void StartsWith(string? expectedStartString, string? actualString)
    public class AssertStartsWithStringSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertStartsWithStringSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("StartsWith",
                ArgumentValidator.IsType(TypeSelector.GetStringType),
                ArgumentValidator.IsType(TypeSelector.GetStringType))
        )
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertStartsWithCodeFix)), Shared]
public class AssertStartsWithCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertStartsWithAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertStartsWithAnalyzer.AssertStartsWithStringSyntaxVisitor):
            return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "StartsWith", "StartWith");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}