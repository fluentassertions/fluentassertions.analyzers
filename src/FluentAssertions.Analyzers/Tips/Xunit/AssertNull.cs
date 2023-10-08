using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.Analyzers.Xunit;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertNullAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertNull;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().BeNull() instead.";

    protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
    {
        get
        {
            yield return new AssertNullSyntaxVisitor();
        }
    }

		public class AssertNullSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public AssertNullSyntaxVisitor() : base(new MemberValidator("Null"))
        {
        }
		}
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertNullCodeFix)), Shared]
public class AssertNullCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertNullAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
    {
        return RenameMethodAndReplaceWithSubjectShould(expression, "Null", "BeNull");
		}
}