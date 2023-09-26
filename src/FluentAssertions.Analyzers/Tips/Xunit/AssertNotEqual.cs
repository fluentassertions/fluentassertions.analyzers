using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using FluentAssertions.Analyzers.Utilities;

namespace FluentAssertions.Analyzers.Xunit;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertNotEqualAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertNotEqual;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use  .Should().NotBeEquivalentTo() for comparer and .Should().NotBe() for other cases.";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
    {
        get
        {
            yield return new AssertDoubleNotEqualWithPrecisionSyntaxVisitor();
            yield return new AssertDecimalNotEqualWithPrecisionSyntaxVisitor();
            yield return new AssertObjectNotEqualWithComparerSyntaxVisitor();
            yield return new AssertObjectNotEqualSyntaxVisitor();
        }
    }

    // public static void NotEqual(double expected, double actual, int precision)
    public class AssertDoubleNotEqualWithPrecisionSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertDoubleNotEqualWithPrecisionSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("NotEqual", 
                ArgumentValidator.IsType(TypeSelector.GetDoubleType), 
                ArgumentValidator.IsType(TypeSelector.GetDoubleType), 
                ArgumentValidator.IsType(TypeSelector.GetIntType))
        )
        {
        }
    }
    
    // public static void NotEqual(decimal expected, decimal actual, int precision)
    public class AssertDecimalNotEqualWithPrecisionSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertDecimalNotEqualWithPrecisionSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("NotEqual", 
                ArgumentValidator.IsType(TypeSelector.GetDecimalType), 
                ArgumentValidator.IsType(TypeSelector.GetDecimalType), 
                ArgumentValidator.IsType(TypeSelector.GetIntType))
        )
        {
        }
    }

    // public static void NotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer)
    public class AssertObjectNotEqualWithComparerSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
	{
		public AssertObjectNotEqualWithComparerSyntaxVisitor() : base(
            MemberValidator.HasArguments("NotEqual", count: 3))
        {
        }
	}

    // public static void NotEqual<T>(T expected, T actual)
	public class AssertObjectNotEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
	{
		public AssertObjectNotEqualSyntaxVisitor() : base(
            MemberValidator.HasArguments("NotEqual", count: 2))
        {
        }
	}
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertNotEqualCodeFix)), Shared]
public class AssertNotEqualCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertEqualAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertNotEqualAnalyzer.AssertDoubleNotEqualWithPrecisionSyntaxVisitor):
            case nameof(AssertNotEqualAnalyzer.AssertDecimalNotEqualWithPrecisionSyntaxVisitor):
                // There is no corresponding API in FluentAssertions
                return expression;
            case nameof(AssertNotEqualAnalyzer.AssertObjectNotEqualWithComparerSyntaxVisitor):
                return GetNewExpressionForEqualityWithComparer(expression, "NotEqual", "NotBeEquivalentTo");
            case nameof(AssertNotEqualAnalyzer.AssertObjectNotEqualSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "NotEqual", "NotBe");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
	}
}
