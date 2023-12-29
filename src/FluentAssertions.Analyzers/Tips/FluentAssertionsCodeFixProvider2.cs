using System;
using System.Collections.Immutable;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Operations;

namespace FluentAssertions.Analyzers;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(FluentAssertionsCodeFix)), Shared]
public class FluentAssertionsCodeFixProvider : CodeFixProviderBase<FluentAssertionsCodeFixProvider.EmptyTestContext>
{
    protected override string Title => FluentAssertionsOperationAnalyzer.Title;
    public override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create(FluentAssertionsOperationAnalyzer.DiagnosticId);

    protected override Func<CancellationToken, Task<Document>> TryComputeFix(IInvocationOperation invocation, CodeFixContext context, EmptyTestContext t, Diagnostic diagnostic)
    {
        if (!diagnostic.Properties.TryGetValue(Constants.DiagnosticProperties.VisitorName, out var visitorName))
        {
            return null;
        }

        if (visitorName == DiagnosticMetadata.ShouldEquals.Name)
        {
            return null;
        }

        switch (visitorName)
        {
            case nameof(DiagnosticMetadata.CollectionShouldBeEmpty_AnyShouldBeFalse):
                return DocumentEditorUtils.RemoveExpressionBeforeShouldAndRenameAssertion(invocation, context, "BeEmpty");
            case nameof(DiagnosticMetadata.CollectionShouldNotBeEmpty_AnyShouldBeTrue):
                return DocumentEditorUtils.RemoveExpressionBeforeShouldAndRenameAssertion(invocation, context, "NotBeEmpty");
            case nameof(DiagnosticMetadata.CollectionShouldBeEmpty_ShouldHaveCount0):
                return DocumentEditorUtils.RenameAssertionAndRemoveArguments(invocation, context, "BeEmpty", removeArgumentIndex: 0);
            case nameof(DiagnosticMetadata.CollectionShouldBeInAscendingOrder_OrderByShouldEqual):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithoutFirstArgumentWithArgumentsFromRemoved(invocation, context, "BeInAscendingOrder");
            case nameof(DiagnosticMetadata.CollectionShouldBeInDescendingOrder_OrderByDescendingShouldEqual):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithoutFirstArgumentWithArgumentsFromRemoved(invocation, context, "BeInDescendingOrder");
            case nameof(DiagnosticMetadata.CollectionShouldContainItem_ContainsShouldBeTrue):
            case nameof(DiagnosticMetadata.CollectionShouldContainProperty_AnyWithLambdaShouldBeTrue):
            case nameof(DiagnosticMetadata.CollectionShouldContainProperty_WhereShouldNotBeEmpty):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "Contain");
            case nameof(DiagnosticMetadata.CollectionShouldContainSingle_ShouldHaveCount1):
                return DocumentEditorUtils.RenameAssertionAndRemoveArguments(invocation, context, "ContainSingle", removeArgumentIndex: 0);
            case nameof(DiagnosticMetadata.CollectionShouldContainSingle_WhereShouldHaveCount1):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithoutFirstArgumentWithArgumentsFromRemoved(invocation, context, "ContainSingle");
            case nameof(DiagnosticMetadata.CollectionShouldEqualOtherCollectionByComparer_SelectShouldEqualOtherCollectionSelect):
                break;
            // return GetNewExpressionForSelectShouldEqualOtherCollectionSelectSyntaxVisitor(expression);
            case nameof(DiagnosticMetadata.CollectionShouldBeEmpty_CountShouldBe0):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithoutFirstArgumentWithArgumentsFromRemoved(invocation, context, "BeEmpty");
            case nameof(DiagnosticMetadata.CollectionShouldContainSingle_CountShouldBe1):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithoutFirstArgumentWithArgumentsFromRemoved(invocation, context, "ContainSingle");
            case nameof(DiagnosticMetadata.CollectionShouldHaveCount_CountShouldBe):
                return DocumentEditorUtils.RemoveExpressionBeforeShouldAndRenameAssertion(invocation, context, "HaveCount");
            case nameof(DiagnosticMetadata.CollectionShouldHaveCount_LengthShouldBe):
                return DocumentEditorUtils.RemoveExpressionBeforeShouldAndRenameAssertion(invocation, context, "HaveCount");
            case nameof(DiagnosticMetadata.CollectionShouldHaveCountGreaterOrEqualTo_CountShouldBeGreaterOrEqualTo):
                return DocumentEditorUtils.RemoveExpressionBeforeShouldAndRenameAssertion(invocation, context, "HaveCountGreaterOrEqualTo");
            case nameof(DiagnosticMetadata.CollectionShouldHaveCountGreaterThan_CountShouldBeGreaterThan):
                return DocumentEditorUtils.RemoveExpressionBeforeShouldAndRenameAssertion(invocation, context, "HaveCountGreaterThan");
            case nameof(DiagnosticMetadata.CollectionShouldHaveCountLessOrEqualTo_CountShouldBeLessOrEqualTo):
                return DocumentEditorUtils.RemoveExpressionBeforeShouldAndRenameAssertion(invocation, context, "HaveCountLessOrEqualTo");
            case nameof(DiagnosticMetadata.CollectionShouldHaveCountLessThan_CountShouldBeLessThan):
                return DocumentEditorUtils.RemoveExpressionBeforeShouldAndRenameAssertion(invocation, context, "HaveCountLessThan");
            case nameof(DiagnosticMetadata.CollectionShouldIntersectWith_IntersectShouldNotBeEmpty):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "IntersectWith");
            case nameof(DiagnosticMetadata.CollectionShouldHaveSameCount_ShouldHaveCountOtherCollectionCount):
                return DocumentEditorUtils.RenameAssertionAndRemoveInvocationOfMethodOnFirstArgument(invocation, context, "HaveSameCount");
            case nameof(DiagnosticMetadata.CollectionShouldNotContainItem_ContainsShouldBeFalse):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "NotContain");
            case nameof(DiagnosticMetadata.CollectionShouldNotContainNulls_SelectShouldNotContainNulls):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "NotContainNulls");
            case nameof(DiagnosticMetadata.CollectionShouldNotContainProperty_AnyLambdaShouldBeFalse):
            case nameof(DiagnosticMetadata.CollectionShouldNotContainProperty_WhereShouldBeEmpty):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "NotContain");
            case nameof(DiagnosticMetadata.CollectionShouldNotContainProperty_ShouldOnlyContainNot):
                break; // TODO: support negation of lambda, rename to "NotContain"
            case nameof(DiagnosticMetadata.CollectionShouldNotHaveCount_CountShouldNotBe):
                return DocumentEditorUtils.RemoveExpressionBeforeShouldAndRenameAssertion(invocation, context, "NotHaveCount");
            case nameof(DiagnosticMetadata.CollectionShouldNotHaveSameCount_CountShouldNotBeOtherCollectionCount):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionAndRemoveInvocationOfMethodOnFirstArgument(invocation, context, "NotHaveSameCount");
            case nameof(DiagnosticMetadata.CollectionShouldNotIntersectWith_IntersectShouldBeEmpty):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "NotIntersectWith");
            case nameof(DiagnosticMetadata.CollectionShouldOnlyContainProperty_AllShouldBeTrue):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "OnlyContain");
            case nameof(DiagnosticMetadata.CollectionShouldOnlyHaveUniqueItems_ShouldHaveSameCountThisCollectionDistinct):
                return DocumentEditorUtils.RenameAssertionAndRemoveArguments(invocation, context, "OnlyHaveUniqueItems", removeArgumentIndex: 0);
            case nameof(DiagnosticMetadata.CollectionShouldOnlyHaveUniqueItemsByComparer_SelectShouldOnlyHaveUniqueItems):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "OnlyHaveUniqueItems");
            case nameof(DiagnosticMetadata.CollectionShouldNotBeNullOrEmpty_ShouldNotBeNullAndNotBeEmpty):
            case nameof(DiagnosticMetadata.StringShouldNotBeNullOrEmpty_StringShouldNotBeNullAndNotBeEmpty):
                break;
            // return GetCombinedAssertions("NotBeEmpty", "NotBeNull", "NotBeNullOrEmpty");
            case nameof(DiagnosticMetadata.CollectionShouldNotBeNullOrEmpty_ShouldNotBeEmptyAndNotBeNull):
            case nameof(DiagnosticMetadata.StringShouldNotBeNullOrEmpty_StringShouldNotBeEmptyAndNotBeNull):
                break;
            // return GetCombinedAssertions("NotBeNull", "NotBeEmpty", "NotBeNullOrEmpty");
            case nameof(DiagnosticMetadata.CollectionShouldHaveElementAt_ElementAtIndexShouldBe):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "HaveElementAt");
            case nameof(DiagnosticMetadata.CollectionShouldHaveElementAt_IndexerShouldBe):
                break;
            // {
            //     var remove = NodeReplacement.RemoveAndRetrieveIndexerArguments("Should");
            //     var newExpression = GetNewExpression(expression, remove);
            //     return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("Be", "HaveElementAt", remove.Arguments));
            // }
            case nameof(DiagnosticMetadata.CollectionShouldHaveElementAt_SkipFirstShouldBe):
                break;
            // {
            //     var remove = NodeReplacement.RemoveAndExtractArguments("Skip");
            //     var newExpression = GetNewExpression(expression, remove, NodeReplacement.Remove("First"));
            //     return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("Be", "HaveElementAt", remove.Arguments));
            // }
            case nameof(DiagnosticMetadata.NumericShouldBePositive_ShouldBeGreaterThan):
                return DocumentEditorUtils.RenameAssertionAndRemoveArguments(invocation, context, "BePositive", removeArgumentIndex: 0);
            case nameof(DiagnosticMetadata.NumericShouldBeNegative_ShouldBeLessThan):
                return DocumentEditorUtils.RenameAssertionAndRemoveArguments(invocation, context, "BeNegative", removeArgumentIndex: 0);
            case nameof(DiagnosticMetadata.NumericShouldBeInRange_BeGreaterOrEqualToAndBeLessOrEqualTo):
                break;
            // return GetCombinedAssertionsWithArguments(remove: "BeLessOrEqualTo", rename: "BeGreaterOrEqualTo", newName: "BeInRange");
            case nameof(DiagnosticMetadata.NumericShouldBeInRange_BeLessOrEqualToAndBeGreaterOrEqualTo):
                break;
            // return GetCombinedAssertionsWithArguments(remove: "BeGreaterOrEqualTo", rename: "BeLessOrEqualTo", newName: "BeInRange");
            case nameof(DiagnosticMetadata.NumericShouldBeApproximately_MathAbsShouldBeLessOrEqualTo):
                break; /*
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Abs");
                    var newExpression = GetNewExpression(expression, remove);

                    var subtractExpression = (BinaryExpressionSyntax)remove.Arguments[0].Expression;

                    var actual = subtractExpression.Right as IdentifierNameSyntax;
                    var expected = subtractExpression.Left;

                    newExpression = GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeLessOrEqualTo", "BeApproximately", new SeparatedSyntaxList<ArgumentSyntax>().Add(SyntaxFactory.Argument(expected))));

                    return RenameIdentifier(newExpression, "Math", actual.Identifier.Text);
                }
                */
            case nameof(DiagnosticMetadata.StringShouldBeNullOrEmpty_StringIsNullOrEmptyShouldBeTrue):
                break;/*
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrEmpty");
                    var newExpression = GetNewExpression(expression, remove);

                    var rename = NodeReplacement.Rename("BeTrue", "BeNullOrEmpty");
                    newExpression = GetNewExpression(newExpression, rename);

                    var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                    var subject = remove.Arguments[0].Expression;

                    return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
                } */
            case nameof(DiagnosticMetadata.StringShouldBeNullOrWhiteSpace_StringIsNullOrWhiteSpaceShouldBeTrue):
                break; /*
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrWhiteSpace");
                    var newExpression = GetNewExpression(expression, remove);

                    var rename = NodeReplacement.Rename("BeTrue", "BeNullOrWhiteSpace");
                    newExpression = GetNewExpression(newExpression, rename);

                    var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                    var subject = remove.Arguments[0].Expression;

                    return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
                } */
            case nameof(DiagnosticMetadata.StringShouldEndWith_EndsWithShouldBeTrue):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "EndWith");
            case nameof(DiagnosticMetadata.StringShouldStartWith_StartsWithShouldBeTrue):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "StartWith");
            case nameof(DiagnosticMetadata.StringShouldNotBeNullOrWhiteSpace_StringShouldNotBeNullOrWhiteSpace):
                break; /*
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrWhiteSpace");
                    var newExpression = GetNewExpression(expression, remove);

                    var rename = NodeReplacement.Rename("BeFalse", "NotBeNullOrWhiteSpace");
                    newExpression = GetNewExpression(newExpression, rename);

                    var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                    var subject = remove.Arguments[0].Expression;

                    return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
                } */
            case nameof(DiagnosticMetadata.StringShouldNotBeNullOrEmpty_StringIsNullOrEmptyShouldBeFalse):
                break; /*
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrEmpty");
                    var newExpression = GetNewExpression(expression, remove);

                    var rename = NodeReplacement.Rename("BeFalse", "NotBeNullOrEmpty");
                    newExpression = GetNewExpression(newExpression, rename);

                    var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                    var subject = remove.Arguments[0].Expression;

                    return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
                } */
            case nameof(DiagnosticMetadata.StringShouldHaveLength_LengthShouldBe):
                return DocumentEditorUtils.RemoveExpressionBeforeShouldAndRenameAssertion(invocation, context, "HaveLength");
            case nameof(DiagnosticMetadata.DictionaryShouldContainKey_ContainsKeyShouldBeTrue):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "ContainKey");
            case nameof(DiagnosticMetadata.DictionaryShouldNotContainKey_ContainsKeyShouldBeFalse):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "NotContainKey");
            case nameof(DiagnosticMetadata.DictionaryShouldContainValue_ContainsValueShouldBeTrue):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "ContainValue");
            case nameof(DiagnosticMetadata.DictionaryShouldNotContainValue_ContainsValueShouldBeFalse):
                return DocumentEditorUtils.RemoveMethodBeforeShouldAndRenameAssertionWithArgumentsFromRemoved(invocation, context, "NotContainValue");
            case nameof(DiagnosticMetadata.DictionaryShouldContainKeyAndValue_ShouldContainKeyAndContainValue):
                break;
            // return GetCombinedAssertionsWithArguments(remove: "ContainValue", rename: "ContainKey", newName: "Contain");
            case nameof(DiagnosticMetadata.DictionaryShouldContainKeyAndValue_ShouldContainValueAndContainKey):
                break;
            // return GetCombinedAssertionsWithArgumentsReversedOrder(remove: "ContainKey", rename: "ContainValue", newName: "Contain");
            case nameof(DiagnosticMetadata.DictionaryShouldContainPair_ShouldContainKeyAndContainValue):
                break;
            case nameof(DiagnosticMetadata.DictionaryShouldContainPair_ShouldContainValueAndContainKey):
                break;
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithInnerException_ShouldThrowWhichInnerExceptionShouldBeOfType):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyWhichInnerExceptionShouldBeOfType):
                break;
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithInnerException_ShouldThrowAndInnerExceptionShouldBeOfType):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyAndInnerExceptionShouldBeOfType):
                break;
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithInnerException_ShouldThrowWhichInnerExceptionShouldBeAssignableTo):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyWhichInnerExceptionShouldBeAssignableTo):
                break;
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithInnerException_ShouldThrowAndInnerExceptionShouldBeAssignableTo):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyAndInnerExceptionShouldBeAssignableTo):
                break;
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldContain):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldContain):
                break;
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldContain):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldContain):
                break;
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldBe):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldBe):
                break;
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldBe):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldBe):
                break;
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldStartWith):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldStartWith):
                break;
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldStartWith):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldStartWith):
                break;
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldEndWith):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldEndWith):
                break;
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldEndWith):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldEndWith):
                break;
            case nameof(DiagnosticMetadata.CollectionShouldEqual_CollectionShouldEquals):
                return DocumentEditorUtils.RenameAssertion(invocation, context, "Equal");
            case nameof(DiagnosticMetadata.StringShouldBe_StringShouldEquals):
            case nameof(DiagnosticMetadata.ShouldBe_ShouldEquals):
                return DocumentEditorUtils.RenameAssertion(invocation, context, "Be");

            default:
                return null;
        }

        return null;
    }

    protected override EmptyTestContext CreateTestContext(SemanticModel semanticModel) => new();

    public class EmptyTestContext
    {

    }
}
