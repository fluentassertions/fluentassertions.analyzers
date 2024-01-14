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
        return assertType.Name switch
        {
            "Assert" => TryComputeFixForAssert(invocation, context, t),
            //"StringAssert" => TryComputeFixForStringAssert(invocation, context, testContext),
            //"CollectionAssert" => TryComputeFixForCollectionAssert(invocation, context, testContext),
            _ => null
        };
    }

    private CreateChangedDocument TryComputeFixForAssert(IInvocationOperation invocation, CodeFixContext context, TestingFrameworkCodeFixContext t)
    {
        switch (invocation.TargetMethod.Name)
        {
            case "True":
            case "IsTrue":
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeTrue", subjectIndex: 0, argumentsToRemove: []);

            case "False":
            case "IsFalse":
                return DocumentEditorUtils.RenameMethodToSubjectShouldAssertion(invocation, context, "BeFalse", subjectIndex: 0, argumentsToRemove: []);
        }

        return null;
    }
}