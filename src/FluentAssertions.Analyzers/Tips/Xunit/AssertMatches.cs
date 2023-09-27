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
public class AssertMatchesAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertMatches;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().MatchRegex()";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertMatchesStringSyntaxVisitor()
    };

    //public static void Matches(string expectedRegexPattern, string? actualString)
    //public static void Matches(Regex expectedRegex, string? actualString)
    public class AssertMatchesStringSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertMatchesStringSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("Matches",
                ArgumentValidator.IsAnyType(TypeSelector.GetStringType, TypeSelector.GetRegexType),
                ArgumentValidator.IsType(TypeSelector.GetStringType))
        )
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertMatchesCodeFix)), Shared]
public class AssertMatchesCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertMatchesAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertMatchesAnalyzer.AssertMatchesStringSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "Matches", "MatchRegex");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}