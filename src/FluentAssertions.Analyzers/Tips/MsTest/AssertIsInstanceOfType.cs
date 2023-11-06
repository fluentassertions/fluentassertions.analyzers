using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FluentAssertions.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertIsInstanceOfTypeAnalyzer : MsTestAssertAnalyzer
{
    public const string DiagnosticId = Constants.Tips.MsTest.AssertIsInstanceOfType;
    public const string Category = Constants.Tips.Category;

    public const string Message = "Use .Should().BeOfType() instead.";

    protected override DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, DiagnosticSeverity.Info, true);
    protected override IEnumerable<FluentAssertionsCSharpSyntaxVisitor> Visitors
    {
        get
        {
            yield return new AssertIsInstanceOfTypeSyntaxVisitor();
        }
    }

    public class AssertIsInstanceOfTypeSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
    {
        public AssertIsInstanceOfTypeSyntaxVisitor() : base(new MemberValidator("IsInstanceOfType"))
        {
        }
    }
}

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AssertIsInstanceOfTypeCodeFix)), Shared]
public class AssertIsInstanceOfTypeCodeFix : MsTestAssertCodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(AssertIsInstanceOfTypeAnalyzer.DiagnosticId);

    protected override ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties)
    {
        var newExpression = RenameMethodAndReplaceWithSubjectShould(expression, "IsInstanceOfType", "BeOfType");
        return ReplaceTypeOfArgumentWithGenericTypeIfExists(newExpression, "BeOfType");
    }
}