using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

namespace FluentAssertions.BestPractices
{
    public abstract class NodeReplacement
    {
        public abstract bool IsValidNode(MemberAccessExpressionSyntax node);
        public abstract SyntaxNode ComputeOld(LinkedListNode<MemberAccessExpressionSyntax> listNode);
        public abstract SyntaxNode ComputeNew(LinkedListNode<MemberAccessExpressionSyntax> listNode);
        public virtual void ExtractValues() { }

        public class Rename : NodeReplacement
        {
            private readonly string _oldName;
            private readonly string _newName;

            public Rename(string oldName, string newName)
            {
                _oldName = oldName;
                _newName = newName;
            }

            public sealed override bool IsValidNode(MemberAccessExpressionSyntax node) => node.Name.Identifier.Text == _oldName;
            public sealed override SyntaxNode ComputeOld(LinkedListNode<MemberAccessExpressionSyntax> listNode) => listNode.Value;
            public override SyntaxNode ComputeNew(LinkedListNode<MemberAccessExpressionSyntax> listNode) => listNode.Value.WithName(SyntaxFactory.IdentifierName(_newName));
        }

        public class Remove : NodeReplacement
        {
            private readonly string _name;

            public Remove(string name)
            {
                _name = name;
            }

            public sealed override bool IsValidNode(MemberAccessExpressionSyntax node) => node.Name.Identifier.Text == _name;
            public sealed override SyntaxNode ComputeOld(LinkedListNode<MemberAccessExpressionSyntax> listNode) => listNode.Previous.Value;
            public sealed override SyntaxNode ComputeNew(LinkedListNode<MemberAccessExpressionSyntax> listNode)
            {
                var previous = listNode.Previous.Value;
                var next = listNode.Next?.Value ?? listNode.Value.Expression;

                if (next.Parent is InvocationExpressionSyntax invocation)
                {
                    return previous.WithExpression(invocation);
                }

                return previous.WithExpression(next);
            }
        }
    }
}
