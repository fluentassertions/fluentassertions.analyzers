using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace FluentAssertions.Analyzers;

public static class CollectionShouldOnlyHaveUniqueItems
{
    public class ShouldHaveSameCountThisCollectionDistinctSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public ShouldHaveSameCountThisCollectionDistinctSyntaxVisitor() : base(MemberValidator.Should, new MemberValidator("HaveSameCount", ArgumentInvokesDistinctMethod))
        {
        }

        private static bool ArgumentInvokesDistinctMethod(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel)
        {
            if (!arguments.Any()) return false;

            if (arguments.First().Expression is InvocationExpressionSyntax invocation)
            {
                var visitor = new FluentAssertionsCSharpSyntaxVisitor(new MemberValidator(nameof(Enumerable.Distinct)));
                invocation.Accept(visitor);

                return visitor.IsValid(invocation) && VariableNameExtractor.ExtractVariableName(arguments.First()) == VariableNameExtractor.ExtractVariableName(invocation);
            }
            return false;
        }
    }
}