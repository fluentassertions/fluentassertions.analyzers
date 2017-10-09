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
    public class CollectionShouldContainItemAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldContainItem;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .Contain() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

        protected override Diagnostic AnalyzeExpressionStatement(ExpressionStatementSyntax statement)
        {
            var visitor = new ContainsShouldBeTrueSyntaxVisitor();
            statement.Accept(visitor);

            if (visitor.IsValid)
            {
                var properties = new Dictionary<string, string>
                {
                    [Constants.DiagnosticProperties.VariableName] = visitor.VariableName,
                    [Constants.DiagnosticProperties.Title] = Title,
                    [Constants.DiagnosticProperties.ExpectedItemString] = visitor.ExpectedItemString
                }.ToImmutableDictionary();

                return Diagnostic.Create(
                    descriptor: Rule,
                    location: statement.Expression.GetLocation(),
                    properties: properties,
                    messageArgs: visitor.VariableName);
            }
            return null;
        }

        private class ContainsShouldBeTrueSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public string ExpectedItemString { get; private set; }
            public override bool IsValid => base.IsValid && ExpectedItemString != null;

            public ContainsShouldBeTrueSyntaxVisitor() : base("Contains", "Should", "BeTrue")
            {
            }

            public override void VisitArgument(ArgumentSyntax node)
            {
                if (RequiredMethods.Count == 0)
                {
                    ExpectedItemString = node.ToFullString();
                }
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldContainItemCodeFix)), Shared]
    public class CollectionShouldContainItemCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldContainItemAnalyzer.DiagnosticId);

        // actual.Should().Contain(expectedItem);
        protected override StatementSyntax GetNewStatement(ImmutableDictionary<string, string> properties)
            => SyntaxFactory.ParseStatement($"{properties[Constants.DiagnosticProperties.VariableName]}.Should().Contain({properties[Constants.DiagnosticProperties.ExpectedItemString]});");
    }
}
