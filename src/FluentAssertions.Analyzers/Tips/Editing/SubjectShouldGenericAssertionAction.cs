using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public class SubjectShouldGenericAssertionAction(int argumentIndex, string assertion, ITypeSymbol type) : SubjectShouldAssertionAction(argumentIndex, assertion)
{
    protected override SyntaxNode GenerateAssertion(SyntaxGenerator generator) => generator.GenericName(assertion, type);
}