using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

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
                // order: 
                // Assert.AreEqual<T>(T actual, T expected)
                // Assert.AreEqual(float actual, float expected, float delta)
                // Assert.AreEqual(double actual, double expected, double delta)
                // Assert.AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture)
                // Assert.AreEqual(object actual, object expected)
                yield break;

                yield return new AssertGenericAreEqualSyntaxVisitor();
                yield return new AssertAreEqualWithDeltaSyntaxVisitor();
                yield return new AssertObjectAreEqualSyntaxVisitor();
                yield return new AssertStringAreEqualSyntaxVisitor();
            }
        }

        // two arguments with same type
        public class AssertGenericAreEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public AssertGenericAreEqualSyntaxVisitor() : base()
            {
            }
        }

        // all three arguments are float/double
        public class AssertAreEqualWithDeltaSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public AssertAreEqualWithDeltaSyntaxVisitor() : base(MemberValidator.ArgumentsMatch("AreEqual", ArgumentValidator.IsType("float"), ArgumentValidator.IsType("float"), ArgumentValidator.IsType("float"))
            {
            }
        }

        // three or four arguments, first and second are string, third is boolean, fourth is CultureInfo
        public class AssertStringAreEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public AssertStringAreEqualSyntaxVisitor() : base()
            {
            }
        }

        // two arguments with different types
        public class AssertObjectAreEqualSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
        {
            public AssertObjectAreEqualSyntaxVisitor() : base()
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
                case nameof(AssertAreEqualAnalyzer.AssertGenericAreEqualSyntaxVisitor):
                    return expression;
                case nameof(AssertAreEqualAnalyzer.AssertAreEqualWithDeltaSyntaxVisitor):
                    return expression;
                case nameof(AssertAreEqualAnalyzer.AssertObjectAreEqualSyntaxVisitor):
                    return expression;
                case nameof(AssertAreEqualAnalyzer.AssertStringAreEqualSyntaxVisitor):
                    return expression;
                default:
                    throw new System.InvalidOperationException($"Invalid visitor name - {properties.VisitorName}");
            }

            return null;
        }
    }
}