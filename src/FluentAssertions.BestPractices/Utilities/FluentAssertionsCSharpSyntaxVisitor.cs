using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace FluentAssertions.BestPractices
{

    public abstract class FluentAssertionsCSharpSyntaxVisitor : CSharpSyntaxVisitor
    {
        protected string CurrentMethod => VisitedMethods.Count > 0 ? VisitedMethods.Peek() : null;

        protected readonly Stack<string> VisitedMethods = new Stack<string>();

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

        public virtual ImmutableDictionary<string, string> ToDiagnosticProperties() => new Dictionary<string, string>
        {
            [Constants.DiagnosticProperties.VariableName] = VariableName,
            [Constants.DiagnosticProperties.VisitorName] = GetType().Name
        }.ToImmutableDictionary();

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            Visit(node.Expression);
            Visit(node.ArgumentList);

            VisitedMethods.Pop();
        }

        public override void VisitArgumentList(ArgumentListSyntax node)
        {
            foreach (var argument in node.Arguments)
            {
                Visit(argument);
            }
        }

        public sealed override void VisitExpressionStatement(ExpressionStatementSyntax node) => Visit(node.Expression);

        public sealed override void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            var methodName = node.Name.Identifier.Text;

            VisitMethod(methodName);

            Visit(node.Expression);

        }
        public sealed override void VisitElementAccessExpression(ElementAccessExpressionSyntax node)
        {
            const string methodName = "[]";

            VisitMethod(methodName);

            Visit(node.Expression);
            Visit(node.ArgumentList);

            VisitedMethods.Pop();
        }

        public sealed override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (RequiredMethods.Count == 0)
            {
                VariableName = node.Identifier.Text;
            }
        }

        private void VisitMethod(string methodName)
        {
            VisitedMethods.Push(methodName);
            if (RequiredMethods.Count > 0 && methodName.Equals(RequiredMethods.Peek()))
            {
                RequiredMethods.Pop();
            }
        }
    }
}
