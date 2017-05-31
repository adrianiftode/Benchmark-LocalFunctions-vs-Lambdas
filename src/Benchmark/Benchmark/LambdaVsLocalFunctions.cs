using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;

namespace Benchmark
{
    [MinColumn, MaxColumn, MarkdownExporter]
    public class LambdaVsLocalFunctions
    {
        private int n;
        public LambdaVsLocalFunctions()
        {
            n = 6;
        }
        [Benchmark]
        public int LambdaFactorial() => Factorial.LambdaFactorial(n);
        [Benchmark]
        public int LocalFunctionFactorial() => Factorial.LocalFunctionFactorial(n);
    }
}
