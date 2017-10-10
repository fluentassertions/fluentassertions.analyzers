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
    public class CollectionShouldHaveCountGreaterThanAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldHaveCountGreaterThan;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .BeGreaterThan() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors
        {
            get
            {
                yield return (new CountShouldBeGreaterThanSyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("BeGreaterThan", 1));
            }
        }

        private class CountShouldBeGreaterThanSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public string CountArgument { get; private set; }

            public override bool IsValid => base.IsValid && CountArgument != null;

            public CountShouldBeGreaterThanSyntaxVisitor() : base("Count", "Should", "BeGreaterThan")
            {
            }

            public override ImmutableDictionary<string, string> ToDiagnosticProperties()
                => base.ToDiagnosticProperties().Add(Constants.DiagnosticProperties.CountArgument, CountArgument);

            public override void VisitArgumentList(ArgumentListSyntax node)
            {
                if (!node.Arguments.Any()) return;
                if (CurrentMethod != "BeGreaterThan") return;

                CountArgument = node.Arguments[0].ToFullString();
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldHaveCountGreaterThanCodeFix)), Shared]
    public class CollectionShouldHaveCountGreaterThanCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldHaveCountGreaterThanAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(FluentAssertionsDiagnosticProperties properties)
            => SyntaxFactory.ParseStatement($"{properties.VariableName}.Should().HaveCountGreaterThan({properties.CombineWithBecauseArgumentsString(properties.CountArgument)});");
    }
}
