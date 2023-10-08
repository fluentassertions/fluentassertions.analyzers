using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertThrowsExceptionAnalyzer : MsTestAssertAnalyzer
{
    public const string DiagnosticId = Constants.Tips.MsTest.AssertThrowsException;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().ThrowExactly<TException>() instead.";

    protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
    {
        get
        {
            yield return new AssertThrowsExceptionSyntaxVisitor();
        }
    }

		public class AssertThrowsExceptionSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public AssertThrowsExceptionSyntaxVisitor() : base(new MemberValidator("ThrowsException"))
        {
			}
		}
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertThrowsExceptionCodeFix)), Shared]
public class AssertThrowsExceptionCodeFix : MsTestAssertCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertThrowsExceptionAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        => RenameMethodAndReplaceWithSubjectShould(expression, "ThrowsException", "ThrowExactly");
}