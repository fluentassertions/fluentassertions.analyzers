using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(FluentAssertionsCodeFix)), Shared]
public partial class FluentAssertionsCodeFix : FluentAssertionsCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(FluentAssertionsOperationAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(DiagnosticMetadata.CollectionShouldBeEmpty_AnyShouldBeFalse):
                return GetNewExpression(expression, NodeReplacement.Remove("Any"), NodeReplacement.Rename("BeFalse", "BeEmpty"));
            case nameof(DiagnosticMetadata.CollectionShouldBeEmpty_ShouldHaveCount0):
                return GetNewExpression(expression, new CollectionShouldBeEmpty.HaveCountNodeReplacement());
            case nameof(DiagnosticMetadata.CollectionShouldNotBeEmpty_AnyShouldBeTrue):
                return GetNewExpression(expression, NodeReplacement.Remove("Any"), NodeReplacement.Rename("BeTrue", "NotBeEmpty"));
            case nameof(DiagnosticMetadata.CollectionShouldBeInAscendingOrder_OrderByShouldEqual):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("OrderBy");
                    var newExpression = GetNewExpression(expression, remove);

                    newExpression = GetNewExpression(newExpression, NodeReplacement.RenameAndRemoveFirstArgument("Equal", "BeInAscendingOrder"));

                    return GetNewExpression(newExpression, NodeReplacement.PrependArguments("BeInAscendingOrder", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldBeInDescendingOrder_OrderByDescendingShouldEqual):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("OrderByDescending");
                    var newExpression = GetNewExpression(expression, remove);

                    newExpression = GetNewExpression(newExpression, NodeReplacement.RenameAndRemoveFirstArgument("Equal", "BeInDescendingOrder"));

                    return GetNewExpression(newExpression, NodeReplacement.PrependArguments("BeInDescendingOrder", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldContainItem_ContainsShouldBeTrue):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Contains");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeTrue", "Contain", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldContainProperty_AnyWithLambdaShouldBeTrue):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Any");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeTrue", "Contain", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldContainProperty_WhereShouldNotBeEmpty):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Where");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("NotBeEmpty", "Contain", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldContainSingle_ShouldHaveCount1):
                return GetNewExpression(expression, NodeReplacement.RenameAndRemoveFirstArgument("HaveCount", "ContainSingle"));
            case nameof(DiagnosticMetadata.CollectionShouldContainSingle_WhereShouldHaveCount1):
                {
                    var newExpression = GetNewExpression(expression, NodeReplacement.RenameAndRemoveFirstArgument("HaveCount", "ContainSingle"));
                    var remove = NodeReplacement.RemoveAndExtractArguments("Where");
                    newExpression = GetNewExpression(newExpression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.PrependArguments("ContainSingle", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldEqualOtherCollectionByComparer_SelectShouldEqualOtherCollectionSelect):
                return GetNewExpressionForSelectShouldEqualOtherCollectionSelectSyntaxVisitor(expression);
            case nameof(DiagnosticMetadata.CollectionShouldHaveCount_CountShouldBe0):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.RenameAndRemoveFirstArgument("Be", "BeEmpty"));
            case nameof(DiagnosticMetadata.CollectionShouldHaveCount_CountShouldBe1):
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
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Intersect");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("NotBeEmpty", "IntersectWith", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldHaveSameCount_ShouldHaveCountOtherCollectionCount):
                return GetNewExpression(expression, NodeReplacement.RenameAndRemoveInvocationOfMethodOnFirstArgument("HaveCount", "HaveSameCount"));
            case nameof(DiagnosticMetadata.CollectionShouldNotContainItem_ContainsShouldBeFalse):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Contains");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeFalse", "NotContain", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldNotContainNulls_SelectShouldNotContainNulls):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Select");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.PrependArguments("NotContainNulls", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldNotContainProperty_AnyLambdaShouldBeFalse):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Any");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeFalse", "NotContain", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldNotContainProperty_WhereShouldBeEmpty):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Where");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeEmpty", "NotContain", remove.Arguments));
                }
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
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Intersect");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeEmpty", "NotIntersectWith", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.CollectionShouldOnlyContainProperty_AllShouldBeTrue):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("All");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeTrue", "OnlyContain", remove.Arguments));
                }
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
                {
                    return GetCombinedAssertions(expression, "NotBeEmpty", "NotBeNull", "NotBeNullOrEmpty");
                }
            case nameof(DiagnosticMetadata.CollectionShouldNotBeNullOrEmpty_ShouldNotBeEmptyAndNotBeNull):
            case nameof(DiagnosticMetadata.StringShouldNotBeNullOrEmpty_StringShouldNotBeEmptyAndNotBeNull):
                {
                    return GetCombinedAssertions(expression, "NotBeNull", "NotBeEmpty", "NotBeNullOrEmpty");
                }
            case nameof(DiagnosticMetadata.CollectionShouldHaveElementAt_ElementAtIndexShouldBe):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("ElementAt");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("Be", "HaveElementAt", remove.Arguments));
                }
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
                {
                    var removeLess = NodeReplacement.RemoveAndExtractArguments("BeLessOrEqualTo");
                    var newExpression = GetNewExpression(expression, NodeReplacement.RemoveMethodBefore("BeLessOrEqualTo"), removeLess);

                    var renameGreater = NodeReplacement.RenameAndExtractArguments("BeGreaterOrEqualTo", "BeInRange");
                    newExpression = GetNewExpression(newExpression, renameGreater);

                    var arguments = renameGreater.Arguments.InsertRange(1, removeLess.Arguments);

                    var result = GetNewExpression(newExpression, NodeReplacement.WithArguments("BeInRange", arguments));

                    return result;
                }
            case nameof(DiagnosticMetadata.NumericShouldBeInRange_BeLessOrEqualToAndBeGreaterOrEqualTo):
                {
                    var removeGreater = NodeReplacement.RemoveAndExtractArguments("BeGreaterOrEqualTo");
                    var newExpression = GetNewExpression(expression, NodeReplacement.RemoveMethodBefore("BeGreaterOrEqualTo"), removeGreater);

                    var renameLess = NodeReplacement.RenameAndExtractArguments("BeLessOrEqualTo", "BeInRange");
                    newExpression = GetNewExpression(newExpression, renameLess);

                    var arguments = removeGreater.Arguments.InsertRange(1, renameLess.Arguments);

                    return GetNewExpression(newExpression, NodeReplacement.WithArguments("BeInRange", arguments));
                }
            case nameof(DiagnosticMetadata.NumericShouldBeApproximately_MathAbsShouldBeLessOrEqualTo):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Abs");
                    var newExpression = GetNewExpression(expression, remove);

                    var subtractExpression = (BinaryExpressionSyntax)remove.Arguments[0].Expression;

                    var actual = subtractExpression.Right as IdentifierNameSyntax;
                    var expected = subtractExpression.Left;

                    newExpression = GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeLessOrEqualTo", "BeApproximately", new SeparatedSyntaxList<ArgumentSyntax>().Add(SyntaxFactory.Argument(expected))));

                    newExpression = RenameIdentifier(newExpression, "Math", actual.Identifier.Text);

                    return newExpression;
                }

            case nameof(DiagnosticMetadata.StringShouldBeNullOrEmpty_StringIsNullOrEmptyShouldBeTrue):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrEmpty");
                    var newExpression = GetNewExpression(expression, remove);

                    var rename = NodeReplacement.Rename("BeTrue", "BeNullOrEmpty");
                    newExpression = GetNewExpression(newExpression, rename);

                    var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                    var subject = remove.Arguments.First().Expression;

                    return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
                }
            case nameof(DiagnosticMetadata.StringShouldBeNullOrWhiteSpace_StringIsNullOrWhiteSpaceShouldBeTrue):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrWhiteSpace");
                    var newExpression = GetNewExpression(expression, remove);

                    var rename = NodeReplacement.Rename("BeTrue", "BeNullOrWhiteSpace");
                    newExpression = GetNewExpression(newExpression, rename);

                    var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                    var subject = remove.Arguments.First().Expression;

                    return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
                }

            case nameof(DiagnosticMetadata.StringShouldEndWith_EndsWithShouldBeTrue):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("EndsWith");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeTrue", "EndWith", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.StringShouldStartWith_StartsWithShouldBeTrue):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("StartsWith");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeTrue", "StartWith", remove.Arguments));
                }
            case nameof(DiagnosticMetadata.StringShouldNotBeNullOrWhiteSpace_StringShouldNotBeNullOrWhiteSpace):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrWhiteSpace");
                    var newExpression = GetNewExpression(expression, remove);

                    var rename = NodeReplacement.Rename("BeFalse", "NotBeNullOrWhiteSpace");
                    newExpression = GetNewExpression(newExpression, rename);

                    var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                    var subject = remove.Arguments.First().Expression;

                    return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
                }


            case nameof(DiagnosticMetadata.StringShouldNotBeNullOrEmpty_StringIsNullOrEmptyShouldBeFalse):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrEmpty");
                    var newExpression = GetNewExpression(expression, remove);

                    var rename = NodeReplacement.Rename("BeFalse", "NotBeNullOrEmpty");
                    newExpression = GetNewExpression(newExpression, rename);

                    var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                    var subject = remove.Arguments.First().Expression;

                    return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
                }
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");

            case nameof(DiagnosticMetadata.StringShouldHaveLength_LengthShouldBe):
                {
                    var remove = NodeReplacement.Remove("Length");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.Rename("Be", "HaveLength"));
                }

            default: throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        };
    }

    private ExpressionSyntax GetCombinedAssertions(ExpressionSyntax expression, string removeMethod, string renameMethod, string newMethod)
    {
        var remove = NodeReplacement.RemoveAndExtractArguments(removeMethod);
        var newExpression = GetNewExpression(expression, NodeReplacement.RemoveMethodBefore(removeMethod), remove);

        return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments(renameMethod, newMethod, remove.Arguments));
    }
}