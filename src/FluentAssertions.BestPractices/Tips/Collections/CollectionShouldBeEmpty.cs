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
    public class CollectionShouldBeEmptyAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionsShouldBeEmpty;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .BeEmpty() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors
        {
            get
            {
                yield return (new AnyShouldBeFalseSyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("BeFalse", 0));
                yield return (new ShouldHaveCount0SyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("HaveCount", 1));
            }
        }

        private class AnyShouldBeFalseSyntaxVisitor : FluentAssertionsWithoutLambdaArgumentCSharpSyntaxVisitor
        {
            protected override string MathodNotContainingLambda => "Any";

            public AnyShouldBeFalseSyntaxVisitor() : base("Any", "Should", "BeFalse")
            {
            }
        }
        private class ShouldHaveCount0SyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            private bool _haveCountMethodHas0Argument;

            public override bool IsValid => base.IsValid && _haveCountMethodHas0Argument;

            public ShouldHaveCount0SyntaxVisitor() : base("Should", "HaveCount")
            {
            }

            public override void VisitArgumentList(ArgumentListSyntax node)
            {
                if (!node.Arguments.Any()) return;

                _haveCountMethodHas0Argument = !_haveCountMethodHas0Argument
                    && CurrentMethod == "HaveCount"
                    && node.Arguments[0].Expression is LiteralExpressionSyntax literal
                    && literal.Token.Value is int argument
                    && argument == 0;
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldBeEmptyCodeFix)), Shared]
    public class CollectionShouldBeEmptyCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldBeEmptyAnalyzer.DiagnosticId);
        
        protected override StatementSyntax GetNewStatement(FluentAssertionsDiagnosticProperties properties)
            => SyntaxFactory.ParseStatement($"{properties.VariableName}.Should().BeEmpty({properties.BecauseArgumentsString});");
    } 
}
