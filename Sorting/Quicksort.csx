
public List<int> Quicksort(List<int> inputList, int low, int high)
{
    if (low < high)
    {
        int partitionIndex = Partition(inputList, low, high);

        Quicksort(inputList, low, partitionIndex - 1);
        Quicksort(inputList, partitionIndex + 1, high);
    }

    return inputList;
}

private int Partition(List<int> inputList, int low, int high)
{
    int pivot = inputList[high];
    int partitionIndex = low;

    for (int i = low; i < high; i++)
    {
        if (inputList[i] < pivot)
        {
            Swap(inputList, partitionIndex, i);
            partitionIndex++;
        }
    }
    Swap(inputList, partitionIndex, high);
    return partitionIndex;
}

private void Swap(List<int> inputList, int i, int j)
{
    var temp = inputList[i];
    inputList[i] = inputList[j];
    inputList[j] = temp;
}

var inputList = new List<int> { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };
var outputList = Quicksort(inputList, 0, inputList.Count - 1);
Console.WriteLine();
foreach (var item in inputList)
{
    Console.Write(item + " ");
}




