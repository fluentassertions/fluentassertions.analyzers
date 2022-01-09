using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;
using TypeSelector = FluentAssertions.Analyzers.Utilities.SemanticModelTypeExtensions;

namespace FluentAssertions.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AssertAreEqualAnalyzer : MsTestAnalyzer
    {
        public const string DiagnosticId = Constants.Tips.MsTest.AssertAreEqual;
        public const string Category = Constants.Tips.Category;

        public const string Message = "Use .Should().BeApproximately() for complex numbers and .Should().Be() for other cases.";

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

        // public static void AreEqual(float expected, float actual, float delta)
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

        // public static void AreEqual(double expected, double actual, double delta)
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

        // public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture
        public class AssertStringAreEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public AssertStringAreEqualSyntaxVisitor() : base(
                MemberValidator.ArgumentsMatch("AreEqual",
                    ArgumentValidator.IsType(TypeSelector.GetStringType),
                    ArgumentValidator.IsType(TypeSelector.GetStringType),
                    ArgumentValidator.IsType(TypeSelector.GetBooleanType)))
            {
            }
        }

        // public static void AreEqual<T>(T expected, T actual)
        // public static void AreEqual(object expected, object actual)
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

        protected override async Task<ExpressionSyntax> GetNewExpressionAsync(ExpressionSyntax expression, Document document, FluentAssertionsDiagnosticProperties properties, CancellationToken cancellationToken)
        {
            switch (properties.VisitorName)
            {
                case nameof(AssertAreEqualAnalyzer.AssertFloatAreEqualWithDeltaSyntaxVisitor):
                case nameof(AssertAreEqualAnalyzer.AssertDoubleAreEqualWithDeltaSyntaxVisitor):
                    return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "AreEqual", "BeApproximately", "Assert");
                case nameof(AssertAreEqualAnalyzer.AssertObjectAreEqualSyntaxVisitor):
                    return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "AreEqual", "Be", "Assert");
                case nameof(AssertAreEqualAnalyzer.AssertStringAreEqualSyntaxVisitor):
                    var semanticModel = await document.GetSemanticModelAsync(cancellationToken);
                    return GetNewExpressionForAreNotEqualOrAreEqualStrings(expression, semanticModel, "AreEqual", "Be", "BeEquivalentTo", "Assert");
                default:
                    throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
            }
        }
    }
}