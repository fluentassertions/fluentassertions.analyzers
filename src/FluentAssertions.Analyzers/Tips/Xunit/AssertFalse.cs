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
    public class AssertFalseAnalyzer : XunitAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Xunit.AssertFalse;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().BeFalse() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new AssertFalseSyntaxVisitor();
            }
        }

		public class AssertFalseSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public AssertFalseSyntaxVisitor() : base(new MemberValidator("False"))
			{
			}
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertFalseCodeFix)), Shared]
    public class AssertFalseCodeFix : XunitCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertFalseAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            return RenameMethodAndReplaceWithSubjectShould(expression, "False", "BeFalse", "Assert");
		}
    }
}