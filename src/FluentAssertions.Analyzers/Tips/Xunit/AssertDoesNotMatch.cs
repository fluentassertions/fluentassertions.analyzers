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
public class AssertDoesNotMatchAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertDoesNotMatch;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().NotMatchRegex()";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertDoesNotMatchStringSyntaxVisitor()
    };

    //public static void DoesNotMatch(string expectedRegexPattern, string? actualString)
    //public static void DoesNotMatch(Regex expectedRegex, string? actualString)
    public class AssertDoesNotMatchStringSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertDoesNotMatchStringSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("DoesNotMatch",
                ArgumentValidator.IsAnyType(TypeSelector.GetStringType, TypeSelector.GetRegexType),
                ArgumentValidator.IsType(TypeSelector.GetStringType))
        )
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertDoesNotMatchCodeFix)), Shared]
public class AssertDoesNotMatchCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertDoesNotMatchAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertDoesNotMatchAnalyzer.AssertDoesNotMatchStringSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "DoesNotMatch", "NotMatchRegex");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}