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
    public class CollectionShouldNotBeEmptyAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionsShouldNotBeEmpty;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .NotBeEmpty() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

        protected override Diagnostic AnalyzeExpressionStatement(ExpressionStatementSyntax statement)
        {
            var visitor = new AnyShouldBeTrueSyntaxVisitor();
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
            return null;
        }

        private class AnyShouldBeTrueSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            private bool _anyMethodHasArgument = false;
            public override bool IsValid => base.IsValid && !_anyMethodHasArgument;

            public AnyShouldBeTrueSyntaxVisitor() : base("Any", "Should", "BeTrue")
            {
            }

            public override void VisitArgument(ArgumentSyntax node)
            {
                // empty RequiredMethods means we are in the Any method
                _anyMethodHasArgument = RequiredMethods.Count == 0 && node.Expression is SimpleLambdaExpressionSyntax;
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldNotBeEmptyCodeFix)), Shared]
    public class CollectionShouldNotBeEmptyCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldNotBeEmptyAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(ImmutableDictionary<string, string> properties)
            => SyntaxFactory.ParseStatement($"{properties[Constants.DiagnosticProperties.VariableName]}.Should().NotBeEmpty();");
    }
}
