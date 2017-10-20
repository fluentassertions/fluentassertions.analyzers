using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
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

        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new AnyShouldBeTrueSyntaxVisitor();
            }
        }

        private class AnyShouldBeTrueSyntaxVisitor : FluentAssertionsWithoutLambdaArgumentCSharpSyntaxVisitor
        {
            protected override string MathodNotContainingLambda => "Any";

            public AnyShouldBeTrueSyntaxVisitor() : base("Any", "Should", "BeTrue")
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldNotBeEmptyCodeFix)), Shared]
    public class CollectionShouldNotBeEmptyCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldNotBeEmptyAnalyzer.DiagnosticId);
        
        protected override StatementSyntax GetNewStatement(ExpressionStatementSyntax statement, FluentAssertionsDiagnosticProperties properties)
        {
            NodeReplacement[] replacements =
            {
                new NodeReplacement.RemoveNodeReplacement("Any"),
                new NodeReplacement.RenameNodeReplacement("BeTrue", "NotBeEmpty")
            };

            return GetNewStatement(statement, replacements);
        }
    }
}
