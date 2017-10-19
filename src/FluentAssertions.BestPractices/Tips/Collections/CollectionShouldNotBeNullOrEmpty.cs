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
    public class CollectionShouldNotBeNullOrEmptyAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldNotBeNullOrEmpty;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .NotBeNullOrEmpty() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

        protected override IEnumerable<(FluentAssertionsCSharpSyntaxVisitor, BecauseArgumentsSyntaxVisitor)> Visitors
        {
            get
            {
                yield return (new ShouldNotBeNullAndNotBeEmptySyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("NotBeEmpty", 0));
                yield return (new ShouldNotBeEmptyAndNotBeNullSyntaxVisitor(), new BecauseArgumentsSyntaxVisitor("NotBeNull", 0));
            }
        }

        public class ShouldNotBeNullAndNotBeEmptySyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldNotBeNullAndNotBeEmptySyntaxVisitor() : base("Should", "NotBeNull", "And", "NotBeEmpty")
            {
            }
        }
        public class ShouldNotBeEmptyAndNotBeNullSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldNotBeEmptyAndNotBeNullSyntaxVisitor() : base("Should", "NotBeEmpty", "And", "NotBeNull")
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldNotBeNullOrEmptyCodeFix)), Shared]
    public class CollectionShouldNotBeNullOrEmptyCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldNotBeNullOrEmptyAnalyzer.DiagnosticId);

        protected override bool CanRewriteAssertion(ExpressionStatementSyntax statement)
        {
            var visitor = new MemberAccessExpressionsCSharpSyntaxVisitor();
            statement.Accept(visitor);

            var notBeEmpty = visitor.Members.Find(member => member.Name.Identifier.Text == "NotBeEmpty");
            var notBeNull = visitor.Members.Find(member => member.Name.Identifier.Text == "NotBeNull");

            return !(notBeEmpty.Parent is InvocationExpressionSyntax notBeEmptyInvocation && notBeEmptyInvocation.ArgumentList.Arguments.Any()
                && notBeNull.Parent is InvocationExpressionSyntax notBeNullInvocation && notBeNullInvocation.ArgumentList.Arguments.Any());
        }

        protected override StatementSyntax GetNewStatement(ExpressionStatementSyntax statement, FluentAssertionsDiagnosticProperties properties)
        {
            if (properties.VisitorName == nameof(CollectionShouldNotBeNullOrEmptyAnalyzer.ShouldNotBeNullAndNotBeEmptySyntaxVisitor))
            {
                var remove = NodeReplacement.RemoveAndExtractArguments("NotBeEmpty");
                var newStatement = GetNewStatement(statement, remove);

                return GetNewStatement(newStatement, NodeReplacement.RenameAndPrependArguments("NotBeNull", "NotBeNullOrEmpty", remove.Arguments));
            }
            else if (properties.VisitorName == nameof(CollectionShouldNotBeNullOrEmptyAnalyzer.ShouldNotBeEmptyAndNotBeNullSyntaxVisitor))
            {
                var remove = NodeReplacement.RemoveAndExtractArguments("NotBeNull");
                var newStatement = GetNewStatement(statement, remove);

                return GetNewStatement(newStatement, NodeReplacement.RenameAndPrependArguments("NotBeEmpty", "NotBeNullOrEmpty", remove.Arguments));
            }
            throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}
