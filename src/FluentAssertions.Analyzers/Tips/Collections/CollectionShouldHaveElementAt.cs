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
    public class CollectionShouldHaveElementAtAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldHaveElementAt;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .HaveElementAt() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new ElementAtIndexShouldBeSyntaxVisitor();
                yield return new IndexerShouldBeSyntaxVisitor();
                yield return new SkipFirstShouldBeSyntaxVisitor();
            }
        }

        public class ElementAtIndexShouldBeSyntaxVisitor : FluentAssertionsWithArgumentsCSharpSyntaxVisitor
        {
            protected override bool AreArgumentsValid() =>                
                Arguments.TryGetValue(("ElementAt", 0), out ExpressionSyntax index) && (index is LiteralExpressionSyntax || index is IdentifierNameSyntax)
                && Arguments.TryGetValue(("Be", 0), out ExpressionSyntax expectedItem) && (expectedItem is LiteralExpressionSyntax || expectedItem is IdentifierNameSyntax);

            public ElementAtIndexShouldBeSyntaxVisitor() : base("ElementAt", "Should", "Be")
            {
            }

            public override ImmutableDictionary<string, string> ToDiagnosticProperties()
                => base.ToDiagnosticProperties()
                .Add(Constants.DiagnosticProperties.ArgumentString, Arguments[("ElementAt", 0)].ToFullString())
                .Add(Constants.DiagnosticProperties.ExpectedItemString, Arguments[("Be", 0)].ToFullString());
        }
        public class IndexerShouldBeSyntaxVisitor : FluentAssertionsWithArgumentsCSharpSyntaxVisitor
        {
            protected override bool AreArgumentsValid() =>
                Arguments.TryGetValue(("[]", 0), out ExpressionSyntax index) && (index is LiteralExpressionSyntax || index is IdentifierNameSyntax)
                && Arguments.TryGetValue(("Be", 0), out ExpressionSyntax expectedItem) && (expectedItem is LiteralExpressionSyntax || expectedItem is IdentifierNameSyntax);

            public IndexerShouldBeSyntaxVisitor() : base("[]", "Should", "Be")
            {
            }
            public override ImmutableDictionary<string, string> ToDiagnosticProperties()
                => base.ToDiagnosticProperties()
                .Add(Constants.DiagnosticProperties.ArgumentString, Arguments[("[]", 0)].ToFullString())
                .Add(Constants.DiagnosticProperties.ExpectedItemString, Arguments[("Be", 0)].ToFullString());
        }

        public class SkipFirstShouldBeSyntaxVisitor : FluentAssertionsWithArgumentsCSharpSyntaxVisitor
        {
            protected override bool AreArgumentsValid() =>
                Arguments.TryGetValue(("Skip", 0), out ExpressionSyntax index) && (index is LiteralExpressionSyntax || index is IdentifierNameSyntax)
                && Arguments.TryGetValue(("Be", 0), out ExpressionSyntax expectedItem) && (expectedItem is LiteralExpressionSyntax || expectedItem is IdentifierNameSyntax);

            public SkipFirstShouldBeSyntaxVisitor() : base("Skip", "First", "Should", "Be")
            {
            }

            public override ImmutableDictionary<string, string> ToDiagnosticProperties()
                => base.ToDiagnosticProperties()
                .Add(Constants.DiagnosticProperties.ArgumentString, Arguments[("Skip", 0)].ToFullString())
                .Add(Constants.DiagnosticProperties.ExpectedItemString, Arguments[("Be", 0)].ToFullString());
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldHaveElementAtCodeFix)), Shared]
    public class CollectionShouldHaveElementAtCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldHaveElementAtAnalyzer.DiagnosticId);
        
        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            if (properties.VisitorName == nameof(CollectionShouldHaveElementAtAnalyzer.ElementAtIndexShouldBeSyntaxVisitor))
            {
                var remove = NodeReplacement.RemoveAndExtractArguments("ElementAt");
                var newStatement = GetNewExpression(expression, remove);

                return GetNewExpression(newStatement, NodeReplacement.RenameAndPrependArguments("Be", "HaveElementAt", remove.Arguments));
            }
            else if (properties.VisitorName == nameof(CollectionShouldHaveElementAtAnalyzer.IndexerShouldBeSyntaxVisitor))
            {
                var remove = NodeReplacement.RemoveAndRetrieveIndexerArguments("Should");
                var newStatement = GetNewExpression(expression, remove);

                return GetNewExpression(newStatement, NodeReplacement.RenameAndPrependArguments("Be", "HaveElementAt", remove.Arguments));
            }
            else if (properties.VisitorName == nameof(CollectionShouldHaveElementAtAnalyzer.SkipFirstShouldBeSyntaxVisitor))
            {
                var remove = NodeReplacement.RemoveAndExtractArguments("Skip");
                var newStatement = GetNewExpression(expression, remove, NodeReplacement.Remove("First"));

                return GetNewExpression(newStatement, NodeReplacement.RenameAndPrependArguments("Be", "HaveElementAt", remove.Arguments));
            }
            throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}
