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
    public class CollectionShouldHaveSameCountAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldHaveSameCount;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .HaveSameCount() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new ShouldHaveCountOtherCollectionCountSyntaxVisitor();
            }
        }

        private class ShouldHaveCountOtherCollectionCountSyntaxVisitor : FluentAssertionsWithArgumentCSharpSyntaxVisitor
        {
            protected override string MethodContainingArgument => "HaveCount";
            public ShouldHaveCountOtherCollectionCountSyntaxVisitor() : base("Should", "HaveCount")
            {
            }

            protected override ExpressionSyntax ModifyArgument(ExpressionSyntax expression)
            {
                var invocation = expression as InvocationExpressionSyntax;
                var memberAccess = invocation?.Expression as MemberAccessExpressionSyntax;
                var identifier = memberAccess?.Expression as IdentifierNameSyntax;

                return identifier;
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldHaveSameCountCodeFix)), Shared]
    public class CollectionShouldHaveSameCountCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldHaveSameCountAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            return GetNewExpression(expression, new NodeReplacement.RenameAndRemoveInvocationOfMethodOnFirstArgumentNodeReplacement("HaveCount", "HaveSameCount"));
        }
    }
}
