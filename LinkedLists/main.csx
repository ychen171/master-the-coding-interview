

class Node
{
    public int Value { get; set; }
    public Node Next { get; set; }
    public Node(int value)
    {
        this.Value = value;
    }
}

class LinkedList
{
    private Node head;
    private Node tail;
    private int length;
    public LinkedList(int value)
    {
        head = new Node(value);
        tail = head;
        length = 1;
    }
    public LinkedList()
    {
        head = null;
        tail = head;
    }

    public LinkedList Append(int value)
    {
        if (tail != null)
        {
            var curr = tail;
            curr.Next = new Node(value);
            tail = curr.Next;
        }
        else
            tail = new Node(value);

        length++;
        return this;
    }

    public LinkedList Prepend(int value)
    {
        if (head != null)
        {
            var curr = new Node(value);
            curr.Next = head;
            head = curr;
        }
        else
            head = new Node(value);

        length++;
        return this;
    }

    public LinkedList Insert(int index, int value)
    {
        if (index == 0)
            return Prepend(value);
        if (index >= length)
            return Append(value);

        Node curr = head;
        int count = 0;
        while (count < index - 1)
        {
            curr = curr.Next;
            count++;
        }
        var newNode = new Node(value);
        newNode.Next = curr.Next;
        curr.Next = newNode;
        length++;
        return this;
    }

    public LinkedList Remove(int index)
    {
        if (index >= length)
            return this;
        if (index == 0)
            head = head.Next;
        else
        {
            Node curr = head;
            int count = 0;
            while (count < index - 1)
            {
                curr = curr.Next;
                count++;
            }
            curr.Next = curr.Next.Next;
        }

        length--;
        return this;
    }

    public LinkedList Reverse()
    {
        if (head == null)
            return this;
        var currNode = head;
        var newLinkedList = new LinkedList();
        while (currNode != null)
        {
            newLinkedList.Prepend(currNode.Value);
            currNode = currNode.Next;
        }
        return newLinkedList;
    }
    
    public LinkedList Reverse2()
    {
        if (head == null || head.Next == null)
            return this;
        var first = head;
        tail = head;
        var second = first.Next;
        while (second != null)
        {
            var temp = second.Next;
            second.Next = first;
            first = second;
            second = temp;
        }
        head.Next = null;
        head = first;
        return this;
    }

    public override string ToString()
    {
        var curr = head;
        var sb = new StringBuilder();
        var linkString = " -> ";
        while (curr != null)
        {
            sb.Append(curr.Value);
            sb.Append(linkString);
            curr = curr.Next;
        }
        sb.Remove(sb.Length - linkString.Length, linkString.Length);
        return sb.ToString();
    }
}

var myLinkedList = new LinkedList(10);
myLinkedList.Append(20).Append(30);
Console.WriteLine(myLinkedList.ToString());
myLinkedList.Prepend(0);
Console.WriteLine(myLinkedList.ToString());
myLinkedList.Insert(2, 15);
Console.WriteLine(myLinkedList.ToString());
myLinkedList.Insert(5, 40);
Console.WriteLine(myLinkedList.ToString());
myLinkedList.Remove(2);
Console.WriteLine(myLinkedList.ToString());
myLinkedList.Remove(4);
Console.WriteLine(myLinkedList);
var reversedLinkedList = myLinkedList.Reverse();
Console.WriteLine(reversedLinkedList);

var reversedLinkedList2 = myLinkedList.Reverse2();
Console.WriteLine(reversedLinkedList2.ToString());
