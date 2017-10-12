using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.BestPractices
{
    public abstract class FluentAssertionsWithArgumentCSharpSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        protected abstract string MethodContainingArgument { get; }
        protected string ArgumentString { get; private set; }

        protected FluentAssertionsWithArgumentCSharpSyntaxVisitor(params string[] requiredMethods) : base(requiredMethods)
        {
        }

        public override ImmutableDictionary<string, string> ToDiagnosticProperties() 
            => base.ToDiagnosticProperties().Add(Constants.DiagnosticProperties.ArgumentString, ArgumentString);

        public override bool IsValid => base.IsValid && ArgumentString != null;

        public override void VisitArgumentList(ArgumentListSyntax node)
        {
            if (!node.Arguments.Any()) return;
            if (CurrentMethod != MethodContainingArgument) return;

            ArgumentString = node.Arguments[0].ToFullString();
        }
    }
}
