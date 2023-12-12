using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace FluentAssertions.Analyzers;

public static class CollectionShouldHaveSameCount
{
    public class ShouldHaveCountOtherCollectionCountSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public ShouldHaveCountOtherCollectionCountSyntaxVisitor() : base(MemberValidator.Should, new MemberValidator("HaveCount", HasArgumentInvokingCountMethod))
        {
        }

        private static bool HasArgumentInvokingCountMethod(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel)
        {
            if (!arguments.Any()) return false;

            return arguments.First().Expression is InvocationExpressionSyntax invocation
                && invocation.Expression is MemberAccessExpressionSyntax memberAccess
                && memberAccess.Name.Identifier.Text == nameof(Enumerable.Count)
                && memberAccess.Expression is IdentifierNameSyntax;
                
        }
    }
}