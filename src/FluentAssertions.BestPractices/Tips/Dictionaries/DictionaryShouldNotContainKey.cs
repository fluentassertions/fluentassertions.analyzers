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
    public class DictionaryShouldNotContainKeyAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Dictionaries.DictionaryShouldNotContainKey;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by ### instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors
        {
            get
            {
                yield return (new DictionaryShouldNotContainKeySyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("###", 0));
            }
        }

		private class DictionaryShouldNotContainKeySyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public DictionaryShouldNotContainKeySyntaxVisitor() : base("###", "Should")
			{
			}
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(DictionaryShouldNotContainKeyCodeFix)), Shared]
    public class DictionaryShouldNotContainKeyCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(DictionaryShouldNotContainKeyAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(FluentAssertionsDiagnosticProperties properties)
            => SyntaxFactory.ParseStatement($"{properties.VariableName}.Should().###;");
    }
}