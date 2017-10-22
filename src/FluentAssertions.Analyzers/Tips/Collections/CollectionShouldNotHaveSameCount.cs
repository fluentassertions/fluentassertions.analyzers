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
    public class CollectionShouldNotHaveSameCountAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Collections.CollectionShouldNotHaveSameCount;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .NotHaveSameCount() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new CountShouldNotBeOtherCollectionCountSyntaxVisitor();
            }
        }
        private class CountShouldNotBeOtherCollectionCountSyntaxVisitor : FluentAssertionsWithArgumentCSharpSyntaxVisitor
        {
            protected override string MethodContainingArgument => "NotBe";
            public CountShouldNotBeOtherCollectionCountSyntaxVisitor() : base("Count", "Should", "NotBe")
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

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionShouldNotHaveSameCountCodeFix)), Shared]
    public class CollectionShouldNotHaveSameCountCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionShouldNotHaveSameCountAnalyzer.DiagnosticId);
        
        protected override StatementSyntax GetNewStatement(ExpressionStatementSyntax statement, FluentAssertionsDiagnosticProperties properties)
        {
            return GetNewStatement(statement, NodeReplacement.Remove("Count"), new NodeReplacement.RenameAndRemoveInvocationOfMethodOnFirstArgumentNodeReplacement("NotBe", "NotHaveSameCount"));
        }
    }
}
