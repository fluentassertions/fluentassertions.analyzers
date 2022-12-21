using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using TypeSelector = FluentAssertions.Analyzers.Utilities.SemanticModelTypeExtensions;

namespace FluentAssertions.Analyzers.Xunit;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertEqualAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertEqual;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().BeApproximately() for complex numbers, .Should().BeEquivalentTo() for comparer, and .Should().Be() for other cases.";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertFloatEqualWithToleranceSyntaxVisitor(),
        new AssertDoubleEqualWithToleranceSyntaxVisitor(),
        new AssertDoubleEqualWithPrecisionSyntaxVisitor(),
        new AssertDecimalEqualWithPrecisionSyntaxVisitor(),
        new AssertDateTimeEqualSyntaxVisitor(),
        new AssertObjectEqualWithComparerSyntaxVisitor(),
        new AssertObjectEqualSyntaxVisitor()
    };
    
    // public static void Equal(float expected, float actual, float tolerance)
    public class AssertFloatEqualWithToleranceSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertFloatEqualWithToleranceSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("Equal", 
                ArgumentValidator.IsType(TypeSelector.GetFloatType), 
                ArgumentValidator.IsType(TypeSelector.GetFloatType), 
                ArgumentValidator.IsType(TypeSelector.GetFloatType))
        )
        {
        }
    }
    
    // public static void Equal(double expected, double actual, double tolerance)
    public class AssertDoubleEqualWithToleranceSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertDoubleEqualWithToleranceSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("Equal", 
                ArgumentValidator.IsType(TypeSelector.GetDoubleType), 
                ArgumentValidator.IsType(TypeSelector.GetDoubleType), 
                ArgumentValidator.IsType(TypeSelector.GetDoubleType))
        )
        {
        }
    }

    // public static void Equal(double expected, double actual, int precision)
    public class AssertDoubleEqualWithPrecisionSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertDoubleEqualWithPrecisionSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("Equal", 
                ArgumentValidator.IsType(TypeSelector.GetDoubleType), 
                ArgumentValidator.IsType(TypeSelector.GetDoubleType), 
                ArgumentValidator.IsType(TypeSelector.GetIntType))
        )
        {
        }
    }
    
    // public static void Equal(decimal expected, decimal actual, int precision)
    // public static void Equal(double expected, double actual, int precision, MidpointRounding rounding)
    public class AssertDecimalEqualWithPrecisionSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertDecimalEqualWithPrecisionSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("Equal", 
                ArgumentValidator.IsType(TypeSelector.GetDecimalType), 
                ArgumentValidator.IsType(TypeSelector.GetDecimalType), 
                ArgumentValidator.IsType(TypeSelector.GetIntType))
        )
        {
        }
    }

    // public static void Equal(DateTime expected, DateTime actual, TimeSpan precision)
    public class AssertDateTimeEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertDateTimeEqualSyntaxVisitor() : base(
            MemberValidator.ArgumentsMatch("Equal", 
                ArgumentValidator.IsType(TypeSelector.GetDateTimeType), 
                ArgumentValidator.IsType(TypeSelector.GetDateTimeType),
                ArgumentValidator.IsType(TypeSelector.GetTimeSpanType)))
        {
        }
    }
    
    // public static void Equal<T>(T expected, T actual, IEqualityComparer<T> comparer)
    public class AssertObjectEqualWithComparerSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertObjectEqualWithComparerSyntaxVisitor() : base(
            MemberValidator.HasArguments("Equal", count: 3))
        {
        }
    }

    // public static void Equal<T>(T expected, T actual)
	public class AssertObjectEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
	{
		public AssertObjectEqualSyntaxVisitor() : base(MemberValidator.HasArguments("Equal", count: 2))
        {
        }
	}
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertEqualCodeFix)), Shared]
public class AssertEqualCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertEqualAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertEqualAnalyzer.AssertFloatEqualWithToleranceSyntaxVisitor):
            case nameof(AssertEqualAnalyzer.AssertDoubleEqualWithToleranceSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "Equal", "BeApproximately");
            case nameof(AssertEqualAnalyzer.AssertDoubleEqualWithPrecisionSyntaxVisitor):
            case nameof(AssertEqualAnalyzer.AssertDecimalEqualWithPrecisionSyntaxVisitor):
                // There is no corresponding API in FluentAssertions
                return expression;
            case nameof(AssertEqualAnalyzer.AssertObjectEqualWithComparerSyntaxVisitor):
                return GetNewExpressionForEqualityWithComparer(expression, "Equal", "BeEquivalentTo");
            case nameof(AssertEqualAnalyzer.AssertDateTimeEqualSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "Equal", "BeCloseTo");
            case nameof(AssertEqualAnalyzer.AssertObjectEqualSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "Equal", "Be");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}
