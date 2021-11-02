
using System.Collections.Generic;
Console.WriteLine("Hello world!");

var aList = new List<int>() { 1, 2, 3, 9 };
var bList = new List<int>() { 1, 2, 4, 4 };
var sum = 8;

// Naive
// Time Complexity: O(n^2)
public bool hasPairWithSum(List<int> aList, int sum)
{
    for (int i=0; i<aList.Count-1; i++)
    {
        for (int j=i+1; j<aList.Count; j++)
        {
            if (aList[i] == aList[j]) return true;
        }
    }
    return false;
}

// Better
// Time Complexity: O(n)
public bool hasPairWithSum2(List<int> aList, int sum)
{
    var complementSet = new HashSet<int>();
    foreach (var item in aList)
    {
        if (complementSet.Contains(item)) return true;
        complementSet.Add(sum - item);
    }
    return false;
}

Console.WriteLine(hasPairWithSum(aList, sum));
Console.WriteLine(hasPairWithSum2(aList, sum));

Console.WriteLine(hasPairWithSum(bList, sum));
Console.WriteLine(hasPairWithSum2(bList, sum));
