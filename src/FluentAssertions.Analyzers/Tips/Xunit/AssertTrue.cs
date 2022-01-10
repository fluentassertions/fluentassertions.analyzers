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
    public class AssertTrueAnalyzer : XunitAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Xunit.AssertTrue;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().BeTrue() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new AssertTrueSyntaxVisitor();
            }
        }

		public class AssertTrueSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public AssertTrueSyntaxVisitor() : base(new MemberValidator("True"))
            {
            }
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertTrueCodeFix)), Shared]
    public class AssertTrueCodeFix : XunitCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertTrueAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            return RenameMethodAndReplaceWithSubjectShould(expression, "True", "BeTrue", "Assert");
		}
    }
}