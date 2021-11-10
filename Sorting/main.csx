
var letters = new List<char>() { 'a', 'd', 'z', 'e', 'r', 'b' };
var numbers = new List<int>() { 2, 65, 34, 2, 1, 7, 8 };

public static void PrintList(List<char> list)
{
    foreach (var item in list)
        Console.Write(item.ToString() + " ");
    Console.WriteLine();
}
public static void PrintList(List<int> list)
{
    foreach (var item in list)
        Console.Write(item.ToString() + " ");
    Console.WriteLine();
}

PrintList(letters);
letters.Sort();
PrintList(letters);

PrintList(numbers);
numbers.Sort();
PrintList(numbers);


