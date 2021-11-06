
public int FindFactorialRecurisive(int n)
{
    // base case: 1! = 1
    // recursive case: n! = n * (n-1)!

    if (n < 2) return 1;
    else return n * FindFactorialRecurisive(n-1);
}

public int FindFactorialIterative(int n)
{
    int result = 1;
    while (n > 1)
    {
        result *= n;
        n--;
    }
    return result;
}

Console.WriteLine(FindFactorialRecurisive(1));
Console.WriteLine(FindFactorialRecurisive(2));
Console.WriteLine(FindFactorialRecurisive(3));
Console.WriteLine(FindFactorialRecurisive(4));
Console.WriteLine(FindFactorialRecurisive(5));

Console.WriteLine(FindFactorialIterative(1));
Console.WriteLine(FindFactorialIterative(2));
Console.WriteLine(FindFactorialIterative(3));
Console.WriteLine(FindFactorialIterative(4));
Console.WriteLine(FindFactorialIterative(5));

