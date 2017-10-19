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
    public class CollectionShouldHaveCountGreaterOrEqualToAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldHaveCountGreaterOrEqualTo;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by ### instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors
        {
            get
            {
                yield return (new CountShouldBeGreaterOrEqualToSyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("BeGreaterOrEqualTo", 1));
            }
        }

        private class CountShouldBeGreaterOrEqualToSyntaxVisitor : FluentAssertionsWithArgumentCSharpSyntaxVisitor
        {
            protected override string MethodContainingArgument => "BeGreaterOrEqualTo";
            public CountShouldBeGreaterOrEqualToSyntaxVisitor() : base("Count", "Should", "BeGreaterOrEqualTo")
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldHaveCountGreaterOrEqualToCodeFix)), Shared]
    public class CollectionShouldHaveCountGreaterOrEqualToCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldHaveCountGreaterOrEqualToAnalyzer.DiagnosticId);
        
        protected override StatementSyntax GetNewStatement(ExpressionStatementSyntax statement, FluentAssertionsDiagnosticProperties properties)
        {
            return GetNewStatement(statement, new NodeReplacement.RemoveNodeReplacement("Count"), new NodeReplacement.RenameNodeReplacement("BeGreaterOrEqualTo", "HaveCountGreaterOrEqualTo"));
        }
    }
}
