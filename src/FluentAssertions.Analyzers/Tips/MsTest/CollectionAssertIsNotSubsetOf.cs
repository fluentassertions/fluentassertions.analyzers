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
    public class CollectionAssertIsNotSubsetOfAnalyzer : MsTestCollectionAssertAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.MsTest.CollectionAssertIsNotSubsetOf;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().NotBeSubsetOf() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new CollectionAssertIsNotSubsetOfSyntaxVisitor();
            }
        }

		public class CollectionAssertIsNotSubsetOfSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public CollectionAssertIsNotSubsetOfSyntaxVisitor() : base(new MemberValidator("IsNotSubsetOf"))
            {
            }
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionAssertIsNotSubsetOfCodeFix)), Shared]
    public class CollectionAssertIsNotSubsetOfCodeFix : MsTestCollectionAssertCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionAssertIsNotSubsetOfAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "IsNotSubsetOf", "NotBeSubsetOf");
		}
    }
}