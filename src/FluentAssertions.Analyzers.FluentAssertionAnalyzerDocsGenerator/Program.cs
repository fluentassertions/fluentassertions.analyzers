using System.Threading.Tasks;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator;

public class Program
{
    public static async Task Main(string[] args)
    {
        var generator = new DocsGenerator();

        await generator.Execute();
    }
}