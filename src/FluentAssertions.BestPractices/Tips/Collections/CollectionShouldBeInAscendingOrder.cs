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
    public class CollectionShouldBeInAscendingOrderAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldBeInAscendingOrder;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .BeInAscendingOrder() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors
        {
            get
            {
                yield return (new OrderByShouldEqualSyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("Equal", 1));
            }
        }
        private class OrderByShouldEqualSyntaxVisitor : FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor
        {
            private bool _argumentIsSelf;
            protected override string MethodContainingLambda => "OrderBy";

            public override bool IsValid => base.IsValid && _argumentIsSelf;

            public OrderByShouldEqualSyntaxVisitor() : base("OrderBy", "Should", "Equal")
            {
            }

            public override void VisitArgumentList(ArgumentListSyntax node)
            {
                if (!node.Arguments.Any()) return;
                if (CurrentMethod != "Equal")
                {
                    base.VisitArgumentList(node);
                    return;
                }

                _argumentIsSelf = node.Arguments[0].Expression is IdentifierNameSyntax identifier
                    && identifier.Identifier.Text == VariableName;
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldBeInAscendingOrderCodeFix)), Shared]
    public class CollectionShouldBeInAscendingOrderCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldBeInAscendingOrderAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(FluentAssertionsDiagnosticProperties properties)
            => SyntaxFactory.ParseStatement($"{properties.VariableName}.Should().BeInAscendingOrder({properties.CombineWithBecauseArgumentsString(properties.LambdaString)});");
    }
}
