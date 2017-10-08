using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.BestPractices
{

    public abstract class FluentAssertionsCSharpSyntaxVisitor : CSharpSyntaxVisitor
    {
        public string VariableName { get; protected set; }
        public virtual bool IsValid => VariableName != null;

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            base.Visit(node.Expression);
            base.Visit(node.ArgumentList);
        }

        public sealed override void VisitExpressionStatement(ExpressionStatementSyntax node) => base.Visit(node.Expression);
    }
}
