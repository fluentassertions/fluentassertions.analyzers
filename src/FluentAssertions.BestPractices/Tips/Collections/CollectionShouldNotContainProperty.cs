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
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new AnyShouldBeFalseSyntaxVisitor();
                yield return new WhereShouldBeEmptySyntaxVisitor();
                yield return new ShouldOnlyContainNotSyntaxVisitor();
            }
        }

        public class AnyShouldBeFalseSyntaxVisitor : FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor
        {
            protected override string MethodContainingLambda => "Any";
            public AnyShouldBeFalseSyntaxVisitor() : base("Any", "Should", "BeFalse")
            {
            }
        }

        public class WhereShouldBeEmptySyntaxVisitor : FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor
        {
            protected override string MethodContainingLambda => "Where";
            public WhereShouldBeEmptySyntaxVisitor() : base("Where", "Should", "BeEmpty")
            {
            }
        }

        public class ShouldOnlyContainNotSyntaxVisitor : FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor
        {
            protected override string MethodContainingLambda => "OnlyContain";
            public override SimpleLambdaExpressionSyntax Lambda => ReverseLambda(base.Lambda);

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
        
        protected override StatementSyntax GetNewStatement(ExpressionStatementSyntax statement, FluentAssertionsDiagnosticProperties properties)
        {
            if (properties.VisitorName == nameof(CollectionShouldNotContainPropertyAnalyzer.AnyShouldBeFalseSyntaxVisitor))
            {
                var remove = new NodeReplacement.RemoveAndExtractArgumentsNodeReplacement("Any");
                var newStatement = GetNewStatement(statement, remove);

                return GetNewStatement(newStatement, NodeReplacement.RenameAndPrependArguments("BeFalse", "NotContain", remove.Arguments));
            }
            else if (properties.VisitorName == nameof(CollectionShouldNotContainPropertyAnalyzer.WhereShouldBeEmptySyntaxVisitor))
            {
                var remove = new NodeReplacement.RemoveAndExtractArgumentsNodeReplacement("Where");
                var newStatement = GetNewStatement(statement, remove);

                return GetNewStatement(newStatement, NodeReplacement.RenameAndPrependArguments("BeEmpty", "NotContain", remove.Arguments));
            }
            else if (properties.VisitorName == nameof(CollectionShouldNotContainPropertyAnalyzer.ShouldOnlyContainNotSyntaxVisitor))
            {
                return GetNewStatement(statement, NodeReplacement.RenameAndNegateLambda("OnlyContain", "NotContain"));
            }
            throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}
