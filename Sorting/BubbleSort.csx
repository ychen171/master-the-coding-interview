

public List<int> BubbleSort(List<int> inputList)
{
    if (inputList == null || inputList.Count < 2)
        return inputList;

    for (int i = inputList.Count - 1; i > 0; i--)
    {
        for (int j = 0; j < i; j++)
        {
            if (inputList[j] > inputList[j + 1])
            {
                var temp = inputList[j];
                inputList[j] = inputList[j + 1];
                inputList[j + 1] = temp;
            }
        }
    }
    return inputList;
}

var inputList = new List<int> { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };

var outputList = BubbleSort(inputList);
foreach (var item in outputList)
{
    Console.Write(item + " ");
}
