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
    public class DictionaryShouldContainKeyAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Dictionaries.DictionaryShouldContainKey;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .ContainKey() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new ContainsKeyShouldBeTrue();
            }
        }

		private class ContainsKeyShouldBeTrue : FluentAssertionsCSharpSyntaxVisitor
		{
			public ContainsKeyShouldBeTrue() : base("ContainsKey", "Should", "BeTrue")
			{
			}
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(DictionaryShouldContainKeyCodeFix)), Shared]
    public class DictionaryShouldContainKeyCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(DictionaryShouldContainKeyAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(ExpressionStatementSyntax statement, FluentAssertionsDiagnosticProperties properties)
        {
            var remove = NodeReplacement.RemoveAndExtractArguments("ContainsKey");
            var newStatement = GetNewStatement(statement, remove);

            return GetNewStatement(newStatement, NodeReplacement.RenameAndPrependArguments("BeTrue", "ContainKey", remove.Arguments));
        }
    }
}