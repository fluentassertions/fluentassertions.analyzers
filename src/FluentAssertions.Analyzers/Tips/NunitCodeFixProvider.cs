using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Operations;
using CreateChangedDocument = System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<Microsoft.CodeAnalysis.Document>>;
using System;
using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis.Simplification;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(NunitCodeFixProvider)), Shared]
public class NunitCodeFixProvider : TestingFrameworkCodeFixProvider<NunitCodeFixProvider.NunitCodeFixContext>
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertAnalyzer.NUnitRule.Id);
    protected override NunitCodeFixContext CreateTestContext(SemanticModel semanticModel) => new(semanticModel.Compilation);
    protected override CreateChangedDocument TryComputeFixCore(IInvocationOperation invocation, CodeFixContext context, NunitCodeFixContext t, Diagnostic diagnostic)
    {
        var assertType = invocation.TargetMethod.ContainingType;
        var nunitVersion = assertType.ContainingAssembly.Identity.Version;

        var isNunit3 = nunitVersion >= new Version(3, 0, 0, 0) && nunitVersion < new Version(4, 0, 0, 0);
        var isNunit4 = nunitVersion >= new Version(4, 0, 0, 0) && nunitVersion < new Version(5, 0, 0, 0);

        return assertType.Name switch
        {
            "Assert" when invocation.TargetMethod.Name is "That" => TryComputeFixForNunitThat(invocation, context, t),
            "Assert" when isNunit3 => TryComputeFixForNunitClassicAssert(invocation, context, t),
            "ClassicAssert" when isNunit4 => TryComputeFixForNunitClassicAssert(invocation, context, t),
            //"StringAssert" => TryComputeFixForStringAssert(invocation, context, t),
            "CollectionAssert" => TryComputeFixForCollectionAssert(invocation, context, t),
            _ => null
        };
    }

    private CreateChangedDocument TryComputeFixForNunitClassicAssert(IInvocationOperation invocation, CodeFixContext context, NunitCodeFixContext t)
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
            case "IsNaN": // Assert.IsNaN(double actual)
                return null;
            case "IsEmpty" when !IsArgumentTypeOfNonGenericEnumerable(invocation, argumentIndex: 0): // Assert.IsEmpty(IEnumerable collection) | Assert.IsEmpty(string s)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeEmpty", subjectIndex: 0, argumentsToRemove: []);
            case "IsNotEmpty" when !IsArgumentTypeOfNonGenericEnumerable(invocation, argumentIndex: 0): // Assert.IsNotEmpty(IEnumerable collection) | Assert.IsNotEmpty(string s)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeEmpty", subjectIndex: 0, argumentsToRemove: []);
            case "Zero": // Assert.Zero(int anObject)
                return DocumentEditorUtils.RewriteExpression(invocation, [
                    EditAction.SubjectShouldAssertion(argumentIndex: 0, "Be"),
                    EditAction.AddArgumentToAssertionArguments(index: 0, generator => generator.LiteralExpression(0)),
                ], context);
            case "NotZero": // Assert.NotZero(int anObject)
                return DocumentEditorUtils.RewriteExpression(invocation, [
                    EditAction.SubjectShouldAssertion(argumentIndex: 0, "NotBe"),
                    EditAction.AddArgumentToAssertionArguments(index: 0, generator => generator.LiteralExpression(0)),
                ], context);
            case "Positive": // Assert.Positive(int anObject)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BePositive", subjectIndex: 0, argumentsToRemove: []);
            case "Negative": // Assert.Negative(int anObject)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeNegative", subjectIndex: 0, argumentsToRemove: []);
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
                    var subject = invocation.Arguments[1];
                    var expected = invocation.Arguments[0];
                    return RewriteContainsAssertion(invocation, context, "Contain", subject, expected);
                }
        }
        return null;
    }

    private CreateChangedDocument TryComputeFixForCollectionAssert(IInvocationOperation invocation, CodeFixContext context, NunitCodeFixContext t)
    {
        switch (invocation.TargetMethod.Name)
        {
            case "IsEmpty" when !IsArgumentTypeOfNonGenericEnumerable(invocation, argumentIndex: 0): // CollectionAssert.IsEmpty(IEnumerable collection)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeEmpty", subjectIndex: 0, argumentsToRemove: []);
            case "IsNotEmpty" when !IsArgumentTypeOfNonGenericEnumerable(invocation, argumentIndex: 0): // CollectionAssert.IsNotEmpty(IEnumerable collection)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeEmpty", subjectIndex: 0, argumentsToRemove: []);
            case "AreEqual" when !IsArgumentTypeOfNonGenericEnumerable(invocation, argumentIndex: 0): // CollectionAssert.AreEqual(IEnumerable expected, IEnumerable actual)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "Equal", subjectIndex: 1, argumentsToRemove: []);
            case "AreNotEqual" when !IsArgumentTypeOfNonGenericEnumerable(invocation, argumentIndex: 0): // CollectionAssert.AreNotEqual(IEnumerable notExpected, IEnumerable actual)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotEqual", subjectIndex: 1, argumentsToRemove: []);
            case "Contains": // CollectionAssert.Contain(IEnumerable collection, object actual)
                return RewriteContainsAssertion(invocation, context, "Contain",
                    subject: invocation.Arguments[0],
                    expectation: invocation.Arguments[1]
                );
            case "DoesNotContain": // CollectionAssert.DoesNotContain(IEnumerable collection, object actual)
                return RewriteContainsAssertion(invocation, context, "NotContain",
                    subject: invocation.Arguments[0],
                    expectation: invocation.Arguments[1]
                );
        }
        return null;
    }

    private CreateChangedDocument TryComputeFixForNunitThat(IInvocationOperation invocation, CodeFixContext context, NunitCodeFixContext t)
    {
        // Assert.That(condition)
        if (invocation.Arguments[0].Value.Type.EqualsSymbol(t.Boolean)
            && (invocation.Arguments.Length is 1
                || (invocation.Arguments.Length >= 2
                    && (invocation.Arguments[1].Value.Type.EqualsSymbol(t.NUnitString)
                        || invocation.Arguments[1].Value.Type.EqualsSymbol(t.String))
                    )
                )
            )
        {
            return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeTrue", subjectIndex: 0, argumentsToRemove: []);
        }

        if (invocation.Arguments[1].Value.UnwrapConversion() is not IPropertyReferenceOperation constraint) return null;
        var subject = invocation.Arguments[0].Value;

        if (IsPropertyOfSymbol(constraint, "True", t.Is) // Assert.That(subject, Is.True)
            || IsPropertyOfSymbol(constraint, "Not", "False", t.Is)) // Assert.That(subject, Is.False)
            return RenameAssertThatAssertionToSubjectShouldAssertion("BeTrue");
        else if (IsPropertyOfSymbol(constraint, "False", t.Is) // Assert.That(subject, Is.False)
            || IsPropertyOfSymbol(constraint, "Not", "True", t.Is)) // Assert.That(subject, Is.Not.True)
            return RenameAssertThatAssertionToSubjectShouldAssertion("BeFalse");
        else if (IsPropertyOfSymbol(constraint, "Null", t.Is)) // Assert.That(subject, Is.Null)
            return RenameAssertThatAssertionToSubjectShouldAssertion("BeNull");
        else if (IsPropertyOfSymbol(constraint, "Not", "Null", t.Is)) // Assert.That(subject, Is.Not.Null)
            return RenameAssertThatAssertionToSubjectShouldAssertion("NotBeNull");
        else if (!IsArgumentTypeOfNonGenericEnumerable(invocation, argumentIndex: 0))
        {
            if (IsPropertyOfSymbol(constraint, "Empty", t.Is)) // Assert.That(subject, Is.Empty)
                return RenameAssertThatAssertionToSubjectShouldAssertion("BeEmpty");
            else if (IsPropertyOfSymbol(constraint, "Not", "Empty", t.Is)) // Assert.That(subject, Is.Not.Empty)
                return RenameAssertThatAssertionToSubjectShouldAssertion("NotBeEmpty");
        }
        if (IsPropertyOfSymbol(constraint, "Zero", t.Is))
            return DocumentEditorUtils.RewriteExpression(invocation, [
                EditAction.ReplaceAssertionArgument(index: 1, generator => generator.LiteralExpression(0)),
                EditAction.SubjectShouldAssertion(argumentIndex: 0, "Be"),
            ], context);
        else if (IsPropertyOfSymbol(constraint, "Not", "Zero", t.Is))
            return DocumentEditorUtils.RewriteExpression(invocation, [
                    EditAction.ReplaceAssertionArgument(index: 1, generator => generator.LiteralExpression(0)),
                EditAction.SubjectShouldAssertion(argumentIndex: 0, "NotBe"),
            ], context);

        return null;

        CreateChangedDocument RenameAssertThatAssertionToSubjectShouldAssertion(string assertionName)
            => DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, assertionName, subjectIndex: 0, argumentsToRemove: [1]);
    }

    private CreateChangedDocument RewriteContainsAssertion(IInvocationOperation invocation, CodeFixContext context, string assertion, IArgumentOperation subject, IArgumentOperation expectation)
    {
        if (!subject.ImplementsOrIsInterface(SpecialType.System_Collections_Generic_IEnumerable_T))
        {
            return null;
        }

        var subjectIndex = invocation.Arguments.IndexOf(subject);
        return DocumentEditorUtils.RewriteExpression(invocation, [
            editActionContext =>
            {
                ITypeSymbol elementType = subject.Value.UnwrapConversion().Type switch
                {
                    INamedTypeSymbol namedType => namedType.TypeArguments[0],
                    IArrayTypeSymbol arrayType => arrayType.ElementType,
                    _ => null
                };

                var argumentToCast = (ArgumentSyntax)expectation.Syntax;
                var castExpression = editActionContext.Editor.Generator.CastExpression(elementType, argumentToCast.Expression);
                editActionContext.Editor.ReplaceNode(argumentToCast.Expression, castExpression.WithAdditionalAnnotations(Simplifier.Annotation));
            },
            EditAction.SubjectShouldAssertion(subjectIndex, assertion)
        ], context);
    }

    private static bool IsPropertyReferencedFromType(IPropertyReferenceOperation propertyReference, INamedTypeSymbol type)
        => propertyReference.Property.ContainingType.EqualsSymbol(type);
    private static bool IsPropertyOfSymbol(IPropertyReferenceOperation propertyReference, string firstProperty, string secondProperty, INamedTypeSymbol type)
        => propertyReference.Property.Name == secondProperty && IsPropertyOfSymbol(propertyReference.Instance, firstProperty, type);
    private static bool IsPropertyOfSymbol(IOperation operation, string property, INamedTypeSymbol type)
        => operation is IPropertyReferenceOperation propertyReference && propertyReference.Property.Name == property && IsPropertyReferencedFromType(propertyReference, type);

    private static bool IsArgumentTypeOfNonGenericEnumerable(IInvocationOperation invocation, int argumentIndex) => IsArgumentTypeOf(invocation, argumentIndex, SpecialType.System_Collections_IEnumerable);
    private static bool IsArgumentTypeOf(IInvocationOperation invocation, int argumentIndex, SpecialType specialType)
        => invocation.Arguments[argumentIndex].Value.UnwrapConversion().Type.SpecialType == specialType;

    public class NunitCodeFixContext(Compilation compilation) : TestingFrameworkCodeFixProvider.TestingFrameworkCodeFixContext(compilation)
    {
        public INamedTypeSymbol Is { get; } = compilation.GetTypeByMetadataName("NUnit.Framework.Is");
        public INamedTypeSymbol Has { get; } = compilation.GetTypeByMetadataName("NUnit.Framework.Has");
        public INamedTypeSymbol Does { get; } = compilation.GetTypeByMetadataName("NUnit.Framework.Does");
        public INamedTypeSymbol Contains { get; } = compilation.GetTypeByMetadataName("NUnit.Framework.Contains");
        public INamedTypeSymbol Throws { get; } = compilation.GetTypeByMetadataName("NUnit.Framework.Throws");
        public INamedTypeSymbol ConstraintExpression { get; } = compilation.GetTypeByMetadataName("NUnit.Framework.Constraints.ConstraintExpression");
        public INamedTypeSymbol NUnitString { get; } = compilation.GetTypeByMetadataName("NUnit.Framework.NUnitString");
    }
}