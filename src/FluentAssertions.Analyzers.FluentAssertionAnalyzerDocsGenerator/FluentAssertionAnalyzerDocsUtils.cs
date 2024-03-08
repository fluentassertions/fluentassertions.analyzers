using System.IO;
using System.Threading.Tasks;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

public static class FluentAssertionAnalyzerDocsUtils
{
    public static async Task<Compilation> GetFluentAssertionAnalyzerDocsCompilation()
    {
        MSBuildLocator.RegisterDefaults();

        using var workspace = MSBuildWorkspace.Create();

        var project = await workspace.OpenProjectAsync(Path.Combine("..", "FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs", "FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs.csproj"));

        return await project.GetCompilationAsync();
    }
}
