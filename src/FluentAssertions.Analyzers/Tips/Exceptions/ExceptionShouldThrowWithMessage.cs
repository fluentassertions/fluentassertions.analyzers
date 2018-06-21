using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentAssertions.Analyzers.Tips.Exceptions
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ExceptionShouldThrowWithMessageAnalyzer : ExceptionAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Exceptions.ExceptionShouldThrowWithMessage;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .WithMessage() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new ShouldThrowExactlyWhichMessageShouldContain();
                yield return new ShouldThrowWhichMessageShouldContain();
                yield return new ShouldThrowExactlyAndMessageShouldContain();
                yield return new ShouldThrowAndMessageShouldContain();
            }
        }

        public class ShouldThrowExactlyWhichMessageShouldContain : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowExactlyWhichMessageShouldContain() : base(MemberValidator.Should, new MemberValidator("ThrowExactly"), MemberValidator.Which, new MemberValidator("Message"), MemberValidator.Should, new MemberValidator("Contain"))
            {
            }
        }
        public class ShouldThrowWhichMessageShouldContain : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowWhichMessageShouldContain() : base(MemberValidator.Should, new MemberValidator("Throw"), MemberValidator.Which, new MemberValidator("Message"), MemberValidator.Should, new MemberValidator("Contain"))
            {
            }
        }
        public class ShouldThrowExactlyAndMessageShouldContain : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowExactlyAndMessageShouldContain() : base(MemberValidator.Should, new MemberValidator("ThrowExactly"), MemberValidator.And, new MemberValidator("Message"), MemberValidator.Should, new MemberValidator("Contain"))
            {
            }
        }
        public class ShouldThrowAndMessageShouldContain : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowAndMessageShouldContain() : base(MemberValidator.Should, new MemberValidator("Throw"), MemberValidator.And, new MemberValidator("Message"), MemberValidator.Should, new MemberValidator("Contain"))
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ExceptionShouldThrowWithMessageCodeFix)), Shared]
    public class ExceptionShouldThrowWithMessageCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(ExceptionShouldThrowWithMessageAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            switch (properties.VisitorName)
            {
                case nameof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowWhichMessageShouldContain):
                case nameof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowExactlyWhichMessageShouldContain):
                    return ReplaceContainMessage(expression, "Which");
                case nameof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowAndMessageShouldContain):
                case nameof(ExceptionShouldThrowWithMessageAnalyzer.ShouldThrowExactlyAndMessageShouldContain):
                    return ReplaceContainMessage(expression, "And");
                default:
                    throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
            }
        }

        private ExpressionSyntax ReplaceContainMessage(ExpressionSyntax expression, string whichOrAnd)
        {
            var replacements = new[]
            {
                NodeReplacement.Remove(whichOrAnd),
                NodeReplacement.Remove("Message"),
                NodeReplacement.RemoveOccurrence("Should", occurrence: 2)
            };
            var newExpression = GetNewExpression(expression, replacements);
            var rename = NodeReplacement.RenameAndExtractArguments("Contain", "WithMessage");
            newExpression = GetNewExpression(newExpression, rename);

            if (rename.Arguments[0].Expression is IdentifierNameSyntax identifier)
            {
                var interpolatedString = SF.ParseExpression($"$\"*{{{identifier.Identifier.Text}}}*\"");
                var newArgument = SF.Argument(interpolatedString);
                var replacement = NodeReplacement.WithArguments("WithMessage", rename.Arguments.Replace(rename.Arguments[0], newArgument));
                return GetNewExpression(newExpression, replacement);
            }

            return newExpression;
        }
    }
}
