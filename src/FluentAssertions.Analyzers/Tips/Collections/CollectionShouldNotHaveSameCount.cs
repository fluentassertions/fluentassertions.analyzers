using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace FluentAssertions.Analyzers;

public static class CollectionShouldNotHaveSameCount
{
    public class CountShouldNotBeOtherCollectionCountSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public CountShouldNotBeOtherCollectionCountSyntaxVisitor() : base(MemberValidator.HasNoArguments("Count"), MemberValidator.Should, new MemberValidator("NotBe", HasArgumentInvokingCountMethod))
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