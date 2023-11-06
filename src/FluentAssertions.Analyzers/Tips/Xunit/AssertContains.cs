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
public class AssertContainsAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertContains;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().Contain().";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertContainsStringSyntaxVisitor(),
        new AssertContainsSetSyntaxVisitor()
    };

    //public static void Contains(string expectedSubstring, string? actualString)
    public class AssertContainsStringSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertContainsStringSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("Contains",
                ArgumentValidator.IsType(TypeSelector.GetStringType),
                ArgumentValidator.IsType(TypeSelector.GetStringType))
        )
        {
        }
    }

    //public static void Contains<T>(T expected, ISet<T> actual)
    //public static void Contains<T>(T expected, IReadOnlySet<T> actual)
    //public static void Contains<T>(T expected, HashSet<T> actual)
    //public static void Contains<T>(T expected, ImmutableHashSet<T> actual)
    public class AssertContainsSetSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertContainsSetSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("Contains",
                ArgumentValidator.Exists(),
                ArgumentValidator.IsTypeOrConstructedFromTypeOrImplementsType(SpecialType.System_Collections_IEnumerable))
        )
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertContainsCodeFix)), Shared]
public class AssertContainsCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertContainsAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertContainsAnalyzer.AssertContainsStringSyntaxVisitor):
            case nameof(AssertContainsAnalyzer.AssertContainsSetSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "Contains", "Contain");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}