using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace FluentAssertions.Analyzers;

public class ArgumentValidator
{
    public static ArgumentPredicate IsIdentifier() 
        => (argument, semanticModel) => argument.Expression.IsKind(SyntaxKind.IdentifierName);
    public static ArgumentPredicate IsType(Func<SemanticModel, INamedTypeSymbol> typeSelector) 
        => (argument, semanticModel) => semanticModel.GetTypeInfo(argument.Expression).Type?.Equals(typeSelector(semanticModel), SymbolEqualityComparer.Default) ?? false;
    public static ArgumentPredicate IsTypeOrConstructedFromTypeOrImplementsType(SpecialType specialType) 
        => (argument, semanticModel) => semanticModel.GetTypeInfo(argument.Expression).Type?.IsTypeOrConstructedFromTypeOrImplementsType(specialType) ?? false;
    public static ArgumentPredicate Exists() {
        return (argument, semanticModel) => true;
    }
    public static ArgumentPredicate IsAnyType(params Func<SemanticModel, INamedTypeSymbol>[] typeSelectors) 
        => (argument, semanticModel) => Array.Exists(typeSelectors, typeSelector => IsType(typeSelector)(argument, semanticModel));
    public static ArgumentPredicate IsNull() 
        => (argument, semanticModel) => argument.Expression is LiteralExpressionSyntax literal && literal.Token.IsKind(SyntaxKind.NullKeyword);
}