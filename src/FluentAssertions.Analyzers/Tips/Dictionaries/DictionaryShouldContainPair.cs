using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DictionaryShouldContainPairAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Dictionaries.DictionaryShouldContainPair;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by .Contain() instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new ShouldContainKeyAndContainValueSyntaxVisitor();
                yield return new ShouldContainValueAndContainKeySyntaxVisitor();
            }
        }

        public abstract class ContainKeyValueSyntaxVisitor : FluentAssertionsWithArgumentsCSharpSyntaxVisitor
        {
            protected override bool AreArgumentsValid()
            {
                return Arguments.TryGetValue(("ContainKey", 0), out var key)
                    && key is MemberAccessExpressionSyntax keyAccess
                    && keyAccess.Expression is IdentifierNameSyntax keyContainer
                    && keyAccess.Name.Identifier.Text == "Key"

                    && Arguments.TryGetValue(("ContainValue", 0), out var value)
                    && value is MemberAccessExpressionSyntax valueAccess
                    && valueAccess.Expression is IdentifierNameSyntax valueContainer
                    && valueAccess.Name.Identifier.Text == "Value"

                    && keyContainer.Identifier.Text == valueContainer.Identifier.Text;
            }

            protected ContainKeyValueSyntaxVisitor(params string[] requiredMethods) : base(requiredMethods)
            {
            }
        }
        public class ShouldContainKeyAndContainValueSyntaxVisitor : ContainKeyValueSyntaxVisitor
        {

            public ShouldContainKeyAndContainValueSyntaxVisitor() : base("Should", "ContainKey", "And", "ContainValue")
            {
            }
        }
        public class ShouldContainValueAndContainKeySyntaxVisitor : ContainKeyValueSyntaxVisitor
        {
            public ShouldContainValueAndContainKeySyntaxVisitor() : base("Should", "ContainValue", "And", "ContainKey")
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(DictionaryShouldContainPairCodeFix)), Shared]
    public class DictionaryShouldContainPairCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(DictionaryShouldContainPairAnalyzer.DiagnosticId);

        protected override bool CanRewriteAssertion(ExpressionStatementSyntax statement)
        {
            var visitor = new MemberAccessExpressionsCSharpSyntaxVisitor();
            statement.Accept(visitor);

            var containKey = visitor.Members.Find(member => member.Name.Identifier.Text == "ContainKey");
            var containValue = visitor.Members.Find(member => member.Name.Identifier.Text == "ContainValue");

            return !(containKey.Parent is InvocationExpressionSyntax containKeyInvocation && containKeyInvocation.ArgumentList.Arguments.Count > 1
                && containValue.Parent is InvocationExpressionSyntax containValueInvocation && containValueInvocation.ArgumentList.Arguments.Count > 1);
        }

        protected override StatementSyntax GetNewStatement(ExpressionStatementSyntax statement, FluentAssertionsDiagnosticProperties properties)
        {
            if (properties.VisitorName == nameof(DictionaryShouldContainPairAnalyzer.ShouldContainKeyAndContainValueSyntaxVisitor))
            {
                var remove = NodeReplacement.RemoveAndExtractArguments("ContainValue");
                var newStatement = GetNewStatement(statement, remove);

                var newArguments = GetArgumentsWithFirstAsPairIdentifierArgument(remove.Arguments);

                newStatement = GetNewStatement(newStatement, NodeReplacement.RenameAndRemoveFirstArgument("ContainKey", "Contain"));

                newStatement = GetNewStatement(newStatement, NodeReplacement.PrependArguments("Contain", newArguments));

                return newStatement;
            }
            else if (properties.VisitorName == nameof(DictionaryShouldContainPairAnalyzer.ShouldContainValueAndContainKeySyntaxVisitor))
            {
                var remove = NodeReplacement.RemoveAndExtractArguments("ContainKey");
                var newStatement = GetNewStatement(statement, remove);

                var newArguments = GetArgumentsWithFirstAsPairIdentifierArgument(remove.Arguments);

                newStatement = GetNewStatement(newStatement, NodeReplacement.RenameAndRemoveFirstArgument("ContainValue", "Contain"));

                newStatement = GetNewStatement(newStatement, NodeReplacement.PrependArguments("Contain", newArguments));

                return newStatement;
            }
            else
            {
                throw new InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
            }
        }

        private SeparatedSyntaxList<ArgumentSyntax> GetArgumentsWithFirstAsPairIdentifierArgument(SeparatedSyntaxList<ArgumentSyntax> arguments)
        {
            var argument = arguments[0];
            var memberAccess = (MemberAccessExpressionSyntax)argument.Expression;
            var identifier = (IdentifierNameSyntax)memberAccess.Expression;

            return arguments.Replace(argument, argument.WithExpression(identifier));
        }
    }
}