using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public class SubjectShouldGenericAssertionAction : SubjectShouldAssertionAction
{
    private readonly ImmutableArray<ITypeSymbol> _types;

    public SubjectShouldGenericAssertionAction(int argumentIndex, string assertion, ImmutableArray<ITypeSymbol> types) : base(argumentIndex, assertion)
    {
        _types = types;
    }

    protected override SyntaxNode GenerateAssertion(SyntaxGenerator generator) => generator.GenericName(_assertion, _types);
}