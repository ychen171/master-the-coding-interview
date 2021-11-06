
public int FibonacciIterative(int n) // O(n)
{
    if (n < 2)
        return n;
    int a = 0;
    int b = 1;
    int c = 0;
    for (int i = 2; i <= n; i++)
    {
        c = a + b;
        a = b;
        b = c;
    }

    return c;
}

public int FibonacciRecursive(int n) // O(2^n)
{
    if (n < 2)
        return n;
    else
        return FibonacciRecursive(n - 2) + FibonacciRecursive(n - 1);
}

Console.WriteLine(FibonacciIterative(0));
Console.WriteLine(FibonacciIterative(1));
Console.WriteLine(FibonacciIterative(2));
Console.WriteLine(FibonacciIterative(3));
Console.WriteLine(FibonacciIterative(4));
Console.WriteLine(FibonacciIterative(5));
Console.WriteLine(FibonacciIterative(6));
Console.WriteLine(FibonacciIterative(7));
Console.WriteLine(FibonacciIterative(8));

Console.WriteLine(FibonacciRecursive(0));
Console.WriteLine(FibonacciRecursive(1));
Console.WriteLine(FibonacciRecursive(2));
Console.WriteLine(FibonacciRecursive(3));
Console.WriteLine(FibonacciRecursive(4));
Console.WriteLine(FibonacciRecursive(5));
Console.WriteLine(FibonacciRecursive(6));
Console.WriteLine(FibonacciRecursive(7));
Console.WriteLine(FibonacciRecursive(8));
