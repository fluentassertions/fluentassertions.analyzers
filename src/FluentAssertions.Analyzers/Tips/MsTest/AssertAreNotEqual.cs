using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions.Analyzers.Utilities;

namespace FluentAssertions.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertAreNotEqualAnalyzer : MsTestAssertAnalyzer
{
    public const string DiagnosticId = Constants.Tips.MsTest.AssertAreNotEqual;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().NotBeApproximately() for complex numbers and .Should().NotBe() for other cases.";

    protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
    {
        get
        {
            yield return new AssertFloatAreNotEqualWithDeltaSyntaxVisitor();
            yield return new AssertDoubleAreNotEqualWithDeltaSyntaxVisitor();
            yield return new AssertStringAreNotEqualSyntaxVisitor();
            yield return new AssertObjectAreNotEqualNullSyntaxVisitor();
            yield return new AssertObjectAreNotEqualSyntaxVisitor();
        }
    }

    // public static void AreNotEqual(float expected, float actual, float delta)
    public class AssertFloatAreNotEqualWithDeltaSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertFloatAreNotEqualWithDeltaSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("AreNotEqual",
                ArgumentValidator.IsType(TypeSelector.GetFloatType),
                ArgumentValidator.IsType(TypeSelector.GetFloatType),
                ArgumentValidator.IsType(TypeSelector.GetFloatType))
            )
        {
        }
    }

    // public static void AreNotEqual(double expected, double actual, double delta)
    public class AssertDoubleAreNotEqualWithDeltaSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertDoubleAreNotEqualWithDeltaSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("AreNotEqual",
                ArgumentValidator.IsType(TypeSelector.GetDoubleType),
                ArgumentValidator.IsType(TypeSelector.GetDoubleType),
                ArgumentValidator.IsType(TypeSelector.GetDoubleType))
            )
        {
        }
    }

    public class AssertObjectAreNotEqualNullSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertObjectAreNotEqualNullSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("AreNotEqual",
                ArgumentValidator.IsIdentifier(),
                ArgumentValidator.IsNull()))
        {
        }
    }

    // public static void AreNotEqual(string expected, string actual, bool ignoreCase, CultureInfo culture
    public class AssertStringAreNotEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertStringAreNotEqualSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("AreNotEqual",
                ArgumentValidator.IsType(TypeSelector.GetStringType),
                ArgumentValidator.IsType(TypeSelector.GetStringType),
                ArgumentValidator.IsType(TypeSelector.GetBooleanType))
            )
        {
        }
    }

    // public static void AreNotEqual<T>(T expected, T actual)
    // public static void AreNotEqual(object expected, object actual)
    public class AssertObjectAreNotEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertObjectAreNotEqualSyntaxVisitor() : base(new MemberValidator("AreNotEqual"))
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertAreNotEqualCodeFix)), Shared]
public class AssertAreNotEqualCodeFix : MsTestAssertCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertAreNotEqualAnalyzer.DiagnosticId);

    protected override async Task<ExpressionSyntax> GetNewExpressionAsync(ExpressionSyntax expression, Document document, FluentAssertionsDiagnosticProperties properties, CancellationToken cancellationToken)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertAreNotEqualAnalyzer.AssertFloatAreNotEqualWithDeltaSyntaxVisitor):
            case nameof(AssertAreNotEqualAnalyzer.AssertDoubleAreNotEqualWithDeltaSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "AreNotEqual", "NotBeApproximately");
            case nameof(AssertAreNotEqualAnalyzer.AssertObjectAreNotEqualSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "AreNotEqual", "NotBe");
            case nameof(AssertAreNotEqualAnalyzer.AssertStringAreNotEqualSyntaxVisitor):
                var semanticModel = await document.GetSemanticModelAsync(cancellationToken);
                return GetNewExpressionForAreNotEqualOrAreEqualStrings(expression, semanticModel, "AreNotEqual", "NotBe", "NotBeEquivalentTo");
            case nameof(AssertAreNotEqualAnalyzer.AssertObjectAreNotEqualNullSyntaxVisitor):
                expression = RenameMethodAndReplaceWithSubjectShould(expression, "AreNotEqual", "NotBeNull");
                return GetNewExpression(expression, NodeReplacement.RemoveFirstArgument("NotBeNull"));
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}