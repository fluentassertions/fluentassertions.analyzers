using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class StringShouldNotBeNullOrWhiteSpaceAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Strings.StringShouldNotBeNullOrWhiteSpace;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should() followed by .NotBeNullOrWhiteSpace() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield break;
                yield return new StringShouldNotBeNullOrWhiteSpaceSyntaxVisitor();
            }
        }

		public class StringShouldNotBeNullOrWhiteSpaceSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
		{
			public StringShouldNotBeNullOrWhiteSpaceSyntaxVisitor() : base()
			{
			}
            public override bool IsValid(ExpressionSyntax expression) => false;
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(StringShouldNotBeNullOrWhiteSpaceCodeFix)), Shared]
    public class StringShouldNotBeNullOrWhiteSpaceCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(StringShouldNotBeNullOrWhiteSpaceAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
			return null;
		}
    }
}