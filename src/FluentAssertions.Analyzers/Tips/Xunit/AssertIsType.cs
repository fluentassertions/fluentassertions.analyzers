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
public class AssertIsTypeAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertIsType;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().BeOfType().";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertIsTypeGenericTypeSyntaxVisitor(),
        new AssertIsTypeTypeSyntaxVisitor()
    };

    //public static T IsType<T>(object? @object)
    public class AssertIsTypeGenericTypeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertIsTypeGenericTypeSyntaxVisitor() : base(
            MemberValidator.HasArguments("IsType", 1)
        )
        {
        }
    }

    //public static T IsType(Type expectedType, object? @object)
    public class AssertIsTypeTypeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertIsTypeTypeSyntaxVisitor() : base(
            MemberValidator.HasArguments("IsType", 2)
        )
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertIsTypeCodeFix)), Shared]
public class AssertIsTypeCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertIsTypeAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertIsTypeAnalyzer.AssertIsTypeGenericTypeSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "IsType", "BeOfType", argumentIndex: 0);
            case nameof(AssertIsTypeAnalyzer.AssertIsTypeTypeSyntaxVisitor):
                var newExpression = RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "IsType", "BeOfType");
                return ReplaceTypeOfArgumentWithGenericTypeIfExists(newExpression, "BeOfType");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}