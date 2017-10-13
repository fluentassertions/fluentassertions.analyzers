using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.BestPractices
{

    public abstract class FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public string PredicateString { get; private set; }

        public override bool IsValid => base.IsValid && PredicateString != null;

        protected abstract string MathodContainingLambda { get; }

        protected FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor(params string[] requiredMethods) : base(requiredMethods)
        {
        }

        public override ImmutableDictionary<string, string> ToDiagnosticProperties()
            => base.ToDiagnosticProperties().Add(Constants.DiagnosticProperties.LambdaString, PredicateString);

        public override void VisitArgumentList(ArgumentListSyntax node)
        {
            if (!node.Arguments.Any()) return;
            if (CurrentMethod != MathodContainingLambda) return;

            if (node.Arguments[0].Expression is SimpleLambdaExpressionSyntax lambda)
            {
                PredicateString = lambda.ToFullString();
            }
        }
    }
}
