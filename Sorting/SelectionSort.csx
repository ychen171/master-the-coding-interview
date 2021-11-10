
public List<int> SelectionSort(List<int> inputList)
{
    if (inputList == null || inputList.Count < 2)
        return inputList;

    for (int i = 0; i < inputList.Count - 1; i++)
    {
        var minIndex = i;
        for (int j = i + 1; j < inputList.Count; j++)
        {
            if (inputList[j] < inputList[minIndex])
            {
                minIndex = j;
            }
        }
        var temp = inputList[i];
        inputList[i] = inputList[minIndex];
        inputList[minIndex] = temp;
    }
    return inputList;
}


var inputList = new List<int> { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };

var outputList = SelectionSort(inputList);
foreach (var item in outputList)
{
    Console.Write(item + " ");
}
