using System.Linq;
using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;

namespace FluentAssertions.Analyzers;

internal static class OperartionExtensions
{
    /// <summary>
    /// Tries to get the first descendent of the parent operation. where each operation has only one child.
    /// </summary>
    public static bool TryGetFirstDescendent<TOperation>(this IOperation parent, out TOperation operation) where TOperation : IOperation
    {
        IOperation current = parent;
        while (current.ChildOperations.Count == 1)
        {
            current = current.ChildOperations.First();
            if (current is TOperation op)
            {
                operation = op;
                return true;
            }
        }

        operation = default;
        return false;
    }

    public static bool HasFirstDescendentInvocation(this IOperation parent, string invocationMethod)
    {
        return parent.TryGetFirstDescendent<IInvocationOperation>(out var invocation) && invocation.TargetMethod.Name == invocationMethod;
    }

    public static bool IsContainedInType(this IPropertyReferenceOperation property, SpecialType type)
        => property.Property.ContainingType.ConstructedFromType(type);
    public static bool IsContainedInType(this IPropertyReferenceOperation property, INamedTypeSymbol type)
        => property.Property.ContainingType.ConstructedFromType(type);
    public static bool IsContainedInType(this IInvocationOperation invocation, SpecialType type)
        => invocation.TargetMethod.ContainingType.ConstructedFromType(type);
    public static bool IsContainedInType(this IInvocationOperation invocation, INamedTypeSymbol type)
        => invocation.TargetMethod.ContainingType.ConstructedFromType(type);
    public static bool ImplementsOrIsInterface(this IInvocationOperation invocation, SpecialType type)
        => invocation.TargetMethod.ContainingType.ImplementsOrIsInterface(type);
    public static bool ImplementsOrIsInterface(this IInvocationOperation invocation, INamedTypeSymbol type)
        => invocation.TargetMethod.ContainingType.ImplementsOrIsInterface(type);

    public static bool IsSameArgumentReference(this IArgumentOperation argument1, IArgumentOperation argument2)
    {
        return argument1.TryGetFirstDescendent<IParameterReferenceOperation>(out var argument1Reference)
        && argument2.TryGetFirstDescendent<IParameterReferenceOperation>(out var argument2Reference)
        && argument1Reference.Parameter.Equals(argument2Reference.Parameter, SymbolEqualityComparer.Default);
    }

    public static bool IsLiteralValue<T>(this IArgumentOperation argument, T value)
        => argument.Value is ILiteralOperation literal && literal.ConstantValue.HasValue && literal.ConstantValue.Value.Equals(value);
    public static bool IsLiteralValue<T>(this IArgumentOperation argument)
        => argument.Value is ILiteralOperation literal && literal.ConstantValue.HasValue && literal.ConstantValue.Value is T;
    public static bool IsReference(this IArgumentOperation argument)
    {
        if (argument.Value is IConversionOperation conversion)
        {
            return conversion.Operand.Kind == OperationKind.LocalReference || conversion.Operand.Kind == OperationKind.ParameterReference;
        }

        return argument.Value.Kind == OperationKind.LocalReference || argument.Value.Kind == OperationKind.ParameterReference;
    }

    public static bool IsLambda(this IArgumentOperation argument)
        => argument.Value is IDelegateCreationOperation delegateCreation && delegateCreation.Target.Kind == OperationKind.AnonymousFunction;

    public static bool HasEmptyBecauseAndReasonArgs(this IInvocationOperation invocation, int startingIndex = 0)
    {
        if (invocation.Arguments.Length != startingIndex + 2)
        {
            return false;
        }

        return invocation.Arguments[startingIndex].Value is ILiteralOperation literal && literal.ConstantValue.HasValue && literal.ConstantValue.Value is ""
        && invocation.Arguments[startingIndex + 1].Value is IArrayCreationOperation arrayCreation && arrayCreation.Initializer.ElementValues.IsEmpty;
    }

    public static bool TryGetChainedInvocationAfterAndConstraint(this IInvocationOperation invocation, string chainedMethod, out IInvocationOperation chainedInvocation)
    {
        if (invocation.Parent is IPropertyReferenceOperation { Property.Name: "And" } andConstraint)
        {
            chainedInvocation = andConstraint.Parent as IInvocationOperation;
            return chainedInvocation.TargetMethod.Name == chainedMethod;
        }

        chainedInvocation = null;
        return false;
    }
}