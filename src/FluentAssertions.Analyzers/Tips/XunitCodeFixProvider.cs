using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Operations;
using CreateChangedDocument = System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<Microsoft.CodeAnalysis.Document>>;

namespace FluentAssertions.Analyzers;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(XunitCodeFixProvider)), Shared]
public class XunitCodeFixProvider : TestingFrameworkCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertAnalyzer.XunitRule.Id);

    protected override CreateChangedDocument TryComputeFix(IInvocationOperation invocation, CodeFixContext context, TestingFrameworkCodeFixContext t, Diagnostic diagnostic)
    {
        switch (invocation.TargetMethod.Name)
        {
            case "True" when ArgumentsAreTypeOf(invocation, t.Boolean): // Assert.True(bool condition)
            case "True" when ArgumentsAreTypeOf(invocation, t.Boolean, t.String): // Assert.True(bool condition, string userMessage)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeTrue", subjectIndex: 0, argumentsToRemove: []);
            case "False" when ArgumentsAreTypeOf(invocation, t.Boolean): // Assert.False(bool condition)
            case "False" when ArgumentsAreTypeOf(invocation, t.Boolean, t.String): // Assert.False(bool condition, string userMessage)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeFalse", subjectIndex: 0, argumentsToRemove: []);
            case "Same" when ArgumentsAreTypeOf(invocation, t.Object, t.Object): // Assert.Same(object expected, object actual)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeSameAs", subjectIndex: 1, argumentsToRemove: []);
            case "NotSame" when ArgumentsAreTypeOf(invocation, t.Object, t.Object): // Assert.NotSame(object expected, object actual)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeSameAs", subjectIndex: 1, argumentsToRemove: []);
            case "Equal" when ArgumentsAreTypeOf(invocation, t.Float, t.Float, t.Float): // Assert.Equal(float expected, float actual, float tolerance)
            case "Equal" when ArgumentsAreTypeOf(invocation, t.Double, t.Double, t.Double): // Assert.Equal(double expected, double actual, double tolerance)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeApproximately", subjectIndex: 1, argumentsToRemove: []);
            case "Equal" when ArgumentsAreTypeOf(invocation, t.Float, t.Float, t.Int32): // Assert.Equal(float expected, float actual, int precision)
            case "Equal" when ArgumentsAreTypeOf(invocation, t.Double, t.Double, t.Int32): // Assert.Equal(double expected, double actual, int precision)
            case "Equal" when ArgumentsAreTypeOf(invocation, t.Decimal, t.Decimal, t.Int32): // Assert.Equal(decimal expected, decimal actual, int precision)
                break; // TODO: support this
            case "Equal" when ArgumentsAreTypeOf(invocation, t.DateTime, t.DateTime): // Assert.Equal(DateTime expected, DateTime actual)
            case "Equal" when ArgumentsAreTypeOf(invocation, t.String, t.String): // Assert.Equal(string expected, string actual)
            case "Equal" when ArgumentsAreTypeOf(invocation, t.Object, t.Object): // Assert.Equal(object expected, object actual)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "Be", subjectIndex: 1, argumentsToRemove: []);
            case "Equal" when ArgumentsAreTypeOf(invocation, t.DateTime, t.DateTime, t.TimeSpan): // Assert.Equal(DateTime expected, DateTime actual, TimeSpan precision)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeCloseTo", subjectIndex: 1, argumentsToRemove: []);
            case "Equal" when ArgumentsAreGenericTypeOf(invocation, t.Identity, t.Identity, t.IEqualityComparerOfT1): // Assert.Equal<T>(T expected, T actual, IEqualityComparer<T> comparer)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertionWithOptionsLambda(invocation, context, "BeEquivalentTo", subjectIndex: 1, optionsIndex: 2);
            case "NotEqual" when ArgumentsAreTypeOf(invocation, t.Float, t.Float, t.Float): // Assert.NotEqual(float expected, float actual, float tolerance)
            case "NotEqual" when ArgumentsAreTypeOf(invocation, t.Double, t.Double, t.Double): // Assert.NotEqual(double expected, double actual, double tolerance)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeApproximately", subjectIndex: 1, argumentsToRemove: []);
            case "NotEqual" when ArgumentsAreTypeOf(invocation, t.Float, t.Float, t.Int32): // Assert.NotEqual(float expected, float actual, int precision)
            case "NotEqual" when ArgumentsAreTypeOf(invocation, t.Double, t.Double, t.Int32): // Assert.NotEqual(double expected, double actual, int precision)
            case "NotEqual" when ArgumentsAreTypeOf(invocation, t.Decimal, t.Decimal, t.Int32): // Assert.NotEqual(decimal expected, decimal actual, int precision)
                break; // TODO: support this
            case "NotEqual" when ArgumentsAreTypeOf(invocation, t.DateTime, t.DateTime): // Assert.NotEqual(DateTime expected, DateTime actual)
            case "NotEqual" when ArgumentsAreTypeOf(invocation, t.String, t.String): // Assert.NotEqual(string expected, string actual)
            case "NotEqual" when ArgumentsAreTypeOf(invocation, t.Object, t.Object): // Assert.NotEqual(object expected, object actual)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBe", subjectIndex: 1, argumentsToRemove: []);
            case "NotEqual" when ArgumentsAreTypeOf(invocation, t.DateTime, t.DateTime, t.TimeSpan): // Assert.NotEqual(DateTime expected, DateTime actual, TimeSpan precision)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeCloseTo", subjectIndex: 1, argumentsToRemove: []);
            case "NotEqual" when ArgumentsAreGenericTypeOf(invocation, t.Identity, t.Identity, t.IEqualityComparerOfT1): // Assert.NotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertionWithOptionsLambda(invocation, context, "NotBeEquivalentTo", subjectIndex: 1, optionsIndex: 2);
            case "StrictEqual" when ArgumentsCount(invocation, arguments: 2): // Assert.StrictEqual<T>(T expected, T actual)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "Be", subjectIndex: 1, argumentsToRemove: []);
            case "NotStrictEqual" when ArgumentsCount(invocation, arguments: 2): // Assert.NotStrictEqual<T>(T expected, T actual)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBe", subjectIndex: 1, argumentsToRemove: []);
            case "Null" when ArgumentsCount(invocation, arguments: 1): // Assert.Null(object? @object)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeNull", subjectIndex: 0, argumentsToRemove: []);
            case "NotNull" when ArgumentsCount(invocation, arguments: 1): // Assert.NotNull(object? @object)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeNull", subjectIndex: 0, argumentsToRemove: []);
            case "Contains" when ArgumentsCount(invocation, arguments: 2): // Assert.Contains<T>(T expected, IEnumerable<T> collection)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "Contain", subjectIndex: 1, argumentsToRemove: []);
            case "Contains" when ArgumentsAreGenericTypeOf(invocation, t.Identity, t.IEnumerableOfT1, t.IEqualityComparerOfT1): // Assert.Contains<T>(T expected, IEnumerable<T> collection, IEqualityComparer<T> comparer)
                break; // TODO: support this
            case "DoesNotContain" when ArgumentsCount(invocation, arguments: 2): // Assert.DoesNotContain(string expectedSubstring, string? actualString)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotContain", subjectIndex: 1, argumentsToRemove: []);
            case "DoesNotContain" when ArgumentsAreGenericTypeOf(invocation, t.Identity, t.IEnumerableOfT1, t.IEqualityComparerOfT1): // Assert.DoesNotContain<T>(T expected, IEnumerable<T> collection, IEqualityComparer<T> comparer)
                break; // TODO: support this
            case "Matches" when ArgumentsAreTypeOf(invocation, t.String, t.String): // Assert.Matches(string regexPattern, string? actualString)
            case "Matches" when ArgumentsAreTypeOf(invocation, t.Regex, t.String): // Assert.Matches(Regex regexPattern, string? actualString)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "MatchRegex", subjectIndex: 1, argumentsToRemove: []);
            case "DoesNotMatch" when ArgumentsAreTypeOf(invocation, t.String, t.String): // Assert.DoesNotMatch(string regexPattern, string? actualString)
            case "DoesNotMatch" when ArgumentsAreTypeOf(invocation, t.Regex, t.String): // Assert.DoesNotMatch(Regex regexPattern, string? actualString)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotMatchRegex", subjectIndex: 1, argumentsToRemove: []);
            case "Empty" when ArgumentsCount(invocation, arguments: 1): // Assert.Empty(string value) | Assert.Empty(IEnumerable collection)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeEmpty", subjectIndex: 0, argumentsToRemove: []);
            // TODO: support NotEmpty
            case "EndsWith" when ArgumentsAreTypeOf(invocation, t.String, t.String): // Assert.EndsWith(string expectedEndString, string? actualString)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "EndWith", subjectIndex: 1, argumentsToRemove: []);
            case "StartsWith" when ArgumentsAreTypeOf(invocation, t.String, t.String): // Assert.StartsWith(string expectedStartString, string? actualString)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "StartWith", subjectIndex: 1, argumentsToRemove: []);
            case "Subset" when ArgumentsCount(invocation, arguments: 2): // Assert.Subset<T>(ISet<T> expectedSubset, ISet<T> actualSet)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeSubsetOf", subjectIndex: 1, argumentsToRemove: []);
            case "IsAssignableFrom" when ArgumentsCount(invocation, arguments: 1): // Assert.IsAssignableFrom<T>(object? @object)
                return DocumentEditorUtils.RenameGenericMethodToSubjectShouldGenericAssertion(invocation, context, "BeAssignableTo", subjectIndex: 0, argumentsToRemove: []);
            case "IsAssignableFrom" when ArgumentsCount(invocation, arguments: 2): // Assert.IsAssignableFrom(Type expectedType, object? @object) 
                {
                    if (invocation.Arguments[0].Value is not ITypeOfOperation typeOf)
                    {
                        return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeAssignableTo", subjectIndex: 1, argumentsToRemove: []);
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldGenericAssertion(invocation, ImmutableArray.Create(typeOf.TypeOperand), context, "BeAssignableTo", subjectIndex: 1, argumentsToRemove: [0]);
                }
            case "IsNotAssignableFrom" when ArgumentsCount(invocation, arguments: 1): // Assert.IsNotAssignableFrom<T>(object? @object)
                return DocumentEditorUtils.RenameGenericMethodToSubjectShouldGenericAssertion(invocation, context, "NotBeAssignableTo", subjectIndex: 0, argumentsToRemove: []);
            case "IsNotAssignableFrom" when ArgumentsCount(invocation, arguments: 2): // Assert.IsNotAssignableFrom(Type expectedType, object? @object) 
                {
                    if (invocation.Arguments[0].Value is not ITypeOfOperation typeOf)
                    {
                        return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeAssignableTo", subjectIndex: 1, argumentsToRemove: []);
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldGenericAssertion(invocation, ImmutableArray.Create(typeOf.TypeOperand), context, "NotBeAssignableTo", subjectIndex: 1, argumentsToRemove: [0]);
                }
            case "IsType" when ArgumentsCount(invocation, 1): // Assert.IsType<T>(object @object)
                return DocumentEditorUtils.RenameGenericMethodToSubjectShouldGenericAssertion(invocation, context, "BeOfType", subjectIndex: 0, argumentsToRemove: []);
            case "IsType" when ArgumentsCount(invocation, arguments: 2): // Assert.IsType(Type expectedType, object? @object) 
                {
                    if (invocation.Arguments[0].Value is not ITypeOfOperation typeOf)
                    {
                        return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeOfType", subjectIndex: 1, argumentsToRemove: []);
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldGenericAssertion(invocation, ImmutableArray.Create(typeOf.TypeOperand), context, "BeOfType", subjectIndex: 1, argumentsToRemove: [0]);
                }
            case "IsNotType" when ArgumentsCount(invocation, 1): // Assert.IsNotType<T>(object @object)
                return DocumentEditorUtils.RenameGenericMethodToSubjectShouldGenericAssertion(invocation, context, "NotBeOfType", subjectIndex: 0, argumentsToRemove: []);
            case "IsNotType" when ArgumentsCount(invocation, arguments: 2): // Assert.IsNotType(Type expectedType, object? @object) 
                {
                    if (invocation.Arguments[0].Value is not ITypeOfOperation typeOf)
                    {
                        return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeOfType", subjectIndex: 1, argumentsToRemove: []);
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldGenericAssertion(invocation, ImmutableArray.Create(typeOf.TypeOperand), context, "NotBeOfType", subjectIndex: 1, argumentsToRemove: [0]);
                }
            case "InRange" when ArgumentsCount(invocation, 3): // Assert.InRange<T>(T actual, T low, T high)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeInRange", subjectIndex: 0, argumentsToRemove: []);
            case "NotInRange" when ArgumentsCount(invocation, 3): // Assert.NotInRange<T>(T actual, T low, T high)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeInRange", subjectIndex: 0, argumentsToRemove: []);
        }
        return null;
    }
}