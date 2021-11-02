
// Google Question
// Given an array = [2,5,1,2,3,5,1,2,4]
// It should return 2
// Given an array = [2,1,1,2,3,5,1,2,4]
// It should return 1
// Given an array = [2,3,4,5]
// It should return null

public int? FindFirstRecurringCharacter(int[] input)
{
    // Naive approach: 2 for loops ---- Time: O(n^2)

    // Better approach: Hash Table ---- Time: O(n)
    // iterate through the input array
    // if dictionary doesn't contain the item, add key to the HashSet, 
    // else return the item
    if (input == null || input.Length < 1) return null;
    var itemSet = new HashSet<dynamic>();
    foreach (var item in input)
    {
        if (itemSet.Contains(item))
            return item;
        else
            itemSet.Add(item);
    }
    return null;
}

var array1 = new int[] { 2, 5, 1, 2, 3, 5, 1, 2, 4 };
Console.WriteLine(FindFirstRecurringCharacter(array1));
var array2 = new int[] { 2, 1, 1, 2, 3, 5, 1, 2, 4 };
Console.WriteLine(FindFirstRecurringCharacter(array2));
var array3 = new int[] { 2, 3, 4, 5 };
Console.WriteLine(FindFirstRecurringCharacter(array3));
