using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;

namespace Benchmark
{
    [MinColumn, MaxColumn, MarkdownExporter, MemoryDiagnoser, RPlotExporter]
    public class LambdaVsLocalFunctions
    {   
        [Params(3, 10, 20)]
        public int N { get; set; }
        [Benchmark]
        public int LambdaFactorial() => Factorial.LambdaFactorial(N);
        [Benchmark]
        public int LocalFunctionFactorial() => Factorial.LocalFunctionFactorial(N);
    }
}
