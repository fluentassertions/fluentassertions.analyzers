using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentAssertions.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertIsNotInstanceOfTypeAnalyzer : MsTestAssertAnalyzer
{
    public const string DiagnosticId = Constants.Tips.MsTest.AssertIsNotInstanceOfType;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().NotBeOfType() instead.";

    protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
    {
        get
        {
            yield return new AssertIsNotInstanceOfTypeSyntaxVisitor();
        }
    }

		public class AssertIsNotInstanceOfTypeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public AssertIsNotInstanceOfTypeSyntaxVisitor() : base(new MemberValidator("IsNotInstanceOfType"))
			{
			}
		}
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertIsNotInstanceOfTypeCodeFix)), Shared]
public class AssertIsNotInstanceOfTypeCodeFix : MsTestAssertCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertIsNotInstanceOfTypeAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
    {
        var newExpression = RenameMethodAndReplaceWithSubjectShould(expression, "IsNotInstanceOfType", "NotBeOfType");
        return ReplaceTypeOfArgumentWithGenericTypeIfExists(newExpression, "NotBeOfType");
    }
}