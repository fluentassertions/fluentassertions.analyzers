using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionCodeFix)), Shared]
public partial class CollectionCodeFix : FluentAssertionsCodeFixProvider
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
                {
                    return GetCombinedAssertions(expression, "NotBeEmpty", "NotBeNull");
                }
            case nameof(DiagnosticMetadata.CollectionShouldNotBeNullOrEmpty_ShouldNotBeEmptyAndNotBeNull):
                {
                    return GetCombinedAssertions(expression, "NotBeNull", "NotBeEmpty");
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

            default: throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        };
    }
}