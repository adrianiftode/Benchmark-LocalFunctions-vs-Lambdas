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

```
 |                 Method |  N |      Mean |     Error |    StdDev |       Min |       Max |  Gen 0 | Allocated |
 |----------------------- |--- |----------:|----------:|----------:|----------:|----------:|-------:|----------:|
 |        **LambdaFactorial** |  **3** | **14.707 ns** | **0.1897 ns** | **0.1775 ns** | **14.443 ns** | **15.023 ns** | **0.0140** |      **44 B** |
 | LocalFunctionFactorial |  3 |  4.111 ns | 0.0469 ns | 0.0439 ns |  4.057 ns |  4.196 ns |      - |       0 B |
 |        **LambdaFactorial** | **10** | **31.992 ns** | **0.0707 ns** | **0.0591 ns** | **31.917 ns** | **32.090 ns** | **0.0139** |      **44 B** |
 | LocalFunctionFactorial | 10 | 15.327 ns | 0.0622 ns | 0.0582 ns | 15.230 ns | 15.424 ns |      - |       0 B |
 |        **LambdaFactorial** | **20** | **62.756 ns** | **0.0966 ns** | **0.0698 ns** | **62.631 ns** | **62.878 ns** | **0.0139** |      **44 B** |
 | LocalFunctionFactorial | 20 | 37.762 ns | 0.2754 ns | 0.2576 ns | 37.210 ns | 38.106 ns |      - |       0 B |


 Benchmarked with [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)