using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

namespace FluentAssertions.BestPractices
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DictionaryShouldContainKeyAndValueAnalyzer : FluentAssertionsAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.Dictionaries.DictionaryShouldContainKeyAndValue;
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
                    && (key is IdentifierNameSyntax || key is LiteralExpressionSyntax)

                    && Arguments.TryGetValue(("ContainValue", 0), out var value)
                    && (value is IdentifierNameSyntax || value is LiteralExpressionSyntax);
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

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(DictionaryShouldContainKeyAndValueCodeFix)), Shared]
    public class DictionaryShouldContainKeyAndValueCodeFix : FluentAssertionsCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(DictionaryShouldContainKeyAndValueAnalyzer.DiagnosticId);

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
                var renameKeyArguments = NodeReplacement.RenameAndExtractArguments("ContainKey", "Contain");
                var removeValueArguments = NodeReplacement.RemoveAndExtractArguments("ContainValue");
                var newStatement = GetNewStatement(statement, renameKeyArguments, removeValueArguments);

                var newArguments = MergeContainKeyAndContainValueArguments(renameKeyArguments.Arguments, removeValueArguments.Arguments);

                return GetNewStatement(newStatement, NodeReplacement.WithArguments("Contain", newArguments));
            }
            else if (properties.VisitorName == nameof(DictionaryShouldContainPairAnalyzer.ShouldContainValueAndContainKeySyntaxVisitor))
            {
                var removeKeyArguments = NodeReplacement.RemoveAndExtractArguments("ContainKey");
                var renameValueArguments = NodeReplacement.RenameAndExtractArguments("ContainValue", "Contain");
                var newStatement = GetNewStatement(statement, removeKeyArguments, renameValueArguments);

                var newArguments = MergeContainKeyAndContainValueArguments(removeKeyArguments.Arguments, renameValueArguments.Arguments);

                return GetNewStatement(newStatement, NodeReplacement.WithArguments("Contain", newArguments));
            }
            else
            {
                throw new InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
            }
        }

        private SeparatedSyntaxList<ArgumentSyntax> MergeContainKeyAndContainValueArguments(SeparatedSyntaxList<ArgumentSyntax> keyArguments, SeparatedSyntaxList<ArgumentSyntax> valueArguments)
        {
            return new SeparatedSyntaxList<ArgumentSyntax>()
                .Add(keyArguments[0])
                .Add(valueArguments[0])
                .AddRange(keyArguments.RemoveAt(0))
                .AddRange(valueArguments.RemoveAt(0));
        }
    }
}