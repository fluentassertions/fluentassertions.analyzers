/*
 * MIT License
 *
 * Copyright (c) 2023 Gérald Barré (https://www.meziantou.net)
 * Modifications copyright (c) Meir Blachman.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Collections.Immutable;
using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace FluentAssertions.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AssertAnalyzer : DiagnosticAnalyzer
{
    public static readonly string Message = "Use FluentAssertions equivalent";
    public static readonly DiagnosticDescriptor XunitRule = new(
       "FAA0002",
       title: "Replace Xunit assertion with Fluent Assertions equivalent",
       messageFormat: Message,
       description: "",
       category: Constants.Tips.Category,
       defaultSeverity: DiagnosticSeverity.Info, // TODO: change to DiagnosticSeverity.Warning,
       isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor MSTestsRule = new(
       "FAA0003",
       title: "Replace MSTests assertion with Fluent Assertions equivalent",
       messageFormat: Message,
       description: "",
       category: Constants.Tips.Category,
       defaultSeverity: DiagnosticSeverity.Info, // TODO: change to DiagnosticSeverity.Warning,
       isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor NUnitRule = new(
       "FAA0004",
       title: "Replace NUnit assertion with Fluent Assertions equivalent",
       messageFormat: Message,
       description: "",
       category: Constants.Tips.Category,
       defaultSeverity: DiagnosticSeverity.Info, // TODO: change to DiagnosticSeverity.Warning,
       isEnabledByDefault: true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(XunitRule, MSTestsRule, NUnitRule);

    public override void Initialize(AnalysisContext context)
    {
        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

        context.RegisterCompilationStartAction(context =>
        {
            if (context.Compilation.GetTypeByMetadataName("FluentAssertions.AssertionExtensions") is null)
                return;

            var analyzerContext = new AnalyzerContext(context.Compilation);

            if (analyzerContext.IsXUnitAvailable)
            {
                context.RegisterOperationAction(analyzerContext.AnalyzeXunitInvocation, OperationKind.Invocation);
            }

            if (analyzerContext.IsMSTestsAvailable)
            {
                context.RegisterOperationAction(analyzerContext.AnalyzeMsTestInvocation, OperationKind.Invocation);
                context.RegisterOperationAction(analyzerContext.AnalyzeMsTestThrow, OperationKind.Throw);
            }

            if (analyzerContext.IsNUnitAvailable)
            {
                context.RegisterOperationAction(analyzerContext.AnalyzeNunitInvocation, OperationKind.Invocation);
                context.RegisterOperationAction(analyzerContext.AnalyzeNunitDynamicInvocation, OperationKind.DynamicInvocation);
                context.RegisterOperationAction(analyzerContext.AnalyzeNunitThrow, OperationKind.Throw);
            }
        });
    }

    private sealed class AnalyzerContext(Compilation compilation)
    {
        private readonly INamedTypeSymbol _xunitAssertSymbol = compilation.GetTypeByMetadataName("Xunit.Assert");

        private readonly INamedTypeSymbol _msTestsAssertSymbol = compilation.GetTypeByMetadataName("Microsoft.VisualStudio.TestTools.UnitTesting.Assert");
        private readonly INamedTypeSymbol _msTestsStringAssertSymbol = compilation.GetTypeByMetadataName("Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert");
        private readonly INamedTypeSymbol _msTestsCollectionAssertSymbol = compilation.GetTypeByMetadataName("Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert");
        private readonly INamedTypeSymbol _msTestsUnitTestAssertExceptionSymbol = compilation.GetTypeByMetadataName("Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestAssertException");

        private readonly INamedTypeSymbol _nunitAssertionExceptionSymbol = compilation.GetTypeByMetadataName("NUnit.Framework.AssertionException");
        private readonly INamedTypeSymbol _nunitAssertSymbol = compilation.GetTypeByMetadataName("NUnit.Framework.Assert");
        private readonly INamedTypeSymbol _nunitCollectionAssertSymbol = compilation.GetTypeByMetadataName("NUnit.Framework.CollectionAssert") ?? compilation.GetTypeByMetadataName("NUnit.Framework.Legacy.CollectionAssert");
        private readonly INamedTypeSymbol _nunitDirectoryAssertSymbol = compilation.GetTypeByMetadataName("NUnit.Framework.DirectoryAssert");
        private readonly INamedTypeSymbol _nunitFileAssertSymbol = compilation.GetTypeByMetadataName("NUnit.Framework.FileAssert");
        private readonly INamedTypeSymbol _nunitStringAssertSymbol = compilation.GetTypeByMetadataName("NUnit.Framework.StringAssert");
        private readonly INamedTypeSymbol _nunitClassicAssertSymbol = compilation.GetTypeByMetadataName("NUnit.Framework.Legacy.ClassicAssert");
        private readonly INamedTypeSymbol _nunitResultStateExceptionSymbol = compilation.GetTypeByMetadataName("NUnit.Framework.ResultStateException");

        public bool IsMSTestsAvailable => _msTestsAssertSymbol is not null;
        public bool IsNUnitAvailable => _nunitAssertionExceptionSymbol is not null;
        public bool IsXUnitAvailable => _xunitAssertSymbol is not null;

        private static readonly char[] SymbolsSeparators = [';'];

        private bool IsMethodExcluded(AnalyzerOptions options, IInvocationOperation operation)
        {
            var location = operation.Syntax.GetLocation().SourceTree;
            if (location is null)
                return false;

            var fileOptions = options.AnalyzerConfigOptionsProvider.GetOptions(location);
            if (fileOptions is null)
                return false;

            if (!fileOptions.TryGetValue("mfa_excluded_methods", out var symbolDocumentationIds))
                return false;

            var parts = symbolDocumentationIds.Split(SymbolsSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                var symbols = DocumentationCommentId.GetSymbolsForDeclarationId(part, compilation);
                foreach (var symbol in symbols)
                {
                    if (operation.TargetMethod.EqualsSymbol(symbol))
                        return true;
                }
            }

            return false;
        }

        public void AnalyzeXunitInvocation(OperationAnalysisContext context)
        {
            var op = (IInvocationOperation)context.Operation;
            if (op.TargetMethod.ContainingType.EqualsSymbol(_xunitAssertSymbol) && !IsMethodExcluded(context.Options, op))
            {
                context.ReportDiagnostic(Diagnostic.Create(XunitRule, op.Syntax.GetLocation()));
            }
        }

        public void AnalyzeMsTestInvocation(OperationAnalysisContext context)
        {
            var op = (IInvocationOperation)context.Operation;
            if (IsMsTestAssertClass(op.TargetMethod.ContainingType) && !IsMethodExcluded(context.Options, op))
            {
                if (op.TargetMethod.Name is "Fail" or "Inconclusive" && op.TargetMethod.ContainingType.EqualsSymbol(_msTestsAssertSymbol))
                    return;
                context.ReportDiagnostic(Diagnostic.Create(MSTestsRule, op.Syntax.GetLocation()));
            }
        }

        public void AnalyzeMsTestThrow(OperationAnalysisContext context)
        {
            var op = (IThrowOperation)context.Operation;
            if (op.Exception is not null && op.Exception.UnwrapConversion().Type.IsOrInheritsFrom(_msTestsUnitTestAssertExceptionSymbol))
            {
                context.ReportDiagnostic(Diagnostic.Create(MSTestsRule, op.Syntax.GetLocation()));
            }
        }

        public void AnalyzeNunitInvocation(OperationAnalysisContext context)
        {
            var op = (IInvocationOperation)context.Operation;
            if (IsNunitAssertClass(op.TargetMethod.ContainingType) && !IsMethodExcluded(context.Options, op))
            {
                if (op.TargetMethod.Name is "Inconclusive" or "Ignore" or "Pass" or "Warn" or "Charlie" && op.TargetMethod.ContainingType.EqualsSymbol(_nunitAssertSymbol))
                    return;

                context.ReportDiagnostic(Diagnostic.Create(NUnitRule, op.Syntax.GetLocation()));
            }
        }

        public void AnalyzeNunitDynamicInvocation(OperationAnalysisContext context)
        {
            var op = (IDynamicInvocationOperation)context.Operation;

            if (op.Arguments.Length < 2)
                return;

            var containingType = ((op.Arguments[1]
                        .Parent as IDynamicInvocationOperation)?
                        .Operation as IDynamicMemberReferenceOperation)?
                        .ContainingType;
            if (IsNunitAssertClass(containingType))
            {
                context.ReportDiagnostic(Diagnostic.Create(NUnitRule, op.Syntax.GetLocation()));
            }
        }

        public void AnalyzeNunitThrow(OperationAnalysisContext context)
        {
            var op = (IThrowOperation)context.Operation;
            if (op.Exception is not null && op.Exception.UnwrapConversion().Type.IsOrInheritsFrom(_nunitResultStateExceptionSymbol))
            {
                context.ReportDiagnostic(Diagnostic.Create(NUnitRule, op.Syntax.GetLocation()));
            }
        }

        private bool IsMsTestAssertClass(ITypeSymbol typeSymbol)
        {
            if (typeSymbol is null)
                return false;

            return typeSymbol.EqualsSymbol(_msTestsAssertSymbol)
                || typeSymbol.EqualsSymbol(_msTestsStringAssertSymbol)
                || typeSymbol.EqualsSymbol(_msTestsCollectionAssertSymbol);
        }

        private bool IsNunitAssertClass(ITypeSymbol typeSymbol)
        {
            if (typeSymbol is null)
                return false;

            return typeSymbol.EqualsSymbol(_nunitAssertSymbol)
                || typeSymbol.EqualsSymbol(_nunitCollectionAssertSymbol)
                || typeSymbol.EqualsSymbol(_nunitDirectoryAssertSymbol)
                || typeSymbol.EqualsSymbol(_nunitFileAssertSymbol)
                || typeSymbol.EqualsSymbol(_nunitStringAssertSymbol)
                || typeSymbol.EqualsSymbol(_nunitClassicAssertSymbol);
        }
    }
}