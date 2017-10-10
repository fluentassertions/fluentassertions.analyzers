using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.BestPractices
{

    public sealed class BecauseArgumentsSyntaxVisitor : CSharpSyntaxVisitor
    {
        private readonly string _methodName;
        private readonly int _argumentsStartingIndex;

        public string BecauseArgumentsString { get; private set; }

        public BecauseArgumentsSyntaxVisitor(string methodName, int argumentsStartingIndex)
        {
            _methodName = methodName;
            _argumentsStartingIndex = argumentsStartingIndex;
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            base.Visit(node.Expression);
            if (BecauseArgumentsString == null)
            {
                base.Visit(node.ArgumentList);
            }
        }

        public override void VisitArgumentList(ArgumentListSyntax node)
        {
            var arguments = node.Arguments;
            for (int i = 0; i < _argumentsStartingIndex; i++)
            {
                arguments = arguments.RemoveAt(0);
            }
            BecauseArgumentsString = arguments.ToFullString();
        }

        public override void VisitExpressionStatement(ExpressionStatementSyntax node) => base.Visit(node.Expression);

        public override void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            string methodName = node.Name.Identifier.Text;
            if (!methodName.Equals(_methodName))
            {
                base.Visit(node.Expression);
            }
        }
    }
}
