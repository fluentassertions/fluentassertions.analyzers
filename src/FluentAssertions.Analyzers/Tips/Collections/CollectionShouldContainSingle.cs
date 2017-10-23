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
    public class CollectionShouldContainSingleAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldContainSingle;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .ContainSingle() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new WhereShouldHaveCount1SyntaxVisitor();
                yield return new ShouldHaveCount1SyntaxVisitor();
            }
        }

        public class WhereShouldHaveCount1SyntaxVisitor : FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor
        {
            private bool _haveCountMethodHas1Argument;

            protected override string MethodContainingLambda => "Where";
            public override bool IsValid => base.IsValid && _haveCountMethodHas1Argument;
            public WhereShouldHaveCount1SyntaxVisitor() : base("Where", "Should", "HaveCount")
            {
            }

            public override void VisitArgumentList(ArgumentListSyntax node)
            {
                if (!node.Arguments.Any()) return;
                if (CurrentMethod != "HaveCount")
                {
                    base.VisitArgumentList(node);
                    return;
                }

                _haveCountMethodHas1Argument =
                    node.Arguments[0].Expression is LiteralExpressionSyntax literal
                    && literal.Token.Value is int argument
                    && argument == 1;
            }
        }
        public class ShouldHaveCount1SyntaxVisitor : FluentAssertionsWithArgumentCSharpSyntaxVisitor
        {
            protected override string MethodContainingArgument => "HaveCount";
            public ShouldHaveCount1SyntaxVisitor() : base("Should", "HaveCount")
            {
            }

            protected override ExpressionSyntax ModifyArgument(ExpressionSyntax expression)
            {
                if (expression is LiteralExpressionSyntax literal
                    && literal.Token.Value is int argument
                    && argument == 1)
                {
                    return expression;
                }
                return null;
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldContainSingleCodeFix)), Shared]
    public class CollectionShouldContainSingleCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldContainSingleAnalyzer.DiagnosticId);
        
        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            var newStatement = GetNewExpression(expression, NodeReplacement.RenameAndRemoveFirstArgument("HaveCount", "ContainSingle"));
            if (properties.VisitorName == nameof(CollectionShouldContainSingleAnalyzer.ShouldHaveCount1SyntaxVisitor))
            {
                return newStatement;
            }
            else if (properties.VisitorName == nameof(CollectionShouldContainSingleAnalyzer.WhereShouldHaveCount1SyntaxVisitor))
            {
                var remove = NodeReplacement.RemoveAndExtractArguments("Where");
                newStatement = GetNewExpression(newStatement, remove);

                return GetNewExpression(newStatement, NodeReplacement.PrependArguments("ContainSingle", remove.Arguments));
            }
            throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}
