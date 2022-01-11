using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.Analyzers.Xunit
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AssertNotSameAnalyzer : XunitAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Xunit.AssertNotSame;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().NotBeSameAs() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new AssertNotSameSyntaxVisitor();
            }
        }

		public class AssertNotSameSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public AssertNotSameSyntaxVisitor() : base(new MemberValidator("NotSame"))
			{
			}
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertNotSameCodeFix)), Shared]
    public class AssertNotSameCodeFix : XunitCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertNotSameAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "NotSame", "NotBeSameAs");
		}
    }
}