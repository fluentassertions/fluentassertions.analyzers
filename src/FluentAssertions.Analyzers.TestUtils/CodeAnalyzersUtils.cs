using System;
using System.Linq;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FluentAssertions.Analyzers.TestUtils
{
    public class CodeAnalyzersUtils
    {
        private static readonly DiagnosticAnalyzer[] AllAnalyzers = CreateAllAnalyzers();

        public static DiagnosticAnalyzer[] GetAllAnalyzers() => AllAnalyzers;

        private static DiagnosticAnalyzer[] CreateAllAnalyzers()
        {
            var assembly = typeof(Constants).Assembly;
            var analyzersTypes = assembly.GetTypes()
                .Where(type => !type.IsAbstract && typeof(DiagnosticAnalyzer).IsAssignableFrom(type));
            var analyzers = analyzersTypes.Select(type => (DiagnosticAnalyzer)Activator.CreateInstance(type));

            return analyzers.ToArray();
        }
    }
}