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

        public const string Message = "Use .Should().HaveElementAt() instead.";

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

        public class ElementAtIndexShouldBeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public ElementAtIndexShouldBeSyntaxVisitor() : base(new MemberValidator("ElementAt"), MemberValidator.Should, new MemberValidator("Be"))
            {
            }
        }

        public class IndexerShouldBeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public IndexerShouldBeSyntaxVisitor() : base(new MemberValidator("[]"), MemberValidator.Should, new MemberValidator("Be"))
            {
            }
        }

        public class SkipFirstShouldBeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public SkipFirstShouldBeSyntaxVisitor() : base(new MemberValidator("Skip"), MemberValidator.MathodNotContainingLambda("First"), MemberValidator.Should, new MemberValidator("Be"))
            {
            }
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
