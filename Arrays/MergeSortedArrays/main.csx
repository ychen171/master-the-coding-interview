
// input: [0, 3, 4, 31], [4, 6, 30]
// output: [0, 3, 4, 4, 6, 30, 31]


public List<int> MergeSortedArrays(List<int> sortedArray1, List<int> sortedArray2)
{
    if (sortedArray1 == null || sortedArray1.Count < 1) return sortedArray2;
    if (sortedArray2 == null || sortedArray2.Count < 1) return sortedArray1;

    var len1 = sortedArray1.Count;
    var len2 = sortedArray2.Count;
    var result = new List<int> { };
    var i = 0;
    var j = 0;

    while (i < len1 && j < len2)
    {
        var item1 = sortedArray1[i];
        var item2 = sortedArray2[j];
        if (item1 < item2)
        {
            result.Add(item1);
            i++;
        }
        else
        {
            result.Add(item2);
            j++;
        }
    }
    while (i < len1)
    {
        result.Add(sortedArray1[i]);
        i++;
    }
    while (j < len2)
    {
        result.Add(sortedArray2[j]);
        j++;
    }

    return result;
}

var sortedArray1 = new List<int>{0, 3, 4, 31};
var sortedArray2 = new List<int>{4, 6, 30};
var result = MergeSortedArrays(sortedArray1, sortedArray2);
Console.WriteLine(result.ToString());
