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
    public class CollectionShouldNotContainItemAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldNotContainItem;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .NotContain() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
               yield return new ContainsShouldBeFalseSyntaxVisitor();
            }
        }

        private class ContainsShouldBeFalseSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public string UnexpectedItemString { get; private set; }
            public override bool IsValid => base.IsValid && UnexpectedItemString != null;

            public ContainsShouldBeFalseSyntaxVisitor() : base("Contains", "Should", "BeFalse")
            {
            }

            public override ImmutableDictionary<string, string> ToDiagnosticProperties() 
                => base.ToDiagnosticProperties().Add(Constants.DiagnosticProperties.UnexpectedItemString, UnexpectedItemString);

            public override void VisitArgumentList(ArgumentListSyntax node)
            {
                if (!node.Arguments.Any()) return;
                if (CurrentMethod != "Contains") return;

                UnexpectedItemString = node.Arguments[0].ToFullString();
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldNotContainItemCodeFix)), Shared]
    public class CollectionShouldNotContainItemCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldNotContainItemAnalyzer.DiagnosticId);
        
        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            var remove = new NodeReplacement.RemoveAndExtractArgumentsNodeReplacement("Contains");
            var newStatement = GetNewExpression(expression, remove);

            return GetNewExpression(newStatement, new NodeReplacement.RenameAndPrependArgumentsNodeReplacement("BeFalse", "NotContain", remove.Arguments));
        }
    }
}
