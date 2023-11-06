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
public class AssertIsAssignableFromAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertIsAssignableFrom;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().BeAssignableTo().";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertIsAssignableFromGenericTypeSyntaxVisitor(),
        new AssertIsAssignableFromTypeSyntaxVisitor()
    };

    //public static T IsAssignableFrom<T>(object? @object)
    public class AssertIsAssignableFromGenericTypeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertIsAssignableFromGenericTypeSyntaxVisitor() : base(
            MemberValidator.HasArguments("IsAssignableFrom", 1)
        )
        {
        }
    }

    //public static T IsAssignableFrom(Type expectedType, object? @object)
    public class AssertIsAssignableFromTypeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertIsAssignableFromTypeSyntaxVisitor() : base(
            MemberValidator.HasArguments("IsAssignableFrom", 2)
        )
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertIsAssignableFromCodeFix)), Shared]
public class AssertIsAssignableFromCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertIsAssignableFromAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertIsAssignableFromAnalyzer.AssertIsAssignableFromGenericTypeSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "IsAssignableFrom", "BeAssignableTo");
            case nameof(AssertIsAssignableFromAnalyzer.AssertIsAssignableFromTypeSyntaxVisitor):
                var newExpression = RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "IsAssignableFrom", "BeAssignableTo");
                return ReplaceTypeOfArgumentWithGenericTypeIfExists(newExpression, "BeAssignableTo");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}