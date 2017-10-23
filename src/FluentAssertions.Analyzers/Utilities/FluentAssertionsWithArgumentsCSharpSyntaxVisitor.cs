using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace FluentAssertions.Analyzers
{
    public abstract class FluentAssertionsWithArgumentsCSharpSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        protected Dictionary<(string Method, int Index), ExpressionSyntax> Arguments { get; } = new Dictionary<(string Method, int Index), ExpressionSyntax>();


        private List<(string Method, SeparatedSyntaxList<ArgumentSyntax> Arguments)> MethodArguments { get; } = new List<(string Method, SeparatedSyntaxList<ArgumentSyntax> Arguments)>();
        protected string a;

        public override bool IsValid => base.IsValid && AreArgumentsValid();

        protected FluentAssertionsWithArgumentsCSharpSyntaxVisitor(params string[] requiredMethods) : base(requiredMethods)
        {
        }

        protected abstract bool AreArgumentsValid();

        public override void VisitArgumentList(ArgumentListSyntax node)
        {
            VisitArguments(node.Arguments);
        }
        public override void VisitBracketedArgumentList(BracketedArgumentListSyntax node)
        {
            VisitArguments(node.Arguments);
        }

        private void VisitArguments(SeparatedSyntaxList<ArgumentSyntax> arguments)
        {
            if (arguments.Any())
            {
                MethodArguments.Add((CurrentMethod, arguments));
                for (int i = 0; i < arguments.Count; i++)
                {
                    Arguments.Add((CurrentMethod, i), arguments[i].Expression);
                }
            }
        }
    }
}
