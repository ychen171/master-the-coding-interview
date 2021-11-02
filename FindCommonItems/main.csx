
using System.Collections.Generic;

var aList = new List<string>(){"a","b","c","x"};
var bList = new List<string>(){"z","y","x"};

bool FindCommonItems(List<string> aList, List<string> bList)
{
    foreach (var a in aList)
    {
        foreach (var b in bList)
        {
            if (a == b) return true;
        }
    }
    return false;
}

bool FindCommonItems2(List<string> aList, List<string> bList)
{
    if (aList.Count == 0) return false;
    var aHashSet = new HashSet<string>(aList);
    foreach (var b in bList)
    {
        if (aHashSet.Contains(b)) return true;
    }
    return false;
}

Console.WriteLine(FindCommonItems(aList, bList));
Console.WriteLine(FindCommonItems2(aList, bList));
