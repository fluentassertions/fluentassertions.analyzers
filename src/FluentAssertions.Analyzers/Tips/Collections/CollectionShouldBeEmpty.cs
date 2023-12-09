using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace FluentAssertions.Analyzers;

public static class CollectionShouldBeEmpty
{
    public class AnyShouldBeFalseSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AnyShouldBeFalseSyntaxVisitor() : base(MemberValidator.MethodNotContainingLambda("Any"), MemberValidator.Should, new MemberValidator("BeFalse"))
        {
        }
    }

    public class ShouldHaveCount0SyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public ShouldHaveCount0SyntaxVisitor() : base(MemberValidator.Should, new MemberValidator("HaveCount", HaveCountArgumentsValidator))
        {
        }

        private static bool HaveCountArgumentsValidator(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel)
        {
            if (!arguments.Any()) return false;

            return arguments[0].Expression is LiteralExpressionSyntax literal
                && literal.Token.Value is int argument
                && argument == 0;
        }
    }

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