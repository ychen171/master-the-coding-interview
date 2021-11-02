

class Node
{
    public int Value { get; set; }
    public Node Prev { get; set; }
    public Node Next { get; set; }
    public Node(int value)
    {
        this.Value = value;
    }
}

class DoublyLinkedList
{
    private Node head;
    private Node tail;
    private int length;
    public DoublyLinkedList(int value)
    {
        head = new Node(value);
        tail = head;
        length = 1;
    }
    public DoublyLinkedList()
    {
        head = null;
        tail = head;
    }

    public DoublyLinkedList Append(int value)
    {
        if (tail != null)
        {
            var newNode = new Node(value);
            var currNode = tail;
            currNode.Next = newNode;
            newNode.Prev = currNode;
            tail = currNode.Next;
        }
        else
            tail = new Node(value);

        length++;
        return this;
    }

    public DoublyLinkedList Prepend(int value)
    {
        if (head != null)
        {
            var newNode = new Node(value);
            var currNode = newNode;
            currNode.Next = head;
            head.Prev = currNode;
            head = currNode;
        }
        else
            head = new Node(value);

        length++;
        return this;
    }

    public DoublyLinkedList Insert(int index, int value)
    {
        if (index == 0)
            return Prepend(value);
        if (index >= length)
            return Append(value);

        Node currNode = head;
        int count = 0;
        while (count < index - 1)
        {
            currNode = currNode.Next;
            count++;
        }
        var newNode = new Node(value);
        var nextNode = currNode.Next;
        newNode.Next = nextNode;
        nextNode.Prev = newNode;
        currNode.Next = newNode;
        newNode.Prev = currNode;
        length++;
        return this;
    }

    public DoublyLinkedList Remove(int index)
    {
        if (index >= length)
            return this;
        if (index == 0)
        {
            head = head.Next;
            head.Prev = null;
        }
        else if (index == length - 1)
        {
            tail = tail.Prev;
            tail.Next = null;
        }
        else
        {
            Node currNode = head;
            int count = 0;
            while (count < index - 1)
            {
                currNode = currNode.Next;
                count++;
            }
            var targetNode = currNode.Next;
            var nextNode = targetNode.Next;
            currNode.Next = nextNode;
            nextNode.Prev = currNode;
        }

        length--;
        return this;
    }

    public override string ToString()
    {
        var curr = head;
        var sb = new StringBuilder();
        var linkString = " <-> ";
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

var myLinkedList = new DoublyLinkedList(10);
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
