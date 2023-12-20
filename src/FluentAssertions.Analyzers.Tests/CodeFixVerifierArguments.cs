using System.Collections.Generic;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FluentAssertions.Analyzers.Tests;

public class CodeFixVerifierArguments : CsProjectArguments
{
    public List<string> FixedSources { get; } = new();

    public List<DiagnosticAnalyzer> DiagnosticAnalyzers { get; } = new();

    public List<CodeFixProvider> CodeFixProviders { get; } = new();

    public CodeFixVerifierArguments() { }

    public CodeFixVerifierArguments WithDiagnosticAnalyzer<TDiagnosticAnalyzer>() where TDiagnosticAnalyzer : DiagnosticAnalyzer, new()
    {
        DiagnosticAnalyzers.Add(new TDiagnosticAnalyzer());
        return this;
    }

    public CodeFixVerifierArguments WithCodeFixProvider<TCodeFixProvider>() where TCodeFixProvider : CodeFixProvider, new()
    {
        CodeFixProviders.Add(new TCodeFixProvider());
        return this;
    }
    
    public CodeFixVerifierArguments WithFixedSources(params string[] fixedSources)
    {
        FixedSources.AddRange(fixedSources);
        return this;
    }
}