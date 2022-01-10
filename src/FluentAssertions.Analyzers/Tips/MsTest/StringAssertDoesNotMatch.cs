using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class StringAssertDoesNotMatchAnalyzer : MsTestStringAssertAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.MsTest.StringAssertDoesNotMatch;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().NotMatchRegex() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new StringAssertDoesNotMatchSyntaxVisitor();
            }
        }

		public class StringAssertDoesNotMatchSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public StringAssertDoesNotMatchSyntaxVisitor() : base(new MemberValidator("DoesNotMatch"))
            {
            }
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(StringAssertDoesNotMatchCodeFix)), Shared]
    public class StringAssertDoesNotMatchCodeFix : MsTestCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(StringAssertDoesNotMatchAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            return RenameMethodAndReplaceWithSubjectShould(expression, "DoesNotMatch", "NotMatchRegex", "StringAssert");
		}
    }
}