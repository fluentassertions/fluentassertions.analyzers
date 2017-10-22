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
    public class CollectionShouldHaveCountLessOrEqualToAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldHaveCountLessOrEqualTo;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .HaveCountLessOrEqualTo() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new CountShouldBeLessOrEqualToSyntaxVisitor();
            }
        }
        private class CountShouldBeLessOrEqualToSyntaxVisitor : FluentAssertionsWithArgumentCSharpSyntaxVisitor
        {
            protected override string MethodContainingArgument => "BeLessOrEqualTo";
            public CountShouldBeLessOrEqualToSyntaxVisitor() : base("Count", "Should", "BeLessOrEqualTo")
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldHaveCountLessOrEqualToCodeFix)), Shared]
    public class CollectionShouldHaveCountLessOrEqualToCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldHaveCountLessOrEqualToAnalyzer.DiagnosticId);
        
        protected override StatementSyntax GetNewStatement(ExpressionStatementSyntax statement, FluentAssertionsDiagnosticProperties properties)
        {
            return GetNewStatement(statement, NodeReplacement.Remove("Count"), NodeReplacement.Rename("BeLessOrEqualTo", "HaveCountLessOrEqualTo"));
        }
    }
}