using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.BestPractices
{

    public abstract class FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor : FluentAssertionsWithArgumentsCSharpSyntaxVisitor
    {
        protected virtual SimpleLambdaExpressionSyntax Lambda => Arguments[(MethodContainingLambda, 0)] as SimpleLambdaExpressionSyntax;

        protected abstract string MethodContainingLambda { get; }

        public override bool IsValid => base.IsValid && Lambda != null;
        protected override bool AreArgumentsValid => Arguments.TryGetValue((MethodContainingLambda, 0), out var lambda) && lambda is SimpleLambdaExpressionSyntax;

        protected FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor(params string[] requiredMethods) : base(requiredMethods)
        {
        }

        public override ImmutableDictionary<string, string> ToDiagnosticProperties()
            => base.ToDiagnosticProperties().Add(Constants.DiagnosticProperties.LambdaString, Lambda.ToFullString());
    }
}
