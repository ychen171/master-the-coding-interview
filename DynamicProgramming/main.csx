
Console.WriteLine("Hello world!");
// 0 1 1 2 3 5 8 13 21 34 55 89

public int Fibonacci(int n)
{
    if (n < 2) return n;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

static Func<A, R> Memoize<A, R>(this Func<A, R> f)
{
    var d = new Dictionary<A, R>();
    return a =>
    {
        R r;
        if (!d.TryGetValue(a, out r))
        {
            r = f(a);
            d[a] = r;
        }
        return r;
    };
}

public int FibonacciMemoize(int n, Dictionary<int, int> memo)
{
    int result;
    if (memo.TryGetValue(n, out result)) return result;
    if (n < 2) return n;
    result = FibonacciMemoize(n - 1, memo) + FibonacciMemoize(n - 2, memo);
    memo[n] = result;
    return result;
}

public int FibonacciBottomUp(int n)
{
    if (n < 2) return n;
    var bottomUp = new int[n + 1];
    bottomUp[0] = 0;
    bottomUp[1] = 1;
    for (int i = 2; i <= n; i++)
    {
        bottomUp[i] = bottomUp[i - 1] + bottomUp[i - 2];
    }
    return bottomUp[n];
}

var sw1 = Stopwatch.StartNew();
// Console.WriteLine(Fibonacci(0));
// Console.WriteLine(Fibonacci(1));
// Console.WriteLine(Fibonacci(2));
// Console.WriteLine(Fibonacci(3));
// Console.WriteLine(Fibonacci(4));
// Console.WriteLine(Fibonacci(5));
Console.WriteLine(Fibonacci(30));
sw1.Stop();
Console.WriteLine($"Time Elapsed: {sw1.ElapsedTicks}");

// Console.WriteLine(Fibonacci(8));
// Console.WriteLine(Fibonacci(9));
// Console.WriteLine(Fibonacci(10));
// Console.WriteLine(Fibonacci(11));

var sw2 = Stopwatch.StartNew();
Func<int, int> fib = n => n < 2 ? n : fib(n - 1) + fib(n - 2);
// Console.WriteLine(fib.Memoize()(0));
// Console.WriteLine(fib.Memoize()(1));
// Console.WriteLine(fib.Memoize()(2));
// Console.WriteLine(fib.Memoize()(3));
// Console.WriteLine(fib.Memoize()(4));
// Console.WriteLine(fib.Memoize()(5));
// Console.WriteLine(fib.Memoize()(6));
// Console.WriteLine(fib.Memoize()(7));
Console.WriteLine(fib.Memoize()(30));
sw2.Stop();
Console.WriteLine($"Time Elapsed: {sw2.ElapsedTicks}");


Func<int, int> fibFunc = n => Fibonacci(n);
// Console.WriteLine(fibFunc.Memoize()(0));
// Console.WriteLine(fibFunc.Memoize()(1));
// Console.WriteLine(fibFunc.Memoize()(2));
// Console.WriteLine(fibFunc.Memoize()(3));
// Console.WriteLine(fibFunc.Memoize()(4));
// Console.WriteLine(fibFunc.Memoize()(5));
// Console.WriteLine(fibFunc.Memoize()(6));

var sw3 = Stopwatch.StartNew();
Console.WriteLine(FibonacciMemoize(30, new Dictionary<int, int>()));
sw3.Stop();
Console.WriteLine($"Time Elapsed: {sw3.ElapsedTicks}");

var sw4 = Stopwatch.StartNew();
Console.WriteLine(FibonacciBottomUp(30));
sw4.Stop();
Console.WriteLine($"Time Elapsed: {sw4.ElapsedTicks}");


