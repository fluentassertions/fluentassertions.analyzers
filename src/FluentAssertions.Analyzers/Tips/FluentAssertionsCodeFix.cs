using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(FluentAssertionsCodeFix)), Shared]
public partial class FluentAssertionsCodeFix : FluentAssertionsCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(FluentAssertionsOperationAnalyzer.DiagnosticId);

    protected override Task<bool> CanRewriteAssertion(ExpressionSyntax expression, CodeFixContext context, Diagnostic diagnostic)
    {
        if (diagnostic.Properties.TryGetValue(Constants.DiagnosticProperties.VisitorName, out var visitorName))
        {
            return visitorName switch
            {
                nameof(DiagnosticMetadata.ShouldEquals) => Task.FromResult(false),
                _ => Task.FromResult(true),
            };
        }

        return base.CanRewriteAssertion(expression, context, diagnostic);
    }

    protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
    {
        // oldAssertion: subject.<remove>(arg1).Should().<rename>(arg2, {reasonArgs});
        // newAssertion: subject.Should().<rename>(arg1, {reasonArgs});
        ExpressionSyntax RemoveAndRenameWithoutFirstArgumentWithArgumentsFromRemoved(string remove, string rename, string newName)
        {
            var removeNode = NodeReplacement.RemoveAndExtractArguments(remove);
            var newExpression = GetNewExpression(expression, removeNode);

            newExpression = GetNewExpression(newExpression, NodeReplacement.RenameAndRemoveFirstArgument(rename, newName));

            return GetNewExpression(newExpression, NodeReplacement.PrependArguments(newName, removeNode.Arguments));
        }

        // oldAssertion: subject.<remove>(arg1).Should().<rename>({reasonArgs});
        // newAssertion: subject.Should().<newName>(arg1, {reasonArgs});
        ExpressionSyntax RemoveAndRenameWithArgumentsFromRemoved(string remove, string rename, string newName)
        {
            var removeNode = NodeReplacement.RemoveAndExtractArguments(remove);
            var newExpression = GetNewExpression(expression, removeNode);

            return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments(rename, newName, removeNode.Arguments));
        }


        // oldAssertion1: subject.Should().<rename>({reasonArgs1}).And.<remove>();
        // oldAssertion2: subject.Should().<rename>().And.<remove>({reasonArgs});
        // newAssertion : subject.Should().<newName>({reasonArgs});
        ExpressionSyntax GetCombinedAssertions(string remove, string rename, string newName)
        {
            var removeNode = NodeReplacement.RemoveAndExtractArguments(remove);
            var newExpression = GetNewExpression(expression, NodeReplacement.RemoveMethodBefore(remove), removeNode);

            return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments(rename, newName, removeNode.Arguments));
        }

        // oldAssertion1: subject.Should().<rename>(arg1, {reasonArgs1}).And.<remove>(arg2);
        // oldAssertion2: subject.Should().<rename>(arg1).And.<remove>(arg2, {reasonArgs});
        // newAssertion : subject.Should().<newName>(arg1, arg2, {reasonArgs});
        ExpressionSyntax GetCombinedAssertionsWithArguments(string remove, string rename, string newName)
        {
            var removeNode = NodeReplacement.RemoveAndExtractArguments(remove);
            var newExpression = GetNewExpression(expression, NodeReplacement.RemoveMethodBefore(remove), removeNode);

            var renameNode = NodeReplacement.RenameAndExtractArguments(rename, newName);
            newExpression = GetNewExpression(newExpression, renameNode);

            var arguments = renameNode.Arguments.InsertRange(1, removeNode.Arguments);

            return GetNewExpression(newExpression, NodeReplacement.WithArguments(newName, arguments));
        }

        // oldAssertion1: subject.Should().<rename>(arg1, {reasonArgs1}).And.<remove>(arg2);
        // oldAssertion2: subject.Should().<rename>(arg1).And.<remove>(arg2, {reasonArgs});
        // newAssertion : subject.Should().<newName>(arg2, arg1, {reasonArgs});
        ExpressionSyntax GetCombinedAssertionsWithArgumentsReversedOrder(string remove, string rename, string newName)
        {
            var removeNode = NodeReplacement.RemoveAndExtractArguments(remove);
            var newExpression = GetNewExpression(expression, NodeReplacement.RemoveMethodBefore(remove), removeNode);

            var renameNode = NodeReplacement.RenameAndExtractArguments(rename, newName);
            newExpression = GetNewExpression(newExpression, renameNode);

            var arguments = removeNode.Arguments.InsertRange(1, renameNode.Arguments);

            return GetNewExpression(newExpression, NodeReplacement.WithArguments(newName, arguments));
        }

        switch (properties.VisitorName)
        {
            case nameof(DiagnosticMetadata.CollectionShouldBeEmpty_AnyShouldBeFalse):
                return GetNewExpression(expression, NodeReplacement.Remove("Any"), NodeReplacement.Rename("BeFalse", "BeEmpty"));
            case nameof(DiagnosticMetadata.CollectionShouldBeEmpty_ShouldHaveCount0):
                return GetNewExpression(expression, new CollectionShouldBeEmpty.HaveCountNodeReplacement());
            case nameof(DiagnosticMetadata.CollectionShouldNotBeEmpty_AnyShouldBeTrue):
                return GetNewExpression(expression, NodeReplacement.Remove("Any"), NodeReplacement.Rename("BeTrue", "NotBeEmpty"));
            case nameof(DiagnosticMetadata.CollectionShouldBeInAscendingOrder_OrderByShouldEqual):
                return RemoveAndRenameWithoutFirstArgumentWithArgumentsFromRemoved(remove: "OrderBy", rename: "Equal", newName: "BeInAscendingOrder");
            case nameof(DiagnosticMetadata.CollectionShouldBeInDescendingOrder_OrderByDescendingShouldEqual):
                return RemoveAndRenameWithoutFirstArgumentWithArgumentsFromRemoved(remove: "OrderByDescending", rename: "Equal", newName: "BeInDescendingOrder");
            case nameof(DiagnosticMetadata.CollectionShouldContainItem_ContainsShouldBeTrue):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "Contains", rename: "BeTrue", newName: "Contain");
            case nameof(DiagnosticMetadata.CollectionShouldContainProperty_AnyWithLambdaShouldBeTrue):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "Any", rename: "BeTrue", newName: "Contain");
            case nameof(DiagnosticMetadata.CollectionShouldContainProperty_WhereShouldNotBeEmpty):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "Where", rename: "NotBeEmpty", newName: "Contain");
            case nameof(DiagnosticMetadata.CollectionShouldContainSingle_ShouldHaveCount1):
                return GetNewExpression(expression, NodeReplacement.RenameAndRemoveFirstArgument("HaveCount", "ContainSingle"));
            case nameof(DiagnosticMetadata.CollectionShouldContainSingle_WhereShouldHaveCount1):
                return RemoveAndRenameWithoutFirstArgumentWithArgumentsFromRemoved(remove: "Where", rename: "HaveCount", newName: "ContainSingle");
            case nameof(DiagnosticMetadata.CollectionShouldEqualOtherCollectionByComparer_SelectShouldEqualOtherCollectionSelect):
                return GetNewExpressionForSelectShouldEqualOtherCollectionSelectSyntaxVisitor(expression);
            case nameof(DiagnosticMetadata.CollectionShouldBeEmpty_CountShouldBe0):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.RenameAndRemoveFirstArgument("Be", "BeEmpty"));
            case nameof(DiagnosticMetadata.CollectionShouldContainSingle_CountShouldBe1):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.RenameAndRemoveFirstArgument("Be", "ContainSingle"));
            case nameof(DiagnosticMetadata.CollectionShouldHaveCount_CountShouldBe):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.Rename("Be", "HaveCount"));
            case nameof(DiagnosticMetadata.CollectionShouldHaveCount_LengthShouldBe):
                return GetNewExpression(expression, NodeReplacement.Remove("Length"), NodeReplacement.Rename("Be", "HaveCount"));
            case nameof(DiagnosticMetadata.CollectionShouldHaveCountGreaterOrEqualTo_CountShouldBeGreaterOrEqualTo):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.Rename("BeGreaterOrEqualTo", "HaveCountGreaterOrEqualTo"));
            case nameof(DiagnosticMetadata.CollectionShouldHaveCountGreaterThan_CountShouldBeGreaterThan):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.Rename("BeGreaterThan", "HaveCountGreaterThan"));
            case nameof(DiagnosticMetadata.CollectionShouldHaveCountLessOrEqualTo_CountShouldBeLessOrEqualTo):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.Rename("BeLessOrEqualTo", "HaveCountLessOrEqualTo"));
            case nameof(DiagnosticMetadata.CollectionShouldHaveCountLessThan_CountShouldBeLessThan):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.Rename("BeLessThan", "HaveCountLessThan"));
            case nameof(DiagnosticMetadata.CollectionShouldIntersectWith_IntersectShouldNotBeEmpty):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "Intersect", rename: "NotBeEmpty", newName: "IntersectWith");
            case nameof(DiagnosticMetadata.CollectionShouldHaveSameCount_ShouldHaveCountOtherCollectionCount):
                return GetNewExpression(expression, NodeReplacement.RenameAndRemoveInvocationOfMethodOnFirstArgument("HaveCount", "HaveSameCount"));
            case nameof(DiagnosticMetadata.CollectionShouldNotContainItem_ContainsShouldBeFalse):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "Contains", rename: "BeFalse", newName: "NotContain");
            case nameof(DiagnosticMetadata.CollectionShouldNotContainNulls_SelectShouldNotContainNulls):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Select");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.PrependArguments("NotContainNulls", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldNotContainProperty_AnyLambdaShouldBeFalse):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "Any", rename: "BeFalse", newName: "NotContain");
            case nameof(DiagnosticMetadata.CollectionShouldNotContainProperty_WhereShouldBeEmpty):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "Where", rename: "BeEmpty", newName: "NotContain");
            case nameof(DiagnosticMetadata.CollectionShouldNotContainProperty_ShouldOnlyContainNot):
                return GetNewExpression(expression, NodeReplacement.RenameAndNegateLambda("OnlyContain", "NotContain"));
            case nameof(DiagnosticMetadata.CollectionShouldNotHaveCount_CountShouldNotBe):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.Rename("NotBe", "NotHaveCount")); ;
            case nameof(DiagnosticMetadata.CollectionShouldNotHaveSameCount_CountShouldNotBeOtherCollectionCount):
                return GetNewExpression(expression,
                    NodeReplacement.Remove("Count"),
                    NodeReplacement.RenameAndRemoveInvocationOfMethodOnFirstArgument("NotBe", "NotHaveSameCount")
                );
            case nameof(DiagnosticMetadata.CollectionShouldNotIntersectWith_IntersectShouldBeEmpty):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "Intersect", rename: "BeEmpty", newName: "NotIntersectWith");
            case nameof(DiagnosticMetadata.CollectionShouldOnlyContainProperty_AllShouldBeTrue):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "All", rename: "BeTrue", newName: "OnlyContain");
            case nameof(DiagnosticMetadata.CollectionShouldOnlyHaveUniqueItems_ShouldHaveSameCountThisCollectionDistinct):
                return GetNewExpression(expression, NodeReplacement.RenameAndRemoveFirstArgument("HaveSameCount", "OnlyHaveUniqueItems"));
            case nameof(DiagnosticMetadata.CollectionShouldOnlyHaveUniqueItemsByComparer_SelectShouldOnlyHaveUniqueItems):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Select");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.PrependArguments("OnlyHaveUniqueItems", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldNotBeNullOrEmpty_ShouldNotBeNullAndNotBeEmpty):
            case nameof(DiagnosticMetadata.StringShouldNotBeNullOrEmpty_StringShouldNotBeNullAndNotBeEmpty):
                return GetCombinedAssertions("NotBeEmpty", "NotBeNull", "NotBeNullOrEmpty");
            case nameof(DiagnosticMetadata.CollectionShouldNotBeNullOrEmpty_ShouldNotBeEmptyAndNotBeNull):
            case nameof(DiagnosticMetadata.StringShouldNotBeNullOrEmpty_StringShouldNotBeEmptyAndNotBeNull):
                return GetCombinedAssertions("NotBeNull", "NotBeEmpty", "NotBeNullOrEmpty");
            case nameof(DiagnosticMetadata.CollectionShouldHaveElementAt_ElementAtIndexShouldBe):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "ElementAt", rename: "Be", newName: "HaveElementAt");
            case nameof(DiagnosticMetadata.CollectionShouldHaveElementAt_IndexerShouldBe):
                {
                    var remove = NodeReplacement.RemoveAndRetrieveIndexerArguments("Should");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("Be", "HaveElementAt", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldHaveElementAt_SkipFirstShouldBe):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Skip");
                    var newExpression = GetNewExpression(expression, remove, NodeReplacement.Remove("First"));

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("Be", "HaveElementAt", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.NumericShouldBePositive_ShouldBeGreaterThan):
                return GetNewExpression(expression, NodeReplacement.RenameAndRemoveFirstArgument("BeGreaterThan", "BePositive"));
            case nameof(DiagnosticMetadata.NumericShouldBeNegative_ShouldBeLessThan):
                return GetNewExpression(expression, NodeReplacement.RenameAndRemoveFirstArgument("BeLessThan", "BeNegative"));
            case nameof(DiagnosticMetadata.NumericShouldBeInRange_BeGreaterOrEqualToAndBeLessOrEqualTo):
                return GetCombinedAssertionsWithArguments(remove: "BeLessOrEqualTo", rename: "BeGreaterOrEqualTo", newName: "BeInRange");
            case nameof(DiagnosticMetadata.NumericShouldBeInRange_BeLessOrEqualToAndBeGreaterOrEqualTo):
                return GetCombinedAssertionsWithArguments(remove: "BeGreaterOrEqualTo", rename: "BeLessOrEqualTo", newName: "BeInRange");
            case nameof(DiagnosticMetadata.NumericShouldBeApproximately_MathAbsShouldBeLessOrEqualTo):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Abs");
                    var newExpression = GetNewExpression(expression, remove);

                    var subtractExpression = (BinaryExpressionSyntax)remove.Arguments[0].Expression;

                    var actual = subtractExpression.Right as IdentifierNameSyntax;
                    var expected = subtractExpression.Left;

                    newExpression = GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeLessOrEqualTo", "BeApproximately", new SeparatedSyntaxList<ArgumentSyntax>().Add(SyntaxFactory.Argument(expected))));

                    return RenameIdentifier(newExpression, "Math", actual.Identifier.Text);
                }
            case nameof(DiagnosticMetadata.StringShouldBeNullOrEmpty_StringIsNullOrEmptyShouldBeTrue):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrEmpty");
                    var newExpression = GetNewExpression(expression, remove);

                    var rename = NodeReplacement.Rename("BeTrue", "BeNullOrEmpty");
                    newExpression = GetNewExpression(newExpression, rename);

                    var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                    var subject = remove.Arguments[0].Expression;

                    return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
                }
            case nameof(DiagnosticMetadata.StringShouldBeNullOrWhiteSpace_StringIsNullOrWhiteSpaceShouldBeTrue):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrWhiteSpace");
                    var newExpression = GetNewExpression(expression, remove);

                    var rename = NodeReplacement.Rename("BeTrue", "BeNullOrWhiteSpace");
                    newExpression = GetNewExpression(newExpression, rename);

                    var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                    var subject = remove.Arguments[0].Expression;

                    return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
                }
            case nameof(DiagnosticMetadata.StringShouldEndWith_EndsWithShouldBeTrue):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "EndsWith", rename: "BeTrue", newName: "EndWith");
            case nameof(DiagnosticMetadata.StringShouldStartWith_StartsWithShouldBeTrue):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "StartsWith", rename: "BeTrue", newName: "StartWith");
            case nameof(DiagnosticMetadata.StringShouldNotBeNullOrWhiteSpace_StringShouldNotBeNullOrWhiteSpace):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrWhiteSpace");
                    var newExpression = GetNewExpression(expression, remove);

                    var rename = NodeReplacement.Rename("BeFalse", "NotBeNullOrWhiteSpace");
                    newExpression = GetNewExpression(newExpression, rename);

                    var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                    var subject = remove.Arguments[0].Expression;

                    return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
                }
            case nameof(DiagnosticMetadata.StringShouldNotBeNullOrEmpty_StringIsNullOrEmptyShouldBeFalse):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrEmpty");
                    var newExpression = GetNewExpression(expression, remove);

                    var rename = NodeReplacement.Rename("BeFalse", "NotBeNullOrEmpty");
                    newExpression = GetNewExpression(newExpression, rename);

                    var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                    var subject = remove.Arguments[0].Expression;

                    return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
                }
            case nameof(DiagnosticMetadata.StringShouldHaveLength_LengthShouldBe):
                return GetNewExpression(expression,
                    NodeReplacement.Remove("Length"),
                    NodeReplacement.Rename("Be", "HaveLength")
                );
            case nameof(DiagnosticMetadata.DictionaryShouldContainKey_ContainsKeyShouldBeTrue):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "ContainsKey", rename: "BeTrue", newName: "ContainKey");
            case nameof(DiagnosticMetadata.DictionaryShouldNotContainKey_ContainsKeyShouldBeFalse):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "ContainsKey", rename: "BeFalse", newName: "NotContainKey");
            case nameof(DiagnosticMetadata.DictionaryShouldContainValue_ContainsValueShouldBeTrue):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "ContainsValue", rename: "BeTrue", newName: "ContainValue");
            case nameof(DiagnosticMetadata.DictionaryShouldNotContainValue_ContainsValueShouldBeFalse):
                return RemoveAndRenameWithArgumentsFromRemoved(remove: "ContainsValue", rename: "BeFalse", newName: "NotContainValue");
            case nameof(DiagnosticMetadata.DictionaryShouldContainKeyAndValue_ShouldContainKeyAndContainValue):
                return GetCombinedAssertionsWithArguments(remove: "ContainValue", rename: "ContainKey", newName: "Contain");
            case nameof(DiagnosticMetadata.DictionaryShouldContainKeyAndValue_ShouldContainValueAndContainKey):
                return GetCombinedAssertionsWithArgumentsReversedOrder(remove: "ContainKey", rename: "ContainValue", newName: "Contain");
            case nameof(DiagnosticMetadata.DictionaryShouldContainPair_ShouldContainKeyAndContainValue):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("ContainValue");
                    var newExpression = GetNewExpression(expression, NodeReplacement.RemoveMethodBefore("ContainValue"), remove);

                    var newArguments = GetArgumentsWithFirstAsPairIdentifierArgument(remove.Arguments);

                    return GetNewExpression(newExpression,
                        NodeReplacement.RenameAndRemoveFirstArgument("ContainKey", "Contain"),
                        NodeReplacement.PrependArguments("Contain", newArguments)
                    );
                }
            case nameof(DiagnosticMetadata.DictionaryShouldContainPair_ShouldContainValueAndContainKey):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("ContainKey");
                    var newExpression = GetNewExpression(expression, NodeReplacement.RemoveMethodBefore("ContainKey"), remove);

                    var newArguments = GetArgumentsWithFirstAsPairIdentifierArgument(remove.Arguments);

                    return GetNewExpression(newExpression,
                        NodeReplacement.RenameAndRemoveFirstArgument("ContainValue", "Contain"),
                        NodeReplacement.PrependArguments("Contain", newArguments)
                    );
                }
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithInnerException_ShouldThrowWhichInnerExceptionShouldBeOfType):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyWhichInnerExceptionShouldBeOfType):
                return ReplaceBeOfTypeInnerException(expression, "Which");
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithInnerException_ShouldThrowAndInnerExceptionShouldBeOfType):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyAndInnerExceptionShouldBeOfType):
                return ReplaceBeOfTypeInnerException(expression, "And");
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithInnerException_ShouldThrowWhichInnerExceptionShouldBeAssignableTo):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyWhichInnerExceptionShouldBeAssignableTo):
                return ReplaceBeAssignableToInnerException(expression, "Which");
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithInnerException_ShouldThrowAndInnerExceptionShouldBeAssignableTo):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithInnerException_ShouldThrowExactlyAndInnerExceptionShouldBeAssignableTo):
                return ReplaceBeAssignableToInnerException(expression, "And");
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldContain):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldContain):
                return ReplaceContainMessage(expression, "Which");
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldContain):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldContain):
                return ReplaceContainMessage(expression, "And");
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldBe):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldBe):
                return ReplaceBeMessage(expression, "Which");
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldBe):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldBe):
                return ReplaceBeMessage(expression, "And");
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldStartWith):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldStartWith):
                return ReplaceStartWithMessage(expression, "Which");
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldStartWith):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldStartWith):
                return ReplaceStartWithMessage(expression, "And");
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowWhichMessageShouldEndWith):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyWhichMessageShouldEndWith):
                return ReplaceEndWithMessage(expression, "Which");
            case nameof(DiagnosticMetadata.ExceptionShouldThrowWithMessage_ShouldThrowAndMessageShouldEndWith):
            case nameof(DiagnosticMetadata.ExceptionShouldThrowExactlyWithMessage_ShouldThrowExactlyAndMessageShouldEndWith):
                return ReplaceEndWithMessage(expression, "And");
            case nameof(DiagnosticMetadata.CollectionShouldEqual_CollectionShouldEquals):
                return GetNewExpression(expression, NodeReplacement.Rename("Equals", "Equal"));
            case nameof(DiagnosticMetadata.StringShouldBe_StringShouldEquals):
            case nameof(DiagnosticMetadata.ShouldBe_ShouldEquals):
                return GetNewExpression(expression, NodeReplacement.Rename("Equals", "Be"));
            default: throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        };
    }
}