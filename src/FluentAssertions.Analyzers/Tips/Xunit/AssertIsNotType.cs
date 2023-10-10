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
public class AssertIsNotTypeAnalyzer : XunitAnalyzer
{
    public const string DiagnosticId = Constants.Tips.Xunit.AssertIsNotType;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().NotBeOfType().";

    protected override DiagnosticDescriptor Rule => new(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);

    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors => new FluentAssertionsCSharpSyntaxVisitor[]
    {
        new AssertIsNotTypeGenericTypeSyntaxVisitor(),
        new AssertIsNotTypeTypeSyntaxVisitor()
    };

    //public static T IsNotType<T>(object? @object)
    public class AssertIsNotTypeGenericTypeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertIsNotTypeGenericTypeSyntaxVisitor() : base(
            MemberValidator.HasArguments("IsNotType", 1)
        )
        {
        }
    }

    //public static T IsNotType(Type expectedType, object? @object)
    public class AssertIsNotTypeTypeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertIsNotTypeTypeSyntaxVisitor() : base(
            MemberValidator.HasArguments("IsNotType", 2)
        )
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertIsNotTypeCodeFix)), Shared]
public class AssertIsNotTypeCodeFix : XunitCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertIsNotTypeAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(
        ExpressionSyntax expression,
        FluentAssertionsDiagnosticProperties properties)
    {
        switch (properties.VisitorName)
        {
            case nameof(AssertIsNotTypeAnalyzer.AssertIsNotTypeGenericTypeSyntaxVisitor):
                return RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "IsNotType", "NotBeOfType");
            case nameof(AssertIsNotTypeAnalyzer.AssertIsNotTypeTypeSyntaxVisitor):
                var newExpression = RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(expression, "IsNotType", "NotBeOfType");
                return ReplaceTypeOfArgumentWithGenericTypeIfExists(newExpression, "NotBeOfType");
            default:
                throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
        }
    }
}