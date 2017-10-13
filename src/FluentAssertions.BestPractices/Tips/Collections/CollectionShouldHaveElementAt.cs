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
    public class CollectionShouldHaveElementAtAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldHaveElementAt;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by ### instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors
        {
            get
            {
                yield return (new ElementAtIndexShouldBeSyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("Be", 1));
                yield return (new IndexerShouldBeSyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("Be", 1));
                yield return (new SkipFirstShouldBeSyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("Be", 1));
            }
        }

        private class ElementAtIndexShouldBeSyntaxVisitor : FluentAssertionsWithArgumentsCSharpSyntaxVisitor
        {
            protected override bool AreArgumentsValid =>
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
        private class IndexerShouldBeSyntaxVisitor : FluentAssertionsWithArgumentsCSharpSyntaxVisitor
        {
            protected override bool AreArgumentsValid =>
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

        private class SkipFirstShouldBeSyntaxVisitor : FluentAssertionsWithArgumentsCSharpSyntaxVisitor
        {
            protected override bool AreArgumentsValid =>
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

        // actual.Skip(k).First().Should().Be(expectedItem{0});
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldHaveElementAtCodeFix)), Shared]
    public class CollectionShouldHaveElementAtCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldHaveElementAtAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(FluentAssertionsDiagnosticProperties properties)
            => SyntaxFactory.ParseStatement($"{properties.VariableName}.Should().HaveElementAt({properties.ArgumentString}, {properties.CombineWithBecauseArgumentsString(properties.ExpectedItemString)});");
    }
}
