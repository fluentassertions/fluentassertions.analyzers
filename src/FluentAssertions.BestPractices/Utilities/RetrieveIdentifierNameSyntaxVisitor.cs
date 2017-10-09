using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.BestPractices
{
    public class RetrieveIdentifierNameSyntaxVisitor : CSharpSyntaxVisitor<string>
    {
        public override string VisitInvocationExpression(InvocationExpressionSyntax node) => base.Visit(node.Expression);
        public override string VisitExpressionStatement(ExpressionStatementSyntax node) => base.Visit(node.Expression);
        public override string VisitMemberAccessExpression(MemberAccessExpressionSyntax node) => base.Visit(node.Expression);
        public override string VisitIdentifierName(IdentifierNameSyntax node) => node.Identifier.Text;
    }
}
