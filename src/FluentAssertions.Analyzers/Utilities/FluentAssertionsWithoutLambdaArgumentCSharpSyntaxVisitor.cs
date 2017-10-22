using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers
{
    public abstract class FluentAssertionsWithoutLambdaArgumentCSharpSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        private bool _methodHasLambdaArgument;

        public override bool IsValid => base.IsValid && !_methodHasLambdaArgument;
        protected abstract string MathodNotContainingLambda { get; }

        protected FluentAssertionsWithoutLambdaArgumentCSharpSyntaxVisitor(params string[] requiredMethods) : base(requiredMethods)
        {
        }

        public override void VisitArgumentList(ArgumentListSyntax node)
        {
            if (!node.Arguments.Any()) return;
            if (CurrentMethod != MathodNotContainingLambda) return;

            _methodHasLambdaArgument = node.Arguments[0].Expression is SimpleLambdaExpressionSyntax;
        }
    }
}
