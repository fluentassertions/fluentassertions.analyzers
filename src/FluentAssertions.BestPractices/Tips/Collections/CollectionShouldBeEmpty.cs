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

        protected override Diagnostic AnalyzeExpressionStatement(ExpressionStatementSyntax statement)
        {
            var visitors = new FluentAssertionsCSharpSyntaxVisitor[]
            {
                new ActualShouldHaveCount0SyntaxVisitor(),
                new AnyShouldBeFalseSyntaxVisitor()
            };

            foreach (var visitor in visitors)
            {
                statement.Accept(visitor);

                if (visitor.IsValid)
                {
                    var properties = new Dictionary<string, string>
                    {
                        [Constants.DiagnosticProperties.VariableName] = visitor.VariableName,
                        [Constants.DiagnosticProperties.Title] = Title
                    }.ToImmutableDictionary();

                    return Diagnostic.Create(
                        descriptor: Rule,
                        location: statement.Expression.GetLocation(),
                        properties: properties,
                        messageArgs: visitor.VariableName);
                }
            }
            return null;
        }

        private class AnyShouldBeFalseSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            private bool _anyMethodHasArgument = false;
            public override bool IsValid => base.IsValid && !_anyMethodHasArgument;

            public AnyShouldBeFalseSyntaxVisitor() : base("Any", "Should", "BeFalse")
            {
            }

            public override void VisitArgument(ArgumentSyntax node)
            {
                // empty RequiredMethods means we are in the Any method
                _anyMethodHasArgument = RequiredMethods.Count == 0 && node.Expression is SimpleLambdaExpressionSyntax;
            }
        }
        private class ActualShouldHaveCount0SyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            private const int HaveCountArgument = 0;

            private bool _foundHaveCountArgument = false;

            public override bool IsValid => base.IsValid && _foundHaveCountArgument;

            public ActualShouldHaveCount0SyntaxVisitor() : base("Should", "HaveCount")
            {
            }

            public override void VisitArgument(ArgumentSyntax node)
            {
                // the Should method has no arguments so we must be inside HaveCount
                if (RequiredMethods.Count == 0
                    && node.Expression is LiteralExpressionSyntax literal
                    && literal.Token.Value is int argument)
                {
                    _foundHaveCountArgument = argument == HaveCountArgument;
                }
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldBeEmptyCodeFix)), Shared]
    public class CollectionShouldBeEmptyCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldBeEmptyAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(ImmutableDictionary<string, string> properties)
            => SyntaxFactory.ParseStatement($"{properties[Constants.DiagnosticProperties.VariableName]}.Should().BeEmpty();");
    }
}
