using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentAssertions.Analyzers.Xunit;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertIsNotAssignableFromAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertIsNotAssignableFrom;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().NotBeAssignableTo().";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertIsNotAssignableFromGenericTypeSyntaxVisitor(),
        new AssertIsNotAssignableFromTypeSyntaxVisitor()
    };

    //public static T IsNotAssignableFrom<T>(object? @object)
    public class AssertIsNotAssignableFromGenericTypeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertIsNotAssignableFromGenericTypeSyntaxVisitor() : base(
            MemberValidator.HasArguments("IsNotAssignableFrom", 1)
        )
        {
        }
    }

    //public static T IsNotAssignableFrom(Type expectedType, object? @object)
    public class AssertIsNotAssignableFromTypeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertIsNotAssignableFromTypeSyntaxVisitor() : base(
            MemberValidator.HasArguments("IsNotAssignableFrom", 2)
        )
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertIsNotAssignableFromCodeFix)), Shared]
public class AssertIsNotAssignableFromCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertIsNotAssignableFromAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertIsNotAssignableFromAnalyzer.AssertIsNotAssignableFromGenericTypeSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "IsNotAssignableFrom", "NotBeAssignableTo", argumentIndex: 0);
            case nameof(AssertIsNotAssignableFromAnalyzer.AssertIsNotAssignableFromTypeSyntaxVisitor):
                var newExpression = RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "IsNotAssignableFrom", "NotBeAssignableTo");
                return ReplaceTypeOfArgumentWithGenericTypeIfExists(newExpression, "NotBeAssignableTo");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}