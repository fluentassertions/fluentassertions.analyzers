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
    public class CollectionAssertDoesNotContainAnalyzer : MsTestCollectionAssertAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.MsTest.CollectionAssertDoesNotContain;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().NotContain() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new CollectionAssertDoesNotContainSyntaxVisitor();
            }
        }

		public class CollectionAssertDoesNotContainSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public CollectionAssertDoesNotContainSyntaxVisitor() : base(new MemberValidator("DoesNotContain"))
			{
			}
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionAssertDoesNotContainCodeFix)), Shared]
    public class CollectionAssertDoesNotContainCodeFix : MsTestCollectionAssertCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionAssertDoesNotContainAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            return RenameMethodAndReplaceWithSubjectShould(expression, "DoesNotContain", "NotContain");
        }
    }
}