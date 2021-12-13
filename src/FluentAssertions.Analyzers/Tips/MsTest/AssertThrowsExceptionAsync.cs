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
    public class AssertThrowsExceptionAsyncAnalyzer : MsTestAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.MsTest.AssertThrowsExceptionAsync;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().ThrowExactlyAsync<TException>() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new AssertThrowsExceptionAsyncSyntaxVisitor();
            }
        }

        public class AssertThrowsExceptionAsyncSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public AssertThrowsExceptionAsyncSyntaxVisitor() : base(new MemberValidator("ThrowsExceptionAsync"))
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertThrowsExceptionAsyncCodeFix)), Shared]
    public class AssertThrowsExceptionAsyncCodeFix : MsTestCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertThrowsExceptionAsyncAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
            => RenameMethodAndReplaceWithSubjectShould(expression, "ThrowsExceptionAsync", "ThrowExactlyAsync", "Assert");
    }
}