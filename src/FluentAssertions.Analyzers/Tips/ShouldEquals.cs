using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
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

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ShouldEqualsBeCodeFix)), Shared]
    public class ShouldEqualsBeCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(ShouldEqualsAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties) 
            => GetNewExpression(expression, NodeReplacement.Rename("Equals", "Be"));

        protected override async Task<bool> CanRewriteAssertion(ExpressionSyntax expression, CodeFixContext context)
        {
            var model = await context.Document.GetSemanticModelAsync(context.CancellationToken).ConfigureAwait(false);

            var visitor = new MemberAccessExpressionsCSharpSyntaxVisitor();
            expression.Accept(visitor);

            var member = visitor.Members[visitor.Members.Count - 1];
            var info = model.GetTypeInfo(member.Expression);

            var ienumerableInfo = model.Compilation.GetTypeByMetadataName(typeof(IEnumerable).FullName);
            var stringInfo = model.Compilation.GetTypeByMetadataName(typeof(string).FullName);

            return info.Type.Equals(stringInfo) || !info.Type.AllInterfaces.Contains(ienumerableInfo);
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ShouldEqualsEqualCodeFix)), Shared]
    public class ShouldEqualsEqualCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(ShouldEqualsAnalyzer.DiagnosticId);

        protected override async Task<bool> CanRewriteAssertion(ExpressionSyntax expression, CodeFixContext context)
        {
            var model = await context.Document.GetSemanticModelAsync(context.CancellationToken).ConfigureAwait(false);

            var visitor = new MemberAccessExpressionsCSharpSyntaxVisitor();
            expression.Accept(visitor);

            var member = visitor.Members[visitor.Members.Count - 1];
            var info = model.GetTypeInfo(member.Expression);

            var ienumerableInfo = model.Compilation.GetTypeByMetadataName(typeof(IEnumerable).FullName);
            var stringInfo = model.Compilation.GetTypeByMetadataName(typeof(string).FullName);

            return !info.Type.Equals(stringInfo) && info.Type.AllInterfaces.Contains(ienumerableInfo);
        }

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
            => GetNewExpression(expression, NodeReplacement.Rename("Equals", "Equal"));
    }
}
