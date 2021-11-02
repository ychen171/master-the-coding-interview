
// Create a function that reverse a string:
// "Hi My name is Yu" should be:
// "uY si eman yM iH"

public string Reverse(string input)
{
    if (input == null || input.Length <= 1) return input;
    var output = string.Empty;
    for (int i = 0; i < input.Length; i++)
    {
        output += input[input.Length - 1 - i];
    }
    return output;
}

var myString = "Hi My name is Yu";
Console.WriteLine(myString);

Console.WriteLine(Reverse(myString));

Console.WriteLine(Reverse(null));
Console.WriteLine(Reverse("!"));
