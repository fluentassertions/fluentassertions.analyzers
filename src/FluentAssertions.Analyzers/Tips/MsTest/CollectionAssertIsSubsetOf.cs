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
    public class CollectionAssertIsSubsetOfAnalyzer : MsTestCollectionAssertAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.MsTest.CollectionAssertIsSubsetOf;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().BeSubsetOf() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new CollectionAssertIsSubsetOfSyntaxVisitor();
            }
        }

		public class CollectionAssertIsSubsetOfSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public CollectionAssertIsSubsetOfSyntaxVisitor() : base(new MemberValidator("IsSubsetOf"))
			{
			}
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionAssertIsSubsetOfCodeFix)), Shared]
    public class CollectionAssertIsSubsetOfCodeFix : MsTestCollectionAssertCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionAssertIsSubsetOfAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "IsSubsetOf", "BeSubsetOf");
		}
    }
}