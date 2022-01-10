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
    public class CollectionAssertAllItemsAreUniqueAnalyzer : MsTestCollectionAssertAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.MsTest.CollectionAssertAllItemsAreUnique;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().OnlyHaveUniqueItems() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new CollectionAssertAllItemsAreUniqueSyntaxVisitor();
            }
        }

		public class CollectionAssertAllItemsAreUniqueSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public CollectionAssertAllItemsAreUniqueSyntaxVisitor() : base(new MemberValidator("AllItemsAreUnique"))
			{
			}
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionAssertAllItemsAreUniqueCodeFix)), Shared]
    public class CollectionAssertAllItemsAreUniqueCodeFix : MsTestCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionAssertAllItemsAreUniqueAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            return RenameMethodAndReplaceWithSubjectShould(expression, "AllItemsAreUnique", "OnlyHaveUniqueItems", "CollectionAssert");
        }
    }
}