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
    public class DictionaryShouldContainKeyAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Dictionaries.DictionaryShouldContainKey;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by ### instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors
        {
            get
            {
                yield return (new DictionaryShouldContainKeySyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("###", 0));
            }
        }

		private class DictionaryShouldContainKeySyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public DictionaryShouldContainKeySyntaxVisitor() : base("###", "Should")
			{
			}
		}
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(DictionaryShouldContainKeyCodeFix)), Shared]
    public class DictionaryShouldContainKeyCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(DictionaryShouldContainKeyAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(FluentAssertionsDiagnosticProperties properties)
            => SyntaxFactory.ParseStatement($"{properties.VariableName}.Should().###;");
    }
}