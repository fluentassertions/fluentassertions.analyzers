using System.Collections.Immutable;
using System.Composition;
using System.Threading.Tasks;
using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using CreateChangedDocument = System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<Microsoft.CodeAnalysis.Document>>;

namespace FluentAssertions.Analyzers;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(MsTestCodeFixProvider)), Shared]
public class MsTestCodeFixProvider : CodeFixProvider
{
    const string Title = "Replace with FluentAssertions";
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertAnalyzer.MSTestsRule.Id);
    public override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

    public override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken);
        var semanticModel = await context.Document.GetSemanticModelAsync(context.CancellationToken);

        var testContext = new MsTestCodeFixContext(semanticModel.Compilation);
        foreach (var diagnostic in context.Diagnostics)
        {
            var node = root.FindNode(diagnostic.Location.SourceSpan);
            if (node is not InvocationExpressionSyntax invocationExpression)
            {
                continue;
            }

            var operation = semanticModel.GetOperation(invocationExpression, context.CancellationToken);
            if (operation is not IInvocationOperation invocation)
            {
                continue;
            }
            TryComputeFix(invocation, context, testContext, diagnostic);
        }
    }

    private void TryComputeFix(IInvocationOperation invocation, CodeFixContext context, MsTestCodeFixContext testContext, Diagnostic diagnostic)
    {
        var assertType = invocation.TargetMethod.ContainingType;
        var createChangedDocument = assertType.Name switch
        {
            "Assert" => TryComputeFixForAssert(invocation, context, testContext),
            "StringAssert" => TryComputeFixForStringAssert(invocation, context, testContext),
            "CollectionAssert" => TryComputeFixForCollectionAssert(invocation, context, testContext),
            _ => null
        };

        if (createChangedDocument is null)
        {
            return;
        }

        context.RegisterCodeFix(CodeAction.Create(Title, createChangedDocument, equivalenceKey: Title), diagnostic);
    }

    private CreateChangedDocument TryComputeFixForAssert(IInvocationOperation invocation, CodeFixContext context, MsTestCodeFixContext t)
    {
        switch (invocation.TargetMethod.Name)
        {
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemBoolean): // AreEqual(string? expected, string? actual, bool ignoreCase)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemBoolean, t.SystemString): // AreEqual(string? expected, string? actual, bool ignoreCase, string? message)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemBoolean, t.SystemString, t.ObjectArray): // AreEqual(string? expected, string? actual, bool ignoreCase, string? message, params object?[]? parameters)
                {
                    var ignoreCase = invocation.Arguments.Length >= 3 && invocation.Arguments[2].IsLiteralValue(true);
                    var newMethod = ignoreCase ? "BeEquivalentTo" : "Be";
                    return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, newMethod, argumentIndex: 1, argumentsToRemove: [2]);
                }
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemBoolean, t.SystemGlobalizationCultureInfo): // AreEqual(string? expected, string? actual, bool ignoreCase, CultureInfo? culture)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemBoolean, t.SystemGlobalizationCultureInfo, t.SystemString): // AreEqual(string? expected, string? actual, bool ignoreCase, CultureInfo? culture, string? message)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemBoolean, t.SystemGlobalizationCultureInfo, t.SystemString, t.ObjectArray): // AreEqual(string? expected, string? actual, bool ignoreCase, CultureInfo? culture, string? message, params object?[]? parameters)
                {
                    var ignoreCase = invocation.Arguments.Length >= 3 && invocation.Arguments[2].IsLiteralValue(true);
                    var newMethod = ignoreCase ? "BeEquivalentTo" : "Be";

                    if (!invocation.Arguments[3].IsStaticPropertyReference(t.SystemGlobalizationCultureInfo, "CurrentCulture"))
                    {
                        break; // TODO: Handle other cultures
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, newMethod, argumentIndex: 1, argumentsToRemove: [2, 3]);
                }
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemFloat, t.SystemFloat, t.SystemFloat): // AreEqual(float expected, float actual, float delta)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemFloat, t.SystemFloat, t.SystemFloat, t.SystemString): // AreEqual(float expected, float actual, float delta, string? message)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemFloat, t.SystemFloat, t.SystemFloat, t.SystemString, t.ObjectArray): // AreEqual(float expected, float actual, float delta, string? message, params object?[]? parameters)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemDouble, t.SystemDouble, t.SystemDouble): // AreEqual(double expected, double actual, double delta)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemDouble, t.SystemDouble, t.SystemDouble, t.SystemString): // AreEqual(double expected, double actual, double delta, string? message)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemDouble, t.SystemDouble, t.SystemDouble, t.SystemString, t.ObjectArray): // AreEqual(double expected, double actual, double delta, string? message, params object?[]? parameters)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemDecimal, t.SystemDecimal, t.SystemDecimal): // AreEqual(decimal expected, decimal actual, decimal delta)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemDecimal, t.SystemDecimal, t.SystemDecimal, t.SystemString): // AreEqual(decimal expected, decimal actual, decimal delta, string? message)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemDecimal, t.SystemDecimal, t.SystemDecimal, t.SystemString, t.ObjectArray): // AreEqual(decimal expected, decimal actual, decimal delta, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeApproximately", argumentIndex: 1, argumentsToRemove: []);
            case "AreEqual" when ArgumentsAreTypeOf(invocation, startFromIndex: 2): // AreEqual<T>(T? expected, T? actual)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, startFromIndex: 2, t.SystemString): // AreEqual<T>(T? expected, T? actual, string? message)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, startFromIndex: 2, t.SystemString, t.ObjectArray): // AreEqual<T>(T? expected, T? actual, string? message, params object?[]? parameters)
                if (invocation.Arguments[0].IsLiteralNull())
                {
                    return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeNull", argumentIndex: 1, argumentsToRemove: [0]);
                }
                else if (invocation.Arguments[1].IsLiteralNull())
                {
                    return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeNull", argumentIndex: 0, argumentsToRemove: [1]);
                }
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "Be", argumentIndex: 1, argumentsToRemove: []);
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemBoolean): // AreNotEqual(string? expected, string? actual, bool ignoreCase)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemBoolean, t.SystemString): // AreNotEqual(string? expected, string? actual, bool ignoreCase, string? message)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemBoolean, t.SystemString, t.ObjectArray): // AreNotEqual(string? expected, string? actual, bool ignoreCase, string? message, params object?[]? parameters)
                {
                    var ignoreCase = invocation.Arguments.Length >= 3 && invocation.Arguments[2].IsLiteralValue(true);
                    var newMethod = ignoreCase ? "NotBeEquivalentTo" : "NotBe";
                    return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, newMethod, argumentIndex: 1, argumentsToRemove: [2]);
                }
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemBoolean, t.SystemGlobalizationCultureInfo): // AreNotEqual(string? expected, string? actual, bool ignoreCase, CultureInfo? culture)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemBoolean, t.SystemGlobalizationCultureInfo, t.SystemString): // AreNotEqual(string? expected, string? actual, bool ignoreCase, CultureInfo? culture, string? message)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemBoolean, t.SystemGlobalizationCultureInfo, t.SystemString, t.ObjectArray): // AreNotEqual(string? expected, string? actual, bool ignoreCase, CultureInfo? culture, string? message, params object?[]? parameters)
                {
                    var ignoreCase = invocation.Arguments.Length >= 3 && invocation.Arguments[2].IsLiteralValue(true);
                    var newMethod = ignoreCase ? "NotBeEquivalentTo" : "NotBe";

                    if (!invocation.Arguments[3].IsStaticPropertyReference(t.SystemGlobalizationCultureInfo, "CurrentCulture"))
                    {
                        break; // TODO: Handle other cultures
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, newMethod, argumentIndex: 1, argumentsToRemove: [2, 3]);
                }
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemFloat, t.SystemFloat, t.SystemFloat): // AreNotEqual(float expected, float actual, float delta)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemFloat, t.SystemFloat, t.SystemFloat, t.SystemString): // AreNotEqual(float expected, float actual, float delta, string? message)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemFloat, t.SystemFloat, t.SystemFloat, t.SystemString, t.ObjectArray): // AreNotEqual(float expected, float actual, float delta, string? message, params object?[]? parameters)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemDouble, t.SystemDouble, t.SystemDouble): // AreNotEqual(double expected, double actual, double delta)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemDouble, t.SystemDouble, t.SystemDouble, t.SystemString): // AreNotEqual(double expected, double actual, double delta, string? message)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemDouble, t.SystemDouble, t.SystemDouble, t.SystemString, t.ObjectArray): // AreNotEqual(double expected, double actual, double delta, string? message, params object?[]? parameters)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemDecimal, t.SystemDecimal, t.SystemDecimal): // AreNotEqual(decimal expected, decimal actual, decimal delta)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemDecimal, t.SystemDecimal, t.SystemDecimal, t.SystemString): // AreNotEqual(decimal expected, decimal actual, decimal delta, string? message)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemDecimal, t.SystemDecimal, t.SystemDecimal, t.SystemString, t.ObjectArray): // AreNotEqual(decimal expected, decimal actual, decimal delta, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeApproximately", argumentIndex: 1, argumentsToRemove: []);
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, startFromIndex: 2): // AreNotEqual<T>(T? expected, T? actual)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, startFromIndex: 2, t.SystemString): // AreNotEqual<T>(T? expected, T? actual, string? message)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, startFromIndex: 2, t.SystemString, t.ObjectArray): // AreNotEqual<T>(T? expected, T? actual, string? message, params object?[]? parameters)
                if (invocation.Arguments[0].IsLiteralNull())
                {
                    return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeNull", argumentIndex: 1, argumentsToRemove: [0]);
                }
                else if (invocation.Arguments[1].IsLiteralNull())
                {
                    return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeNull", argumentIndex: 0, argumentsToRemove: [1]);
                }
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBe", argumentIndex: 1, argumentsToRemove: []);
            case "AreSame" when ArgumentsAreTypeOf(invocation, startFromIndex: 2): // AreSame(string? expected, string? actual)
            case "AreSame" when ArgumentsAreTypeOf(invocation, startFromIndex: 2, t.SystemString): // AreSame(string? expected, string? actual, string? message)
            case "AreSame" when ArgumentsAreTypeOf(invocation, startFromIndex: 2, t.SystemString, t.ObjectArray): // AreSame(string? expected, string? actual, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeSameAs", argumentIndex: 1, argumentsToRemove: []);
            case "AreNotSame" when ArgumentsAreTypeOf(invocation, startFromIndex: 2): // AreNotSame(string? expected, string? actual)
            case "AreNotSame" when ArgumentsAreTypeOf(invocation, startFromIndex: 2, t.SystemString): // AreNotSame(string? expected, string? actual, string? message)
            case "AreNotSame" when ArgumentsAreTypeOf(invocation, startFromIndex: 2, t.SystemString, t.ObjectArray): // AreNotSame(string? expected, string? actual, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeSameAs", argumentIndex: 1, argumentsToRemove: []);
            case "IsTrue" when ArgumentsAreTypeOf(invocation, t.SystemBoolean): // IsTrue(bool condition)
            case "IsTrue" when ArgumentsAreTypeOf(invocation, t.SystemBoolean, t.SystemString): // IsTrue(bool condition, string? message)
            case "IsTrue" when ArgumentsAreTypeOf(invocation, t.SystemBoolean, t.SystemString, t.ObjectArray): // IsTrue(bool condition, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeTrue", argumentIndex: 0, argumentsToRemove: []);
            case "IsFalse" when ArgumentsAreTypeOf(invocation, t.SystemBoolean): // IsFalse(bool condition)
            case "IsFalse" when ArgumentsAreTypeOf(invocation, t.SystemBoolean, t.SystemString): // IsFalse(bool condition, string? message)
            case "IsFalse" when ArgumentsAreTypeOf(invocation, t.SystemBoolean, t.SystemString, t.ObjectArray): // IsFalse(bool condition, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeFalse", argumentIndex: 0, argumentsToRemove: []);
            case "IsNull" when ArgumentsAreTypeOf(invocation, t.SystemObject): // IsNull(object? value)
            case "IsNull" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemString): // IsNull(object? value, string? message)
            case "IsNull" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemString, t.ObjectArray): // IsNull(object? value, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeNull", argumentIndex: 0, argumentsToRemove: []);
            case "IsNotNull" when ArgumentsAreTypeOf(invocation, t.SystemObject): // IsNotNull(object? value)
            case "IsNotNull" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemString): // IsNotNull(object? value, string? message)
            case "IsNotNull" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemString, t.ObjectArray): // IsNotNull(object? value, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeNull", argumentIndex: 0, argumentsToRemove: []);
            case "ThrowsException" when ArgumentsAreTypeOf(invocation, t.SystemAction): // ThrowsException<T>(Action action)
            case "ThrowsException" when ArgumentsAreTypeOf(invocation, t.SystemAction, t.SystemString): // ThrowsException<T>(Action action, string? message)
            case "ThrowsException" when ArgumentsAreTypeOf(invocation, t.SystemAction, t.SystemString, t.ObjectArray): // ThrowsException<T>(Action action, string? message, params object?[]? parameters)
            case "ThrowsException" when ArgumentsAreTypeOf(invocation, t.SystemFuncOfObject): // ThrowsException<T>(Func<object?> action)
            case "ThrowsException" when ArgumentsAreTypeOf(invocation, t.SystemFuncOfObject, t.SystemString): // ThrowsException<T>(Func<object?> action, string? message)
            case "ThrowsException" when ArgumentsAreTypeOf(invocation, t.SystemFuncOfObject, t.SystemString, t.ObjectArray): // ThrowsException<T>(Func<object?> action, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameGenericMethodToSubjectShouldGenericAssertion(invocation, context, "ThrowExactly", argumentIndex: 0, argumentsToRemove: []);
            case "ThrowsExceptionAsync" when ArgumentsAreTypeOf(invocation, t.SystemFuncOfTask): // ThrowsExceptionAsync<T>(Func<Task> action)
            case "ThrowsExceptionAsync" when ArgumentsAreTypeOf(invocation, t.SystemFuncOfTask, t.SystemString): // ThrowsExceptionAsync<T>(Func<Task> action, string? message)
            case "ThrowsExceptionAsync" when ArgumentsAreTypeOf(invocation, t.SystemFuncOfTask, t.SystemString, t.ObjectArray): // ThrowsExceptionAsync<T>(Func<Task> action, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameGenericMethodToSubjectShouldGenericAssertion(invocation, context, "ThrowExactlyAsync", argumentIndex: 0, argumentsToRemove: []);
            case "IsInstanceOfType" when ArgumentsAreTypeOf(invocation, t.SystemObject): // IsInstanceOfType<T>(object? value)
            case "IsInstanceOfType" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemString): // IsInstanceOfType<T>(object? value, string? message)
            case "IsInstanceOfType" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemString, t.ObjectArray): // IsInstanceOfType<T>(object? value, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameGenericMethodToSubjectShouldGenericAssertion(invocation, context, "BeOfType", argumentIndex: 0, argumentsToRemove: []);
            case "IsInstanceOfType" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemType): // IsInstanceOfType(object? value, Type expectedType)
            case "IsInstanceOfType" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemType, t.SystemString): // IsInstanceOfType(object? value, Type expectedType, string? message)
            case "IsInstanceOfType" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemType, t.SystemString, t.ObjectArray): // IsInstanceOfType(object? value, Type expectedType, string? message, params object?[]? parameters)
                {
                    if (invocation.Arguments[1].Value is not ITypeOfOperation typeOf)
                    {
                        return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeOfType", argumentIndex: 0, argumentsToRemove: []);
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldGenericAssertion(invocation, ImmutableArray.Create(typeOf.TypeOperand), context, "BeOfType", argumentIndex: 0, argumentsToRemove: [1]);
                }
            case "IsNotInstanceOfType" when ArgumentsAreTypeOf(invocation, t.SystemObject): // IsNotInstanceOfType<T>(object? value)
            case "IsNotInstanceOfType" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemString): // IsNotInstanceOfType<T>(object? value, string? message)
            case "IsNotInstanceOfType" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemString, t.ObjectArray): // IsNotInstanceOfType<T>(object? value, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameGenericMethodToSubjectShouldGenericAssertion(invocation, context, "NotBeOfType", argumentIndex: 0, argumentsToRemove: []);
            case "IsNotInstanceOfType" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemType): // IsNotInstanceOfType(object? value, Type expectedType)
            case "IsNotInstanceOfType" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemType, t.SystemString): // IsNotInstanceOfType(object? value, Type expectedType, string? message)
            case "IsNotInstanceOfType" when ArgumentsAreTypeOf(invocation, t.SystemObject, t.SystemType, t.SystemString, t.ObjectArray): // IsNotInstanceOfType(object? value, Type expectedType, string? message, params object?[]? parameters)
                {
                    if (invocation.Arguments[1].Value is not ITypeOfOperation typeOf)
                    {
                        return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeOfType", argumentIndex: 0, argumentsToRemove: []);
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldGenericAssertion(invocation, ImmutableArray.Create(typeOf.TypeOperand), context, "NotBeOfType", argumentIndex: 0, argumentsToRemove: [1]);
                }
        }

        return null;
    }

    private CreateChangedDocument TryComputeFixForStringAssert(IInvocationOperation invocation, CodeFixContext context, MsTestCodeFixContext t)
    {
        switch (invocation.TargetMethod.Name)
        {
            case "Contains" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString): // Contains(string? value, string? substring)
            case "Contains" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemString): // Contains(string? value, string? substring, string? message)
            case "Contains" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemString, t.ObjectArray): // Contains(string? value, string? substring, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "Contain", argumentIndex: 0, argumentsToRemove: []);
            case "Contains" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemStringComparison): // Contains(string? value, string? substring, StringComparison comparisonType)
                break; // TODO: support StringComparison constant values
            case "Contains" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemString, t.SystemStringComparison): // Contains(string? value, string? substring, string? message, StringComparison comparisonType)
            case "Contains" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemString, t.SystemStringComparison, t.ObjectArray): // Contains(string? value, string? substring, string? message, StringComparison comparisonType, params object?[]? parameters)
                break; // TODO: support StringComparison constant values
            case "StartsWith" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString): // StartsWith(string? value, string? substring)
            case "StartsWith" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemString): // StartsWith(string? value, string? substring, string? message)
            case "StartsWith" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemString, t.ObjectArray): // StartsWith(string? value, string? substring, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "StartWith", argumentIndex: 0, argumentsToRemove: []);
            case "StartsWith" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemStringComparison): // StartsWith(string? value, string? substring, StringComparison comparisonType)
                break; // TODO: support StringComparison constant values
            case "StartsWith" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemString, t.SystemStringComparison): // StartsWith(string? value, string? substring, string? message, StringComparison comparisonType)
            case "StartsWith" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemString, t.SystemStringComparison, t.ObjectArray): // StartsWith(string? value, string? substring, string? message, StringComparison comparisonType, params object?[]? parameters)
                break; // TODO: support StringComparison constant values
            case "EndsWith" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString): // EndsWith(string? value, string? substring)
            case "EndsWith" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemString): // EndsWith(string? value, string? substring, string? message)
            case "EndsWith" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemString, t.ObjectArray): // EndsWith(string? value, string? substring, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "EndWith", argumentIndex: 0, argumentsToRemove: []);
            case "EndsWith" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemStringComparison): // EndsWith(string? value, string? substring, StringComparison comparisonType)
                break; // TODO: support StringComparison constant values
            case "EndsWith" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemString, t.SystemStringComparison): // EndsWith(string? value, string? substring, string? message, StringComparison comparisonType)
            case "EndsWith" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemString, t.SystemString, t.SystemStringComparison, t.ObjectArray): // EndsWith(string? value, string? substring, string? message, StringComparison comparisonType, params object?[]? parameters)
                break; // TODO: support StringComparison constant values
            case "Matches" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemTextRegularExpressionsRegex): // Matches(string? value, Regex? pattern)
            case "Matches" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemTextRegularExpressionsRegex, t.SystemString): // Matches(string? value, Regex? pattern, string? message)
            case "Matches" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemTextRegularExpressionsRegex, t.SystemString, t.ObjectArray): // Matches(string? value, Regex? pattern, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "MatchRegex", argumentIndex: 0, argumentsToRemove: []);
            case "DoesNotMatch" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemTextRegularExpressionsRegex): // DoesNotMatch(string? value, Regex? pattern)
            case "DoesNotMatch" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemTextRegularExpressionsRegex, t.SystemString): // DoesNotMatch(string? value, Regex? pattern, string? message)
            case "DoesNotMatch" when ArgumentsAreTypeOf(invocation, t.SystemString, t.SystemTextRegularExpressionsRegex, t.SystemString, t.ObjectArray): // DoesNotMatch(string? value, Regex? pattern, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotMatchRegex", argumentIndex: 0, argumentsToRemove: []);
        }
        return null;
    }

    private CreateChangedDocument TryComputeFixForCollectionAssert(IInvocationOperation invocation, CodeFixContext context, MsTestCodeFixContext t)
    {
        if (!invocation.Arguments[0].ImplementsOrIsInterface(SpecialType.System_Collections_Generic_IEnumerable_T))
        {
            return null;
        }

        switch (invocation.TargetMethod.Name)
        {
            case "Contains" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemObject): // Contains(ICollection collection, object? element)
            case "Contains" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemObject, t.SystemString): // Contains(ICollection collection, object? element, string? message)
            case "Contains" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemObject, t.SystemString, t.ObjectArray): // Contains(ICollection collection, object? element, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "Contain", argumentIndex: 0, argumentsToRemove: []);
            case "DoesNotContain" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemObject): // DoesNotContain(ICollection collection, object? element)
            case "DoesNotContain" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemObject, t.SystemString): // DoesNotContain(ICollection collection, object? element, string? message)
            case "DoesNotContain" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemObject, t.SystemString, t.ObjectArray): // DoesNotContain(ICollection collection, object? element, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotContain", argumentIndex: 0, argumentsToRemove: []);
            case "AllItemsAreNotNull" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection): // AllItemsAreInstancesOfType(ICollection collection)
            case "AllItemsAreNotNull" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemString): // AllItemsAreInstancesOfType(ICollection collection, string? message)
            case "AllItemsAreNotNull" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemString, t.ObjectArray): // AllItemsAreInstancesOfType(ICollection collection, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotContainNulls", argumentIndex: 0, argumentsToRemove: []);
            case "AllItemsAreUnique" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection): // AllItemsAreUnique(ICollection collection)
            case "AllItemsAreUnique" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemString): // AllItemsAreUnique(ICollection collection, string? message)
            case "AllItemsAreUnique" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemString, t.ObjectArray): // AllItemsAreUnique(ICollection collection, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "OnlyHaveUniqueItems", argumentIndex: 0, argumentsToRemove: []);
            case "IsSubsetOf" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection): // IsSubsetOf(ICollection subset, ICollection superset)
            case "IsSubsetOf" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemString): // IsSubsetOf(ICollection subset, ICollection superset, string? message)
            case "IsSubsetOf" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemString, t.ObjectArray): // IsSubsetOf(ICollection subset, ICollection superset, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeSubsetOf", argumentIndex: 0, argumentsToRemove: []);
            case "IsNotSubsetOf" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection): // IsNotSubsetOf(ICollection subset, ICollection superset)
            case "IsNotSubsetOf" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemString): // IsNotSubsetOf(ICollection subset, ICollection superset, string? message)
            case "IsNotSubsetOf" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemString, t.ObjectArray): // IsNotSubsetOf(ICollection subset, ICollection superset, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeSubsetOf", argumentIndex: 0, argumentsToRemove: []);
            case "AreEquivalent" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection): // AreEquivalent(ICollection expected, ICollection actual)
            case "AreEquivalent" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemString): // AreEquivalent(ICollection expected, ICollection actual, string? message)
            case "AreEquivalent" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemString, t.ObjectArray): // AreEquivalent(ICollection expected, ICollection actual, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeEquivalentTo", argumentIndex: 1, argumentsToRemove: []);
            case "AreNotEquivalent" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection): // AreNotEquivalent(ICollection expected, ICollection actual)
            case "AreNotEquivalent" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemString): // AreNotEquivalent(ICollection expected, ICollection actual, string? message)
            case "AreNotEquivalent" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemString, t.ObjectArray): // AreNotEquivalent(ICollection expected, ICollection actual, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotBeEquivalentTo", argumentIndex: 1, argumentsToRemove: []);
            case "AllItemsAreInstancesOfType" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemType): // AllItemsAreInstancesOfType(ICollection collection, Type expectedType)
            case "AllItemsAreInstancesOfType" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemType, t.SystemString): // AllItemsAreInstancesOfType(ICollection collection, Type expectedType, string? message)
            case "AllItemsAreInstancesOfType" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemType, t.SystemString, t.ObjectArray): // AllItemsAreInstancesOfType(ICollection collection, Type expectedType, string? message, params object?[]? parameters)
                {
                    if (invocation.Arguments[1].Value is not ITypeOfOperation typeOf)
                    {
                        return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "AllBeOfType", argumentIndex: 0, argumentsToRemove: []);
                    }

                    return DocumentEditorUtils.RenameMethodToSubjectShouldGenericAssertion(invocation, ImmutableArray.Create(typeOf.TypeOperand), context, "AllBeOfType", argumentIndex: 0, argumentsToRemove: [1]);
                }
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection): // AreEqual(ICollection expected, ICollection actual)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemString): // AreEqual(ICollection expected, ICollection actual, string? message)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemString, t.ObjectArray): // AreEqual(ICollection expected, ICollection actual, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "Equal", argumentIndex: 1, argumentsToRemove: []);
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemCollectionsIComparer): // AreEqual(ICollection expected, ICollection actual, IComparer? comparer)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemCollectionsIComparer, t.SystemString): // AreEqual(ICollection expected, ICollection actual, IComparer? comparer, string? message)
            case "AreEqual" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemCollectionsIComparer, t.SystemString, t.ObjectArray): // AreEqual(ICollection expected, ICollection actual, IComparer? comparer, string? message, params object?[]? parameters)
                break; // TODO: support IComparer
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection): // AreNotEqual(ICollection notExpected, ICollection actual)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemString): // AreNotEqual(ICollection notExpected, ICollection actual, string? message)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemString, t.ObjectArray): // AreNotEqual(ICollection notExpected, ICollection actual, string? message, params object?[]? parameters)
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "NotEqual", argumentIndex: 1, argumentsToRemove: []);
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemCollectionsIComparer): // AreNotEqual(ICollection notExpected, ICollection actual, IComparer? comparer)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemCollectionsIComparer, t.SystemString): // AreNotEqual(ICollection notExpected, ICollection actual, IComparer? comparer, string? message)
            case "AreNotEqual" when ArgumentsAreTypeOf(invocation, t.SystemCollectionsICollection, t.SystemCollectionsICollection, t.SystemCollectionsIComparer, t.SystemString, t.ObjectArray): // AreNotEqual(ICollection notExpected, ICollection actual, IComparer? comparer, string? message, params object?[]? parameters)
                break; // TODO: support IComparer
        }
        return null;
    }

    private static bool ArgumentsAreTypeOf(IInvocationOperation invocation, params ITypeSymbol[] types) => ArgumentsAreTypeOf(invocation, 0, types);
    private static bool ArgumentsAreTypeOf(IInvocationOperation invocation, int startFromIndex, params ITypeSymbol[] types)
    {
        if (invocation.TargetMethod.Parameters.Length != types.Length + startFromIndex)
        {
            return false;
        }

        for (int i = startFromIndex; i < types.Length; i++)
        {
            if (!invocation.TargetMethod.Parameters[i].Type.EqualsSymbol(types[i]))
            {
                return false;
            }
        }

        return true;
    }

    private sealed class MsTestCodeFixContext(Compilation compilation)
    {
        public INamedTypeSymbol SystemObject { get; } = compilation.ObjectType;
        public INamedTypeSymbol SystemString { get; } = compilation.GetTypeByMetadataName("System.String");
        public INamedTypeSymbol SystemFloat { get; } = compilation.GetTypeByMetadataName("System.Single");
        public INamedTypeSymbol SystemDouble { get; } = compilation.GetTypeByMetadataName("System.Double");
        public INamedTypeSymbol SystemDecimal { get; } = compilation.GetTypeByMetadataName("System.Decimal");
        public INamedTypeSymbol SystemBoolean { get; } = compilation.GetTypeByMetadataName("System.Boolean");
        public INamedTypeSymbol SystemAction { get; } = compilation.GetTypeByMetadataName("System.Action");
        public INamedTypeSymbol SystemType { get; } = compilation.GetTypeByMetadataName("System.Type");
        public INamedTypeSymbol SystemFuncOfObject { get; } = compilation.GetTypeByMetadataName("System.Func`1").Construct(compilation.ObjectType);
        public INamedTypeSymbol SystemFuncOfTask { get; } = compilation.GetTypeByMetadataName("System.Func`1").Construct(compilation.GetTypeByMetadataName("System.Threading.Tasks.Task"));
        public IArrayTypeSymbol ObjectArray { get; } = compilation.CreateArrayTypeSymbol(compilation.ObjectType);
        public INamedTypeSymbol SystemGlobalizationCultureInfo { get; } = compilation.GetTypeByMetadataName("System.Globalization.CultureInfo");
        public INamedTypeSymbol SystemStringComparison { get; } = compilation.GetTypeByMetadataName("System.StringComparison");
        public INamedTypeSymbol SystemTextRegularExpressionsRegex { get; } = compilation.GetTypeByMetadataName("System.Text.RegularExpressions.Regex");
        public INamedTypeSymbol SystemCollectionsICollection { get; } = compilation.GetTypeByMetadataName("System.Collections.ICollection");
        public INamedTypeSymbol SystemCollectionsIComparer { get; } = compilation.GetTypeByMetadataName("System.Collections.IComparer");

    }
}
