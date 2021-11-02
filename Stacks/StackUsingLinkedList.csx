
class Node
{
    public string Value { get; set; }
    public Node Next { get; set; }
    public Node(string value)
    {
        Value = value;
        Next = null;
    }
}

class Stack
{
    public Node Top { get; set; }
    public Node Bottom { get; set; }
    public int Length { get; set; }
    public Stack()
    {
        Top = null;
        Bottom = null;
        Length = 0;
    }

    public string Peek()
    {
        return Top.Value;
    }

    public void Push(string value)
    {
        var newNode = new Node(value);
        if (Length == 0)
        {
            Top = newNode;
            Bottom = newNode;
        }
        else
        {
            newNode.Next = Top;
            Top = newNode;
        }
        Length++;
        return;
    }

    public string Pop()
    {
        if (Top == null)
            return null;
        var currNode = Top;
        if (Length == 1)
        {
            Top = null;
            Bottom = null;
        }
        else
        {
            Top = Top.Next;
        }
        Length--;
        return currNode.Value;
    }

    public bool IsEmpty()
    {
        if (Length < 1 || Top == null)
            return true;
        else
            return false;
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
