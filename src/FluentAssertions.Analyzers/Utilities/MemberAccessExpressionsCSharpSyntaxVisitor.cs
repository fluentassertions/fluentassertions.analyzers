using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace FluentAssertions.Analyzers
{
    public class MemberAccessExpressionsCSharpSyntaxVisitor : CSharpSyntaxVisitor
    {
        public List<MemberAccessExpressionSyntax> Members { get; } = new List<MemberAccessExpressionSyntax>();

        public override void VisitInvocationExpression(InvocationExpressionSyntax node) => Visit(node.Expression);

        public sealed override void VisitExpressionStatement(ExpressionStatementSyntax node) => Visit(node.Expression);


        public sealed override void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            if (node.Name.Identifier.Text != "And")
            {
                Members.Add(node);
            }
            Visit(node.Expression);
        }
    }
}
