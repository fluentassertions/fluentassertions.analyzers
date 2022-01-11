using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class CollectionAssertAllItemsAreInstancesOfTypeAnalyzer : MsTestCollectionAssertAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.MsTest.CollectionAssertAllItemsAreInstancesOfType;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().AllBeOfType() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new CollectionAssertAllItemsAreInstancesOfTypeSyntaxVisitor();
            }
        }

        public class CollectionAssertAllItemsAreInstancesOfTypeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public CollectionAssertAllItemsAreInstancesOfTypeSyntaxVisitor() : base(new MemberValidator("AllItemsAreInstancesOfType"))
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CollectionAssertAllItemsAreInstancesOfTypeCodeFix)), Shared]
    public class CollectionAssertAllItemsAreInstancesOfTypeCodeFix : MsTestCollectionAssertCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(CollectionAssertAllItemsAreInstancesOfTypeAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            var newExpression = RenameMethodAndReplaceWithSubjectShould(expression, "AllItemsAreInstancesOfType", "AllBeOfType");

            var argumentsReplacer = NodeReplacement.RemoveFirstArgument("AllBeOfType");
            var possibleNewExpression = GetNewExpression(newExpression, argumentsReplacer);

            if (argumentsReplacer.Argument.Expression is TypeOfExpressionSyntax typeOfExpression)
            {
                var addTypeArgument = NodeReplacement.AddTypeArgument("AllBeOfType", typeOfExpression.Type);
                return GetNewExpression(possibleNewExpression, addTypeArgument);
            }

            return newExpression;
        }
    }
}