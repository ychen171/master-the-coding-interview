
Console.WriteLine("Hello world!");

class Node
{
    public string Value {get;set;}
    public Node Next{get;set;}
    public Node(string value)
    {
        Value = value;
        Next = null;
    }
}
class Queue
{
    private Node first;
    private Node last;
    private int length;
    public Queue()
    {
        first = null;
        last = null;
        length = 0;
    }
    public string Peek()
    {
        if (length == 0)
            return null;
        return first.Value;
    }
    public void Enqueue(string value)
    {
        var newNode = new Node(value);
        if (length == 0)
        {
            first = newNode;
            last = newNode;
        }
        else
        {
            last.Next = newNode;
            last = newNode;
        }
        length++;
        return;
    }
    public string Dequeue()
    {
        if (first == null)
            return null;
        var currNode = first;
        if (length == 1)
        {
            first = null;
            last = null;
        }
        else
        {
            first = first.Next;
        }
        length--;
        return currNode.Value;
    }
    public bool IsEmpty()
    {
        return length == 0;
    }
}

var myQueue = new Queue();
myQueue.Enqueue("Joy");
myQueue.Enqueue("Matt");
myQueue.Enqueue("Pavel");
myQueue.Enqueue("Samir");

var item = string.Empty;
Console.WriteLine(myQueue.IsEmpty());
item = myQueue.Peek();
Console.WriteLine(item);

item = myQueue.Dequeue();
Console.WriteLine(item);
item = myQueue.Dequeue();
Console.WriteLine(item);
item = myQueue.Dequeue();
Console.WriteLine(item);
item = myQueue.Dequeue();
Console.WriteLine(item);

Console.WriteLine(myQueue.IsEmpty());
