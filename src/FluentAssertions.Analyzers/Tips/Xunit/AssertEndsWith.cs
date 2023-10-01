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
public class AssertEndsWithAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertEndsWith;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().NotMatchRegex()";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertEndsWithStringSyntaxVisitor()
    };

    //public static void EndsWith(string? expectedEndString, string? actualString)
    public class AssertEndsWithStringSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertEndsWithStringSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("EndsWith",
                ArgumentValidator.IsType(TypeSelector.GetStringType),
                ArgumentValidator.IsType(TypeSelector.GetStringType))
        )
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertEndsWithCodeFix)), Shared]
public class AssertEndsWithCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertEndsWithAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertEndsWithAnalyzer.AssertEndsWithStringSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "EndsWith", "EndWith");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}