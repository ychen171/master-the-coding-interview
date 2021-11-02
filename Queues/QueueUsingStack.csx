
class MyQueue
{
    private Stack<int> pushStack;
    private Stack<int> popStack;
    public MyQueue()
    {
        pushStack = new Stack<int>();
        popStack = new Stack<int>();
    }

    public void Push(int x)
    {
        while (popStack.Count > 0)
        {
            pushStack.Push(popStack.Pop());
        }
        pushStack.Push(x);
    }
    public int Pop()
    {
        while (pushStack.Count > 0)
        {
            popStack.Push(pushStack.Pop());
        }
        return popStack.Pop();
    }
    public int Peek()
    {
        while (pushStack.Count > 0)
        {
            popStack.Push(pushStack.Pop());
        }
        return popStack.Peek();
    }
    public bool Empty()
    {
        return pushStack.Count() == 0 && popStack.Count() == 0;
    }
}

var obj = new MyQueue();
obj.Push(1);
obj.Push(2);
obj.Push(3);
obj.Push(4);
Console.WriteLine(obj.Empty());
Console.WriteLine(obj.Peek());
int item;
item = obj.Pop();
Console.WriteLine(item);
item = obj.Pop();
Console.WriteLine(item);
item = obj.Pop();
Console.WriteLine(item);
item = obj.Pop();
Console.WriteLine(item);
Console.WriteLine(obj.Empty());
