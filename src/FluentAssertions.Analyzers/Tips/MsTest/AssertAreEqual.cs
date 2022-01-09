using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

using TypeSelector = FluentAssertions.Analyzers.Utilities.SemanticModelTypeExtensions;

namespace FluentAssertions.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AssertAreEqualAnalyzer : MsTestAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.MsTest.AssertAreEqual;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use {0} .Should() followed by ### instead.";

        protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
        protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
        {
            get
            {
                yield return new AssertFloatAreEqualWithDeltaSyntaxVisitor();
                yield return new AssertDoubleAreEqualWithDeltaSyntaxVisitor();
                yield return new AssertStringAreEqualSyntaxVisitor();
                yield return new AssertObjectAreEqualSyntaxVisitor();
            }
        }

        // all three arguments are float
        public class AssertFloatAreEqualWithDeltaSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public AssertFloatAreEqualWithDeltaSyntaxVisitor() : base(
                MemberValidator.ArgumentsMatch("AreEqual", 
                    ArgumentValidator.IsType(TypeSelector.GetFloatType), 
                    ArgumentValidator.IsType(TypeSelector.GetFloatType), 
                    ArgumentValidator.IsType(TypeSelector.GetFloatType))
                )
            {
            }
        }

        // all three arguments are double
        public class AssertDoubleAreEqualWithDeltaSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public AssertDoubleAreEqualWithDeltaSyntaxVisitor() : base(
                MemberValidator.ArgumentsMatch("AreEqual",
                    ArgumentValidator.IsType(TypeSelector.GetDoubleType),
                    ArgumentValidator.IsType(TypeSelector.GetDoubleType),
                    ArgumentValidator.IsType(TypeSelector.GetDoubleType))
                )
            {
            }
        }

        // three or four arguments, first and second are string, third is boolean, fourth is CultureInfo
        public class AssertStringAreEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public AssertStringAreEqualSyntaxVisitor() : base(
                MemberValidator.ArgumentsMatch("AreEqual",
                    ArgumentValidator.IsType(TypeSelector.GetStringType),
                    ArgumentValidator.IsType(TypeSelector.GetStringType),
                    ArgumentValidator.IsType(TypeSelector.GetBooleanType),
                    ArgumentValidator.IsType(TypeSelector.GetCultureInfoType)))
            {
            }
        }

        // two arguments with different types
        public class AssertObjectAreEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public AssertObjectAreEqualSyntaxVisitor() : base(new MemberValidator("AreEqual"))
            {
            }
        }
    }

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertAreEqualCodeFix)), Shared]
    public class AssertAreEqualCodeFix : MsTestCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertAreEqualAnalyzer.DiagnosticId);

        protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
        {
            switch (properties.VisitorName)
            {
                case nameof(AssertAreEqualAnalyzer.AssertFloatAreEqualWithDeltaSyntaxVisitor):
                case nameof(AssertAreEqualAnalyzer.AssertDoubleAreEqualWithDeltaSyntaxVisitor):
                    return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "AreEqual", "BeApproximately", "Assert");
                case nameof(AssertAreEqualAnalyzer.AssertObjectAreEqualSyntaxVisitor):
                    return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "AreEqual", "Be", "Assert");
                case nameof(AssertAreEqualAnalyzer.AssertStringAreEqualSyntaxVisitor):
                    return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "AreEqual", "Be", "Assert");
                default:
                    throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
            }
        }
    }
}