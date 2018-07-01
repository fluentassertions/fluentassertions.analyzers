using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentAssertions.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ExceptionShouldThrowWithInnerExceptionAnalyzer : ExceptionAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Exceptions.ExceptionShouldThrowWithInnerException;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .WithInnerException() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new ShouldThrowExactlyWhichInnerExceptionShouldBeOfType();
                yield return new ShouldThrowWhichInnerExceptionShouldBeOfType();
                yield return new ShouldThrowExactlyAndInnerExceptionShouldBeOfType();
                yield return new ShouldThrowAndInnerExceptionShouldBeOfType();
                yield return new ShouldThrowExactlyWhichInnerExceptionShouldBe();
                yield return new ShouldThrowWhichInnerExceptionShouldBe();
                yield return new ShouldThrowExactlyAndInnerExceptionShouldBe();
                yield return new ShouldThrowAndInnerExceptionShouldBe();
                yield return new ShouldThrowExactlyWhichInnerExceptionShouldStartWith();
                yield return new ShouldThrowWhichInnerExceptionShouldStartWith();
                yield return new ShouldThrowExactlyAndInnerExceptionShouldStartWith();
                yield return new ShouldThrowAndInnerExceptionShouldStartWith();
                yield return new ShouldThrowExactlyWhichInnerExceptionShouldEndWith();
                yield return new ShouldThrowWhichInnerExceptionShouldEndWith();
                yield return new ShouldThrowExactlyAndInnerExceptionShouldEndWith();
                yield return new ShouldThrowAndInnerExceptionShouldEndWith();
            }
        }

        public class ShouldThrowExactlyWhichInnerExceptionShouldBeOfType : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowExactlyWhichInnerExceptionShouldBeOfType() : base(MemberValidator.Should, new MemberValidator("ThrowExactly"), MemberValidator.Which, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("BeOfType"))
            {
            }
        }
        public class ShouldThrowWhichInnerExceptionShouldBeOfType : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowWhichInnerExceptionShouldBeOfType() : base(MemberValidator.Should, new MemberValidator("Throw"), MemberValidator.Which, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("BeOfType"))
            {
            }
        }
        public class ShouldThrowExactlyAndInnerExceptionShouldBeOfType : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowExactlyAndInnerExceptionShouldBeOfType() : base(MemberValidator.Should, new MemberValidator("ThrowExactly"), MemberValidator.And, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("BeOfType"))
            {
            }
        }
        public class ShouldThrowAndInnerExceptionShouldBeOfType : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowAndInnerExceptionShouldBeOfType() : base(MemberValidator.Should, new MemberValidator("Throw"), MemberValidator.And, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("BeOfType"))
            {
            }
        }
        public class ShouldThrowExactlyWhichInnerExceptionShouldBe : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowExactlyWhichInnerExceptionShouldBe() : base(MemberValidator.Should, new MemberValidator("ThrowExactly"), MemberValidator.Which, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("Be"))
            {
            }
        }
        public class ShouldThrowWhichInnerExceptionShouldBe : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowWhichInnerExceptionShouldBe() : base(MemberValidator.Should, new MemberValidator("Throw"), MemberValidator.Which, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("Be"))
            {
            }
        }
        public class ShouldThrowExactlyAndInnerExceptionShouldBe : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowExactlyAndInnerExceptionShouldBe() : base(MemberValidator.Should, new MemberValidator("ThrowExactly"), MemberValidator.And, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("Be"))
            {
            }
        }
        public class ShouldThrowAndInnerExceptionShouldBe : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowAndInnerExceptionShouldBe() : base(MemberValidator.Should, new MemberValidator("Throw"), MemberValidator.And, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("Be"))
            {
            }
        }
        public class ShouldThrowExactlyWhichInnerExceptionShouldStartWith : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowExactlyWhichInnerExceptionShouldStartWith() : base(MemberValidator.Should, new MemberValidator("ThrowExactly"), MemberValidator.Which, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("StartWith"))
            {
            }
        }
        public class ShouldThrowWhichInnerExceptionShouldStartWith : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowWhichInnerExceptionShouldStartWith() : base(MemberValidator.Should, new MemberValidator("Throw"), MemberValidator.Which, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("StartWith"))
            {
            }
        }
        public class ShouldThrowExactlyAndInnerExceptionShouldStartWith : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowExactlyAndInnerExceptionShouldStartWith() : base(MemberValidator.Should, new MemberValidator("ThrowExactly"), MemberValidator.And, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("StartWith"))
            {
            }
        }
        public class ShouldThrowAndInnerExceptionShouldEndWith : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowAndInnerExceptionShouldEndWith() : base(MemberValidator.Should, new MemberValidator("Throw"), MemberValidator.And, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("EndWith"))
            {
            }
        }
        public class ShouldThrowExactlyWhichInnerExceptionShouldEndWith : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowExactlyWhichInnerExceptionShouldEndWith() : base(MemberValidator.Should, new MemberValidator("ThrowExactly"), MemberValidator.Which, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("EndWith"))
            {
            }
        }
        public class ShouldThrowWhichInnerExceptionShouldEndWith : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowWhichInnerExceptionShouldEndWith() : base(MemberValidator.Should, new MemberValidator("Throw"), MemberValidator.Which, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("EndWith"))
            {
            }
        }
        public class ShouldThrowExactlyAndInnerExceptionShouldEndWith : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowExactlyAndInnerExceptionShouldEndWith() : base(MemberValidator.Should, new MemberValidator("ThrowExactly"), MemberValidator.And, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("EndWith"))
            {
            }
        }
        public class ShouldThrowAndInnerExceptionShouldStartWith : FluentAssertionsCSharpSyntaxVisitor
        {
            public ShouldThrowAndInnerExceptionShouldStartWith() : base(MemberValidator.Should, new MemberValidator("Throw"), MemberValidator.And, new MemberValidator("InnerException"), MemberValidator.Should, new MemberValidator("StartWith"))
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ExceptionShouldThrowWithInnerExceptionCodeFix)), Shared]
    public class ExceptionShouldThrowWithInnerExceptionCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(ExceptionShouldThrowWithInnerExceptionAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            switch (properties.VisitorName)
            {
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowWhichInnerExceptionShouldBeOfType):
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowExactlyWhichInnerExceptionShouldBeOfType):
                    return ReplaceBeOfTypeInnerException(expression, "Which");
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowAndInnerExceptionShouldBeOfType):
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowExactlyAndInnerExceptionShouldBeOfType):
                    return ReplaceBeOfTypeInnerException(expression, "And");
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowWhichInnerExceptionShouldBe):
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowExactlyWhichInnerExceptionShouldBe):
                    return ReplaceBeInnerException(expression, "Which");
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowAndInnerExceptionShouldBe):
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowExactlyAndInnerExceptionShouldBe):
                    return ReplaceBeInnerException(expression, "And");
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowWhichInnerExceptionShouldStartWith):
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowExactlyWhichInnerExceptionShouldStartWith):
                    return ReplaceStartWithInnerException(expression, "Which");
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowAndInnerExceptionShouldStartWith):
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowExactlyAndInnerExceptionShouldStartWith):
                    return ReplaceStartWithInnerException(expression, "And");
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowWhichInnerExceptionShouldEndWith):
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowExactlyWhichInnerExceptionShouldEndWith):
                    return ReplaceEndWithInnerException(expression, "Which");
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowAndInnerExceptionShouldEndWith):
                case nameof(ExceptionShouldThrowWithInnerExceptionAnalyzer.ShouldThrowExactlyAndInnerExceptionShouldEndWith):
                    return ReplaceEndWithInnerException(expression, "And");
                default:
                    throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
            }
        }

        private ExpressionSyntax ReplaceBeOfTypeInnerException(ExpressionSyntax expression, string whichOrAnd)
            => ReplaceWithInnerException(expression, whichOrAnd, renameMethod: "BeOfType", prefix: "*", postfix: "*");

        private ExpressionSyntax ReplaceBeInnerException(ExpressionSyntax expression, string whichOrAnd)
        {
            var replacements = new[]
            {
                NodeReplacement.Remove(whichOrAnd),
                NodeReplacement.Remove("InnerException"),
                NodeReplacement.RemoveOccurrence("Should", occurrence: 2),
                NodeReplacement.Rename("Be", "WithInnerException")
            };
            return GetNewExpression(expression, replacements);
        }

        private ExpressionSyntax ReplaceStartWithInnerException(ExpressionSyntax expression, string whichOrAnd)
            => ReplaceWithInnerException(expression, whichOrAnd, renameMethod: "StartWith", postfix: "*");

        private ExpressionSyntax ReplaceEndWithInnerException(ExpressionSyntax expression, string whichOrAnd)
            => ReplaceWithInnerException(expression, whichOrAnd, renameMethod: "EndWith", prefix: "*");

        private ExpressionSyntax ReplaceWithInnerException(ExpressionSyntax expression, string whichOrAnd, string renameMethod, string prefix = "", string postfix = "")
        {
            var replacements = new[]
            {
                NodeReplacement.Remove(whichOrAnd),
                NodeReplacement.Remove("InnerException"),
                NodeReplacement.RemoveOccurrence("Should", occurrence: 2)
            };
            var newExpression = GetNewExpression(expression, replacements);
            var rename = NodeReplacement.RenameAndExtractArguments(renameMethod, "WithInnerException");
            newExpression = GetNewExpression(newExpression, rename);

            ArgumentSyntax newArgument = null;
            switch (rename.Arguments[0].Expression)
            {
                case IdentifierNameSyntax identifier:
                    newArgument = SF.Argument(SF.ParseExpression($"$\"{prefix}{{{identifier.Identifier.Text}}}{postfix}\""));
                    break;
                case LiteralExpressionSyntax literal:
                    newArgument = SF.Argument(SF.ParseExpression($"\"{prefix}{literal.Token.ValueText}{postfix}\""));
                    break;
            }

            var replacement = NodeReplacement.WithArguments("WithInnerException", rename.Arguments.Replace(rename.Arguments[0], newArgument));
            return GetNewExpression(newExpression, replacement);
        }
    }
}
