using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.Analyzers.Xunit;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertNotNullAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertNotNull;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().NotBeNull() instead.";

    protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
    {
        get
        {
            yield return new AssertNotNullSyntaxVisitor();
        }
    }

		public class AssertNotNullSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public AssertNotNullSyntaxVisitor() : base(new MemberValidator("NotNull"))
        {
        }
		}
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertNotNullCodeFix)), Shared]
public class AssertNotNullCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertNotNullAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
    {
        return RenameMethodAndReplaceWithSubjectShould(expression, "NotNull", "NotBeNull");
		}
}