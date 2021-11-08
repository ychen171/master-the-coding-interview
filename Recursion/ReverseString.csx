
public string ReverseIterative(string input)
{
    if (input == null || input.Length < 2) // corner case
        return input;

    var output = string.Empty;
    for (int i = 0; i < input.Length; i++)
    {
        output += input[input.Length - 1 - i];
    }
    return output;
}

public string ReverseRecursive(string input)
{
    var output = string.Empty;
    // base case
    if (input.Length < 2) return input;
    // recursive case
    return ReverseRecursive(input.Substring(1, input.Length - 1)) + input[0];
}

var input = "abc";
var output = string.Empty;

output = ReverseIterative(input);
Console.WriteLine(output);

output = ReverseRecursive(input);
Console.WriteLine(output);


