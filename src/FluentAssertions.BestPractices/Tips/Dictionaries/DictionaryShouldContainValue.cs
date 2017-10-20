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
    public class DictionaryShouldContainValueAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Dictionaries.DictionaryShouldContainValue;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .ContainValue() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new ContainsValueShouldBeTrue();
            }
        }

        private class ContainsValueShouldBeTrue : FluentAssertionsCSharpSyntaxVisitor
        {
            public ContainsValueShouldBeTrue() : base("ContainsValue", "Should", "BeTrue")
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(DictionaryShouldContainValueCodeFix)), Shared]
    public class DictionaryShouldContainValueCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(DictionaryShouldContainValueAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(ExpressionStatementSyntax statement, FluentAssertionsDiagnosticProperties properties)
        {
            var remove = NodeReplacement.RemoveAndExtractArguments("ContainsValue");
            var newStatement = GetNewStatement(statement, remove);

            return GetNewStatement(newStatement, NodeReplacement.RenameAndPrependArguments("BeTrue", "ContainValue", remove.Arguments));
        }
    }
}