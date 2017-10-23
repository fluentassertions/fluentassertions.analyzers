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
    public class CollectionShouldBeInDescendingOrderAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldBeInDescendingOrder;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .BeInDescendingOrder() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new OrderByDescendingShouldEqualSyntaxVisitor();
            }
        }
        private class OrderByDescendingShouldEqualSyntaxVisitor : FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor
        {
            private bool _argumentIsSelf;
            protected override string MethodContainingLambda => "OrderByDescending";

            public override bool IsValid => base.IsValid && _argumentIsSelf;

            public OrderByDescendingShouldEqualSyntaxVisitor() : base("OrderByDescending", "Should", "Equal")
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

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldBeInDescendingOrderCodeFix)), Shared]
    public class CollectionShouldBeInDescendingOrderCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldBeInDescendingOrderAnalyzer.DiagnosticId);
        
        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            var remove = NodeReplacement.RemoveAndExtractArguments("OrderByDescending");
            var newStatement = GetNewExpression(expression, remove);

            newStatement = GetNewExpression(newStatement, NodeReplacement.RenameAndRemoveFirstArgument("Equal", "BeInDescendingOrder"));

            return GetNewExpression(newStatement, NodeReplacement.PrependArguments("BeInDescendingOrder", remove.Arguments));
        }
    }
}
