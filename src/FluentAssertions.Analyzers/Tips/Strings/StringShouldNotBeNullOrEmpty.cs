using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;

namespace FluentAssertions.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class StringShouldNotBeNullOrEmptyAnalyzer : StringAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Strings.StringShouldNotBeNullOrEmpty;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should() followed by .NotBeNullOrEmpty() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new StringShouldNotBeNullAndNotBeEmptySyntaxVisitor();
                yield return new StringShouldNotBeEmptyAndNotBeNullSyntaxVisitor();
                yield return new StringIsNullOrEmptyShouldBeFalseSyntaxVisitor();
            }
        }


        public class StringShouldNotBeNullAndNotBeEmptySyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public StringShouldNotBeNullAndNotBeEmptySyntaxVisitor() : base(MemberValidator.Should, new MemberValidator("NotBeNull"), MemberValidator.And, new MemberValidator("NotBeEmpty"))
            {
            }
        }

        public class StringShouldNotBeEmptyAndNotBeNullSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public StringShouldNotBeEmptyAndNotBeNullSyntaxVisitor() : base(MemberValidator.Should, new MemberValidator("NotBeEmpty"), MemberValidator.And, new MemberValidator("NotBeNull"))
            {
            }
        }

        public class StringIsNullOrEmptyShouldBeFalseSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public StringIsNullOrEmptyShouldBeFalseSyntaxVisitor() : base(new MemberValidator("IsNullOrEmpty"), MemberValidator.Should, new MemberValidator("BeFalse"))
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(StringShouldNotBeNullOrEmptyCodeFix)), Shared]
    public class StringShouldNotBeNullOrEmptyCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(StringShouldNotBeNullOrEmptyAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            if (properties.VisitorName == nameof(StringShouldNotBeNullOrEmptyAnalyzer.StringShouldNotBeNullAndNotBeEmptySyntaxVisitor))
            {
                var remove = NodeReplacement.RemoveAndExtractArguments("NotBeEmpty");
                var newExpression = GetNewExpression(expression, NodeReplacement.Remove("And"), remove);

                return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("NotBeNull", "NotBeNullOrEmpty", remove.Arguments));
            }
            else if (properties.VisitorName == nameof(StringShouldNotBeNullOrEmptyAnalyzer.StringShouldNotBeEmptyAndNotBeNullSyntaxVisitor))
            {
                var remove = NodeReplacement.RemoveAndExtractArguments("NotBeNull");
                var newExpression = GetNewExpression(expression, NodeReplacement.Remove("And"), remove);

                return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments("NotBeEmpty", "NotBeNullOrEmpty", remove.Arguments));
            }
            else if (properties.VisitorName == nameof(StringShouldNotBeNullOrEmptyAnalyzer.StringIsNullOrEmptyShouldBeFalseSyntaxVisitor))
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
        }
    }
}