using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using FluentAssertions.Analyzers.Utilities;

namespace FluentAssertions.Analyzers.Xunit;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertStrictEqualAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertStrictEqual;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().Be() instead.";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertStrictEqualSyntaxVisitor()
    };

    // public static void StrictEqual<T>(T expected, T actual)
	public class AssertStrictEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
	{
		public AssertStrictEqualSyntaxVisitor() : base(MemberValidator.HasArguments("StrictEqual", count: 2))
        {
        }
	}
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertStrictEqualCodeFix)), Shared]
public class AssertStrictEqualCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertStrictEqualAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertStrictEqualAnalyzer.AssertStrictEqualSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "StrictEqual", "Be");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}
