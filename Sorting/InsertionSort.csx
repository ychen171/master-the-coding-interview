
public List<int> InsertionSort(List<int> inputList)
{
    for (int i = 1; i < inputList.Count; i++)
    {
        // select the item at i
        var key = inputList[i];
        // go through all items before item i in the reverse order
        // find the place to insert
        int j = i - 1;
        while (j >= 0 && inputList[j] > key)
        {
            inputList[j + 1] = inputList[j];
            j--;
        }
        inputList[j + 1] = key;
    }
    return inputList;
}


var inputList = new List<int> { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };

var outputList = InsertionSort(inputList);
foreach (var item in outputList)
{
    Console.Write(item + " ");
}
