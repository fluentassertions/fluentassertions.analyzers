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
    public class StringAssertMatchesAnalyzer : MsTestStringAssertAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.MsTest.StringAssertMatches;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().MatchRegex() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new StringAssertMatchesSyntaxVisitor();
            }
        }

		public class StringAssertMatchesSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public StringAssertMatchesSyntaxVisitor() : base(new MemberValidator("Matches"))
            {
            }
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(StringAssertMatchesCodeFix)), Shared]
    public class StringAssertMatchesCodeFix : MsTestCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(StringAssertMatchesAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            return RenameMethodAndReplaceWithSubjectShould(expression, "Matches", "MatchRegex", "StringAssert");
		}
    }
}