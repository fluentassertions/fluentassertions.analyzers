using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.BestPractices
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class CollectionShouldOnlyHaveUniqueItemsAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldOnlyHaveUniqueItems;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by ### instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors
        {
            get
            {
                yield return (new ShouldHaveSameCountThisCollectionDistinctSyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("HaveSameCount", 1));
            }
        }

        private class ShouldHaveSameCountThisCollectionDistinctSyntaxVisitor : FluentAssertionsWithArgumentCSharpSyntaxVisitor
        {
            protected override string MethodContainingArgument => "HaveSameCount";
            public ShouldHaveSameCountThisCollectionDistinctSyntaxVisitor() : base("Should", "HaveSameCount")
            {
            }

            protected override ExpressionSyntax ModifyArgument(ExpressionSyntax expression)
            {
                var visitor = new CollectionDistinctSyntaxVisitor();
                expression.Accept(visitor);

                return (visitor.IsValid && visitor.VariableName == VariableName) ? expression : null;
            }

            private class CollectionDistinctSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
            {
                public CollectionDistinctSyntaxVisitor() : base("Distinct")
                {
                }
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldOnlyHaveUniqueItemsCodeFix)), Shared]
    public class CollectionShouldOnlyHaveUniqueItemsCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldOnlyHaveUniqueItemsAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(ExpressionStatementSyntax statement, FluentAssertionsDiagnosticProperties properties)
        {
            return GetNewStatement(statement, NodeReplacement.RenameAndRemoveFirstArgument("HaveSameCount", "OnlyHaveUniqueItems"));
        }
    }
}
