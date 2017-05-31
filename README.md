# Benchmark LocalFunctions vs Lambdas

Benchmark the statements in the following article https://docs.microsoft.com/en-us/dotnet/csharp/local-functions-vs-lambdas

````
 public static int LambdaFactorial(int n)
        {
            Func<int, int> nthFactorial = default(Func<int, int>);
            nthFactorial = (number) => (number < 2) ?
                1 : number * nthFactorial(number - 1);
            return nthFactorial(n);
        }
````
vs

````
   public static int LocalFunctionFactorial(int n)
        {
            return nthFactorial(n);
            int nthFactorial(int number) => (number < 2) ?
                1 : number * nthFactorial(number - 1);
        }
````

## Results

``` ini

BenchmarkDotNet=v0.10.6, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i5-4590 CPU 3.30GHz (Haswell), ProcessorCount=4
Frequency=3215225 Hz, Resolution=311.0202 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0


```
 |                 Method |     Mean |     Error |    StdDev |      Min |      Max |  Gen 0 | Allocated |
 |----------------------- |---------:|----------:|----------:|---------:|---------:|-------:|----------:|
 |        LambdaFactorial | 31.86 ns | 0.2249 ns | 0.2104 ns | 31.52 ns | 32.15 ns | 0.0139 |      44 B |
 | LocalFunctionFactorial | 15.16 ns | 0.1195 ns | 0.1118 ns | 14.98 ns | 15.34 ns |      - |       0 B |


 Benchmarked with [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)