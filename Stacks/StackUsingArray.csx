
class Stack
{
    public string Top { get; set; }
    public string Bottm { get; set; }
    private List<string> myList;

    public Stack()
    {
        myList = new List<string>();
    }

    public string Peek()
    {
        if (myList.Count == 0) 
            return null;
        return myList[myList.Count - 1];
    }

    public Stack Push(string value)
    {
        myList.Add(value);
        return this;
    }

    public string Pop()
    {
        if (myList.Count == 0) 
            return null;
        var item = myList[myList.Count - 1];
        myList.RemoveAt(myList.Count - 1);
        return item;
    }

    public bool IsEmpty()
    {
        return myList.Count == 0;
    }
}

var myStack = new Stack();
myStack.Push("Google");
myStack.Push("Udemy");
myStack.Push("Discord");
Console.WriteLine(myStack.IsEmpty());
var item = string.Empty;
item = myStack.Pop();
Console.WriteLine(item);
item = myStack.Pop();
Console.WriteLine(item);
item = myStack.Pop();
Console.WriteLine(item);
Console.WriteLine(myStack.IsEmpty());
