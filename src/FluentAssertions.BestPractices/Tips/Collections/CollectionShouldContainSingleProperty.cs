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
    public class CollectionShouldContainSinglePropertyAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldContainSingleProperty;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by ### instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors
        {
            get
            {
                yield return (new WhereShouldHaveCount1SyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("HaveCount", 1));
            }
        }
        // actual.Where(x => x.BooleanProperty).Should().HaveCount(1{0});
        private class WhereShouldHaveCount1SyntaxVisitor : FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor
        {
            private bool _haveCountMethodHas1Argument;

            protected override string MathodContainingLambda => "Where";
            public override bool IsValid => base.IsValid && _haveCountMethodHas1Argument;
            public WhereShouldHaveCount1SyntaxVisitor() : base("Where", "Should", "HaveCount")
            {
            }

            public override void VisitArgumentList(ArgumentListSyntax node)
            {
                if (!node.Arguments.Any()) return;
                if (CurrentMethod != "HaveCount") base.VisitArgumentList(node); ;

                _haveCountMethodHas1Argument =
                    node.Arguments[0].Expression is LiteralExpressionSyntax literal
                    && literal.Token.Value is int argument
                    && argument == 1;
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldContainSinglePropertyCodeFix)), Shared]
    public class CollectionShouldContainSinglePropertyCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldContainSinglePropertyAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(FluentAssertionsDiagnosticProperties properties)
            => SyntaxFactory.ParseStatement($"{properties.VariableName}.Should().ContainSingle({properties.CombineWithBecauseArgumentsString(properties.PredicateString)});");
    }
}
