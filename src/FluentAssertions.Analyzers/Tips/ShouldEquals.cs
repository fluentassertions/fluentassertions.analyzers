using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FluentAssertions.Analyzers.Tips
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ShouldEqualsAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.CodeSmell.ShouldEquals;
        public const string Category = Constants.CodeSmell.Category;
        public const string Message = ".Should().Equals() is not an assertion, it just calls the native Object.Equals method.\n"
            + "Use .Should().Equal() for collections or .Should().Be() for other types";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new ShouldEqualsSyntaxVisitor();
            }
        }

        public class ShouldEqualsSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldEqualsSyntaxVisitor() : base(MemberValidator.Should, new MemberValidator("Equals"))
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ShouldEqualsCodeFix)), Shared]
    public class ShouldEqualsCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(ShouldEqualsAnalyzer.DiagnosticId);

        protected override async Task<bool> CanRewriteAssertion(ExpressionSyntax expression, CodeFixContext context)
        {
            var model = await context.Document.GetSemanticModelAsync(context.CancellationToken).ConfigureAwait(false);

            var visitor = new MemberAccessExpressionsCSharpSyntaxVisitor();
            expression.Accept(visitor);

            var member = visitor.Members[visitor.Members.Count - 1];
            var info = model.GetTypeInfo(member.Expression);

            var taskCompletionSourceInfo = model.Compilation.GetTypeByMetadataName(typeof(TaskCompletionSource<>).FullName);
            if (info.Type.Equals(taskCompletionSourceInfo)) return false;

            var streamInfo = model.Compilation.GetTypeByMetadataName(typeof(Stream).FullName);
            if (info.Type.AllInterfaces.Contains(streamInfo)) return false;

            return true;
        }

        protected override async Task<ExpressionSyntax> GetNewExpressionAsync(ExpressionSyntax expression, Document document, FluentAssertionsDiagnosticProperties properties, CancellationToken cancellationToken)
        {
            var model = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);

            var visitor = new MemberAccessExpressionsCSharpSyntaxVisitor();
            expression.Accept(visitor);

            var member = visitor.Members[visitor.Members.Count - 1];
            var info = model.GetTypeInfo(member.Expression);

            var stringInfo = model.Compilation.GetTypeByMetadataName(typeof(string).FullName);

            if (info.Type.Equals(stringInfo))
            {
                return GetNewExpression(expression, NodeReplacement.Rename("Equals", "Be"));
            }

            var ienumerableInfo = model.Compilation.GetTypeByMetadataName(typeof(IEnumerable).FullName);
            if (info.Type.AllInterfaces.Contains(ienumerableInfo))
            {
                return GetNewExpression(expression, NodeReplacement.Rename("Equals", "Equal"));
            }

            return GetNewExpression(expression, NodeReplacement.Rename("Equals", "Be"));
        }
    }
}
