using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.Analyzers.Xunit
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AssertSameAnalyzer : XunitAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Xunit.AssertSame;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().BeSameAs() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new AssertSameSyntaxVisitor();
            }
        }

		public class AssertSameSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public AssertSameSyntaxVisitor() : base(new MemberValidator("Same"))
            {
            }
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertSameCodeFix)), Shared]
    public class AssertSameCodeFix : XunitCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertSameAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
             return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "Same", "BeSameAs");
		}
    }
}