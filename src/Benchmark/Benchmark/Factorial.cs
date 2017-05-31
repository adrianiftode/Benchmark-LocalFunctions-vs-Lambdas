using System;

namespace Benchmark
{
    public static class Factorial
    {
        public static int LambdaFactorial(int n)
        {
            Func<int, int> nthFactorial = default(Func<int, int>);
            nthFactorial = (number) => (number < 2) ?
                1 : number * nthFactorial(number - 1);
            return nthFactorial(n);
        }

        public static int LocalFunctionFactorial(int n)
        {
            return nthFactorial(n);
            int nthFactorial(int number) => (number < 2) ?
                1 : number * nthFactorial(number - 1);
        }
    }
}
