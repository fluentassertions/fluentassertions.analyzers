using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Operations;
using CreateChangedDocument = System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<Microsoft.CodeAnalysis.Document>>;
using System;

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
            "Assert" when isNunit3 => TryComputeFixForNunit3Assert(invocation, context, t),
            "ClassicAssert" when isNunit4 => TryComputeFixForNunit4ClassicAssert(invocation, context, t),
            //"StringAssert" => TryComputeFixForStringAssert(invocation, context, testContext),
            //"CollectionAssert" => TryComputeFixForCollectionAssert(invocation, context, testContext),
            _ => null
        };
    }

    private CreateChangedDocument TryComputeFixForNunit3Assert(IInvocationOperation invocation, CodeFixContext context, TestingFrameworkCodeFixContext t)
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
        }

        return null;
    }

    private CreateChangedDocument TryComputeFixForNunit4ClassicAssert(IInvocationOperation invocation, CodeFixContext context, TestingFrameworkCodeFixContext t)
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
        }

        return null;
    }
}