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
    public class StringShouldBeNullOrEmptyAnalyzer : StringAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Strings.StringShouldBeNullOrEmpty;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should() followed by .BeNullOrEmpty() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new StringShouldBeNullAndBeEmptySyntaxVisitor();
                yield return new StringShouldBeEmptyAndBeNullSyntaxVisitor();
                yield return new StringIsNullOrEmptyShouldBeTrueSyntaxVisitor();
            }
        }

        public class StringShouldBeNullAndBeEmptySyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public StringShouldBeNullAndBeEmptySyntaxVisitor() : base(MemberValidator.Should, new MemberValidator("BeNull"), MemberValidator.And, new MemberValidator("BeEmpty"))
            {
            }
        }

        public class StringShouldBeEmptyAndBeNullSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public StringShouldBeEmptyAndBeNullSyntaxVisitor() : base(MemberValidator.Should, new MemberValidator("BeEmpty"), MemberValidator.And, new MemberValidator("BeNull"))
            {
            }
        }

        public class StringIsNullOrEmptyShouldBeTrueSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public StringIsNullOrEmptyShouldBeTrueSyntaxVisitor() : base(new MemberValidator("IsNullOrEmpty"), MemberValidator.Should, new MemberValidator("BeTrue"))
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(StringShouldBeNullOrEmptyCodeFix)), Shared]
    public class StringShouldBeNullOrEmptyCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(StringShouldBeNullOrEmptyAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            if (properties.VisitorName == nameof(StringShouldBeNullOrEmptyAnalyzer.StringShouldBeNullAndBeEmptySyntaxVisitor))
            {
                return GetCombinedAssertions(expression, "BeEmpty", "BeNull");
            }
            else if (properties.VisitorName == nameof(StringShouldBeNullOrEmptyAnalyzer.StringShouldBeEmptyAndBeNullSyntaxVisitor))
            {
                return GetCombinedAssertions(expression, "BeNull", "BeEmpty");
            }
            else if (properties.VisitorName == nameof(StringShouldBeNullOrEmptyAnalyzer.StringIsNullOrEmptyShouldBeTrueSyntaxVisitor))
            {
                var remove = NodeReplacement.RemoveAndExtractArguments("IsNullOrEmpty");
                var newExpression = GetNewExpression(expression, remove);

                var rename = NodeReplacement.Rename("BeTrue", "BeNullOrEmpty");
                newExpression = GetNewExpression(newExpression, rename);

                var stringKeyword = newExpression.DescendantNodes().OfType<PredefinedTypeSyntax>().Single();
                var subject = remove.Arguments.First().Expression;

                return newExpression.ReplaceNode(stringKeyword, subject.WithTriviaFrom(stringKeyword));
            }
            throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }

        private ExpressionSyntax GetCombinedAssertions(ExpressionSyntax expression, string removeMethod, string renameMethod)
        {
            var remove = NodeReplacement.RemoveAndExtractArguments(removeMethod);
            var newExpression = GetNewExpression(expression, NodeReplacement.RemoveMethodBefore(removeMethod), remove);

            return GetNewExpression(newExpression, NodeReplacement.RenameAndPrependArguments(renameMethod, "BeNullOrEmpty", remove.Arguments));
        }
    }
}