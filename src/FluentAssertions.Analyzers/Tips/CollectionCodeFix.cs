using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FluentAssertions.Analyzers;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionCodeFix)), Shared]
public partial class CollectionCodeFix : FluentAssertionsCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(FluentAssertionsOperationAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(CollectionShouldBeEmpty.AnyShouldBeFalseSyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.Remove("Any"), NodeReplacement.Rename("BeFalse", "BeEmpty"));
            case nameof(CollectionShouldBeEmpty.ShouldHaveCount0SyntaxVisitor):
                return GetNewExpression(expression, new CollectionShouldBeEmpty.HaveCountNodeReplacement());
            case nameof(CollectionShouldNotBeEmpty.AnyShouldBeTrueSyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.Remove("Any"), NodeReplacement.Rename("BeTrue", "NotBeEmpty"));
            case nameof(CollectionShouldBeInAscendingOrder.OrderByShouldEqualSyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("OrderBy");
                    var newExpression = GetNewExpression(expression, remove);

                    newExpression = GetNewExpression(newExpression, NodeReplacement.RenameAndRemoveFirstArgument("Equal", "BeInAscendingOrder"));

                    return GetNewExpression(newExpression, NodeReplacement.PrependArguments("BeInAscendingOrder", remove.Arguments));
                }
            case nameof(CollectionShouldBeInDescendingOrder.OrderByDescendingShouldEqualSyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("OrderByDescending");
                    var newExpression = GetNewExpression(expression, remove);

                    newExpression = GetNewExpression(newExpression, NodeReplacement.RenameAndRemoveFirstArgument("Equal", "BeInDescendingOrder"));

                    return GetNewExpression(newExpression, NodeReplacement.PrependArguments("BeInDescendingOrder", remove.Arguments));
                }
            case nameof(CollectionShouldContainItem.ContainsShouldBeTrueSyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Contains");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeTrue", "Contain", remove.Arguments));
                }
            case nameof(CollectionShouldContainProperty.AnyWithLambdaShouldBeTrueSyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Any");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeTrue", "Contain", remove.Arguments));
                }
            case nameof(CollectionShouldContainProperty.WhereShouldNotBeEmptySyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Where");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("NotBeEmpty", "Contain", remove.Arguments));
                }
            case nameof(CollectionShouldContainSingle.ShouldHaveCount1SyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.RenameAndRemoveFirstArgument("HaveCount", "ContainSingle"));
            case nameof(CollectionShouldContainSingle.WhereShouldHaveCount1SyntaxVisitor):
                {
                    var newExpression = GetNewExpression(expression, NodeReplacement.RenameAndRemoveFirstArgument("HaveCount", "ContainSingle"));
                    var remove = NodeReplacement.RemoveAndExtractArguments("Where");
                    newExpression = GetNewExpression(newExpression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.PrependArguments("ContainSingle", remove.Arguments));
                }
            case nameof(CollectionShouldEqualOtherCollectionByComparer.SelectShouldEqualOtherCollectionSelectSyntaxVisitor):
                return GetNewExpressionForSelectShouldEqualOtherCollectionSelectSyntaxVisitor(expression);
            case nameof(CollectionShouldHaveCount.CountShouldBe0SyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.RenameAndRemoveFirstArgument("Be", "BeEmpty"));
            case nameof(CollectionShouldHaveCount.CountShouldBe1SyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.RenameAndRemoveFirstArgument("Be", "ContainSingle"));
            case nameof(CollectionShouldHaveCount.CountShouldBeSyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.Rename("Be", "HaveCount"));
            case nameof(CollectionShouldHaveCount.LengthShouldBeSyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.Remove("Length"), NodeReplacement.Rename("Be", "HaveCount"));
            case nameof(CollectionShouldHaveCountGreaterOrEqualTo.CountShouldBeGreaterOrEqualToSyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.Rename("BeGreaterOrEqualTo", "HaveCountGreaterOrEqualTo"));
            case nameof(CollectionShouldHaveCountGreaterThan.CountShouldBeGreaterThanSyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.Rename("BeGreaterThan", "HaveCountGreaterThan"));
            case nameof(CollectionShouldHaveCountLessOrEqualTo.CountShouldBeLessOrEqualToSyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.Rename("BeLessOrEqualTo", "HaveCountLessOrEqualTo"));
            case nameof(CollectionShouldHaveCountLessThan.CountShouldBeLessThanSyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.Rename("BeLessThan", "HaveCountLessThan"));
            case nameof(CollectionShouldIntersectWith.IntersectShouldNotBeEmptySyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Intersect");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("NotBeEmpty", "IntersectWith", remove.Arguments));
                }
            case nameof(CollectionShouldHaveSameCount.ShouldHaveCountOtherCollectionCountSyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.RenameAndRemoveInvocationOfMethodOnFirstArgument("HaveCount", "HaveSameCount"));
            case nameof(CollectionShouldNotContainItem.ContainsShouldBeFalseSyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Contains");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeFalse", "NotContain", remove.Arguments));
                }
            case nameof(CollectionShouldNotContainNulls.SelectShouldNotContainNullsSyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Select");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.PrependArguments("NotContainNulls", remove.Arguments));
                }
            case nameof(CollectionShouldNotContainProperty.AnyLambdaShouldBeFalseSyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Any");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeFalse", "NotContain", remove.Arguments));
                }
            case nameof(CollectionShouldNotContainProperty.WhereShouldBeEmptySyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Where");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeEmpty", "NotContain", remove.Arguments));
                }
            case nameof(CollectionShouldNotContainProperty.ShouldOnlyContainNotSyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.RenameAndNegateLambda("OnlyContain", "NotContain"));
            case nameof(CollectionShouldNotHaveCount.CountShouldNotBeSyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.Remove("Count"), NodeReplacement.Rename("NotBe", "NotHaveCount")); ;
            case nameof(CollectionShouldNotHaveSameCount.CountShouldNotBeOtherCollectionCountSyntaxVisitor):
                return GetNewExpression(expression,
                    NodeReplacement.Remove("Count"),
                    NodeReplacement.RenameAndRemoveInvocationOfMethodOnFirstArgument("NotBe", "NotHaveSameCount")
                );
            case nameof(CollectionShouldNotIntersectWith.IntersectShouldBeEmptySyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Intersect");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeEmpty", "NotIntersectWith", remove.Arguments));
                }
            case nameof(CollectionShouldOnlyContainProperty.AllShouldBeTrueSyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("All");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("BeTrue", "OnlyContain", remove.Arguments));
                }
            case nameof(CollectionShouldOnlyHaveUniqueItems.ShouldHaveSameCountThisCollectionDistinctSyntaxVisitor):
                return GetNewExpression(expression, NodeReplacement.RenameAndRemoveFirstArgument("HaveSameCount", "OnlyHaveUniqueItems"));
            case nameof(CollectionShouldOnlyHaveUniqueItemsByComparer.SelectShouldOnlyHaveUniqueItemsSyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Select");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.PrependArguments("OnlyHaveUniqueItems", remove.Arguments));
                }
            case nameof(CollectionShouldNotBeNullOrEmpty.ShouldNotBeNullAndNotBeEmptySyntaxVisitor):
                {
                    return GetCombinedAssertions(expression, "NotBeEmpty", "NotBeNull");
                }
            case nameof(CollectionShouldNotBeNullOrEmpty.ShouldNotBeEmptyAndNotBeNullSyntaxVisitor):
                {
                    return GetCombinedAssertions(expression, "NotBeNull", "NotBeEmpty");
                }

            case nameof(CollectionShouldHaveElementAt.ElementAtIndexShouldBeSyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("ElementAt");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("Be", "HaveElementAt", remove.Arguments));
                }
            case nameof(CollectionShouldHaveElementAt.IndexerShouldBeSyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndRetrieveIndexerArguments("Should");
                    var newExpression = GetNewExpression(expression, remove);

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("Be", "HaveElementAt", remove.Arguments));
                }
            case nameof(CollectionShouldHaveElementAt.SkipFirstShouldBeSyntaxVisitor):
                {
                    var remove = NodeReplacement.RemoveAndExtractArguments("Skip");
                    var newExpression = GetNewExpression(expression, remove, NodeReplacement.Remove("First"));

                    return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("Be", "HaveElementAt", remove.Arguments));
                }

            default: throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        };
    }
}