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
    public class CollectionShouldHaveCountAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldHaveCount;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .HaveCount() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors
        {
            get
            {
                yield return (new CountShouldBeSyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("Be", 1));
            }
        }

        private class CountShouldBeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public string CountArgument { get; private set; }

            public override bool IsValid => base.IsValid && CountArgument != null;

            public CountShouldBeSyntaxVisitor() : base("Count", "Should", "Be")
            {
            }

            public override ImmutableDictionary<string, string> ToDiagnosticProperties()
                => base.ToDiagnosticProperties().Add(Constants.DiagnosticProperties.ArgumentString, CountArgument);

            public override void VisitArgumentList(ArgumentListSyntax node)
            {
                if (!node.Arguments.Any()) return;
                if (CurrentMethod != "Be") return;

                CountArgument = node.Arguments[0].ToFullString();
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldHaveCountCodeFix)), Shared]
    public class CollectionShouldHaveCountCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldHaveCountAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(FluentAssertionsDiagnosticProperties properties)
            => SyntaxFactory.ParseStatement($"{properties.VariableName}.Should().HaveCount({properties.CombineWithBecauseArgumentsString(properties.ArgumentString)});");
    }
}
