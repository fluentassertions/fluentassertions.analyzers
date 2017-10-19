using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FluentAssertions.BestPractices
{
    public abstract class NodeReplacement
    {
        public abstract bool IsValidNode(MemberAccessExpressionSyntax node);
        public abstract SyntaxNode ComputeOld(LinkedListNode<MemberAccessExpressionSyntax> listNode);
        public abstract SyntaxNode ComputeNew(LinkedListNode<MemberAccessExpressionSyntax> listNode);
        public virtual void ExtractValues(MemberAccessExpressionSyntax node) { }

        public static NodeReplacement Rename(string oldName, string newName) => new RenameNodeReplacement(oldName, newName);
        public static NodeReplacement Remove(string name) => new RemoveNodeReplacement(name);
        public static RemoveAndExtractArgumentsNodeReplacement RemoveAndExtractArguments(string name) => new RemoveAndExtractArgumentsNodeReplacement(name);
        public static NodeReplacement RenameAndPrependArguments(string oldName, string newName, SeparatedSyntaxList<ArgumentSyntax> arguments) => new RenameAndPrependArgumentsNodeReplacement(oldName, newName, arguments);
        public static NodeReplacement RenameAndRemoveInvocationOfMethodOnFirstArgument(string oldName, string newName) => new RenameAndRemoveInvocationOfMethodOnFirstArgumentNodeReplacement(oldName, newName);
        public static NodeReplacement RenameAndRemoveFirstArgument(string oldName, string newName) => new RenameAndRemoveFirstArgumentNodeReplacement(oldName, newName);
        public static RemoveFirstArgumentNodeReplacement RemoveFirstArgument(string name) => new RemoveFirstArgumentNodeReplacement(name);
        public static NodeReplacement PrependArguments(string name, SeparatedSyntaxList<ArgumentSyntax> arguments) => new PrependArgumentsNodeReplacement(name, arguments);
        public static RemoveAndRetrieveIndexerArgumentsNodeReplacement RemoveAndRetrieveIndexerArguments(string methodAfterIndexer) => new RemoveAndRetrieveIndexerArgumentsNodeReplacement(methodAfterIndexer);

        public class RenameNodeReplacement : NodeReplacement
        {
            private readonly string _oldName;
            private readonly string _newName;

            public RenameNodeReplacement(string oldName, string newName)
            {
                _oldName = oldName;
                _newName = newName;
            }

            public virtual InvocationExpressionSyntax ComputeNew(InvocationExpressionSyntax node) => node;

            public sealed override bool IsValidNode(MemberAccessExpressionSyntax node) => node.Name.Identifier.Text == _oldName;
            public sealed override SyntaxNode ComputeOld(LinkedListNode<MemberAccessExpressionSyntax> listNode) => listNode.Value.Parent;
            public sealed override SyntaxNode ComputeNew(LinkedListNode<MemberAccessExpressionSyntax> listNode)
            {
                var current = listNode.Value;
                var parent = (InvocationExpressionSyntax)current.Parent;

                var newNode = parent.WithExpression(current.WithName(SyntaxFactory.IdentifierName(_newName)));
                return ComputeNew(newNode);
            }
        }

        public abstract class EditNodeReplacement : NodeReplacement
        {
            private readonly string _name;

            protected EditNodeReplacement(string name)
            {
                _name = name;
            }

            public abstract InvocationExpressionSyntax ComputeNew(InvocationExpressionSyntax node);

            public sealed override bool IsValidNode(MemberAccessExpressionSyntax node) => node.Name.Identifier.Text == _name;
            public sealed override SyntaxNode ComputeOld(LinkedListNode<MemberAccessExpressionSyntax> listNode) => listNode.Value.Parent;
            public sealed override SyntaxNode ComputeNew(LinkedListNode<MemberAccessExpressionSyntax> listNode)
            {
                return ComputeNew((InvocationExpressionSyntax)listNode.Value.Parent);
            }
        }

        public class RemoveNodeReplacement : NodeReplacement
        {
            private readonly string _name;

            public RemoveNodeReplacement(string name)
            {
                _name = name;
            }

            public sealed override bool IsValidNode(MemberAccessExpressionSyntax node) => node.Name.Identifier.Text == _name;
            public sealed override SyntaxNode ComputeOld(LinkedListNode<MemberAccessExpressionSyntax> listNode) => listNode?.Previous?.Value ?? listNode.Value.Parent;
            public sealed override SyntaxNode ComputeNew(LinkedListNode<MemberAccessExpressionSyntax> listNode)
            {
                if (listNode.Previous == null) return listNode.Next.Value.Parent;

                var previous = listNode.Previous.Value;
                var next = listNode.Next?.Value ?? listNode.Value.Expression;

                if (next.Parent is InvocationExpressionSyntax nextInvocation)
                {
                    if (nextInvocation.Parent is MemberAccessExpressionSyntax access && access.Name.Identifier.Text == "And")
                    {
                        return previous.WithExpression(access);
                    }
                    return previous.WithExpression(nextInvocation);
                }


                return previous.WithExpression(next);
            }
        }

        public class RemoveAndExtractArgumentsNodeReplacement : RemoveNodeReplacement
        {
            public SeparatedSyntaxList<ArgumentSyntax> Arguments { get; private set; }

            public RemoveAndExtractArgumentsNodeReplacement(string name) : base(name)
            {
            }

            public override void ExtractValues(MemberAccessExpressionSyntax node)
            {
                var invocation = (InvocationExpressionSyntax)node.Parent;

                Arguments = invocation.ArgumentList.Arguments;
            }
        }

        public class RenameAndPrependArgumentsNodeReplacement : RenameNodeReplacement
        {
            private readonly SeparatedSyntaxList<ArgumentSyntax> _arguments;

            public RenameAndPrependArgumentsNodeReplacement(string oldName, string newName, SeparatedSyntaxList<ArgumentSyntax> arguments) : base(oldName, newName)
            {
                _arguments = arguments;
            }

            public override InvocationExpressionSyntax ComputeNew(InvocationExpressionSyntax node)
            {
                var combinedArguments = node.ArgumentList.WithArguments(_arguments)
                    .AddArguments(node.ArgumentList.Arguments.ToArray());

                return node.WithArgumentList(combinedArguments);
            }
        }

        public class RenameAndRemoveInvocationOfMethodOnFirstArgumentNodeReplacement : RenameNodeReplacement
        {
            public RenameAndRemoveInvocationOfMethodOnFirstArgumentNodeReplacement(string oldName, string newName) : base(oldName, newName)
            {
            }

            public override InvocationExpressionSyntax ComputeNew(InvocationExpressionSyntax node)
            {
                // replaces: .oldName(expected.XXX()) with .newName(expected)
                var oldArgumentExpression = (InvocationExpressionSyntax)node.ArgumentList.Arguments[0].Expression;
                var newArgumentExpression = ((MemberAccessExpressionSyntax)oldArgumentExpression.Expression).Expression;

                return node.ReplaceNode(oldArgumentExpression, newArgumentExpression);
            }
        }

        public class RenameAndRemoveFirstArgumentNodeReplacement : RenameNodeReplacement
        {
            public RenameAndRemoveFirstArgumentNodeReplacement(string oldName, string newName) : base(oldName, newName)
            {
            }

            public override InvocationExpressionSyntax ComputeNew(InvocationExpressionSyntax node)
            {
                var exceptFirstArgument = node.ArgumentList.Arguments.RemoveAt(0);

                return node.WithArgumentList(node.ArgumentList.WithArguments(exceptFirstArgument));
            }
        }

        public class RenameAndNegateLambdaNodeReplacement : RenameNodeReplacement
        {
            public RenameAndNegateLambdaNodeReplacement(string oldName, string newName) : base(oldName, newName)
            {
            }

            public override InvocationExpressionSyntax ComputeNew(InvocationExpressionSyntax node)
            {
                var oldLambda = (LambdaExpressionSyntax)node.ArgumentList.Arguments[0].Expression;
                var newLambda = NagateLambda(oldLambda);

                return node.ReplaceNode(oldLambda, newLambda);
            }

            private LambdaExpressionSyntax NagateLambda(LambdaExpressionSyntax lambda)
            {
                throw new NotImplementedException();
            }
        }

        public class RemoveFirstArgumentNodeReplacement : EditNodeReplacement
        {
            public ArgumentSyntax Argument { get; private set; }

            public RemoveFirstArgumentNodeReplacement(string name) : base(name)
            {
            }

            public override InvocationExpressionSyntax ComputeNew(InvocationExpressionSyntax node)
            {
                Argument = node.ArgumentList.Arguments[0];
                var exceptFirstArgument = node.ArgumentList.Arguments.Remove(Argument);

                return node.WithArgumentList(node.ArgumentList.WithArguments(exceptFirstArgument));
            }
        }
        public class PrependArgumentsNodeReplacement : EditNodeReplacement
        {
            private readonly SeparatedSyntaxList<ArgumentSyntax> _arguments;

            public PrependArgumentsNodeReplacement(string name, SeparatedSyntaxList<ArgumentSyntax> arguments) : base(name)
            {
                _arguments = arguments;
            }

            public override InvocationExpressionSyntax ComputeNew(InvocationExpressionSyntax node)
            {
                var combinedArguments = node.ArgumentList.WithArguments(_arguments)
                    .AddArguments(node.ArgumentList.Arguments.ToArray());

                return node.WithArgumentList(combinedArguments);
            }
        }

        public class RemoveAndRetrieveIndexerArgumentsNodeReplacement : NodeReplacement
        {
            private readonly string _methodAfterIndexer;

            public SeparatedSyntaxList<ArgumentSyntax> Arguments { get; private set; }

            public RemoveAndRetrieveIndexerArgumentsNodeReplacement(string methodAfterIndexer)
            {
                _methodAfterIndexer = methodAfterIndexer;
            }

            public sealed override bool IsValidNode(MemberAccessExpressionSyntax node) => node.Name.Identifier.Text == _methodAfterIndexer;
            public sealed override SyntaxNode ComputeOld(LinkedListNode<MemberAccessExpressionSyntax> listNode) => listNode.Value;
            public sealed override SyntaxNode ComputeNew(LinkedListNode<MemberAccessExpressionSyntax> listNode)
            {
                var current = listNode.Value;

                var elementAccess = (ElementAccessExpressionSyntax)current.Expression;
                Arguments = elementAccess.ArgumentList.Arguments;

                return current.WithExpression(elementAccess.Expression);
            }
        }
    }
}
