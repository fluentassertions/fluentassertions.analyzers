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
    public class CollectionShouldNotContainPropertyAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldNotContainProperty;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .NotContain() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors
        {
            get
            {
                yield return (new AnyShouldBeFalseSyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("BeFalse", 0));
                yield return (new WhereShouldBeEmptySyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("BeEmpty", 0));
                yield return (new ShouldOnlyContainNotSyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("OnlyContain", 1));
            }
        }

        private class AnyShouldBeFalseSyntaxVisitor : FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor
        {
            protected override string MethodContainingLambda => "Any";
            public AnyShouldBeFalseSyntaxVisitor() : base("Any", "Should", "BeFalse")
            {
            }
        }
        private class WhereShouldBeEmptySyntaxVisitor : FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor
        {
            protected override string MethodContainingLambda => "Where";
            public WhereShouldBeEmptySyntaxVisitor() : base("Where", "Should", "BeEmpty")
            {
            }
        }
        // actual.Should().OnlyContain(e => !e.BooleanProperty{0});
        private class ShouldOnlyContainNotSyntaxVisitor : FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor
        {
            protected override string MethodContainingLambda => "OnlyContain";
            protected override SimpleLambdaExpressionSyntax Lambda => ReverseLambda(base.Lambda);

            public ShouldOnlyContainNotSyntaxVisitor() : base("Should", "OnlyContain")
            {
            }

            private SimpleLambdaExpressionSyntax ReverseLambda(SimpleLambdaExpressionSyntax lambda)
            {
                if (lambda.Body is PrefixUnaryExpressionSyntax prefixUnary && prefixUnary.OperatorToken.IsKind(SyntaxKind.ExclamationToken))
                {
                    return lambda.WithBody(prefixUnary.Operand);
                }

                return lambda;
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldNotContainPropertyCodeFix)), Shared]
    public class CollectionShouldNotContainPropertyCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldNotContainPropertyAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(FluentAssertionsDiagnosticProperties properties)
            => SyntaxFactory.ParseStatement($"{properties.VariableName}.Should().NotContain({properties.CombineWithBecauseArgumentsString(properties.LambdaString)});");
    }
}
