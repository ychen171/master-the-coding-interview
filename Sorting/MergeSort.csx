
public List<int> MergeSort(List<int> inputList)
{
    // base case
    if (inputList == null || inputList.Count < 2)
        return inputList;
    
    // recursive case
    // split
    var midpoint = inputList.Count / 2;
    var left = new List<int>();
    var right = new List<int>();
    for (int i=0; i< midpoint; i++)
        left.Add(inputList[i]);
    for (int i=midpoint; i<inputList.Count; i++)
        right.Add(inputList[i]);
    // divide
    left = MergeSort(left);
    right = MergeSort(right); 

    // conquer
    return Merge(left, right);
}

private List<int> Merge(List<int> leftList, List<int> rightList)
{
    var mergedList = new List<int>();
    int i = 0;
    int j = 0;
    
    while (i < leftList.Count && j < rightList.Count)
    {
        if (leftList[i] < rightList[j])
        {
            mergedList.Add(leftList[i]);
            i++;
        }
        else
        {
            mergedList.Add(rightList[j]);
            j++;
        }
    }
    while (i < leftList.Count)
    {
        mergedList.Add(leftList[i]);
        i++;
    }
    while (j < rightList.Count)
    {
        mergedList.Add(rightList[j]);
        j++;
    }

    return mergedList;
}

var inputList = new List<int> { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };

var outputList = MergeSort(inputList);
foreach (var item in outputList)
{
    Console.Write(item + " ");
}

