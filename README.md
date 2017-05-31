# Benchmark LocalFunctions vs Lambdas

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

``` ini

BenchmarkDotNet=v0.10.6, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i5-4590 CPU 3.30GHz (Haswell), ProcessorCount=4
Frequency=3215225 Hz, Resolution=311.0202 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0


```
 |                 Method |     Mean |     Error |    StdDev |
 |----------------------- |---------:|----------:|----------:|
 |        LambdaFactorial | 34.54 ns | 0.2510 ns | 0.2348 ns |
 | LocalFunctionFactorial | 17.26 ns | 0.1190 ns | 0.1113 ns |


 Benchmarked with [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)