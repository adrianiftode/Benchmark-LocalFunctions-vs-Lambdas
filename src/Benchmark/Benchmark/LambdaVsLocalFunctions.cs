using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;

namespace Benchmark
{
    [MinColumn, MaxColumn, MarkdownExporter, MemoryDiagnoser]
    public class LambdaVsLocalFunctions
    {
        private int n;
        public LambdaVsLocalFunctions()
        {
            n = 10;
        }
        [Benchmark]
        public int LambdaFactorial() => Factorial.LambdaFactorial(n);
        [Benchmark]
        public int LocalFunctionFactorial() => Factorial.LocalFunctionFactorial(n);
    }
}
