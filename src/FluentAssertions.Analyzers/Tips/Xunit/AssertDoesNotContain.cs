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
public class AssertDoesNotContainAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertDoesNotContain;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().NotContain().";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertDoesNotContainStringSyntaxVisitor()
    };

    //public static void DoesNotContain(string expectedSubstring, string? actualString)
    public class AssertDoesNotContainStringSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertDoesNotContainStringSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("DoesNotContain",
                ArgumentValidator.IsType(TypeSelector.GetStringType),
                ArgumentValidator.IsType(TypeSelector.GetStringType))
        )
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertDoesNotContainCodeFix)), Shared]
public class AssertDoesNotContainCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertDoesNotContainAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertDoesNotContainAnalyzer.AssertDoesNotContainStringSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "DoesNotContain", "NotContain");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}