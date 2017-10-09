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
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new AnyShouldBeFalseSyntaxVisitor();
                yield return new ShouldHaveCount0SyntaxVisitor();
            }
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
        private class ShouldHaveCount0SyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            private bool _foundHaveCount0 = false;

            public override bool IsValid => base.IsValid && _foundHaveCount0;

            public ShouldHaveCount0SyntaxVisitor() : base("Should", "HaveCount")
            {
            }

            public override void VisitArgument(ArgumentSyntax node)
            {
                // the Should method has no arguments so we must be inside HaveCount
                if (RequiredMethods.Count == 0
                    && node.Expression is LiteralExpressionSyntax literal
                    && literal.Token.Value is int argument)
                {
                    _foundHaveCount0 = argument == 0;
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
