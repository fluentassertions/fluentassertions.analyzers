using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace FluentAssertions.BestPractices
{

    public abstract class FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor : FluentAssertionsWithoutArgumentsCSharpSyntaxVisitor
    {
        public string PredicateString { get; private set; }

        public override bool IsValid => base.IsValid && PredicateString != null;

        public FluentAssertionsWithLambdaArgumentCSharpSyntaxVisitor(params string[] requiredMethods) : base(requiredMethods)
        {
        }

        public override void VisitArgumentList(ArgumentListSyntax node)
        {
            if (node.Arguments.Count == 1 && RequiredMethods.Count == 0)
            {
                base.Visit(node.Arguments[0]);
            }
        }

        public override void VisitArgument(ArgumentSyntax node)
        {
            if (node.Expression is SimpleLambdaExpressionSyntax lambda)
            {
                PredicateString = lambda.ToFullString();
            }
        }
    }
}
