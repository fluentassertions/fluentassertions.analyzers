using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace FluentAssertions.BestPractices
{

    public abstract class FluentAssertionsCSharpSyntaxVisitor : CSharpSyntaxVisitor
    {
        /// <summary>
        /// The order in the syntax tree is reversed
        /// </summary>
        protected Stack<string> RequiredMethods { get; }
        
        public string VariableName { get; protected set; }

        public virtual bool IsValid => VariableName != null && RequiredMethods.Count == 0;

        protected FluentAssertionsCSharpSyntaxVisitor(params string[] requiredMethods)
        {
            RequiredMethods = new Stack<string>(requiredMethods);
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            base.Visit(node.Expression);
            base.Visit(node.ArgumentList);
        }

        public override void VisitArgumentList(ArgumentListSyntax node)
        {
            foreach (var argument in node.Arguments)
            {
                base.Visit(argument);
            }
        }

        public sealed override void VisitExpressionStatement(ExpressionStatementSyntax node) => base.Visit(node.Expression);
        
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
