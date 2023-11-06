using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using FluentAssertions.Analyzers.TestUtils;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace FluentAssertions.Analyzers.BenchmarkTests
{
    [SimpleJob(RuntimeMoniker.Net60, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [RPlotExporter]
    public class FluentAssertionsBenchmarks
    {
        private CompilationWithAnalyzers MinimalCompiliation;

        [GlobalSetup]
        public async Task GlobalSetup()
        {
            MinimalCompiliation = await CreateCompilationFromAsync(GenerateCode.ObjectStatement("actual.Should().Equals(expected);"));
        }

        [Benchmark]
        public Task MinimalCompilation()
        {
            return MinimalCompiliation.GetAnalyzerDiagnosticsAsync();
        }

        private async Task<CompilationWithAnalyzers> CreateCompilationFromAsync(params string[] sources)
        {
            var project = CsProjectGenerator.CreateProject(sources);
            var compilation = await project.GetCompilationAsync();

            if (compilation is null)
            {
                throw new InvalidOperationException("Compilation is null");
            }

            return compilation.WithOptions(compilation.Options.WithSpecificDiagnosticOptions(new Dictionary<string, ReportDiagnostic>
            {
                ["CS1701"] = ReportDiagnostic.Suppress, // Binding redirects
                ["CS1702"] = ReportDiagnostic.Suppress,
                ["CS1705"] = ReportDiagnostic.Suppress,
                ["CS8019"] = ReportDiagnostic.Suppress // TODO: Unnecessary using directive
            })).WithAnalyzers(CodeAnalyzersUtils.GetAllAnalyzers().ToImmutableArray());
        }
    }
}