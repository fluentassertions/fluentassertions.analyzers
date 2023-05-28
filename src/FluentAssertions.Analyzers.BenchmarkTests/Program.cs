using BenchmarkDotNet.Running;

namespace FluentAssertions.Analyzers.BenchmarkTests
{
    public class Program
    {
        public static void Main() 
            => BenchmarkDotNet.Running.BenchmarkRunner.Run<FluentAssertionsBenchmarks>();
    }
}