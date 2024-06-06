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
        while (current.ChildOperations.Count >= 1)
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

    /// <summary>
    /// Tries to get the first descendent of the parent operation. where each operation has only one child.
    /// </summary>
    public static TOperation GetFirstDescendent<TOperation>(this IOperation parent) where TOperation : IOperation
    {
        IOperation current = parent;
        while (current.ChildOperations.Count >= 1)
        {
            current = current.ChildOperations.First();
            if (current is TOperation op)
            {
                return op;
            }
        }

        return default;
    }

    public static TOperation GetFirstAncestor<TOperation>(this IOperation parent) where TOperation : IOperation
    {
        IOperation current = parent;
        while (current.Parent is not null)
        {
            current = current.Parent;
            if (current is TOperation op)
            {
                return op;
            }
        }

        return default;
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
    public static bool ImplementsOrIsInterface(this IPropertyReferenceOperation property, SpecialType type)
        => property.Property.ContainingType.ImplementsOrIsInterface(type);
    public static bool ImplementsOrIsInterface(this IInvocationOperation invocation, SpecialType type)
        => invocation.TargetMethod.ContainingType.ImplementsOrIsInterface(type);
    public static bool ImplementsOrIsInterface(this IInvocationOperation invocation, INamedTypeSymbol type)
        => invocation.TargetMethod.ContainingType.ImplementsOrIsInterface(type);
    public static bool ImplementsOrIsInterface(this IArgumentOperation argument, SpecialType type)
        => argument.Value.UnwrapConversion().Type.ImplementsOrIsInterface(type);
    public static bool ImplementsOrIsInterface(this IArgumentOperation argument, INamedTypeSymbol type)
        => argument.Value.UnwrapConversion().Type.ImplementsOrIsInterface(type);
    public static bool IsTypeof(this IArgumentOperation argument, SpecialType type)
        => argument.Value.UnwrapConversion().Type.SpecialType == type;
    public static bool IsTypeof(this IArgumentOperation argument, INamedTypeSymbol type)
        => argument.Value.UnwrapConversion().Type.EqualsSymbol(type);

    public static bool IsSameArgumentReference(this IArgumentOperation argument1, IArgumentOperation argument2)
    {
        return argument1.TryGetFirstDescendent<IParameterReferenceOperation>(out var argument1Reference)
        && argument2.TryGetFirstDescendent<IParameterReferenceOperation>(out var argument2Reference)
        && argument1Reference.Parameter.EqualsSymbol(argument2Reference.Parameter);
    }
    public static bool IsSamePropertyReference(this IPropertyReferenceOperation property1, IPropertyReferenceOperation property2)
    {
        return (property1.Instance is ILocalReferenceOperation local1
        && property2.Instance is ILocalReferenceOperation local2
        && local1.Local.EqualsSymbol(local2.Local))
        ||
        (property1.Instance is IParameterReferenceOperation parameter1
        && property2.Instance is IParameterReferenceOperation parameter2
        && parameter1.Parameter.EqualsSymbol(parameter2.Parameter));
    }

    public static bool IsStaticPropertyReference(this IArgumentOperation argument, INamedTypeSymbol type, string property)
    {
        return argument.Value is IPropertyReferenceOperation propertyReference && propertyReference.Instance is null
            && propertyReference.Property.Type.EqualsSymbol(type)
            && propertyReference.Property.Name == property;
    }

    public static bool IsLiteralValue(this IArgumentOperation argument)
        => UnwrapConversion(argument.Value).Kind is OperationKind.Literal;
    public static bool IsLiteralValue<T>(this IArgumentOperation argument, T value)
        => UnwrapConversion(argument.Value) is ILiteralOperation literal && literal.ConstantValue.HasValue && literal.ConstantValue.Value.Equals(value);
    public static bool IsLiteralNull(this IArgumentOperation argument)
        => UnwrapConversion(argument.Value) is ILiteralOperation literal && literal.ConstantValue.HasValue && literal.ConstantValue.Value is null;
    public static bool IsLiteralValue<T>(this IArgumentOperation argument)
        => UnwrapConversion(argument.Value) is ILiteralOperation literal && literal.ConstantValue.HasValue && literal.ConstantValue.Value is T;
    public static bool TryGetLiteralValue<T>(this IArgumentOperation argument, out T value)
    {
        if (UnwrapConversion(argument.Value) is ILiteralOperation literal && literal.ConstantValue.HasValue && literal.ConstantValue.Value is T tValue)
        {
            value = tValue;
            return true;
        }

        value = default;
        return false;
    }

    public static bool IsReference(this IArgumentOperation argument)
    {
        var operation = UnwrapConversion(argument.Value);
        return operation.Kind is OperationKind.LocalReference || operation.Kind is OperationKind.ParameterReference;
    }

    public static bool IsReferenceOfType(this IArgumentOperation argument, SpecialType type)
    {
        var current = UnwrapConversion(argument.Value);
        return current switch
        {
            ILocalReferenceOperation local => local.Local.Type.SpecialType == type,
            IParameterReferenceOperation parameter => parameter.Parameter.Type.SpecialType == type,
            _ => false,
        };
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
            return chainedInvocation?.TargetMethod?.Name == chainedMethod;
        }

        chainedInvocation = null;
        return false;
    }

    public static IOperation UnwrapConversion(this IOperation operation)
    {
        return operation switch
        {
            IConversionOperation conversion => conversion.Operand,
            _ => operation,
        };
    }
    public static IOperation UnwrapParentConversion(this IOperation operation)
    {
        return operation switch
        {
            IConversionOperation conversion => conversion.Parent,
            _ => operation,
        };
    }
}