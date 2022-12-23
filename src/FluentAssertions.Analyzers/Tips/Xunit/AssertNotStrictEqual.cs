using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using TypeSelector = FluentAssertions.Analyzers.Utilities.SemanticModelTypeExtensions;

namespace FluentAssertions.Analyzers.Xunit;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertNotStrictEqualAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertNotStrictEqual;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().NotBe() instead.";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertNotStrictEqualSyntaxVisitor()
    };

    // public static void NotStrictEqual<T>(T expected, T actual)
	public class AssertNotStrictEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
	{
		public AssertNotStrictEqualSyntaxVisitor() : base(MemberValidator.HasArguments("NotStrictEqual", count: 2))
        {
        }
	}
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertNotStrictEqualCodeFix)), Shared]
public class AssertNotStrictEqualCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertNotStrictEqualAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertNotStrictEqualAnalyzer.AssertNotStrictEqualSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "NotStrictEqual", "NotBe");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}
