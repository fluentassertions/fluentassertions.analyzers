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
    public class CollectionShouldIntersectWithAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldIntersectWith;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by ### instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

        protected override Diagnostic AnalyzeExpressionStatement(ExpressionStatementSyntax statement)
        {
            return null;
            var visitor = new CollectionShouldIntersectWithSyntaxVisitor();
            statement.Accept(visitor);

            if (visitor.IsValid)
            {
                var properties = new Dictionary<string, string>
                {
                    [Constants.DiagnosticProperties.VariableName] = visitor.VariableName,
                    [Constants.DiagnosticProperties.Title] = Title
                }.ToImmutableDictionary();
				throw new System.NotImplementedException();

                return Diagnostic.Create(
                    descriptor: Rule,
                    location: statement.Expression.GetLocation(),
                    properties: properties,
                    messageArgs: visitor.VariableName);
            }
            return null;
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldIntersectWithCodeFix)), Shared]
    public class CollectionShouldIntersectWithCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldIntersectWithAnalyzer.DiagnosticId);

        protected override StatementSyntax GetNewStatement(ImmutableDictionary<string, string> properties)
        {
			throw new System.NotImplementedException();
		}
    }

    public class CollectionShouldIntersectWithSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public CollectionShouldIntersectWithSyntaxVisitor() : base("###")
        {
			throw new System.NotImplementedException();
        }
    }
}
