using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace FluentAssertions.Analyzers;

public static class CollectionShouldBeEmpty
{
    public sealed class AnyShouldBeFalseSyntaxVisitor {}

    public sealed class ShouldHaveCount0SyntaxVisitor {}

    public class HaveCountNodeReplacement : NodeReplacement
    {
        public override bool IsValidNode(LinkedListNode<MemberAccessExpressionSyntax> listNode) => listNode.Value.Name.Identifier.Text == "HaveCount";
        public override SyntaxNode ComputeOld(LinkedListNode<MemberAccessExpressionSyntax> listNode) => listNode.Value.Parent;
        public override SyntaxNode ComputeNew(LinkedListNode<MemberAccessExpressionSyntax> listNode)
        {
            var invocation = (InvocationExpressionSyntax)listNode.Value.Parent;

            invocation = invocation.ReplaceNode(listNode.Value, listNode.Value.WithName(SyntaxFactory.IdentifierName("BeEmpty")));

            // remove the 0 argument
            var arguments = invocation.ArgumentList.Arguments.RemoveAt(0);

            return invocation.WithArgumentList(invocation.ArgumentList.WithArguments(arguments));
        }
    }
}