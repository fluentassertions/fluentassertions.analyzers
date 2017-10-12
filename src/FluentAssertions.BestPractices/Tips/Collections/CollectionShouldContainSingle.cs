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
    public class CollectionShouldContainSingleAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldContainSingle;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by ContainSingle() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors {
            get
            {
               yield return (new ShouldHaveCount1SyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("HaveCount", 1));
            }
        }

        private class ShouldHaveCount1SyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            private bool _haveCountMethodHas0Argument;

            public override bool IsValid => base.IsValid && _haveCountMethodHas0Argument;

            public ShouldHaveCount1SyntaxVisitor() : base("Should", "HaveCount")
            {
            }

            public override void VisitArgumentList(ArgumentListSyntax node)
            {
                if (!node.Arguments.Any()) return;
                if (CurrentMethod != "HaveCount") return;

                _haveCountMethodHas0Argument =
                    node.Arguments[0].Expression is LiteralExpressionSyntax literal
                    && literal.Token.Value is int argument
                    && argument == 1;
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldContainSingleCodeFix)), Shared]
    public class CollectionShouldContainSingleCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldContainSingleAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(FluentAssertionsDiagnosticProperties properties)
            => SyntaxFactory.ParseStatement($"{properties.VariableName}.Should().ContainSingle({properties.BecauseArgumentsString});");
    }
}
