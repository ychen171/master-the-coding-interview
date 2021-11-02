public class MyArray<T>
{
    public int Length { get; private set; }
    private List<T> data;
    public MyArray()
    {
        Length = 0;
        data = new List<T>();
    }

    public T Get(int index)
    {
        return data[index];
    }

    public int Push(T item)
    {
        data.Add(item);
        Length += 1;
        return Length;
    }

    public T Pop()
    {
        var item = data[data.Count - 1];
        Length -= 1;
        data.Remove(item);
        return item;
    }

    public void Delete(int index)
    {
        var item = data[index];
        for (int i = index; i < Length - 1; i++)
        {
            this.data[i] = this.data[i + 1];
        }
        Pop();
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append("[");
        foreach (var item in this.data)
            result.Append($"{item}, ");
        result.Remove(result.Length - 2, 2);
        result.Append("]");
        return result.ToString();
    }
}

var newArray = new MyArray<string>();
newArray.Push("hi");
newArray.Push("you");
newArray.Push("!");
Console.WriteLine(newArray.ToString());
newArray.Delete(1);
Console.WriteLine(newArray.ToString());
