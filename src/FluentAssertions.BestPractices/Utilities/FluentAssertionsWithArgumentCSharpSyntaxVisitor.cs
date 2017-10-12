using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.BestPractices
{
    public abstract class FluentAssertionsWithArgumentCSharpSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        protected abstract string MethodContainingArgument { get; }
        protected ExpressionSyntax Argument { get; set; }

        protected virtual ExpressionSyntax ModifyArgument(ExpressionSyntax expression) => expression;

        protected FluentAssertionsWithArgumentCSharpSyntaxVisitor(params string[] requiredMethods) : base(requiredMethods)
        {
        }

        public override ImmutableDictionary<string, string> ToDiagnosticProperties()
            => base.ToDiagnosticProperties().Add(Constants.DiagnosticProperties.ArgumentString, Argument.ToFullString());

        public override bool IsValid => base.IsValid && Argument != null;

        public override void VisitArgumentList(ArgumentListSyntax node)
        {
            if (!node.Arguments.Any()) return;
            if (CurrentMethod != MethodContainingArgument) return;

            Argument = ModifyArgument(node.Arguments[0].Expression);
        }
    }
}
