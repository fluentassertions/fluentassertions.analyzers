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
public class AssertSubsetAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertSubset;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().BeSubset()";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertSubsetSyntaxVisitor()
    };

    //public static void Subset(ISet expectedSubset, ISet? actual)
    public class AssertSubsetSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertSubsetSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("Subset",
                ArgumentValidator.Exists(),
                ArgumentValidator.IsTypeOrConstructedFromTypeOrImplementsType(SpecialType.System_Collections_IEnumerable))
        )
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertSubsetCodeFix)), Shared]
public class AssertSubsetCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertSubsetAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertSubsetAnalyzer.AssertSubsetSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "Subset", "BeSubsetOf");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}