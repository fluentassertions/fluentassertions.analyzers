using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace FluentAssertions.BestPractices
{

    public abstract class FluentAssertionsWithoutArgumentsCSharpSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        /// <summary>
        /// The order in the syntax tree is reversed
        /// </summary>
        protected Stack<string> RequiredMethods { get; }

        public override bool IsValid => base.IsValid && RequiredMethods.Count == 0;

        protected FluentAssertionsWithoutArgumentsCSharpSyntaxVisitor(params string[] requiredMethods)
        {
            RequiredMethods = new Stack<string>(requiredMethods);
        }

        public sealed override void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            string methodName = node.Name.Identifier.Text;
            if (methodName.Equals(RequiredMethods.Pop()))
            {
                base.Visit(node.Expression);
            }
        }

        public sealed override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (RequiredMethods.Count == 0)
            {
                VariableName = node.Identifier.Text;
            }
        }
    }
}
