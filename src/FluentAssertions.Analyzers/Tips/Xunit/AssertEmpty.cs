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
public class AssertEmptyAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertEmpty;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().NotMatchRegex()";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertEmptyStringSyntaxVisitor()
    };

    //public static void Empty(string value)
    public class AssertEmptyStringSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertEmptyStringSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("Empty",
                ArgumentValidator.IsType(TypeSelector.GetStringType))
        )
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertEmptyCodeFix)), Shared]
public class AssertEmptyCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertEmptyAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertEmptyAnalyzer.AssertEmptyStringSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "Empty", "BeEmpty");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}