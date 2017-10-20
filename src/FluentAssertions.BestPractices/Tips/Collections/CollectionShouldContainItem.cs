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
    public class CollectionShouldContainItemAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldContainItem;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by Contain() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new ContainsShouldBeTrueSyntaxVisitor();
            }
        }

        private class ContainsShouldBeTrueSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public string ExpectedItemString { get; private set; }
            public override bool IsValid => base.IsValid && ExpectedItemString != null;

            public ContainsShouldBeTrueSyntaxVisitor() : base("Contains", "Should", "BeTrue")
            {
            }

            public override ImmutableDictionary<string, string> ToDiagnosticProperties()
                => base.ToDiagnosticProperties().Add(Constants.DiagnosticProperties.ExpectedItemString, ExpectedItemString);

            public override void VisitArgumentList(ArgumentListSyntax node)
            {
                if (!node.Arguments.Any()) return;
                if (CurrentMethod != "Contains") return;

                ExpectedItemString = node.Arguments[0].ToFullString();
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldContainItemCodeFix)), Shared]
    public class CollectionShouldContainItemCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldContainItemAnalyzer.DiagnosticId);
        
        protected override StatementSyntax GetNewStatement(ExpressionStatementSyntax statement, FluentAssertionsDiagnosticProperties properties)
        {
            var remove = new NodeReplacement.RemoveAndExtractArgumentsNodeReplacement("Contains");
            var newStatement = GetNewStatement(statement, remove);

            return GetNewStatement(newStatement, new NodeReplacement.RenameAndPrependArgumentsNodeReplacement("BeTrue", "Contain", remove.Arguments));
        }
    }
}
