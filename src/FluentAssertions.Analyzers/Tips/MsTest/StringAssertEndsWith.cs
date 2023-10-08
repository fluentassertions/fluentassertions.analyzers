using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class StringAssertEndsWithAnalyzer : MsTestStringAssertAnalyzer
{
    public const string DiagnosticId = Constants.Tips.MsTest.StringAssertEndsWith;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().EndWith() instead.";

    protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
    {
        get
        {
            yield return new StringAssertEndsWithSyntaxVisitor();
        }
    }

		public class StringAssertEndsWithSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public StringAssertEndsWithSyntaxVisitor() : base(new MemberValidator("EndsWith"))
        {
        }
		}
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(StringAssertEndsWithCodeFix)), Shared]
public class StringAssertEndsWithCodeFix : MsTestStringAssertCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(StringAssertEndsWithAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
    {
        return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "EndsWith", "EndWith");
		}
}