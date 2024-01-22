using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Operations;
using CreateChangedDocument = System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<Microsoft.CodeAnalysis.Document>>;
using System;
using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis.Simplification;

namespace FluentAssertions.Analyzers;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(NunitCodeFixProvider)), Shared]
public class NunitCodeFixProvider : TestingFrameworkCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertAnalyzer.NUnitRule.Id);
    protected override CreateChangedDocument TryComputeFixCore(IInvocationOperation invocation, CodeFixContext context, TestingFrameworkCodeFixContext t, Diagnostic diagnostic)
    {
        var assertType = invocation.TargetMethod.ContainingType;
        var nunitVersion = assertType.ContainingAssembly.Identity.Version;

        var isNunit3 = nunitVersion >= new Version(3, 0, 0, 0) && nunitVersion < new Version(4, 0, 0, 0);
        var isNunit4 = nunitVersion >= new Version(4, 0, 0, 0) && nunitVersion < new Version(5, 0, 0, 0);

        return assertType.Name switch
        {
            "Assert" when isNunit3 => TryComputeFixForNunitClassicAssert(invocation, context, t),
            "ClassicAssert" when isNunit4 => TryComputeFixForNunitClassicAssert(invocation, context, t),
            //"StringAssert" => TryComputeFixForStringAssert(invocation, context, testContext),
            //"CollectionAssert" => TryComputeFixForCollectionAssert(invocation, context, testContext),
            _ => null
        };
    }

    private CreateChangedDocument TryComputeFixForNunitClassicAssert(IInvocationOperation invocation, CodeFixContext context, TestingFrameworkCodeFixContext t)
    {
        switch (invocation.TargetMethod.Name)
        {
            case "True": // Assert.True(bool condition)
            case "IsTrue": // Assert.IsTrue(bool condition)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeTrue", subjectIndex: 0, argumentsToRemove: []);
            case "False": // Assert.False(bool condition)
            case "IsFalse": // Assert.IsFalse(bool condition)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeFalse", subjectIndex: 0, argumentsToRemove: []);
            case "Null": // Assert.Null(object anObject)
            case "IsNull": // Assert.IsNull(object anObject)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeNull", subjectIndex: 0, argumentsToRemove: []);
            case "NotNull": // Assert.NotNull(object anObject)
            case "IsNotNull": // Assert.IsNotNull(object anObject)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeNull", subjectIndex: 0, argumentsToRemove: []);
            case "Greater" when ArgumentsAreTypeOf(invocation, t.Int32, t.Int32): // Assert.Greater(int arg1, int arg2)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.UInt32, t.UInt32): // Assert.Greater(uint arg1, uint arg2)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.Long, t.Long): // Assert.Greater(long arg1, long arg2)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.ULong, t.ULong): // Assert.Greater(ulong arg1, ulong arg2)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.Float, t.Float): // Assert.Greater(float arg1, float arg2)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.Double, t.Double): // Assert.Greater(double arg1, double arg2)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.Decimal, t.Decimal): // Assert.Greater(decimal arg1, decimal arg2)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.Int32, t.Int32, t.String, t.ObjectArray): // Assert.Greater(int arg1, int arg2, string message, params object[] parms)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.UInt32, t.UInt32, t.String, t.ObjectArray): // Assert.Greater(uint arg1, uint arg2, string message, params object[] parms)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.Long, t.Long, t.String, t.ObjectArray): // Assert.Greater(long arg1, long arg2, string message, params object[] parms)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.ULong, t.ULong, t.String, t.ObjectArray): // Assert.Greater(ulong arg1, ulong arg2, string message, params object[] parms)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.Float, t.Float, t.String, t.ObjectArray): // Assert.Greater(float arg1, float arg2, string message, params object[] parms)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.Double, t.Double, t.String, t.ObjectArray): // Assert.Greater(double arg1, double arg2, string message, params object[] parms)
            case "Greater" when ArgumentsAreTypeOf(invocation, t.Decimal, t.Decimal, t.String, t.ObjectArray): // Assert.Greater(decimal arg1, decimal arg2, string message, params object[] parms)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeGreaterThan", subjectIndex: 0, argumentsToRemove: []);
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.Int32, t.Int32): // Assert.GreaterOrEqual(int arg1, int arg2)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.UInt32, t.UInt32): // Assert.GreaterOrEqual(uint arg1, uint arg2)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.Long, t.Long): // Assert.GreaterOrEqual(long arg1, long arg2)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.ULong, t.ULong): // Assert.GreaterOrEqual(ulong arg1, ulong arg2)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.Float, t.Float): // Assert.GreaterOrEqual(float arg1, float arg2)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.Double, t.Double): // Assert.GreaterOrEqual(double arg1, double arg2)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.Decimal, t.Decimal): // Assert.GreaterOrEqual(decimal arg1, decimal arg2)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.Int32, t.Int32, t.String, t.ObjectArray): // Assert.GreaterOrEqual(int arg1, int arg2, string message, params object[] parms)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.UInt32, t.UInt32, t.String, t.ObjectArray): // Assert.GreaterOrEqual(uint arg1, uint arg2, string message, params object[] parms)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.Long, t.Long, t.String, t.ObjectArray): // Assert.GreaterOrEqual(long arg1, long arg2, string message, params object[] parms)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.ULong, t.ULong, t.String, t.ObjectArray): // Assert.GreaterOrEqual(ulong arg1, ulong arg2, string message, params object[] parms)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.Float, t.Float, t.String, t.ObjectArray): // Assert.GreaterOrEqual(float arg1, float arg2, string message, params object[] parms)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.Double, t.Double, t.String, t.ObjectArray): // Assert.GreaterOrEqual(double arg1, double arg2, string message, params object[] parms)
            case "GreaterOrEqual" when ArgumentsAreTypeOf(invocation, t.Decimal, t.Decimal, t.String, t.ObjectArray): // Assert.GreaterOrEqual(decimal arg1, decimal arg2, string message, params object[] parms)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeGreaterOrEqualTo", subjectIndex: 0, argumentsToRemove: []);
            case "Less" when ArgumentsAreTypeOf(invocation, t.Int32, t.Int32): // Assert.Less(int arg1, int arg2)
            case "Less" when ArgumentsAreTypeOf(invocation, t.UInt32, t.UInt32): // Assert.Less(uint arg1, uint arg2)
            case "Less" when ArgumentsAreTypeOf(invocation, t.Long, t.Long): // Assert.Less(long arg1, long arg2)
            case "Less" when ArgumentsAreTypeOf(invocation, t.ULong, t.ULong): // Assert.Less(ulong arg1, ulong arg2)
            case "Less" when ArgumentsAreTypeOf(invocation, t.Float, t.Float): // Assert.Less(float arg1, float arg2)
            case "Less" when ArgumentsAreTypeOf(invocation, t.Double, t.Double): // Assert.Less(double arg1, double arg2)
            case "Less" when ArgumentsAreTypeOf(invocation, t.Decimal, t.Decimal): // Assert.Less(decimal arg1, decimal arg2)
            case "Less" when ArgumentsAreTypeOf(invocation, t.Int32, t.Int32, t.String, t.ObjectArray): // Assert.Less(int arg1, int arg2, string message, params object[] parms)
            case "Less" when ArgumentsAreTypeOf(invocation, t.UInt32, t.UInt32, t.String, t.ObjectArray): // Assert.Less(uint arg1, uint arg2, string message, params object[] parms)
            case "Less" when ArgumentsAreTypeOf(invocation, t.Long, t.Long, t.String, t.ObjectArray): // Assert.Less(long arg1, long arg2, string message, params object[] parms)
            case "Less" when ArgumentsAreTypeOf(invocation, t.ULong, t.ULong, t.String, t.ObjectArray): // Assert.Less(ulong arg1, ulong arg2, string message, params object[] parms)
            case "Less" when ArgumentsAreTypeOf(invocation, t.Float, t.Float, t.String, t.ObjectArray): // Assert.Less(float arg1, float arg2, string message, params object[] parms)
            case "Less" when ArgumentsAreTypeOf(invocation, t.Double, t.Double, t.String, t.ObjectArray): // Assert.Less(double arg1, double arg2, string message, params object[] parms)
            case "Less" when ArgumentsAreTypeOf(invocation, t.Decimal, t.Decimal, t.String, t.ObjectArray): // Assert.Less(decimal arg1, decimal arg2, string message, params object[] parms)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeLessThan", subjectIndex: 0, argumentsToRemove: []);
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.Int32, t.Int32): // Assert.LessOrEqual(int arg1, int arg2)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.UInt32, t.UInt32): // Assert.LessOrEqual(uint arg1, uint arg2)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.Long, t.Long): // Assert.LessOrEqual(long arg1, long arg2)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.ULong, t.ULong): // Assert.LessOrEqual(ulong arg1, ulong arg2)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.Float, t.Float): // Assert.LessOrEqual(float arg1, float arg2)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.Double, t.Double): // Assert.LessOrEqual(double arg1, double arg2)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.Decimal, t.Decimal): // Assert.LessOrEqual(decimal arg1, decimal arg2)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.Int32, t.Int32, t.String, t.ObjectArray): // Assert.LessOrEqual(int arg1, int arg2, string message, params object[] parms)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.UInt32, t.UInt32, t.String, t.ObjectArray): // Assert.LessOrEqual(uint arg1, uint arg2, string message, params object[] parms)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.Long, t.Long, t.String, t.ObjectArray): // Assert.LessOrEqual(long arg1, long arg2, string message, params object[] parms)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.ULong, t.ULong, t.String, t.ObjectArray): // Assert.LessOrEqual(ulong arg1, ulong arg2, string message, params object[] parms)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.Float, t.Float, t.String, t.ObjectArray): // Assert.LessOrEqual(float arg1, float arg2, string message, params object[] parms)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.Double, t.Double, t.String, t.ObjectArray): // Assert.LessOrEqual(double arg1, double arg2, string message, params object[] parms)
            case "LessOrEqual" when ArgumentsAreTypeOf(invocation, t.Decimal, t.Decimal, t.String, t.ObjectArray): // Assert.LessOrEqual(decimal arg1, decimal arg2, string message, params object[] parms)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeLessOrEqualTo", subjectIndex: 0, argumentsToRemove: []);
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.Double, t.Double, t.Double): // Assert.AreEqual(double expected, double actual, double delta)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.Double, t.Double, t.Double, t.String, t.ObjectArray): // Assert.AreEqual(double expected, double actual, double delta, string message, params object[] parms)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeApproximately", subjectIndex: 1, argumentsToRemove: []);
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.Object, t.Object): // Assert.AreEqual(object expected, object actual)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.Object, t.Object, t.String, t.ObjectArray): // Assert.AreEqual(object expected, object actual, string message, params object[] parms)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "Be", subjectIndex: 1, argumentsToRemove: []);
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.Object, t.Object): // Assert.AreNotEqual(object expected, object actual)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.Object, t.Object, t.String, t.ObjectArray): // Assert.AreNotEqual(object expected, object actual, string message, params object[] parms)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBe", subjectIndex: 1, argumentsToRemove: []);
            case "AreSame": // Assert.AreSame(object expected, object actual)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeSameAs", subjectIndex: 1, argumentsToRemove: []);
            case "AreNotSame": // Assert.AreNotSame(object expected, object actual)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeSameAs", subjectIndex: 1, argumentsToRemove: []);
            case "IsAssignableFrom" when ArgumentsAreTypeOf(invocation, t.Type, t.Object): // Assert.IsAssignableFrom(Type expectedType, object obj)
            case "IsAssignableFrom" when ArgumentsAreTypeOf(invocation, t.Type, t.Object, t.String, t.ObjectArray): // Assert.IsAssignableFrom(Type expectedType, object obj, string message, params object[] parms)
                {
                    if (invocation.Arguments[0].Value is not ITypeOfOperation typeOf)
                    {
                        return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeAssignableTo", subjectIndex: 1, argumentsToRemove: []);
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldGenericAssertion(invocation, ImmutableArray.Create(typeOf.TypeOperand), context, "BeAssignableTo", subjectIndex: 1, argumentsToRemove: [0]);
                }
            case "IsAssignableFrom" when ArgumentsAreTypeOf(invocation, t.Object): // Assert.IsAssignableFrom<T>(object actual)
            case "IsAssignableFrom" when ArgumentsAreTypeOf(invocation, t.Object, t.String, t.ObjectArray): // Assert.IsAssignableFrom<T>(object actual, string message, params object[] parms)
                return DocumentEditorUtils.RenameGenericMethodToSubjectShouldGenericAssertion(invocation, context, "BeAssignableTo", subjectIndex: 0, argumentsToRemove: []);
            case "IsNotAssignableFrom" when ArgumentsAreTypeOf(invocation, t.Type, t.Object): // Assert.IsNotAssignableFrom(Type expectedType, object obj)
            case "IsNotAssignableFrom" when ArgumentsAreTypeOf(invocation, t.Type, t.Object, t.String, t.ObjectArray): // Assert.IsNotAssignableFrom(Type expectedType, object obj, string message, params object[] parms)
                {
                    if (invocation.Arguments[0].Value is not ITypeOfOperation typeOf)
                    {
                        return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeAssignableTo", subjectIndex: 1, argumentsToRemove: []);
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldGenericAssertion(invocation, ImmutableArray.Create(typeOf.TypeOperand), context, "NotBeAssignableTo", subjectIndex: 1, argumentsToRemove: [0]);
                }
            case "IsNotAssignableFrom" when ArgumentsAreTypeOf(invocation, t.Object): // Assert.IsNotAssignableFrom<T>(object actual)
            case "IsNotAssignableFrom" when ArgumentsAreTypeOf(invocation, t.Object, t.String, t.ObjectArray): // Assert.IsNotAssignableFrom<T>(object actual, string message, params object[] parms)
                return DocumentEditorUtils.RenameGenericMethodToSubjectShouldGenericAssertion(invocation, context, "NotBeAssignableTo", subjectIndex: 0, argumentsToRemove: []);
            case "IsInstanceOf" when ArgumentsAreTypeOf(invocation, t.Type, t.Object): // Assert.IsInstanceOf(Type expectedType, object actual)
            case "IsInstanceOf" when ArgumentsAreTypeOf(invocation, t.Type, t.Object, t.String, t.ObjectArray): // Assert.IsInstanceOf(Type expectedType, object actual, string message, params object[] parms)
                {
                    if (invocation.Arguments[0].Value is not ITypeOfOperation typeOf)
                    {
                        return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeOfType", subjectIndex: 1, argumentsToRemove: []);
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldGenericAssertion(invocation, ImmutableArray.Create(typeOf.TypeOperand), context, "BeOfType", subjectIndex: 1, argumentsToRemove: [0]);
                }
            case "IsInstanceOf" when ArgumentsAreTypeOf(invocation, t.Object): // Assert.IsInstanceOf<T>(object actual)
            case "IsInstanceOf" when ArgumentsAreTypeOf(invocation, t.Object, t.String, t.ObjectArray): // Assert.IsInstanceOf<T>(object actual, string message, params object[] parms)
                return DocumentEditorUtils.RenameGenericMethodToSubjectShouldGenericAssertion(invocation, context, "BeOfType", subjectIndex: 0, argumentsToRemove: []);
            case "IsNotInstanceOf" when ArgumentsAreTypeOf(invocation, t.Type, t.Object): // Assert.IsNotInstanceOf(Type expectedType, object actual)
            case "IsNotInstanceOf" when ArgumentsAreTypeOf(invocation, t.Type, t.Object, t.String, t.ObjectArray): // Assert.IsNotInstanceOf(Type expectedType, object actual, string message, params object[] parms)
                {
                    if (invocation.Arguments[0].Value is not ITypeOfOperation typeOf)
                    {
                        return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeOfType", subjectIndex: 1, argumentsToRemove: []);
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldGenericAssertion(invocation, ImmutableArray.Create(typeOf.TypeOperand), context, "NotBeOfType", subjectIndex: 1, argumentsToRemove: [0]);
                }
            case "IsNotInstanceOf" when ArgumentsAreTypeOf(invocation, t.Object): // Assert.IsNotInstanceOf<T>(object actual)
            case "IsNotInstanceOf" when ArgumentsAreTypeOf(invocation, t.Object, t.String, t.ObjectArray): // Assert.IsNotInstanceOf<T>(object actual, string message, params object[] parms)
                return DocumentEditorUtils.RenameGenericMethodToSubjectShouldGenericAssertion(invocation, context, "NotBeOfType", subjectIndex: 0, argumentsToRemove: []);
            case "Contains": // Assert.Contains(object expected, ICollection actual)
                {
                    var collectionArgument = invocation.Arguments[1].Value.UnwrapConversion();
                    if (collectionArgument.Type.ImplementsOrIsInterface(SpecialType.System_Collections_Generic_IEnumerable_T))
                    {
                        return async ctx => await DocumentEditorUtils.RewriteExpression(invocation, [
                            (EditActionContext editActionContext) => 
                            {
                                ITypeSymbol elementType = collectionArgument.Type switch
                                {
                                    INamedTypeSymbol namedType => namedType.TypeArguments[0],
                                    IArrayTypeSymbol arrayType => arrayType.ElementType,
                                    _ => null
                                };

                                var argumentToCast = editActionContext.InvocationExpression.ArgumentList.Arguments[0];
                                var castExpression = editActionContext.Editor.Generator.CastExpression(elementType, argumentToCast.Expression);
                                editActionContext.Editor.ReplaceNode(argumentToCast.Expression, castExpression.WithAdditionalAnnotations(Simplifier.Annotation));
                            },
                            EditAction.SubjectShouldAssertion(argumentIndex: 1, "Contain")
                        ], context, ctx);
                    }
                    return null;
                }

            case "IsNaN": // Assert.IsNaN(double actual)
                return null;
        }
        return null;
    }
}